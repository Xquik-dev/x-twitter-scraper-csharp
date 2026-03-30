using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        List<DrawListItem> expectedDraws =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                TotalEntries = 0,
                TweetUrl = "https://example.com",
                ValidEntries = 0,
                DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedHasMore = true;
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedDraws.Count, model.Draws.Count);
        for (int i = 0; i < expectedDraws.Count; i++)
        {
            Assert.Equal(expectedDraws[i], model.Draws[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<DrawListItem> expectedDraws =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                TotalEntries = 0,
                TweetUrl = "https://example.com",
                ValidEntries = 0,
                DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedHasMore = true;
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedDraws.Count, deserialized.Draws.Count);
        for (int i = 0; i < expectedDraws.Count; i++)
        {
            Assert.Equal(expectedDraws[i], deserialized.Draws[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new DrawListResponse
        {
            Draws =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    TotalEntries = 0,
                    TweetUrl = "https://example.com",
                    ValidEntries = 0,
                    DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = true,
            NextCursor = "nextCursor",
        };

        DrawListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
