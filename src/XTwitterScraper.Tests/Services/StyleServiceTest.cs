using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class StyleServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var styles = await this.client.Styles.List(new(), TestContext.Current.CancellationToken);
        styles.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Analyze_Works()
    {
        var response = await this.client.Styles.Analyze(
            new() { Username = "elonmusk" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Compare_Works()
    {
        var response = await this.client.Styles.Compare(
            new() { Username1 = "username1", Username2 = "username2" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
