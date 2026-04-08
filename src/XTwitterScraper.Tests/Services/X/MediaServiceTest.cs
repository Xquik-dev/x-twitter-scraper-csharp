using System.Text;
using System.Threading.Tasks;

namespace XTwitterScraper.Tests.Services.X;

public class MediaServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Download_Works()
    {
        var response = await this.client.X.Media.Download(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upload_Works()
    {
        var response = await this.client.X.Media.Upload(
            new() { Account = "@elonmusk", File = Encoding.UTF8.GetBytes("Example data") },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
