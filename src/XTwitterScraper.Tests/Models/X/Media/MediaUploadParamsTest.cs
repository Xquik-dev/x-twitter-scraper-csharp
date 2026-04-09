using System;
using System.Text;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Tests.Models.X.Media;

public class MediaUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new MediaUploadParams
        {
            Account = "@elonmusk",
            File = file,
            IsLongVideo = true,
        };

        string expectedAccount = "@elonmusk";
        BinaryContent expectedFile = file;
        bool expectedIsLongVideo = true;

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedFile, parameters.File);
        Assert.Equal(expectedIsLongVideo, parameters.IsLongVideo);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new MediaUploadParams { Account = "@elonmusk", File = file };

        Assert.Null(parameters.IsLongVideo);
        Assert.False(parameters.RawBodyData.ContainsKey("is_long_video"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new MediaUploadParams
        {
            Account = "@elonmusk",
            File = file,

            // Null should be interpreted as omitted for these properties
            IsLongVideo = null,
        };

        Assert.Null(parameters.IsLongVideo);
        Assert.False(parameters.RawBodyData.ContainsKey("is_long_video"));
    }

    [Fact]
    public void Url_Works()
    {
        MediaUploadParams parameters = new()
        {
            Account = "@elonmusk",
            File = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/media"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MediaUploadParams
        {
            Account = "@elonmusk",
            File = Encoding.UTF8.GetBytes("Example data"),
            IsLongVideo = true,
        };

        MediaUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
