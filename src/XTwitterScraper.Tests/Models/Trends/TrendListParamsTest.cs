using System;
using XTwitterScraper.Models.Trends;

namespace XTwitterScraper.Tests.Models.Trends;

public class TrendListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrendListParams { Count = 1, Woeid = 0 };

        long expectedCount = 1;
        long expectedWoeid = 0;

        Assert.Equal(expectedCount, parameters.Count);
        Assert.Equal(expectedWoeid, parameters.Woeid);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TrendListParams { };

        Assert.Null(parameters.Count);
        Assert.False(parameters.RawQueryData.ContainsKey("count"));
        Assert.Null(parameters.Woeid);
        Assert.False(parameters.RawQueryData.ContainsKey("woeid"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TrendListParams
        {
            // Null should be interpreted as omitted for these properties
            Count = null,
            Woeid = null,
        };

        Assert.Null(parameters.Count);
        Assert.False(parameters.RawQueryData.ContainsKey("count"));
        Assert.Null(parameters.Woeid);
        Assert.False(parameters.RawQueryData.ContainsKey("woeid"));
    }

    [Fact]
    public void Url_Works()
    {
        TrendListParams parameters = new() { Count = 1, Woeid = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/trends?count=1&woeid=0"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TrendListParams { Count = 1, Woeid = 0 };

        TrendListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
