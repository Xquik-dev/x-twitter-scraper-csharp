using System;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetDeleteParams { ID = "id", Account = "@elonmusk" };

        string expectedID = "id";
        string expectedAccount = "@elonmusk";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        TweetDeleteParams parameters = new() { ID = "id", Account = "@elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/tweets/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetDeleteParams { ID = "id", Account = "@elonmusk" };

        TweetDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
