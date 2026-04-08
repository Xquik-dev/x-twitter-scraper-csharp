using System.Text.Json;
using System.Threading.Tasks;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Services;

public class IntegrationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var integration = await this.client.Integrations.Create(
            new()
            {
                Config = new("-1001234567890"),
                EventTypes = [EventType.TweetNew, EventType.FollowerGained],
                Name = "My Telegram Bot",
                Type = JsonSerializer.SerializeToElement("telegram"),
            },
            TestContext.Current.CancellationToken
        );
        integration.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var integration = await this.client.Integrations.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        integration.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var integration = await this.client.Integrations.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        integration.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var integrations = await this.client.Integrations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        integrations.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var integration = await this.client.Integrations.Delete(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        integration.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListDeliveries_Works()
    {
        var response = await this.client.Integrations.ListDeliveries(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SendTest_Works()
    {
        var response = await this.client.Integrations.SendTest(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
