using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class TweetServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var tweet = await this.client.X.Tweets.Create(
            new() { Account = "@elonmusk", Text = "Just launched our new feature!" },
            TestContext.Current.CancellationToken
        );
        tweet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var tweet = await this.client.X.Tweets.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        tweet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.List(
            new() { Ids = "ids" },
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var tweet = await this.client.X.Tweets.Delete(
            "id",
            new() { Account = "@elonmusk" },
            TestContext.Current.CancellationToken
        );
        tweet.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetFavoriters_Works()
    {
        var paginatedUsers = await this.client.X.Tweets.GetFavoriters(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedUsers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetQuotes_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.GetQuotes(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetReplies_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.GetReplies(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetRetweeters_Works()
    {
        var paginatedUsers = await this.client.X.Tweets.GetRetweeters(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedUsers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetThread_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.GetThread(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Search_Works()
    {
        var paginatedTweets = await this.client.X.Tweets.Search(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }
}
