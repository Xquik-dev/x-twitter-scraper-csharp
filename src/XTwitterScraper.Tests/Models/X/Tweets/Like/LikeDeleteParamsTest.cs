using System;
using XTwitterScraper.Models.X.Tweets.Like;

namespace XTwitterScraper.Tests.Models.X.Tweets.Like;

public class LikeDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LikeDeleteParams { TweetID = "tweetId", Account = "account" };

        string expectedTweetID = "tweetId";
        string expectedAccount = "account";

        Assert.Equal(expectedTweetID, parameters.TweetID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        LikeDeleteParams parameters = new() { TweetID = "tweetId", Account = "account" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/tweets/tweetId/like"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LikeDeleteParams { TweetID = "tweetId", Account = "account" };

        LikeDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
