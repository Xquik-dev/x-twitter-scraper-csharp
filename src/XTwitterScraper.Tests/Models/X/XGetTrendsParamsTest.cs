using System;
using XTwitterScraper.Models.X;

namespace XTwitterScraper.Tests.Models.X;

public class XGetTrendsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new XGetTrendsParams { Count = 1, Woeid = 0 };

        long expectedCount = 1;
        long expectedWoeid = 0;

        Assert.Equal(expectedCount, parameters.Count);
        Assert.Equal(expectedWoeid, parameters.Woeid);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new XGetTrendsParams { };

        Assert.Null(parameters.Count);
        Assert.False(parameters.RawQueryData.ContainsKey("count"));
        Assert.Null(parameters.Woeid);
        Assert.False(parameters.RawQueryData.ContainsKey("woeid"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new XGetTrendsParams
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
        XGetTrendsParams parameters = new() { Count = 1, Woeid = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/trends?count=1&woeid=0"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new XGetTrendsParams { Count = 1, Woeid = 0 };

        XGetTrendsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
