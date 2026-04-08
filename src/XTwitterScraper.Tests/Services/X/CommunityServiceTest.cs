using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class CommunityServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var community = await this.client.X.Communities.Create(
            new() { Account = "@elonmusk", Name = "Example Name" },
            TestContext.Current.CancellationToken
        );
        community.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var community = await this.client.X.Communities.Delete(
            "id",
            new() { Account = "@elonmusk", CommunityName = "Tesla Fans" },
            TestContext.Current.CancellationToken
        );
        community.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveInfo_Works()
    {
        var response = await this.client.X.Communities.RetrieveInfo(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveMembers_Works()
    {
        var response = await this.client.X.Communities.RetrieveMembers(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveModerators_Works()
    {
        var response = await this.client.X.Communities.RetrieveModerators(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveSearch_Works()
    {
        var response = await this.client.X.Communities.RetrieveSearch(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
