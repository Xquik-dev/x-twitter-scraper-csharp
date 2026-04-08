using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionJobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, ExtractionJobStatus> expectedStatus = ExtractionJobStatus.Running;
        ApiEnum<string, ExtractionJobToolType> expectedToolType =
            ExtractionJobToolType.FollowerExplorer;
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
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionJob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionJob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, ExtractionJobStatus> expectedStatus = ExtractionJobStatus.Running;
        ApiEnum<string, ExtractionJobToolType> expectedToolType =
            ExtractionJobToolType.FollowerExplorer;
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
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
            TotalResults = 0,
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
            TotalResults = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
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
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
            TotalResults = 0,

            // Null should be interpreted as omitted for these properties
            CompletedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractionJob
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = ExtractionJobStatus.Running,
            ToolType = ExtractionJobToolType.FollowerExplorer,
            TotalResults = 0,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ExtractionJob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractionJobStatusTest : TestBase
{
    [Theory]
    [InlineData(ExtractionJobStatus.Running)]
    [InlineData(ExtractionJobStatus.Completed)]
    [InlineData(ExtractionJobStatus.Failed)]
    public void Validation_Works(ExtractionJobStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionJobStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionJobStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionJobStatus.Running)]
    [InlineData(ExtractionJobStatus.Completed)]
    [InlineData(ExtractionJobStatus.Failed)]
    public void SerializationRoundtrip_Works(ExtractionJobStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionJobStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionJobStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionJobStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionJobStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionJobToolTypeTest : TestBase
{
    [Theory]
    [InlineData(ExtractionJobToolType.ArticleExtractor)]
    [InlineData(ExtractionJobToolType.CommunityExtractor)]
    [InlineData(ExtractionJobToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionJobToolType.CommunityPostExtractor)]
    [InlineData(ExtractionJobToolType.CommunitySearch)]
    [InlineData(ExtractionJobToolType.FollowerExplorer)]
    [InlineData(ExtractionJobToolType.FollowingExplorer)]
    [InlineData(ExtractionJobToolType.ListFollowerExplorer)]
    [InlineData(ExtractionJobToolType.ListMemberExtractor)]
    [InlineData(ExtractionJobToolType.ListPostExtractor)]
    [InlineData(ExtractionJobToolType.MentionExtractor)]
    [InlineData(ExtractionJobToolType.PeopleSearch)]
    [InlineData(ExtractionJobToolType.PostExtractor)]
    [InlineData(ExtractionJobToolType.QuoteExtractor)]
    [InlineData(ExtractionJobToolType.ReplyExtractor)]
    [InlineData(ExtractionJobToolType.RepostExtractor)]
    [InlineData(ExtractionJobToolType.SpaceExplorer)]
    [InlineData(ExtractionJobToolType.ThreadExtractor)]
    [InlineData(ExtractionJobToolType.TweetSearchExtractor)]
    [InlineData(ExtractionJobToolType.VerifiedFollowerExplorer)]
    public void Validation_Works(ExtractionJobToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionJobToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionJobToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionJobToolType.ArticleExtractor)]
    [InlineData(ExtractionJobToolType.CommunityExtractor)]
    [InlineData(ExtractionJobToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionJobToolType.CommunityPostExtractor)]
    [InlineData(ExtractionJobToolType.CommunitySearch)]
    [InlineData(ExtractionJobToolType.FollowerExplorer)]
    [InlineData(ExtractionJobToolType.FollowingExplorer)]
    [InlineData(ExtractionJobToolType.ListFollowerExplorer)]
    [InlineData(ExtractionJobToolType.ListMemberExtractor)]
    [InlineData(ExtractionJobToolType.ListPostExtractor)]
    [InlineData(ExtractionJobToolType.MentionExtractor)]
    [InlineData(ExtractionJobToolType.PeopleSearch)]
    [InlineData(ExtractionJobToolType.PostExtractor)]
    [InlineData(ExtractionJobToolType.QuoteExtractor)]
    [InlineData(ExtractionJobToolType.ReplyExtractor)]
    [InlineData(ExtractionJobToolType.RepostExtractor)]
    [InlineData(ExtractionJobToolType.SpaceExplorer)]
    [InlineData(ExtractionJobToolType.ThreadExtractor)]
    [InlineData(ExtractionJobToolType.TweetSearchExtractor)]
    [InlineData(ExtractionJobToolType.VerifiedFollowerExplorer)]
    public void SerializationRoundtrip_Works(ExtractionJobToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionJobToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionJobToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionJobToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionJobToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
