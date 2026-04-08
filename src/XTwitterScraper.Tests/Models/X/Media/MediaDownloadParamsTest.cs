using System;
using System.Collections.Generic;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Tests.Models.X.Media;

public class MediaDownloadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MediaDownloadParams
        {
            TweetIds = ["1234567890", "1234567891"],
            TweetInput = "https://x.com/elonmusk/status/1234567890",
        };

        List<string> expectedTweetIds = ["1234567890", "1234567891"];
        string expectedTweetInput = "https://x.com/elonmusk/status/1234567890";

        Assert.NotNull(parameters.TweetIds);
        Assert.Equal(expectedTweetIds.Count, parameters.TweetIds.Count);
        for (int i = 0; i < expectedTweetIds.Count; i++)
        {
            Assert.Equal(expectedTweetIds[i], parameters.TweetIds[i]);
        }
        Assert.Equal(expectedTweetInput, parameters.TweetInput);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MediaDownloadParams { };

        Assert.Null(parameters.TweetIds);
        Assert.False(parameters.RawBodyData.ContainsKey("tweetIds"));
        Assert.Null(parameters.TweetInput);
        Assert.False(parameters.RawBodyData.ContainsKey("tweetInput"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MediaDownloadParams
        {
            // Null should be interpreted as omitted for these properties
            TweetIds = null,
            TweetInput = null,
        };

        Assert.Null(parameters.TweetIds);
        Assert.False(parameters.RawBodyData.ContainsKey("tweetIds"));
        Assert.Null(parameters.TweetInput);
        Assert.False(parameters.RawBodyData.ContainsKey("tweetInput"));
    }

    [Fact]
    public void Url_Works()
    {
        MediaDownloadParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/media/download"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MediaDownloadParams
        {
            TweetIds = ["1234567890", "1234567891"],
            TweetInput = "https://x.com/elonmusk/status/1234567890",
        };

        MediaDownloadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
