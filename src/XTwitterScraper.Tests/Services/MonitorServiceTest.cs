using System.Threading.Tasks;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Services;

public class MonitorServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var monitor = await this.client.Monitors.Create(
            new() { EventTypes = [EventType.TweetNew], Username = "username" },
            TestContext.Current.CancellationToken
        );
        monitor.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var monitor = await this.client.Monitors.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        monitor.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var monitor = await this.client.Monitors.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        monitor.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var monitors = await this.client.Monitors.List(
            new(),
            TestContext.Current.CancellationToken
        );
        monitors.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Deactivate_Works()
    {
        var response = await this.client.Monitors.Deactivate(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
