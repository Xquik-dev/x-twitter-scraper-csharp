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
                Email = "account@example.invalid",
                Password = "<ACCOUNT_PASSWORD>",
                Username = "your_x_username",
            },
            TestContext.Current.CancellationToken
        );
        account.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var xAccountDetail = await this.client.X.Accounts.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        xAccountDetail.Validate();
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
    public async Task BulkRetry_Works()
    {
        var response = await this.client.X.Accounts.BulkRetry(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Reauth_Works()
    {
        var response = await this.client.X.Accounts.Reauth(
            "id",
            new() { Password = "<ACCOUNT_PASSWORD>" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
