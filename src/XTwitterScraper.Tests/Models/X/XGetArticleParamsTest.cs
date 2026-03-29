using System;
using XTwitterScraper.Models.X;

namespace XTwitterScraper.Tests.Models.X;

public class XGetArticleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new XGetArticleParams { TweetID = "tweetId" };

        string expectedTweetID = "tweetId";

        Assert.Equal(expectedTweetID, parameters.TweetID);
    }

    [Fact]
    public void Url_Works()
    {
        XGetArticleParams parameters = new() { TweetID = "tweetId" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/articles/tweetId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new XGetArticleParams { TweetID = "tweetId" };

        XGetArticleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
