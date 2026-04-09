using System;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DrawListParams { After = "after", Limit = 1 };

        string expectedAfter = "after";
        long expectedLimit = 1;

        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DrawListParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DrawListParams
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Limit = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        DrawListParams parameters = new() { After = "after", Limit = 1 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/draws?after=after&limit=1"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DrawListParams { After = "after", Limit = 1 };

        DrawListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
