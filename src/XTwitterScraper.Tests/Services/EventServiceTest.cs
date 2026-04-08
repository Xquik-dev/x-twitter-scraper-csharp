using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class EventServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var eventDetail = await this.client.Events.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        eventDetail.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var events = await this.client.Events.List(new(), TestContext.Current.CancellationToken);
        events.Validate();
    }
}
