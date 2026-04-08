using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services;

public class StyleServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var styleProfile = await this.client.Styles.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        styleProfile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var styleProfile = await this.client.Styles.Update(
            "id",
            new()
            {
                Label = "Professional Voice",
                Tweets = [new("Excited to share our latest research findings.")],
            },
            TestContext.Current.CancellationToken
        );
        styleProfile.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var styles = await this.client.Styles.List(new(), TestContext.Current.CancellationToken);
        styles.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Styles.Delete("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Analyze_Works()
    {
        var styleProfile = await this.client.Styles.Analyze(
            new() { Username = "elonmusk" },
            TestContext.Current.CancellationToken
        );
        styleProfile.Validate();
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

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetPerformance_Works()
    {
        var response = await this.client.Styles.GetPerformance(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
