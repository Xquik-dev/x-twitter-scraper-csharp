using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Drafts;

namespace XTwitterScraper.Tests.Models.Drafts;

public class DraftListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        List<Draft> expectedDrafts =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Text = "Draft tweet about AI trends",
                Goal = "Engagement",
                Topic = "Technology",
            },
        ];
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

        Assert.Equal(expectedDrafts.Count, model.Drafts.Count);
        for (int i = 0; i < expectedDrafts.Count; i++)
        {
            Assert.Equal(expectedDrafts[i], model.Drafts[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DraftListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DraftListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Draft> expectedDrafts =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Text = "Draft tweet about AI trends",
                Goal = "Engagement",
                Topic = "Technology",
            },
        ];
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

        Assert.Equal(expectedDrafts.Count, deserialized.Drafts.Count);
        for (int i = 0; i < expectedDrafts.Count; i++)
        {
            Assert.Equal(expectedDrafts[i], deserialized.Drafts[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DraftListResponse
        {
            Drafts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Text = "Draft tweet about AI trends",
                    Goal = "Engagement",
                    Topic = "Technology",
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        DraftListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
