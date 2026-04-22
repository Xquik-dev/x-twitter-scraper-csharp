using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Radar;

namespace XTwitterScraper.Tests.Models.Radar;

public class RadarItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",
            Description = "AI is transforming every industry",
            ImageUrl = "https://example.com/images/ai.jpg",
            Url = "https://example.com/article/ai-revolution",
        };

        string expectedID = "4712";
        ApiEnum<string, RadarItemCategory> expectedCategory = RadarItemCategory.Tech;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z");
        string expectedLanguage = "en";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedPublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedRegion = "global";
        double expectedScore = 95.5;
        ApiEnum<string, RadarItemSource> expectedSource = RadarItemSource.Trustmrr;
        string expectedSourceID = "trustmrr_acme";
        string expectedTitle = "AI Revolution in 2025";
        string expectedDescription = "AI is transforming every industry";
        string expectedImageUrl = "https://example.com/images/ai.jpg";
        string expectedUrl = "https://example.com/article/ai-revolution";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedImageUrl, model.ImageUrl);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",
            Description = "AI is transforming every industry",
            ImageUrl = "https://example.com/images/ai.jpg",
            Url = "https://example.com/article/ai-revolution",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RadarItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",
            Description = "AI is transforming every industry",
            ImageUrl = "https://example.com/images/ai.jpg",
            Url = "https://example.com/article/ai-revolution",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RadarItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "4712";
        ApiEnum<string, RadarItemCategory> expectedCategory = RadarItemCategory.Tech;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z");
        string expectedLanguage = "en";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedPublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedRegion = "global";
        double expectedScore = 95.5;
        ApiEnum<string, RadarItemSource> expectedSource = RadarItemSource.Trustmrr;
        string expectedSourceID = "trustmrr_acme";
        string expectedTitle = "AI Revolution in 2025";
        string expectedDescription = "AI is transforming every industry";
        string expectedImageUrl = "https://example.com/images/ai.jpg";
        string expectedUrl = "https://example.com/article/ai-revolution";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedImageUrl, deserialized.ImageUrl);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",
            Description = "AI is transforming every industry",
            ImageUrl = "https://example.com/images/ai.jpg",
            Url = "https://example.com/article/ai-revolution",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ImageUrl);
        Assert.False(model.RawData.ContainsKey("imageUrl"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",

            // Null should be interpreted as omitted for these properties
            Description = null,
            ImageUrl = null,
            Url = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ImageUrl);
        Assert.False(model.RawData.ContainsKey("imageUrl"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",

            // Null should be interpreted as omitted for these properties
            Description = null,
            ImageUrl = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RadarItem
        {
            ID = "4712",
            Category = RadarItemCategory.Tech,
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:01:00Z"),
            Language = "en",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "global",
            Score = 95.5,
            Source = RadarItemSource.Trustmrr,
            SourceID = "trustmrr_acme",
            Title = "AI Revolution in 2025",
            Description = "AI is transforming every industry",
            ImageUrl = "https://example.com/images/ai.jpg",
            Url = "https://example.com/article/ai-revolution",
        };

        RadarItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RadarItemCategoryTest : TestBase
{
    [Theory]
    [InlineData(RadarItemCategory.General)]
    [InlineData(RadarItemCategory.Tech)]
    [InlineData(RadarItemCategory.Dev)]
    [InlineData(RadarItemCategory.Science)]
    [InlineData(RadarItemCategory.Culture)]
    [InlineData(RadarItemCategory.Politics)]
    [InlineData(RadarItemCategory.Business)]
    [InlineData(RadarItemCategory.Entertainment)]
    public void Validation_Works(RadarItemCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RadarItemCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RadarItemCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RadarItemCategory.General)]
    [InlineData(RadarItemCategory.Tech)]
    [InlineData(RadarItemCategory.Dev)]
    [InlineData(RadarItemCategory.Science)]
    [InlineData(RadarItemCategory.Culture)]
    [InlineData(RadarItemCategory.Politics)]
    [InlineData(RadarItemCategory.Business)]
    [InlineData(RadarItemCategory.Entertainment)]
    public void SerializationRoundtrip_Works(RadarItemCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RadarItemCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RadarItemCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RadarItemCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RadarItemCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RadarItemSourceTest : TestBase
{
    [Theory]
    [InlineData(RadarItemSource.GitHub)]
    [InlineData(RadarItemSource.GoogleTrends)]
    [InlineData(RadarItemSource.HackerNews)]
    [InlineData(RadarItemSource.Polymarket)]
    [InlineData(RadarItemSource.Reddit)]
    [InlineData(RadarItemSource.Trustmrr)]
    [InlineData(RadarItemSource.Wikipedia)]
    public void Validation_Works(RadarItemSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RadarItemSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RadarItemSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RadarItemSource.GitHub)]
    [InlineData(RadarItemSource.GoogleTrends)]
    [InlineData(RadarItemSource.HackerNews)]
    [InlineData(RadarItemSource.Polymarket)]
    [InlineData(RadarItemSource.Reddit)]
    [InlineData(RadarItemSource.Trustmrr)]
    [InlineData(RadarItemSource.Wikipedia)]
    public void SerializationRoundtrip_Works(RadarItemSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RadarItemSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RadarItemSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RadarItemSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RadarItemSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
