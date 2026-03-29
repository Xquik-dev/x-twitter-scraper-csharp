using System.Threading.Tasks;
using XTwitterScraper.Models.Compose;

namespace XTwitterScraper.Tests.Services;

public class ComposeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        await this.client.Compose.Create(
            new() { Step = Step.Compose },
            TestContext.Current.CancellationToken
        );
    }
}
