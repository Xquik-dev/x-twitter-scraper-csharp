using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class DraftServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var draftDetail = await this.client.Drafts.Create(
            new() { Text = "AI is the future of productivity" },
            TestContext.Current.CancellationToken
        );
        draftDetail.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var draftDetail = await this.client.Drafts.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        draftDetail.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var drafts = await this.client.Drafts.List(new(), TestContext.Current.CancellationToken);
        drafts.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Drafts.Delete("id", new(), TestContext.Current.CancellationToken);
    }
}
