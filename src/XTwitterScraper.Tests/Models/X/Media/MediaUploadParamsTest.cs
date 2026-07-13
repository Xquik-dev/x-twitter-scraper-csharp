using System;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Tests.Models.X.Media;

public class MediaUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MediaUploadParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/image.png",
        };

        string expectedAccount = "@elonmusk";
        string expectedUrlValue = "https://example.com/image.png";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        MediaUploadParams parameters = new()
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/image.png",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/media"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MediaUploadParams
        {
            Account = "@elonmusk",
            UrlValue = "https://example.com/image.png",
        };

        MediaUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
