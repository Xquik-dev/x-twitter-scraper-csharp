using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class FollowerServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Check_Works()
    {
        var response = await this.client.X.Followers.Check(
            new() { Source = "source", Target = "target" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
