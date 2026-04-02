using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveBatch_Works()
    {
        await this.client.X.Users.RetrieveBatch(
            new() { Ids = "ids" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFollowers_Works()
    {
        await this.client.X.Users.RetrieveFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFollowersYouKnow_Works()
    {
        var response = await this.client.X.Users.RetrieveFollowersYouKnow(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFollowing_Works()
    {
        await this.client.X.Users.RetrieveFollowing(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveLikes_Works()
    {
        var response = await this.client.X.Users.RetrieveLikes(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveMedia_Works()
    {
        var response = await this.client.X.Users.RetrieveMedia(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveMentions_Works()
    {
        await this.client.X.Users.RetrieveMentions(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveSearch_Works()
    {
        await this.client.X.Users.RetrieveSearch(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveTweets_Works()
    {
        var response = await this.client.X.Users.RetrieveTweets(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveVerifiedFollowers_Works()
    {
        await this.client.X.Users.RetrieveVerifiedFollowers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
