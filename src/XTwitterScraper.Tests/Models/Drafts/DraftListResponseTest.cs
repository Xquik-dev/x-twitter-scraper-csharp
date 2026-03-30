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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        List<Draft> expectedDrafts =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Text = "text",
                Goal = "goal",
                Topic = "topic",
            },
        ];
        bool expectedHasMore = true;
        string expectedNextCursor = "nextCursor";

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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
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
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Text = "text",
                Goal = "goal",
                Topic = "topic",
            },
        ];
        bool expectedHasMore = true;
        string expectedNextCursor = "nextCursor";

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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,
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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,
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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,

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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,

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
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    Goal = "goal",
                    Topic = "topic",
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        DraftListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
