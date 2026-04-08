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
            HasMore = false,
            NextCursor = "abc123",
        };

        List<DrawListResponseDraw> expectedDraws =
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
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

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
            HasMore = false,
            NextCursor = "abc123",
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
            HasMore = false,
            NextCursor = "abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<DrawListResponseDraw> expectedDraws =
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
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

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
            HasMore = false,
            NextCursor = "abc123",
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
            HasMore = false,
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
            HasMore = false,
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
            HasMore = false,

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
            HasMore = false,
            NextCursor = "abc123",
        };

        DrawListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DrawListResponseDrawTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        long expectedTotalEntries = 0;
        string expectedTweetUrl = "https://example.com";
        long expectedValidEntries = 0;
        DateTimeOffset expectedDrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTotalEntries, model.TotalEntries);
        Assert.Equal(expectedTweetUrl, model.TweetUrl);
        Assert.Equal(expectedValidEntries, model.ValidEntries);
        Assert.Equal(expectedDrawnAt, model.DrawnAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawListResponseDraw>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DrawListResponseDraw>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        long expectedTotalEntries = 0;
        string expectedTweetUrl = "https://example.com";
        long expectedValidEntries = 0;
        DateTimeOffset expectedDrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTotalEntries, deserialized.TotalEntries);
        Assert.Equal(expectedTweetUrl, deserialized.TweetUrl);
        Assert.Equal(expectedValidEntries, deserialized.ValidEntries);
        Assert.Equal(expectedDrawnAt, deserialized.DrawnAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,
        };

        Assert.Null(model.DrawnAt);
        Assert.False(model.RawData.ContainsKey("drawnAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,

            // Null should be interpreted as omitted for these properties
            DrawnAt = null,
        };

        Assert.Null(model.DrawnAt);
        Assert.False(model.RawData.ContainsKey("drawnAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,

            // Null should be interpreted as omitted for these properties
            DrawnAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DrawListResponseDraw
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            TotalEntries = 0,
            TweetUrl = "https://example.com",
            ValidEntries = 0,
            DrawnAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DrawListResponseDraw copied = new(model);

        Assert.Equal(model, copied);
    }
}
