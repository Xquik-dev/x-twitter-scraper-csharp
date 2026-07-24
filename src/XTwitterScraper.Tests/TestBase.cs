using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper;

namespace XTwitterScraper.Tests;

public class TestBase : IDisposable
{
    protected IXTwitterScraperClient client;

    public TestBase()
    {
        client = new XTwitterScraperClient()
        {
            BaseUrl = "http://127.0.0.1",
            ApiKey = "My API Key",
            BearerToken = "My Bearer Token",
            HttpClient = new HttpClient(new LoopbackMockHandler()),
        };
    }

    public void Dispose()
    {
        client.Dispose();
        GC.SuppressFinalize(this);
    }

    internal static bool UrisEqual(Uri uri1, Uri uri2)
    {
        if (
            uri1.Scheme != uri2.Scheme
            || uri1.Host != uri2.Host
            || uri1.Port != uri2.Port
            || uri1.AbsolutePath != uri2.AbsolutePath
        )
        {
            return false;
        }

        var query1 = ParseQueryString(uri1.Query);
        var query2 = ParseQueryString(uri2.Query);

        return Enumerable.SequenceEqual(query1, query2);
    }

    private static readonly char[] _ampersandArray = ['&'];
    private static readonly char[] _equalsArray = ['='];

    static SortedDictionary<string, string> ParseQueryString(string query)
    {
        var ret = new SortedDictionary<string, string>(StringComparer.Ordinal);

        if (string.IsNullOrEmpty(query))
            return ret;

        var pairs = query
            .TrimStart('?')
            .Split(_ampersandArray, StringSplitOptions.RemoveEmptyEntries);

        foreach (var pair in pairs)
        {
            var parts = pair.Split(_equalsArray, 2);
            var key = Uri.UnescapeDataString(parts[0]);
            var value = parts.Length > 1 ? Uri.UnescapeDataString(parts[1]) : string.Empty;
            ret[key] = value;
        }

        return ret;
    }
}

sealed class LoopbackMockHandler : HttpMessageHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (
            request.RequestUri is not { Scheme: "http", Host: "127.0.0.1" }
            || !request.RequestUri.IsLoopback
        )
        {
            throw new InvalidOperationException(
                "Tests may only request the literal loopback host."
            );
        }

        if (request.Content?.Headers.ContentType?.MediaType == "application/json")
        {
            var body = await request
                .Content.ReadAsStringAsync(
#if NET
                    cancellationToken
#endif
                )
                .ConfigureAwait(false);
            using var _ = JsonDocument.Parse(body);
        }

        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("{}", Encoding.UTF8, "application/json"),
            RequestMessage = request,
        };
    }
}
