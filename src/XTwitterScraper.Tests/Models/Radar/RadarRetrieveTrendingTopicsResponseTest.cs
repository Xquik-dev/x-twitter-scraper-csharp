using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Radar;

namespace XTwitterScraper.Tests.Models.Radar;

public class RadarRetrieveTrendingTopicsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        bool expectedHasMore = false;
        List<RadarItem> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RadarRetrieveTrendingTopicsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RadarRetrieveTrendingTopicsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasMore = false;
        List<RadarItem> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RadarRetrieveTrendingTopicsResponse
        {
            HasMore = false,
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        RadarRetrieveTrendingTopicsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
