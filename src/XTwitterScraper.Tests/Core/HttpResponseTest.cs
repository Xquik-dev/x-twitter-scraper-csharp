using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Tests.Core;

public class HttpResponseTest
{
    [Fact]
    public async Task ResponseReadersAndMetadataWork()
    {
        using var raw = new HttpResponseMessage(HttpStatusCode.Accepted)
        {
            Content = new StringContent("{\"value\":42}", Encoding.UTF8, "application/json"),
        };
        raw.Headers.Add("X-Test", "value");
        using var response = new HttpResponse { RawMessage = raw };

        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        Assert.Equal("value", Assert.Single(response.GetHeaderValues("X-Test")));
        Assert.True(response.TryGetHeaderValues("X-Test", out var values));
        Assert.Equal("value", Assert.Single(values));
        Assert.False(response.TryGetHeaderValues("X-Missing", out _));
        Assert.Contains("202", response.ToString());
        Assert.Equal(raw.GetHashCode(), response.GetHashCode());
        Assert.Equal(
            "{\"value\":42}",
            await response.ReadAsString(TestContext.Current.CancellationToken)
        );

        using var stream = await response.ReadAsStream(TestContext.Current.CancellationToken);
        using var reader = new StreamReader(stream);
        Assert.Equal(
            "{\"value\":42}",
#if NET
            await reader.ReadToEndAsync(TestContext.Current.CancellationToken)
#else
            await reader.ReadToEndAsync()
#endif
        );
    }

    [Fact]
    public async Task GenericDeserializePreservesCancellation()
    {
        var started = new TaskCompletionSource<bool>(
            TaskCreationOptions.RunContinuationsAsynchronously
        );
        using var response = new HttpResponse<int>(async cancellationToken =>
        {
            started.SetResult(true);
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            return 42;
        })
        {
            RawMessage = new HttpResponseMessage(HttpStatusCode.OK),
        };
        using var cancellationSource = new CancellationTokenSource();

        var deserialize = response.Deserialize(cancellationSource.Token);
        var completed = await Task.WhenAny(
            started.Task,
            Task.Delay(Timeout.InfiniteTimeSpan, TestContext.Current.CancellationToken)
        );
        Assert.Same(started.Task, completed);
        cancellationSource.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => deserialize);
    }

    [Fact]
    public async Task DeserializeRejectsNullJson()
    {
        using var response = new HttpResponse
        {
            RawMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("null", Encoding.UTF8, "application/json"),
            },
        };

        await Assert.ThrowsAsync<XTwitterScraperInvalidDataException>(() =>
            response.Deserialize<Dictionary<string, string>>(TestContext.Current.CancellationToken)
        );
    }

    [Fact]
    public void EqualityUsesTheRawResponse()
    {
        using var raw = new HttpResponseMessage(HttpStatusCode.OK);
        using var first = new HttpResponse { RawMessage = raw };
        using var second = new HttpResponse { RawMessage = raw };
        using var other = new HttpResponse
        {
            RawMessage = new HttpResponseMessage(HttpStatusCode.OK),
        };

        Assert.Equal(first, second);
        Assert.NotEqual(first, other);
        Assert.False(first.Equals(new object()));
    }

    [Fact]
    public void DisposeReleasesTheOwnedCancellationSource()
    {
        var cancellationSource = new CancellationTokenSource();
        var response = new HttpResponse
        {
            RawMessage = new HttpResponseMessage(HttpStatusCode.OK),
            CancellationSource = cancellationSource,
            CancellationToken = cancellationSource.Token,
        };

        response.Dispose();

        Assert.Throws<ObjectDisposedException>(() => cancellationSource.Cancel());
    }
}
