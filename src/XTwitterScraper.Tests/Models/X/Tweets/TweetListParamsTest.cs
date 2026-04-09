using System;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TweetListParams { Ids = "ids" };

        string expectedIds = "ids";

        Assert.Equal(expectedIds, parameters.Ids);
    }

    [Fact]
    public void Url_Works()
    {
        TweetListParams parameters = new() { Ids = "ids" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/x/tweets?ids=ids"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TweetListParams { Ids = "ids" };

        TweetListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
