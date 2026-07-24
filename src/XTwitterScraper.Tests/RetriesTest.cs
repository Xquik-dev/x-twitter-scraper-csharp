// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using XTwitterScraper;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Tests;

public class RetriesTest : TestBase
{
    record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // do nothing
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    record class ParamsWithOverwrittenRetryHeader : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions _options
        )
        {
            request.Headers.TryAddWithoutValidation("x-stainless-retry-count", "42");
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    record class NonRetryableParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // do nothing
        }

        internal override HttpContent? BodyContent()
        {
            return new StreamContent(new MemoryStream([1, 2, 3]));
        }

        internal override bool BodyCanRetry()
        {
            return false;
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    [Fact]
    public async Task ImmediateSuccess_Works()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        XTwitterScraperClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryAfterHeader_Works()
    {
        var ResponseWithRetryDate = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        ResponseWithRetryDate.Headers.Add("Retry-After", "Wed, 21 Oct 2015 07:28:00 GMT");

        var ResponseWithRetryDelay = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        // decimals are technically out of spec, but we want to ensure we can parse them regardless
        ResponseWithRetryDelay.Headers.TryAddWithoutValidation("Retry-After", "1.234");

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(ResponseWithRetryDate)
            .ReturnsAsync(ResponseWithRetryDelay)
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        XTwitterScraperClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "0"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "1"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "2"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task OverwrittenRetryCountHeader_Works()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Content = new StringContent("foo"),
                }
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        XTwitterScraperClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<ParamsWithOverwrittenRetryHeader>
            {
                Method = HttpMethod.Get,
                Params = new(),
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "42"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryAfterMsHeader_Works()
    {
        var failResponse = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        failResponse.Headers.TryAddWithoutValidation("Retry-After-Ms", "10");

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(failResponse)
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        XTwitterScraperClient client = new() { HttpClient = httpClient, MaxRetries = 1 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryableException_Works()
    {
        var callCount = 0;

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns<HttpRequestMessage, CancellationToken>(
                (_, ct) =>
                {
                    callCount++;
                    if (callCount == 1)
                        throw new HttpRequestException("Simulated retryable failure");

                    return Task.FromResult(
                        new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = new StringContent("foo"),
                        }
                    );
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        XTwitterScraperClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "0"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "1"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task OneShotBodyIsNotRetried()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Content = new StringContent("failure"),
                }
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("success"),
                }
            );
        using var httpClient = new HttpClient(handlerMock.Object);
        using XTwitterScraperClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        await Assert.ThrowsAsync<XTwitterScraper5xxException>(() =>
            client.WithRawResponse.Execute(
                new HttpRequest<NonRetryableParams> { Method = HttpMethod.Post, Params = new() },
                TestContext.Current.CancellationToken
            )
        );

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public void RetryHeadersUseInvariantCulture()
    {
        using var milliseconds = Response(HttpStatusCode.ServiceUnavailable);
        milliseconds.RawMessage.Headers.TryAddWithoutValidation("Retry-After-Ms", "12.5");
        using var seconds = Response(HttpStatusCode.ServiceUnavailable);
        seconds.RawMessage.Headers.TryAddWithoutValidation("Retry-After", "1.5");
        using var invalid = Response(HttpStatusCode.ServiceUnavailable);
        invalid.RawMessage.Headers.TryAddWithoutValidation("Retry-After", "not-a-delay");
        using var notANumber = Response(HttpStatusCode.ServiceUnavailable);
        notANumber.RawMessage.Headers.TryAddWithoutValidation("Retry-After", "NaN");
        using var infinity = Response(HttpStatusCode.ServiceUnavailable);
        infinity.RawMessage.Headers.TryAddWithoutValidation("Retry-After-Ms", "Infinity");
        using var excessive = Response(HttpStatusCode.ServiceUnavailable);
        excessive.RawMessage.Headers.TryAddWithoutValidation("Retry-After", "1E30");
        using var httpDate = Response(HttpStatusCode.ServiceUnavailable);
        httpDate.RawMessage.Headers.TryAddWithoutValidation(
            "Retry-After",
            "Sun, 06 Nov 1994 08:49:37 GMT"
        );
        var previousCulture = CultureInfo.CurrentCulture;

        try
        {
            CultureInfo.CurrentCulture = new("tr-TR");
            Assert.Equal(
                TimeSpan.FromMilliseconds(12.5),
                XTwitterScraperClientWithRawResponse.ParseRetryAfterMsHeader(milliseconds)
            );
            Assert.Equal(
                TimeSpan.FromSeconds(1.5),
                XTwitterScraperClientWithRawResponse.ParseRetryAfterHeader(seconds)
            );
            Assert.Null(XTwitterScraperClientWithRawResponse.ParseRetryAfterHeader(invalid));
            Assert.Null(XTwitterScraperClientWithRawResponse.ParseRetryAfterHeader(notANumber));
            Assert.Null(XTwitterScraperClientWithRawResponse.ParseRetryAfterMsHeader(infinity));
            Assert.Null(XTwitterScraperClientWithRawResponse.ParseRetryAfterHeader(excessive));
            Assert.True(
                XTwitterScraperClientWithRawResponse.ParseRetryAfterHeader(httpDate) < TimeSpan.Zero
            );
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }
    }

    [Fact]
    public void RetryPolicyHonorsHeadersStatusesAndExceptions()
    {
        using var forced = Response(HttpStatusCode.BadRequest);
        forced.RawMessage.Headers.Add("X-Should-Retry", "true");
        Assert.True(XTwitterScraperClientWithRawResponse.ShouldRetry(forced));

        using var blocked = Response(HttpStatusCode.ServiceUnavailable);
        blocked.RawMessage.Headers.Add("X-Should-Retry", "false");
        Assert.False(XTwitterScraperClientWithRawResponse.ShouldRetry(blocked));

        foreach (
            var status in new[]
            {
                HttpStatusCode.RequestTimeout,
                HttpStatusCode.Conflict,
                (HttpStatusCode)429,
                HttpStatusCode.InternalServerError,
            }
        )
        {
            using var response = Response(status);
            Assert.True(XTwitterScraperClientWithRawResponse.ShouldRetry(response));
        }

        using var success = Response(HttpStatusCode.OK);
        Assert.False(XTwitterScraperClientWithRawResponse.ShouldRetry(success));
        Assert.True(XTwitterScraperClientWithRawResponse.ShouldRetry(new IOException()));
        Assert.True(
            XTwitterScraperClientWithRawResponse.ShouldRetry(
                new XTwitterScraperIOException("offline", new HttpRequestException())
            )
        );
        Assert.False(
            XTwitterScraperClientWithRawResponse.ShouldRetry(new InvalidOperationException())
        );
    }

    [Fact]
    public void RetryBackoffUsesBoundedServerDelay()
    {
        using var accepted = Response(HttpStatusCode.ServiceUnavailable);
        accepted.RawMessage.Headers.Add("Retry-After-Ms", "10");
        Assert.Equal(
            TimeSpan.FromMilliseconds(10),
            XTwitterScraperClientWithRawResponse.ComputeRetryBackoff(1, accepted)
        );

        using var excessive = Response(HttpStatusCode.ServiceUnavailable);
        excessive.RawMessage.Headers.Add("Retry-After", "120");
        var fallback = XTwitterScraperClientWithRawResponse.ComputeRetryBackoff(1, excessive);
        Assert.InRange(fallback, TimeSpan.FromMilliseconds(375), TimeSpan.FromMilliseconds(500));
    }

    static HttpResponse Response(HttpStatusCode status)
    {
        return new()
        {
            RawMessage = new HttpResponseMessage(status) { Content = new StringContent("{}") },
        };
    }
}
