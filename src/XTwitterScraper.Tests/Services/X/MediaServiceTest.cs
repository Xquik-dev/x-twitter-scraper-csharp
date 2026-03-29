using System.Text;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class MediaServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var media = await this.client.X.Media.Create(
            new() { Account = "account", File = Encoding.UTF8.GetBytes("Example data") },
            TestContext.Current.CancellationToken
        );
        media.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Download_Works()
    {
        var response = await this.client.X.Media.Download(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
