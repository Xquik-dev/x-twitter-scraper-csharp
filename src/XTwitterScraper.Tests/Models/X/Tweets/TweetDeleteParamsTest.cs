using System;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetDeleteParams { TweetID = "tweetId", Account = "account" };

        string expectedTweetID = "tweetId";
        string expectedAccount = "account";

        Assert.Equal(expectedTweetID, parameters.TweetID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        TweetDeleteParams parameters = new() { TweetID = "tweetId", Account = "account" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/tweets/tweetId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetDeleteParams { TweetID = "tweetId", Account = "account" };

        TweetDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
