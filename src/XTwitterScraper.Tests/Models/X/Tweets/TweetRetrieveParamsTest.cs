using System;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetRetrieveParams { TweetID = "tweetId" };

        string expectedTweetID = "tweetId";

        Assert.Equal(expectedTweetID, parameters.TweetID);
    }

    [Fact]
    public void Url_Works()
    {
        TweetRetrieveParams parameters = new() { TweetID = "tweetId" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/tweets/tweetId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetRetrieveParams { TweetID = "tweetId" };

        TweetRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
