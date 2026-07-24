// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class TweetServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var tweet = await this.client.X.Tweets.Create(
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(tweet);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var tweet = await this.client.X.Tweets.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(tweet);
    }

    [Fact]
    public async Task List_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.List(
            new() { Ids = "ids" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task Delete_Works()
    {
        var tweet = await this.client.X.Tweets.Delete(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(tweet);
    }

    [Fact]
    public async Task GetFavoriters_Works()
    {
        var paginatedUsers = await this.client.X.Tweets.GetFavoriters(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task GetQuotes_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.GetQuotes(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task GetReplies_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.GetReplies(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task GetRetweeters_Works()
    {
        var paginatedUsers = await this.client.X.Tweets.GetRetweeters(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task GetThread_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.GetThread(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task Search_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.Search(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }
}
