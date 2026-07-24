using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class UserServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var userProfile = await this.client.X.Users.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(userProfile);
    }

    [Fact]
    public async Task RemoveFollower_Works()
    {
        var response = await this.client.X.Users.RemoveFollower(
            "id",
            new() { Account = "@elonmusk", IdempotencyKey = "Idempotency-Key" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveBatch_Works()
    {
        var response = await this.client.X.Users.RetrieveBatch(
            new() { Ids = "ids" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task RetrieveFollowers_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveFollowersYouKnow_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowersYouKnow(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveFollowing_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowing(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveLikes_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveLikes(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveMedia_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveMedia(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveMentions_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveMentions(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveReplies_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveReplies(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveSearch_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveSearch(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }

    [Fact]
    public async Task RetrieveTweets_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveTweets(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedTweets);
    }

    [Fact]
    public async Task RetrieveVerifiedFollowers_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveVerifiedFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(paginatedUsers);
    }
}
