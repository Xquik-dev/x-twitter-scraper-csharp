using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Radar;

namespace XTwitterScraper.Tests.Models.Radar;

public class RadarItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RadarItem
        {
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
            Title = "AI Revolution in 2025",
            Description = "AI is transforming every industry",
            ImageUrl = "https://example.com/images/ai.jpg",
            Url = "https://example.com/article/ai-revolution",
        };

        string expectedCategory = "Technology";
        DateTimeOffset expectedPublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedRegion = "US";
        double expectedScore = 95.5;
        string expectedSource = "X";
        string expectedTitle = "AI Revolution in 2025";
        string expectedDescription = "AI is transforming every industry";
        string expectedImageUrl = "https://example.com/images/ai.jpg";
        string expectedUrl = "https://example.com/article/ai-revolution";

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSource, model.Source);
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
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
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
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
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

        string expectedCategory = "Technology";
        DateTimeOffset expectedPublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedRegion = "US";
        double expectedScore = 95.5;
        string expectedSource = "X";
        string expectedTitle = "AI Revolution in 2025";
        string expectedDescription = "AI is transforming every industry";
        string expectedImageUrl = "https://example.com/images/ai.jpg";
        string expectedUrl = "https://example.com/article/ai-revolution";

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSource, deserialized.Source);
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
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
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
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
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
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
            Title = "AI Revolution in 2025",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RadarItem
        {
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
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
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
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
            Category = "Technology",
            PublishedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Region = "US",
            Score = 95.5,
            Source = "X",
            Title = "AI Revolution in 2025",
            Description = "AI is transforming every industry",
            ImageUrl = "https://example.com/images/ai.jpg",
            Url = "https://example.com/article/ai-revolution",
        };

        RadarItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
