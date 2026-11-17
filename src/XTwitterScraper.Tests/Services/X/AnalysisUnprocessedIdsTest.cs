// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Services.X;

public class AnalysisUnprocessedIdsTest
{
    const string Page =
        "\"results\":[],\"unanalyzed\":[],\"analysisSummary\":{\"schemaVersion\":1,"
        + "\"rows\":{\"analyzed\":0,\"failed\":0,\"skipped\":0},\"engagement\":0,\"questions\":{},"
        + "\"targets\":[],\"cashtags\":[],\"sourceDomains\":[],\"monitor\":null},"
        + "\"has_next_page\":false,\"next_cursor\":\"\"";

    static readonly Dictionary<
        string,
        Func<IXTwitterScraperClient, CancellationToken, Task<TweetAnalysisPage>>
    > Routes = new()
    {
        ["sentiment"] = (client, token) =>
            client.X.Analysis.Sentiment(new() { TweetIDs = ["1"] }, token),
        ["brand"] = (client, token) => client.X.Analysis.Brand(new() { TweetIDs = ["1"] }, token),
        ["news"] = (client, token) => client.X.Analysis.News(new() { TweetIDs = ["1"] }, token),
        ["market-signals"] = (client, token) =>
            client.X.Analysis.MarketSignals(new() { TweetIDs = ["1"] }, token),
        ["viral-score"] = (client, token) =>
            client.X.Analysis.ViralScore(new() { TweetIDs = ["1"] }, token),
        ["classify"] = (client, token) =>
            client.X.Analysis.Classify(new() { TweetIDs = ["1"] }, token),
    };

    public static TheoryData<string> RouteNames() => new(Routes.Keys);

    [Fact]
    public void EveryAnalysisRouteIsListed()
    {
        Assert.Equal(6, Routes.Count);
    }

    [Theory]
    [MemberData(nameof(RouteNames))]
    public async Task RouteReadsTheIdsTheTimeRanOutFor(string route)
    {
        using XTwitterScraperClient client = new()
        {
            BaseUrl = "http://127.0.0.1",
            ApiKey = "My API Key",
            HttpClient = new HttpClient(
                new PageHandler("{" + Page + ",\"unprocessed_ids\":[\"2\",\"3\"]}")
            ),
            ResponseValidation = true,
        };

        var page = await Routes[route](client, TestContext.Current.CancellationToken);

        Assert.Equal(["2", "3"], page.UnprocessedIDs);
    }

    [Fact]
    public void APageThatFinishedInTimeReadsAnEmptyList()
    {
        var page = JsonSerializer.Deserialize<TweetAnalysisPage>(
            "{" + Page + ",\"unprocessed_ids\":[]}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(page);
        page.Validate();
        Assert.NotNull(page.UnprocessedIDs);
        Assert.Empty(page.UnprocessedIDs);
    }

    [Fact]
    public void APageFromBeforeTheFieldReadsNull()
    {
        var page = JsonSerializer.Deserialize<TweetAnalysisPage>(
            "{" + Page + "}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(page);
        page.Validate();
        Assert.Null(page.UnprocessedIDs);
    }

    sealed class PageHandler(string json) : HttpMessageHandler
    {
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

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                RequestMessage = request,
            };
            return Task.FromResult(response);
        }
    }
}
