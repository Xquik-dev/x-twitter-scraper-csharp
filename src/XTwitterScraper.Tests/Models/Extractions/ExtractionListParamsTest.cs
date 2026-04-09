using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExtractionListParams
        {
            After = "after",
            Limit = 1,
            Status = Status.Running,
            ToolType = ToolType.FollowerExplorer,
        };

        string expectedAfter = "after";
        long expectedLimit = 1;
        ApiEnum<string, Status> expectedStatus = Status.Running;
        ApiEnum<string, ToolType> expectedToolType = ToolType.FollowerExplorer;

        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedToolType, parameters.ToolType);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExtractionListParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.ToolType);
        Assert.False(parameters.RawQueryData.ContainsKey("toolType"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExtractionListParams
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Limit = null,
            Status = null,
            ToolType = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.ToolType);
        Assert.False(parameters.RawQueryData.ContainsKey("toolType"));
    }

    [Fact]
    public void Url_Works()
    {
        ExtractionListParams parameters = new()
        {
            After = "after",
            Limit = 1,
            Status = Status.Running,
            ToolType = ToolType.FollowerExplorer,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://xquik.com/api/v1/extractions?after=after&limit=1&status=running&toolType=follower_explorer"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractionListParams
        {
            After = "after",
            Limit = 1,
            Status = Status.Running,
            ToolType = ToolType.FollowerExplorer,
        };

        ExtractionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Running)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ToolTypeTest : TestBase
{
    [Theory]
    [InlineData(ToolType.ArticleExtractor)]
    [InlineData(ToolType.CommunityExtractor)]
    [InlineData(ToolType.CommunityModeratorExplorer)]
    [InlineData(ToolType.CommunityPostExtractor)]
    [InlineData(ToolType.CommunitySearch)]
    [InlineData(ToolType.FollowerExplorer)]
    [InlineData(ToolType.FollowingExplorer)]
    [InlineData(ToolType.ListFollowerExplorer)]
    [InlineData(ToolType.ListMemberExtractor)]
    [InlineData(ToolType.ListPostExtractor)]
    [InlineData(ToolType.MentionExtractor)]
    [InlineData(ToolType.PeopleSearch)]
    [InlineData(ToolType.PostExtractor)]
    [InlineData(ToolType.QuoteExtractor)]
    [InlineData(ToolType.ReplyExtractor)]
    [InlineData(ToolType.RepostExtractor)]
    [InlineData(ToolType.SpaceExplorer)]
    [InlineData(ToolType.ThreadExtractor)]
    [InlineData(ToolType.TweetSearchExtractor)]
    [InlineData(ToolType.VerifiedFollowerExplorer)]
    public void Validation_Works(ToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolType.ArticleExtractor)]
    [InlineData(ToolType.CommunityExtractor)]
    [InlineData(ToolType.CommunityModeratorExplorer)]
    [InlineData(ToolType.CommunityPostExtractor)]
    [InlineData(ToolType.CommunitySearch)]
    [InlineData(ToolType.FollowerExplorer)]
    [InlineData(ToolType.FollowingExplorer)]
    [InlineData(ToolType.ListFollowerExplorer)]
    [InlineData(ToolType.ListMemberExtractor)]
    [InlineData(ToolType.ListPostExtractor)]
    [InlineData(ToolType.MentionExtractor)]
    [InlineData(ToolType.PeopleSearch)]
    [InlineData(ToolType.PostExtractor)]
    [InlineData(ToolType.QuoteExtractor)]
    [InlineData(ToolType.ReplyExtractor)]
    [InlineData(ToolType.RepostExtractor)]
    [InlineData(ToolType.SpaceExplorer)]
    [InlineData(ToolType.ThreadExtractor)]
    [InlineData(ToolType.TweetSearchExtractor)]
    [InlineData(ToolType.VerifiedFollowerExplorer)]
    public void SerializationRoundtrip_Works(ToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
