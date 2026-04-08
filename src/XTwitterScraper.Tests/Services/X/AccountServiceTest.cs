using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class AccountServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var account = await this.client.X.Accounts.Create(
            new()
            {
                Email = "user@example.com",
                Password = "s3cur3Pa$$w0rd",
                Username = "elonmusk",
            },
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var account = await this.client.X.Accounts.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var accounts = await this.client.X.Accounts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        accounts.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var account = await this.client.X.Accounts.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Reauth_Works()
    {
        var response = await this.client.X.Accounts.Reauth(
            "id",
            new() { Password = "password_value" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
