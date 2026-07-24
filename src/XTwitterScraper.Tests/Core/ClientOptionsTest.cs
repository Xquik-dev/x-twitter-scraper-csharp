using System;
using System.Net;
using System.Threading;
using XTwitterScraper.Core;

namespace XTwitterScraper.Tests.Core;

public class ClientOptionsTest
{
    [Fact]
    public void DefaultTransportBlocksAutomaticRedirects()
    {
        using var handler = ClientOptions.CreateDefaultHttpClientHandler();

        Assert.False(handler.AllowAutoRedirect);
        Assert.Equal(
            XTwitterScraper.Core.DecompressionMethods.Available,
            handler.AutomaticDecompression
        );
    }

    [Fact]
    public void DefaultsAreBounded()
    {
        using var httpClient = new ClientOptions().HttpClient;

        Assert.Equal(2, ClientOptions.DefaultMaxRetries);
        Assert.Equal(TimeSpan.FromMinutes(1), ClientOptions.DefaultTimeout);
        Assert.Equal(Timeout.InfiniteTimeSpan, httpClient.Timeout);
    }
}
