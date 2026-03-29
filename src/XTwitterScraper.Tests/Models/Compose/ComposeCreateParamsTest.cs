using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Compose;

namespace XTwitterScraper.Tests.Models.Compose;

public class ComposeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ComposeCreateParams
        {
            Step = Step.Compose,
            AdditionalContext = "additionalContext",
            CallToAction = "callToAction",
            Draft = "draft",
            Goal = Goal.Engagement,
            HasLink = true,
            HasMedia = true,
            MediaType = MediaType.Photo,
            StyleUsername = "styleUsername",
            Tone = "tone",
            Topic = "topic",
        };

        ApiEnum<string, Step> expectedStep = Step.Compose;
        string expectedAdditionalContext = "additionalContext";
        string expectedCallToAction = "callToAction";
        string expectedDraft = "draft";
        ApiEnum<string, Goal> expectedGoal = Goal.Engagement;
        bool expectedHasLink = true;
        bool expectedHasMedia = true;
        ApiEnum<string, MediaType> expectedMediaType = MediaType.Photo;
        string expectedStyleUsername = "styleUsername";
        string expectedTone = "tone";
        string expectedTopic = "topic";

        Assert.Equal(expectedStep, parameters.Step);
        Assert.Equal(expectedAdditionalContext, parameters.AdditionalContext);
        Assert.Equal(expectedCallToAction, parameters.CallToAction);
        Assert.Equal(expectedDraft, parameters.Draft);
        Assert.Equal(expectedGoal, parameters.Goal);
        Assert.Equal(expectedHasLink, parameters.HasLink);
        Assert.Equal(expectedHasMedia, parameters.HasMedia);
        Assert.Equal(expectedMediaType, parameters.MediaType);
        Assert.Equal(expectedStyleUsername, parameters.StyleUsername);
        Assert.Equal(expectedTone, parameters.Tone);
        Assert.Equal(expectedTopic, parameters.Topic);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ComposeCreateParams { Step = Step.Compose };

        Assert.Null(parameters.AdditionalContext);
        Assert.False(parameters.RawBodyData.ContainsKey("additionalContext"));
        Assert.Null(parameters.CallToAction);
        Assert.False(parameters.RawBodyData.ContainsKey("callToAction"));
        Assert.Null(parameters.Draft);
        Assert.False(parameters.RawBodyData.ContainsKey("draft"));
        Assert.Null(parameters.Goal);
        Assert.False(parameters.RawBodyData.ContainsKey("goal"));
        Assert.Null(parameters.HasLink);
        Assert.False(parameters.RawBodyData.ContainsKey("hasLink"));
        Assert.Null(parameters.HasMedia);
        Assert.False(parameters.RawBodyData.ContainsKey("hasMedia"));
        Assert.Null(parameters.MediaType);
        Assert.False(parameters.RawBodyData.ContainsKey("mediaType"));
        Assert.Null(parameters.StyleUsername);
        Assert.False(parameters.RawBodyData.ContainsKey("styleUsername"));
        Assert.Null(parameters.Tone);
        Assert.False(parameters.RawBodyData.ContainsKey("tone"));
        Assert.Null(parameters.Topic);
        Assert.False(parameters.RawBodyData.ContainsKey("topic"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ComposeCreateParams
        {
            Step = Step.Compose,

            // Null should be interpreted as omitted for these properties
            AdditionalContext = null,
            CallToAction = null,
            Draft = null,
            Goal = null,
            HasLink = null,
            HasMedia = null,
            MediaType = null,
            StyleUsername = null,
            Tone = null,
            Topic = null,
        };

        Assert.Null(parameters.AdditionalContext);
        Assert.False(parameters.RawBodyData.ContainsKey("additionalContext"));
        Assert.Null(parameters.CallToAction);
        Assert.False(parameters.RawBodyData.ContainsKey("callToAction"));
        Assert.Null(parameters.Draft);
        Assert.False(parameters.RawBodyData.ContainsKey("draft"));
        Assert.Null(parameters.Goal);
        Assert.False(parameters.RawBodyData.ContainsKey("goal"));
        Assert.Null(parameters.HasLink);
        Assert.False(parameters.RawBodyData.ContainsKey("hasLink"));
        Assert.Null(parameters.HasMedia);
        Assert.False(parameters.RawBodyData.ContainsKey("hasMedia"));
        Assert.Null(parameters.MediaType);
        Assert.False(parameters.RawBodyData.ContainsKey("mediaType"));
        Assert.Null(parameters.StyleUsername);
        Assert.False(parameters.RawBodyData.ContainsKey("styleUsername"));
        Assert.Null(parameters.Tone);
        Assert.False(parameters.RawBodyData.ContainsKey("tone"));
        Assert.Null(parameters.Topic);
        Assert.False(parameters.RawBodyData.ContainsKey("topic"));
    }

    [Fact]
    public void Url_Works()
    {
        ComposeCreateParams parameters = new() { Step = Step.Compose };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/compose"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ComposeCreateParams
        {
            Step = Step.Compose,
            AdditionalContext = "additionalContext",
            CallToAction = "callToAction",
            Draft = "draft",
            Goal = Goal.Engagement,
            HasLink = true,
            HasMedia = true,
            MediaType = MediaType.Photo,
            StyleUsername = "styleUsername",
            Tone = "tone",
            Topic = "topic",
        };

        ComposeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StepTest : TestBase
{
    [Theory]
    [InlineData(Step.Compose)]
    [InlineData(Step.Refine)]
    [InlineData(Step.Score)]
    public void Validation_Works(Step rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Step> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Step>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Step.Compose)]
    [InlineData(Step.Refine)]
    [InlineData(Step.Score)]
    public void SerializationRoundtrip_Works(Step rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Step> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Step>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Step>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Step>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GoalTest : TestBase
{
    [Theory]
    [InlineData(Goal.Engagement)]
    [InlineData(Goal.Followers)]
    [InlineData(Goal.Authority)]
    [InlineData(Goal.Conversation)]
    public void Validation_Works(Goal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Goal> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Goal>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Goal.Engagement)]
    [InlineData(Goal.Followers)]
    [InlineData(Goal.Authority)]
    [InlineData(Goal.Conversation)]
    public void SerializationRoundtrip_Works(Goal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Goal> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Goal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Goal>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Goal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MediaTypeTest : TestBase
{
    [Theory]
    [InlineData(MediaType.Photo)]
    [InlineData(MediaType.Video)]
    [InlineData(MediaType.None)]
    public void Validation_Works(MediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MediaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MediaType.Photo)]
    [InlineData(MediaType.Video)]
    [InlineData(MediaType.None)]
    public void SerializationRoundtrip_Works(MediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MediaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
