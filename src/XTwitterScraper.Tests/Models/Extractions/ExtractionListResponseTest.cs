using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        List<Extraction> expectedExtractions =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = ExtractionStatus.Running,
                ToolType = ExtractionToolType.FollowerExplorer,
                TotalResults = 0,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

        Assert.Equal(expectedExtractions.Count, model.Extractions.Count);
        for (int i = 0; i < expectedExtractions.Count; i++)
        {
            Assert.Equal(expectedExtractions[i], model.Extractions[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Extraction> expectedExtractions =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = ExtractionStatus.Running,
                ToolType = ExtractionToolType.FollowerExplorer,
                TotalResults = 0,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        bool expectedHasMore = false;
        string expectedNextCursor = "abc123";

        Assert.Equal(expectedExtractions.Count, deserialized.Extractions.Count);
        for (int i = 0; i < expectedExtractions.Count; i++)
        {
            Assert.Equal(expectedExtractions[i], deserialized.Extractions[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new ExtractionListResponse
        {
            Extractions =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = ExtractionStatus.Running,
                    ToolType = ExtractionToolType.FollowerExplorer,
                    TotalResults = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            HasMore = false,
            NextCursor = "abc123",
        };

        ExtractionListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, ExtractionStatus> expectedStatus = ExtractionStatus.Running;
        ApiEnum<string, ExtractionToolType> expectedToolType = ExtractionToolType.FollowerExplorer;
        long expectedTotalResults = 0;
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedToolType, model.ToolType);
        Assert.Equal(expectedTotalResults, model.TotalResults);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Extraction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Extraction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, ExtractionStatus> expectedStatus = ExtractionStatus.Running;
        ApiEnum<string, ExtractionToolType> expectedToolType = ExtractionToolType.FollowerExplorer;
        long expectedTotalResults = 0;
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedToolType, deserialized.ToolType);
        Assert.Equal(expectedTotalResults, deserialized.TotalResults);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,

            // Null should be interpreted as omitted for these properties
            CompletedAt = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,

            // Null should be interpreted as omitted for these properties
            CompletedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Extraction
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionStatus.Running,
            ToolType = ExtractionToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Extraction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractionStatusTest : TestBase
{
    [Theory]
    [InlineData(ExtractionStatus.Running)]
    [InlineData(ExtractionStatus.Completed)]
    [InlineData(ExtractionStatus.Failed)]
    public void Validation_Works(ExtractionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionStatus.Running)]
    [InlineData(ExtractionStatus.Completed)]
    [InlineData(ExtractionStatus.Failed)]
    public void SerializationRoundtrip_Works(ExtractionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionToolTypeTest : TestBase
{
    [Theory]
    [InlineData(ExtractionToolType.ArticleExtractor)]
    [InlineData(ExtractionToolType.CommunityExtractor)]
    [InlineData(ExtractionToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionToolType.CommunityPostExtractor)]
    [InlineData(ExtractionToolType.CommunitySearch)]
    [InlineData(ExtractionToolType.FollowerExplorer)]
    [InlineData(ExtractionToolType.FollowingExplorer)]
    [InlineData(ExtractionToolType.ListFollowerExplorer)]
    [InlineData(ExtractionToolType.ListMemberExtractor)]
    [InlineData(ExtractionToolType.ListPostExtractor)]
    [InlineData(ExtractionToolType.MentionExtractor)]
    [InlineData(ExtractionToolType.PeopleSearch)]
    [InlineData(ExtractionToolType.PostExtractor)]
    [InlineData(ExtractionToolType.QuoteExtractor)]
    [InlineData(ExtractionToolType.ReplyExtractor)]
    [InlineData(ExtractionToolType.RepostExtractor)]
    [InlineData(ExtractionToolType.SpaceExplorer)]
    [InlineData(ExtractionToolType.ThreadExtractor)]
    [InlineData(ExtractionToolType.TweetSearchExtractor)]
    [InlineData(ExtractionToolType.VerifiedFollowerExplorer)]
    public void Validation_Works(ExtractionToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionToolType.ArticleExtractor)]
    [InlineData(ExtractionToolType.CommunityExtractor)]
    [InlineData(ExtractionToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionToolType.CommunityPostExtractor)]
    [InlineData(ExtractionToolType.CommunitySearch)]
    [InlineData(ExtractionToolType.FollowerExplorer)]
    [InlineData(ExtractionToolType.FollowingExplorer)]
    [InlineData(ExtractionToolType.ListFollowerExplorer)]
    [InlineData(ExtractionToolType.ListMemberExtractor)]
    [InlineData(ExtractionToolType.ListPostExtractor)]
    [InlineData(ExtractionToolType.MentionExtractor)]
    [InlineData(ExtractionToolType.PeopleSearch)]
    [InlineData(ExtractionToolType.PostExtractor)]
    [InlineData(ExtractionToolType.QuoteExtractor)]
    [InlineData(ExtractionToolType.ReplyExtractor)]
    [InlineData(ExtractionToolType.RepostExtractor)]
    [InlineData(ExtractionToolType.SpaceExplorer)]
    [InlineData(ExtractionToolType.ThreadExtractor)]
    [InlineData(ExtractionToolType.TweetSearchExtractor)]
    [InlineData(ExtractionToolType.VerifiedFollowerExplorer)]
    public void SerializationRoundtrip_Works(ExtractionToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
