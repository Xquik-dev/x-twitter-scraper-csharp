using System;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Tests.Models.X.Profile;

public class ProfileUpdateAvatarParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileUpdateAvatarParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/avatar.png",
        };

        string expectedAccount = "@elonmusk";
        string expectedUrlValue = "https://example.com/avatar.png";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateAvatarParams parameters = new()
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/avatar.png",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/profile/avatar"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileUpdateAvatarParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/avatar.png",
        };

        ProfileUpdateAvatarParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
