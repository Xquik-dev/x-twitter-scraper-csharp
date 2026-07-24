using System.Threading.Tasks;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Services;

public class WebhookServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var webhook = await this.client.Webhooks.Create(
            new()
            {
                EventTypes = [EventType.TweetNew, EventType.TweetReply],
                UrlValue = "https://example.com/webhook",
            },
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(webhook);
    }

    [Fact]
    public async Task Update_Works()
    {
        var webhook = await this.client.Webhooks.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(webhook);
    }

    [Fact]
    public async Task List_Works()
    {
        var webhooks = await this.client.Webhooks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(webhooks);
    }

    [Fact]
    public async Task Deactivate_Works()
    {
        var response = await this.client.Webhooks.Deactivate(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task ListDeliveries_Works()
    {
        var response = await this.client.Webhooks.ListDeliveries(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Resume_Works()
    {
        var response = await this.client.Webhooks.Resume(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }

    [Fact]
    public async Task Test_Works()
    {
        var response = await this.client.Webhooks.Test(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        Assert.NotNull(response);
    }
}
