using System;
using XTwitterScraper.Models.X.Tweets.Retweet;

namespace XTwitterScraper.Tests.Models.X.Tweets.Retweet;

public class RetweetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RetweetCreateParams { ID = "id", Account = "@elonmusk" };

        string expectedID = "id";
        string expectedAccount = "@elonmusk";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        RetweetCreateParams parameters = new() { ID = "id", Account = "@elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/tweets/id/retweet"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RetweetCreateParams { ID = "id", Account = "@elonmusk" };

        RetweetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
