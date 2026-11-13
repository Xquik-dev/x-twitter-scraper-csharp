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
using XTwitterScraper.Models.X.Analysis;

namespace XTwitterScraper.Tests.Services.X;

public class AnalysisFiltersTest
{
    const string Topic = "the Rust programming language";
    const string ImageShows = "charts";

    const string PageJson =
        "{\"results\":[],\"unanalyzed\":[],\"analysisSummary\":{\"schemaVersion\":1,"
        + "\"rows\":{\"analyzed\":0,\"failed\":0,\"skipped\":0},\"engagement\":0,\"questions\":{},"
        + "\"targets\":[],\"cashtags\":[],\"sourceDomains\":[],\"monitor\":null},"
        + "\"has_next_page\":false,\"next_cursor\":\"\","
        + "\"topicFilter\":{\"topic\":\"the Rust programming language\","
        + "\"question\":\"Is this post about the Rust programming language?\",\"cutoff\":0.5,"
        + "\"checked\":3,\"kept\":1,\"unchecked\":[{\"id\":\"1234567891\",\"reason\":\"model_error\"}]},"
        + "\"imageFilter\":{\"imageShows\":\"charts\","
        + "\"question\":\"Does a picture attached to this post show a chart?\",\"cutoff\":0.5,"
        + "\"checked\":16,\"kept\":4,\"unchecked\":[{\"id\":\"1234567892\",\"reason\":\"no_safe_photos\"}]}}";

    static readonly Dictionary<
        string,
        Func<IXTwitterScraperClient, CancellationToken, Task<TweetAnalysisPage>>
    > Routes = new()
    {
        ["sentiment"] = (client, token) =>
            client.X.Analysis.Sentiment(
                new()
                {
                    Query = "rust",
                    Topic = Topic,
                    ImageShows = ImageShows,
                },
                token
            ),
        ["brand"] = (client, token) =>
            client.X.Analysis.Brand(
                new()
                {
                    Query = "rust",
                    Topic = Topic,
                    ImageShows = ImageShows,
                },
                token
            ),
        ["news"] = (client, token) =>
            client.X.Analysis.News(
                new()
                {
                    Query = "rust",
                    Topic = Topic,
                    ImageShows = ImageShows,
                },
                token
            ),
        ["market-signals"] = (client, token) =>
            client.X.Analysis.MarketSignals(
                new()
                {
                    Query = "rust",
                    Topic = Topic,
                    ImageShows = ImageShows,
                },
                token
            ),
        ["viral-score"] = (client, token) =>
            client.X.Analysis.ViralScore(
                new()
                {
                    Query = "rust",
                    Topic = Topic,
                    ImageShows = ImageShows,
                },
                token
            ),
        ["classify"] = (client, token) =>
            client.X.Analysis.Classify(
                new()
                {
                    Query = "rust",
                    Topic = Topic,
                    ImageShows = ImageShows,
                },
                token
            ),
    };

    public static TheoryData<string> RouteNames() => new(Routes.Keys);

    [Fact]
    public void EveryAnalysisRouteIsListed()
    {
        Assert.Equal(6, Routes.Count);
    }

    [Theory]
    [MemberData(nameof(RouteNames))]
    public async Task RouteSendsBothFiltersAndReadsBothSummaries(string route)
    {
        var handler = new CapturingHandler();
        using XTwitterScraperClient client = new()
        {
            BaseUrl = "http://127.0.0.1",
            ApiKey = "My API Key",
            BearerToken = "My Bearer Token",
            HttpClient = new HttpClient(handler),
            ResponseValidation = true,
        };

        var page = await Routes[route](client, TestContext.Current.CancellationToken);

        Assert.Equal(HttpMethod.Post, handler.Method);
        Assert.Equal($"/x/analysis/{route}", handler.Path);
        Assert.NotNull(handler.Body);
        using (var body = JsonDocument.Parse(handler.Body))
        {
            Assert.Equal(Topic, body.RootElement.GetProperty("topic").GetString());
            Assert.Equal(ImageShows, body.RootElement.GetProperty("imageShows").GetString());
        }

        Assert.NotNull(page.TopicFilter);
        Assert.Equal(Topic, page.TopicFilter.Topic);
        Assert.Equal(0.5, page.TopicFilter.Cutoff);
        Assert.Equal(3L, page.TopicFilter.Checked);
        Assert.Equal(1L, page.TopicFilter.Kept);
        Assert.Equal("model_error", page.TopicFilter.Unchecked[0].Reason);
        Assert.NotNull(page.ImageFilter);
        Assert.Equal(ImageShows, page.ImageFilter.ImageShows);
        Assert.Equal(16L, page.ImageFilter.Checked);
        Assert.Equal(4L, page.ImageFilter.Kept);
        Assert.Equal("no_safe_photos", page.ImageFilter.Unchecked[0].Reason);
    }

    [Fact]
    public void UnsetFiltersStayOutOfTheBody()
    {
        AnalysisSentimentParams parameters = new() { Query = "rust" };

        Assert.False(parameters.RawBodyData.ContainsKey("topic"));
        Assert.False(parameters.RawBodyData.ContainsKey("imageShows"));
    }

    [Fact]
    public void APageWithoutFiltersHasNoSummaries()
    {
        var page = JsonSerializer.Deserialize<TweetAnalysisPage>(
            "{\"results\":[],\"unanalyzed\":[],\"analysisSummary\":{\"schemaVersion\":1,"
                + "\"rows\":{\"analyzed\":0,\"failed\":0,\"skipped\":0},\"engagement\":0,"
                + "\"questions\":{},\"targets\":[],\"cashtags\":[],\"sourceDomains\":[],"
                + "\"monitor\":null},\"has_next_page\":false,\"next_cursor\":\"\"}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(page);
        page.Validate();
        Assert.Null(page.TopicFilter);
        Assert.Null(page.ImageFilter);
    }

    sealed class CapturingHandler : HttpMessageHandler
    {
        public HttpMethod? Method { get; private set; }
        public string? Path { get; private set; }
        public string? Body { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(
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
            this.Path = request.RequestUri.AbsolutePath;
            if (request.Content != null)
            {
                this.Body = await request
                    .Content.ReadAsStringAsync(
#if NET
                        cancellationToken
#endif
                    )
                    .ConfigureAwait(false);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(PageJson, Encoding.UTF8, "application/json"),
                RequestMessage = request,
            };
        }
    }
}
