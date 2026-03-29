using System;
using XTwitterScraper.Models.X.Tweets.Retweet;

namespace XTwitterScraper.Tests.Models.X.Tweets.Retweet;

public class RetweetDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RetweetDeleteParams { TweetID = "tweetId", Account = "account" };

        string expectedTweetID = "tweetId";
        string expectedAccount = "account";

        Assert.Equal(expectedTweetID, parameters.TweetID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        RetweetDeleteParams parameters = new() { TweetID = "tweetId", Account = "account" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/tweets/tweetId/retweet"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RetweetDeleteParams { TweetID = "tweetId", Account = "account" };

        RetweetDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
