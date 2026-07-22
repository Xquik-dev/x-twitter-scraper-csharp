using System.Threading.Tasks;
using XTwitterScraper.Models.Compose;

namespace XTwitterScraper.Tests.Services;

public class ComposeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var compose = await this.client.Compose.Create(
            new()
            {
                Body = new ComposePrepareRequest()
                {
                    Topic = "PostgreSQL query planning",
                    Goal = Goal.Engagement,
                    StyleUsername = "x",
                },
            },
            TestContext.Current.CancellationToken
        );
        compose.Validate();
    }
}
