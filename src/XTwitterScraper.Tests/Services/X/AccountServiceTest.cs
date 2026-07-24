using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class AccountServiceTest : TestBase
{
    [Fact]
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
        Assert.NotNull(account);
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var xAccountDetail = await this.client.X.Accounts.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(xAccountDetail);
    }

    [Fact]
    public async Task List_Works()
    {
        var accounts = await this.client.X.Accounts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(accounts);
    }

    [Fact]
    public async Task Delete_Works()
    {
        var account = await this.client.X.Accounts.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(account);
    }

    [Fact]
    public async Task BulkRetry_Works()
    {
        var response = await this.client.X.Accounts.BulkRetry(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Reauth_Works()
    {
        var response = await this.client.X.Accounts.Reauth(
            "id",
            new() { Password = "<ACCOUNT_PASSWORD>" },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
