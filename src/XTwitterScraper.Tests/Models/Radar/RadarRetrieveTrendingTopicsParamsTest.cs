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
            After = "after",
            Category = Category.General,
            Hours = 1,
            Limit = 1,
            Region = "region",
            Source = Source.GitHub,
        };

        string expectedAfter = "after";
        ApiEnum<string, Category> expectedCategory = Category.General;
        long expectedHours = 1;
        long expectedLimit = 1;
        string expectedRegion = "region";
        ApiEnum<string, Source> expectedSource = Source.GitHub;

        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedHours, parameters.Hours);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedRegion, parameters.Region);
        Assert.Equal(expectedSource, parameters.Source);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RadarRetrieveTrendingTopicsParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Hours);
        Assert.False(parameters.RawQueryData.ContainsKey("hours"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
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
            After = null,
            Category = null,
            Hours = null,
            Limit = null,
            Region = null,
            Source = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.Hours);
        Assert.False(parameters.RawQueryData.ContainsKey("hours"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
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
            After = "after",
            Category = Category.General,
            Hours = 1,
            Limit = 1,
            Region = "region",
            Source = Source.GitHub,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/radar?after=after&category=general&hours=1&limit=1&region=region&source=github"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RadarRetrieveTrendingTopicsParams
        {
            After = "after",
            Category = Category.General,
            Hours = 1,
            Limit = 1,
            Region = "region",
            Source = Source.GitHub,
        };

        RadarRetrieveTrendingTopicsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.General)]
    [InlineData(Category.Tech)]
    [InlineData(Category.Dev)]
    [InlineData(Category.Science)]
    [InlineData(Category.Culture)]
    [InlineData(Category.Politics)]
    [InlineData(Category.Business)]
    [InlineData(Category.Entertainment)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.General)]
    [InlineData(Category.Tech)]
    [InlineData(Category.Dev)]
    [InlineData(Category.Science)]
    [InlineData(Category.Culture)]
    [InlineData(Category.Politics)]
    [InlineData(Category.Business)]
    [InlineData(Category.Entertainment)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
