using System;
using System.Text;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Tests.Models.X.Profile;

public class ProfileUpdateBannerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new ProfileUpdateBannerParams { Account = "@elonmusk", File = file };

        string expectedAccount = "@elonmusk";
        BinaryContent expectedFile = file;

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedFile, parameters.File);
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateBannerParams parameters = new()
        {
            Account = "@elonmusk",
            File = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/profile/banner"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileUpdateBannerParams
        {
            Account = "@elonmusk",
            File = Encoding.UTF8.GetBytes("Example data"),
        };

        ProfileUpdateBannerParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
