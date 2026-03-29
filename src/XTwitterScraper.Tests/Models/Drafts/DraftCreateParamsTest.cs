using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Drafts;

namespace XTwitterScraper.Tests.Models.Drafts;

public class DraftCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DraftCreateParams
        {
            Text = "text",
            Goal = Goal.Engagement,
            Topic = "topic",
        };

        string expectedText = "text";
        ApiEnum<string, Goal> expectedGoal = Goal.Engagement;
        string expectedTopic = "topic";

        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedGoal, parameters.Goal);
        Assert.Equal(expectedTopic, parameters.Topic);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DraftCreateParams { Text = "text" };

        Assert.Null(parameters.Goal);
        Assert.False(parameters.RawBodyData.ContainsKey("goal"));
        Assert.Null(parameters.Topic);
        Assert.False(parameters.RawBodyData.ContainsKey("topic"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DraftCreateParams
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Goal = null,
            Topic = null,
        };

        Assert.Null(parameters.Goal);
        Assert.False(parameters.RawBodyData.ContainsKey("goal"));
        Assert.Null(parameters.Topic);
        Assert.False(parameters.RawBodyData.ContainsKey("topic"));
    }

    [Fact]
    public void Url_Works()
    {
        DraftCreateParams parameters = new() { Text = "text" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/drafts"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DraftCreateParams
        {
            Text = "text",
            Goal = Goal.Engagement,
            Topic = "topic",
        };

        DraftCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
