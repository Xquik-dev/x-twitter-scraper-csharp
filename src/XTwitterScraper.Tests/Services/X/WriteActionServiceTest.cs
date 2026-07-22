using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class WriteActionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var writeAction = await this.client.X.WriteActions.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        writeAction.Validate();
    }
}
