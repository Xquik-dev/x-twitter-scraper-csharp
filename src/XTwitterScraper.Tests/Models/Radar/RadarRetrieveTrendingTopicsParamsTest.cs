using System;
using XTwitterScraper.Models.Radar;

namespace XTwitterScraper.Tests.Models.Radar;

public class RadarRetrieveTrendingTopicsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RadarRetrieveTrendingTopicsParams
        {
            Category = "category",
            Count = 0,
            Hours = 0,
            Region = "region",
            Source = "source",
        };

        string expectedCategory = "category";
        long expectedCount = 0;
        long expectedHours = 0;
        string expectedRegion = "region";
        string expectedSource = "source";

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedCount, parameters.Count);
        Assert.Equal(expectedHours, parameters.Hours);
        Assert.Equal(expectedRegion, parameters.Region);
        Assert.Equal(expectedSource, parameters.Source);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RadarRetrieveTrendingTopicsParams { };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Count);
        Assert.False(parameters.RawQueryData.ContainsKey("count"));
        Assert.Null(parameters.Hours);
        Assert.False(parameters.RawQueryData.ContainsKey("hours"));
        Assert.Null(parameters.Region);
        Assert.False(parameters.RawQueryData.ContainsKey("region"));
        Assert.Null(parameters.Source);
        Assert.False(parameters.RawQueryData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RadarRetrieveTrendingTopicsParams
        {
            // Null should be interpreted as omitted for these properties
            Category = null,
            Count = null,
            Hours = null,
            Region = null,
            Source = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Count);
        Assert.False(parameters.RawQueryData.ContainsKey("count"));
        Assert.Null(parameters.Hours);
        Assert.False(parameters.RawQueryData.ContainsKey("hours"));
        Assert.Null(parameters.Region);
        Assert.False(parameters.RawQueryData.ContainsKey("region"));
        Assert.Null(parameters.Source);
        Assert.False(parameters.RawQueryData.ContainsKey("source"));
    }

    [Fact]
    public void Url_Works()
    {
        RadarRetrieveTrendingTopicsParams parameters = new()
        {
            Category = "category",
            Count = 0,
            Hours = 0,
            Region = "region",
            Source = "source",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri(
                "https://xquik.com/api/v1/radar?category=category&count=0&hours=0&region=region&source=source"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RadarRetrieveTrendingTopicsParams
        {
            Category = "category",
            Count = 0,
            Hours = 0,
            Region = "region",
            Source = "source",
        };

        RadarRetrieveTrendingTopicsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
