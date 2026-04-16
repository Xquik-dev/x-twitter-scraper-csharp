using System;
using XTwitterScraper.Models.X.Tweets.Like;

namespace XTwitterScraper.Tests.Models.X.Tweets.Like;

public class LikeDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LikeDeleteParams { ID = "id", Account = "@elonmusk" };

        string expectedID = "id";
        string expectedAccount = "@elonmusk";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        LikeDeleteParams parameters = new() { ID = "id", Account = "@elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/tweets/id/like"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LikeDeleteParams { ID = "id", Account = "@elonmusk" };

        LikeDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
