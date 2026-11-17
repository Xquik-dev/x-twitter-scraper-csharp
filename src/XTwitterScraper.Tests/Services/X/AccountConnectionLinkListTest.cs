// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Services.X;

public class AccountConnectionLinkListTest
{
    const string LinkJson =
        "{\"object\":\"x_account_connection_link\",\"id\":\"xlink_AAAAAAAAAAAAAAAA\","
        + "\"purpose\":\"connect\",\"status\":\"revoked\",\"reference\":\"crm-user-7\","
        + "\"returnUrl\":null,\"apiKeyId\":\"17\",\"accountId\":null,\"xUserId\":null,"
        + "\"xUsername\":null,\"health\":null,\"failure\":null,"
        + "\"createdAt\":\"2026-11-08T12:00:00Z\",\"expiresAt\":\"2026-11-08T12:30:00Z\","
        + "\"completedAt\":null}";

    const string DashboardLinkJson =
        "{\"object\":\"x_account_connection_link\",\"id\":\"xlink_BBBBBBBBBBBBBBBB\","
        + "\"purpose\":\"reconnect\",\"status\":\"pending\",\"reference\":null,"
        + "\"returnUrl\":null,\"apiKeyId\":null,\"accountId\":\"42\",\"xUserId\":null,"
        + "\"xUsername\":null,\"health\":null,\"failure\":null,"
        + "\"createdAt\":\"2026-11-08T11:00:00Z\",\"expiresAt\":\"2026-11-08T11:30:00Z\","
        + "\"completedAt\":null}";

    static XTwitterScraperClient Client(CapturingHandler handler)
    {
        return new()
        {
            BaseUrl = "http://127.0.0.1",
            ApiKey = "My API Key",
            HttpClient = new HttpClient(handler),
            ResponseValidation = true,
        };
    }

    [Fact]
    public async Task ListSendsLimitAndCursorAndReadsThePage()
    {
        var handler = new CapturingHandler(
            "{\"links\":["
                + LinkJson
                + ","
                + DashboardLinkJson
                + "],\"hasMore\":true,\"nextCursor\":\"abc123\"}"
        );
        using var client = Client(handler);

        var page = await client.X.AccountConnectionLinks.List(
            new() { Limit = 2, Cursor = "prev" },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpMethod.Get, handler.Method);
        Assert.Equal("/x/account-connection-links", handler.Uri?.AbsolutePath);
        Assert.True(
            TestBase.UrisEqual(
                new Uri("http://127.0.0.1/x/account-connection-links?limit=2&cursor=prev"),
                handler.Uri!
            )
        );
        Assert.True(page.HasMore);
        Assert.Equal("abc123", page.NextCursor);
        Assert.Equal(2, page.Links.Count);
        Assert.Equal("xlink_AAAAAAAAAAAAAAAA", page.Links[0].ID);
        Assert.Equal(XAccountConnectionLinkStatus.Revoked, page.Links[0].Status.Value());
        Assert.Equal("17", page.Links[0].ApiKeyID);
        Assert.Equal("xlink_BBBBBBBBBBBBBBBB", page.Links[1].ID);
        Assert.Equal("42", page.Links[1].AccountID);
        Assert.Null(page.Links[1].ApiKeyID);
    }

    [Fact]
    public async Task ListWithoutParamsSendsNoQueryAndReadsTheLastPage()
    {
        var handler = new CapturingHandler("{\"links\":[],\"hasMore\":false}");
        using var client = Client(handler);

        var page = await client.X.AccountConnectionLinks.List(
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal("", handler.Uri?.Query);
        Assert.Empty(page.Links);
        Assert.False(page.HasMore);
        Assert.Null(page.NextCursor);
    }

    [Fact]
    public async Task RawListReturnsTheResponse()
    {
        using var client = Client(new CapturingHandler("{\"links\":[],\"hasMore\":false}"));

        using var response = await client.X.AccountConnectionLinks.WithRawResponse.List(
            new() { Limit = 1 },
            TestContext.Current.CancellationToken
        );
        var page = await response.Deserialize(TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.False(page.HasMore);
    }

    sealed class CapturingHandler(string json) : HttpMessageHandler
    {
        public HttpMethod? Method { get; private set; }
        public Uri? Uri { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            if (
                request.RequestUri is not { Scheme: "http", Host: "127.0.0.1" }
                || !request.RequestUri.IsLoopback
            )
            {
                throw new InvalidOperationException(
                    "Tests may only request the literal loopback host."
                );
            }

            this.Method = request.Method;
            this.Uri = request.RequestUri;
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                RequestMessage = request,
            };
            return Task.FromResult(response);
        }
    }
}
