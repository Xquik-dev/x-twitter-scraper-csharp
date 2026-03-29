using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionRunResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractionRunResponse
        {
            ID = "id",
            Status = ExtractionRunResponseStatus.Running,
            ToolType = ExtractionRunResponseToolType.ArticleExtractor,
        };

        string expectedID = "id";
        ApiEnum<string, ExtractionRunResponseStatus> expectedStatus =
            ExtractionRunResponseStatus.Running;
        ApiEnum<string, ExtractionRunResponseToolType> expectedToolType =
            ExtractionRunResponseToolType.ArticleExtractor;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedToolType, model.ToolType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractionRunResponse
        {
            ID = "id",
            Status = ExtractionRunResponseStatus.Running,
            ToolType = ExtractionRunResponseToolType.ArticleExtractor,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionRunResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractionRunResponse
        {
            ID = "id",
            Status = ExtractionRunResponseStatus.Running,
            ToolType = ExtractionRunResponseToolType.ArticleExtractor,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionRunResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, ExtractionRunResponseStatus> expectedStatus =
            ExtractionRunResponseStatus.Running;
        ApiEnum<string, ExtractionRunResponseToolType> expectedToolType =
            ExtractionRunResponseToolType.ArticleExtractor;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedToolType, deserialized.ToolType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractionRunResponse
        {
            ID = "id",
            Status = ExtractionRunResponseStatus.Running,
            ToolType = ExtractionRunResponseToolType.ArticleExtractor,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractionRunResponse
        {
            ID = "id",
            Status = ExtractionRunResponseStatus.Running,
            ToolType = ExtractionRunResponseToolType.ArticleExtractor,
        };

        ExtractionRunResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractionRunResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(ExtractionRunResponseStatus.Running)]
    public void Validation_Works(ExtractionRunResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionRunResponseStatus.Running)]
    public void SerializationRoundtrip_Works(ExtractionRunResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionRunResponseToolTypeTest : TestBase
{
    [Theory]
    [InlineData(ExtractionRunResponseToolType.ArticleExtractor)]
    [InlineData(ExtractionRunResponseToolType.CommunityExtractor)]
    [InlineData(ExtractionRunResponseToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionRunResponseToolType.CommunityPostExtractor)]
    [InlineData(ExtractionRunResponseToolType.CommunitySearch)]
    [InlineData(ExtractionRunResponseToolType.FollowerExplorer)]
    [InlineData(ExtractionRunResponseToolType.FollowingExplorer)]
    [InlineData(ExtractionRunResponseToolType.ListFollowerExplorer)]
    [InlineData(ExtractionRunResponseToolType.ListMemberExtractor)]
    [InlineData(ExtractionRunResponseToolType.ListPostExtractor)]
    [InlineData(ExtractionRunResponseToolType.MentionExtractor)]
    [InlineData(ExtractionRunResponseToolType.PeopleSearch)]
    [InlineData(ExtractionRunResponseToolType.PostExtractor)]
    [InlineData(ExtractionRunResponseToolType.QuoteExtractor)]
    [InlineData(ExtractionRunResponseToolType.ReplyExtractor)]
    [InlineData(ExtractionRunResponseToolType.RepostExtractor)]
    [InlineData(ExtractionRunResponseToolType.SpaceExplorer)]
    [InlineData(ExtractionRunResponseToolType.ThreadExtractor)]
    [InlineData(ExtractionRunResponseToolType.TweetSearchExtractor)]
    [InlineData(ExtractionRunResponseToolType.VerifiedFollowerExplorer)]
    public void Validation_Works(ExtractionRunResponseToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunResponseToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunResponseToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionRunResponseToolType.ArticleExtractor)]
    [InlineData(ExtractionRunResponseToolType.CommunityExtractor)]
    [InlineData(ExtractionRunResponseToolType.CommunityModeratorExplorer)]
    [InlineData(ExtractionRunResponseToolType.CommunityPostExtractor)]
    [InlineData(ExtractionRunResponseToolType.CommunitySearch)]
    [InlineData(ExtractionRunResponseToolType.FollowerExplorer)]
    [InlineData(ExtractionRunResponseToolType.FollowingExplorer)]
    [InlineData(ExtractionRunResponseToolType.ListFollowerExplorer)]
    [InlineData(ExtractionRunResponseToolType.ListMemberExtractor)]
    [InlineData(ExtractionRunResponseToolType.ListPostExtractor)]
    [InlineData(ExtractionRunResponseToolType.MentionExtractor)]
    [InlineData(ExtractionRunResponseToolType.PeopleSearch)]
    [InlineData(ExtractionRunResponseToolType.PostExtractor)]
    [InlineData(ExtractionRunResponseToolType.QuoteExtractor)]
    [InlineData(ExtractionRunResponseToolType.ReplyExtractor)]
    [InlineData(ExtractionRunResponseToolType.RepostExtractor)]
    [InlineData(ExtractionRunResponseToolType.SpaceExplorer)]
    [InlineData(ExtractionRunResponseToolType.ThreadExtractor)]
    [InlineData(ExtractionRunResponseToolType.TweetSearchExtractor)]
    [InlineData(ExtractionRunResponseToolType.VerifiedFollowerExplorer)]
    public void SerializationRoundtrip_Works(ExtractionRunResponseToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionRunResponseToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractionRunResponseToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionRunResponseToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractionRunResponseToolType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
