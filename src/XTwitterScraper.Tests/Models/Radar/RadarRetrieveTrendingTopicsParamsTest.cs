using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
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
            Source = Source.GitHub,
        };

        string expectedCategory = "category";
        long expectedCount = 0;
        long expectedHours = 0;
        string expectedRegion = "region";
        ApiEnum<string, Source> expectedSource = Source.GitHub;

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
            Source = Source.GitHub,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://xquik.com/api/v1/radar?category=category&count=0&hours=0&region=region&source=github"
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
            Source = Source.GitHub,
        };

        RadarRetrieveTrendingTopicsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.GitHub)]
    [InlineData(Source.GoogleTrends)]
    [InlineData(Source.HackerNews)]
    [InlineData(Source.Polymarket)]
    [InlineData(Source.Reddit)]
    [InlineData(Source.Trustmrr)]
    [InlineData(Source.Wikipedia)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.GitHub)]
    [InlineData(Source.GoogleTrends)]
    [InlineData(Source.HackerNews)]
    [InlineData(Source.Polymarket)]
    [InlineData(Source.Reddit)]
    [InlineData(Source.Trustmrr)]
    [InlineData(Source.Wikipedia)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
