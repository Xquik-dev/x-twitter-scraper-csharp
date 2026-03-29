using System;
using System.Text;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Tests.Models.X.Media;

public class MediaCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new MediaCreateParams
        {
            Account = "account",
            File = file,
            IsLongVideo = true,
        };

        string expectedAccount = "account";
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

        var parameters = new MediaCreateParams { Account = "account", File = file };

        Assert.Null(parameters.IsLongVideo);
        Assert.False(parameters.RawBodyData.ContainsKey("is_long_video"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new MediaCreateParams
        {
            Account = "account",
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
        MediaCreateParams parameters = new()
        {
            Account = "account",
            File = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/media"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MediaCreateParams
        {
            Account = "account",
            File = Encoding.UTF8.GetBytes("Example data"),
            IsLongVideo = true,
        };

        MediaCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
