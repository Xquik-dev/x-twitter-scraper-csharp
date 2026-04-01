using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Compose;

namespace XTwitterScraper.Tests.Models.Compose;

public class ComposeCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComposeCreateResponse
        {
            Feedback = "feedback",
            Score = 0,
            Suggestions = ["string"],
            Text = "text",
        };

        string expectedFeedback = "feedback";
        double expectedScore = 0;
        List<string> expectedSuggestions = ["string"];
        string expectedText = "text";

        Assert.Equal(expectedFeedback, model.Feedback);
        Assert.Equal(expectedScore, model.Score);
        Assert.NotNull(model.Suggestions);
        Assert.Equal(expectedSuggestions.Count, model.Suggestions.Count);
        for (int i = 0; i < expectedSuggestions.Count; i++)
        {
            Assert.Equal(expectedSuggestions[i], model.Suggestions[i]);
        }
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComposeCreateResponse
        {
            Feedback = "feedback",
            Score = 0,
            Suggestions = ["string"],
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComposeCreateResponse
        {
            Feedback = "feedback",
            Score = 0,
            Suggestions = ["string"],
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComposeCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFeedback = "feedback";
        double expectedScore = 0;
        List<string> expectedSuggestions = ["string"];
        string expectedText = "text";

        Assert.Equal(expectedFeedback, deserialized.Feedback);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.NotNull(deserialized.Suggestions);
        Assert.Equal(expectedSuggestions.Count, deserialized.Suggestions.Count);
        for (int i = 0; i < expectedSuggestions.Count; i++)
        {
            Assert.Equal(expectedSuggestions[i], deserialized.Suggestions[i]);
        }
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComposeCreateResponse
        {
            Feedback = "feedback",
            Score = 0,
            Suggestions = ["string"],
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComposeCreateResponse { };

        Assert.Null(model.Feedback);
        Assert.False(model.RawData.ContainsKey("feedback"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Suggestions);
        Assert.False(model.RawData.ContainsKey("suggestions"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComposeCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComposeCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            Feedback = null,
            Score = null,
            Suggestions = null,
            Text = null,
        };

        Assert.Null(model.Feedback);
        Assert.False(model.RawData.ContainsKey("feedback"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Suggestions);
        Assert.False(model.RawData.ContainsKey("suggestions"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComposeCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            Feedback = null,
            Score = null,
            Suggestions = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComposeCreateResponse
        {
            Feedback = "feedback",
            Score = 0,
            Suggestions = ["string"],
            Text = "text",
        };

        ComposeCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
