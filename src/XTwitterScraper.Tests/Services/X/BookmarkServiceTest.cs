using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class BookmarkServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.X.Bookmarks.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFolders_Works()
    {
        var response = await this.client.X.Bookmarks.RetrieveFolders(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
