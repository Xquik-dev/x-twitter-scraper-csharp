using System;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Tests.Models.X.Profile;

public class ProfileUpdateBannerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileUpdateBannerParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/banner.png",
        };

        string expectedAccount = "@elonmusk";
        string expectedUrlValue = "https://example.com/banner.png";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateBannerParams parameters = new()
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/banner.png",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/profile/banner"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileUpdateBannerParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/banner.png",
        };

        ProfileUpdateBannerParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
