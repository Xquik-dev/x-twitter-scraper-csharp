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
            Body = new ComposePrepareRequest()
            {
                Topic = "PostgreSQL query planning",
                Goal = Goal.Engagement,
                StyleUsername = "x",
            },
        };

        Body expectedBody = new ComposePrepareRequest()
        {
            Topic = "PostgreSQL query planning",
            Goal = Goal.Engagement,
            StyleUsername = "x",
        };

        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        ComposeCreateParams parameters = new()
        {
            Body = new ComposePrepareRequest()
            {
                Topic = "PostgreSQL query planning",
                Goal = Goal.Engagement,
                StyleUsername = "x",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/compose"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ComposeCreateParams
        {
            Body = new ComposePrepareRequest()
            {
                Topic = "PostgreSQL query planning",
                Goal = Goal.Engagement,
                StyleUsername = "x",
            },
        };

        ComposeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void ComposePrepareRequestValidationWorks()
    {
        Body value = new ComposePrepareRequest()
        {
            Topic = "PostgreSQL query planning",
            Goal = Goal.Engagement,
            StyleUsername = "x",
        };
        value.Validate();
    }

    [Fact]
    public void ComposeRefineRequestValidationWorks()
    {
        Body value = new ComposeRefineRequest()
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
            AdditionalContext = "x",
            CallToAction = "x",
            MediaType = MediaType.Photo,
        };
        value.Validate();
    }

    [Fact]
    public void ComposeScoreRequestValidationWorks()
    {
        Body value = new ComposeScoreRequest()
        {
            Draft = "x",
            HasLink = true,
            HasMedia = true,
        };
        value.Validate();
    }

    [Fact]
    public void ComposePrepareRequestSerializationRoundtripWorks()
    {
        Body value = new ComposePrepareRequest()
        {
            Topic = "PostgreSQL query planning",
            Goal = Goal.Engagement,
            StyleUsername = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComposeRefineRequestSerializationRoundtripWorks()
    {
        Body value = new ComposeRefineRequest()
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
            AdditionalContext = "x",
            CallToAction = "x",
            MediaType = MediaType.Photo,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComposeScoreRequestSerializationRoundtripWorks()
    {
        Body value = new ComposeScoreRequest()
        {
            Draft = "x",
            HasLink = true,
            HasMedia = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ComposePrepareRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComposePrepareRequest
        {
            Topic = "PostgreSQL query planning",
            Goal = Goal.Engagement,
            StyleUsername = "x",
        };

        JsonElement expectedStep = JsonSerializer.SerializeToElement("compose");
        string expectedTopic = "PostgreSQL query planning";
        ApiEnum<string, Goal> expectedGoal = Goal.Engagement;
        string expectedStyleUsername = "x";

        Assert.True(JsonElement.DeepEquals(expectedStep, model.Step));
        Assert.Equal(expectedTopic, model.Topic);
        Assert.Equal(expectedGoal, model.Goal);
        Assert.Equal(expectedStyleUsername, model.StyleUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComposePrepareRequest
        {
            Topic = "PostgreSQL query planning",
            Goal = Goal.Engagement,
            StyleUsername = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposePrepareRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComposePrepareRequest
        {
            Topic = "PostgreSQL query planning",
            Goal = Goal.Engagement,
            StyleUsername = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposePrepareRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedStep = JsonSerializer.SerializeToElement("compose");
        string expectedTopic = "PostgreSQL query planning";
        ApiEnum<string, Goal> expectedGoal = Goal.Engagement;
        string expectedStyleUsername = "x";

        Assert.True(JsonElement.DeepEquals(expectedStep, deserialized.Step));
        Assert.Equal(expectedTopic, deserialized.Topic);
        Assert.Equal(expectedGoal, deserialized.Goal);
        Assert.Equal(expectedStyleUsername, deserialized.StyleUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComposePrepareRequest
        {
            Topic = "PostgreSQL query planning",
            Goal = Goal.Engagement,
            StyleUsername = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComposePrepareRequest { Topic = "PostgreSQL query planning" };

        Assert.Null(model.Goal);
        Assert.False(model.RawData.ContainsKey("goal"));
        Assert.Null(model.StyleUsername);
        Assert.False(model.RawData.ContainsKey("styleUsername"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComposePrepareRequest { Topic = "PostgreSQL query planning" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComposePrepareRequest
        {
            Topic = "PostgreSQL query planning",

            // Null should be interpreted as omitted for these properties
            Goal = null,
            StyleUsername = null,
        };

        Assert.Null(model.Goal);
        Assert.False(model.RawData.ContainsKey("goal"));
        Assert.Null(model.StyleUsername);
        Assert.False(model.RawData.ContainsKey("styleUsername"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComposePrepareRequest
        {
            Topic = "PostgreSQL query planning",

            // Null should be interpreted as omitted for these properties
            Goal = null,
            StyleUsername = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComposePrepareRequest
        {
            Topic = "PostgreSQL query planning",
            Goal = Goal.Engagement,
            StyleUsername = "x",
        };

        ComposePrepareRequest copied = new(model);

        Assert.Equal(model, copied);
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

public class ComposeRefineRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
            AdditionalContext = "x",
            CallToAction = "x",
            MediaType = MediaType.Photo,
        };

        ApiEnum<string, ComposeRefineRequestGoal> expectedGoal =
            ComposeRefineRequestGoal.Engagement;
        JsonElement expectedStep = JsonSerializer.SerializeToElement("refine");
        string expectedTone = "professional";
        string expectedTopic = "x";
        string expectedAdditionalContext = "x";
        string expectedCallToAction = "x";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.Photo;

        Assert.Equal(expectedGoal, model.Goal);
        Assert.True(JsonElement.DeepEquals(expectedStep, model.Step));
        Assert.Equal(expectedTone, model.Tone);
        Assert.Equal(expectedTopic, model.Topic);
        Assert.Equal(expectedAdditionalContext, model.AdditionalContext);
        Assert.Equal(expectedCallToAction, model.CallToAction);
        Assert.Equal(expectedMediaType, model.MediaType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
            AdditionalContext = "x",
            CallToAction = "x",
            MediaType = MediaType.Photo,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeRefineRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
            AdditionalContext = "x",
            CallToAction = "x",
            MediaType = MediaType.Photo,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeRefineRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ComposeRefineRequestGoal> expectedGoal =
            ComposeRefineRequestGoal.Engagement;
        JsonElement expectedStep = JsonSerializer.SerializeToElement("refine");
        string expectedTone = "professional";
        string expectedTopic = "x";
        string expectedAdditionalContext = "x";
        string expectedCallToAction = "x";
        ApiEnum<string, MediaType> expectedMediaType = MediaType.Photo;

        Assert.Equal(expectedGoal, deserialized.Goal);
        Assert.True(JsonElement.DeepEquals(expectedStep, deserialized.Step));
        Assert.Equal(expectedTone, deserialized.Tone);
        Assert.Equal(expectedTopic, deserialized.Topic);
        Assert.Equal(expectedAdditionalContext, deserialized.AdditionalContext);
        Assert.Equal(expectedCallToAction, deserialized.CallToAction);
        Assert.Equal(expectedMediaType, deserialized.MediaType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
            AdditionalContext = "x",
            CallToAction = "x",
            MediaType = MediaType.Photo,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
        };

        Assert.Null(model.AdditionalContext);
        Assert.False(model.RawData.ContainsKey("additionalContext"));
        Assert.Null(model.CallToAction);
        Assert.False(model.RawData.ContainsKey("callToAction"));
        Assert.Null(model.MediaType);
        Assert.False(model.RawData.ContainsKey("mediaType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",

            // Null should be interpreted as omitted for these properties
            AdditionalContext = null,
            CallToAction = null,
            MediaType = null,
        };

        Assert.Null(model.AdditionalContext);
        Assert.False(model.RawData.ContainsKey("additionalContext"));
        Assert.Null(model.CallToAction);
        Assert.False(model.RawData.ContainsKey("callToAction"));
        Assert.Null(model.MediaType);
        Assert.False(model.RawData.ContainsKey("mediaType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",

            // Null should be interpreted as omitted for these properties
            AdditionalContext = null,
            CallToAction = null,
            MediaType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComposeRefineRequest
        {
            Goal = ComposeRefineRequestGoal.Engagement,
            Tone = "professional",
            Topic = "x",
            AdditionalContext = "x",
            CallToAction = "x",
            MediaType = MediaType.Photo,
        };

        ComposeRefineRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComposeRefineRequestGoalTest : TestBase
{
    [Theory]
    [InlineData(ComposeRefineRequestGoal.Engagement)]
    [InlineData(ComposeRefineRequestGoal.Followers)]
    [InlineData(ComposeRefineRequestGoal.Authority)]
    [InlineData(ComposeRefineRequestGoal.Conversation)]
    public void Validation_Works(ComposeRefineRequestGoal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComposeRefineRequestGoal> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComposeRefineRequestGoal>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ComposeRefineRequestGoal.Engagement)]
    [InlineData(ComposeRefineRequestGoal.Followers)]
    [InlineData(ComposeRefineRequestGoal.Authority)]
    [InlineData(ComposeRefineRequestGoal.Conversation)]
    public void SerializationRoundtrip_Works(ComposeRefineRequestGoal rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComposeRefineRequestGoal> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComposeRefineRequestGoal>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComposeRefineRequestGoal>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComposeRefineRequestGoal>>(
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

public class ComposeScoreRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComposeScoreRequest
        {
            Draft = "x",
            HasLink = true,
            HasMedia = true,
        };

        string expectedDraft = "x";
        JsonElement expectedStep = JsonSerializer.SerializeToElement("score");
        bool expectedHasLink = true;
        bool expectedHasMedia = true;

        Assert.Equal(expectedDraft, model.Draft);
        Assert.True(JsonElement.DeepEquals(expectedStep, model.Step));
        Assert.Equal(expectedHasLink, model.HasLink);
        Assert.Equal(expectedHasMedia, model.HasMedia);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComposeScoreRequest
        {
            Draft = "x",
            HasLink = true,
            HasMedia = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeScoreRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComposeScoreRequest
        {
            Draft = "x",
            HasLink = true,
            HasMedia = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeScoreRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDraft = "x";
        JsonElement expectedStep = JsonSerializer.SerializeToElement("score");
        bool expectedHasLink = true;
        bool expectedHasMedia = true;

        Assert.Equal(expectedDraft, deserialized.Draft);
        Assert.True(JsonElement.DeepEquals(expectedStep, deserialized.Step));
        Assert.Equal(expectedHasLink, deserialized.HasLink);
        Assert.Equal(expectedHasMedia, deserialized.HasMedia);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComposeScoreRequest
        {
            Draft = "x",
            HasLink = true,
            HasMedia = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComposeScoreRequest { Draft = "x" };

        Assert.Null(model.HasLink);
        Assert.False(model.RawData.ContainsKey("hasLink"));
        Assert.Null(model.HasMedia);
        Assert.False(model.RawData.ContainsKey("hasMedia"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComposeScoreRequest { Draft = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComposeScoreRequest
        {
            Draft = "x",

            // Null should be interpreted as omitted for these properties
            HasLink = null,
            HasMedia = null,
        };

        Assert.Null(model.HasLink);
        Assert.False(model.RawData.ContainsKey("hasLink"));
        Assert.Null(model.HasMedia);
        Assert.False(model.RawData.ContainsKey("hasMedia"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComposeScoreRequest
        {
            Draft = "x",

            // Null should be interpreted as omitted for these properties
            HasLink = null,
            HasMedia = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComposeScoreRequest
        {
            Draft = "x",
            HasLink = true,
            HasMedia = true,
        };

        ComposeScoreRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
