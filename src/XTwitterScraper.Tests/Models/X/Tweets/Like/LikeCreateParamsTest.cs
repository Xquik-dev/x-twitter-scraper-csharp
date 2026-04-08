using System;
using XTwitterScraper.Models.X.Tweets.Like;

namespace XTwitterScraper.Tests.Models.X.Tweets.Like;

public class LikeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LikeCreateParams { ID = "id", Account = "@elonmusk" };

        string expectedID = "id";
        string expectedAccount = "@elonmusk";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAccount, parameters.Account);
    }

    [Fact]
    public void Url_Works()
    {
        LikeCreateParams parameters = new() { ID = "id", Account = "@elonmusk" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/tweets/id/like"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LikeCreateParams { ID = "id", Account = "@elonmusk" };

        LikeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
