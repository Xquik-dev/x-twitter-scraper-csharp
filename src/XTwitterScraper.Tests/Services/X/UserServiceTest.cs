using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var userProfile = await this.client.X.Users.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        userProfile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveBatch_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveBatch(
            new() { Ids = "ids" },
            TestContext.Current.CancellationToken
        );
        paginatedUsers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFollowers_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedUsers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFollowersYouKnow_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowersYouKnow(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedUsers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFollowing_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveFollowing(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedUsers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveLikes_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveLikes(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveMedia_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveMedia(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveMentions_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveMentions(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveSearch_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveSearch(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        paginatedUsers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveTweets_Works()
    {
        var paginatedTweets = await this.client.X.Users.RetrieveTweets(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedTweets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveVerifiedFollowers_Works()
    {
        var paginatedUsers = await this.client.X.Users.RetrieveVerifiedFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        paginatedUsers.Validate();
    }
}
