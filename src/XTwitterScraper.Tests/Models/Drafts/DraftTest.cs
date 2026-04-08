using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Drafts;

namespace XTwitterScraper.Tests.Models.Drafts;

public class DraftTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",
            Goal = "Engagement",
            Topic = "Technology",
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedText = "Draft tweet about AI trends";
        string expectedGoal = "Engagement";
        string expectedTopic = "Technology";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedGoal, model.Goal);
        Assert.Equal(expectedTopic, model.Topic);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",
            Goal = "Engagement",
            Topic = "Technology",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draft>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",
            Goal = "Engagement",
            Topic = "Technology",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draft>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        string expectedText = "Draft tweet about AI trends";
        string expectedGoal = "Engagement";
        string expectedTopic = "Technology";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedGoal, deserialized.Goal);
        Assert.Equal(expectedTopic, deserialized.Topic);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",
            Goal = "Engagement",
            Topic = "Technology",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",
        };

        Assert.Null(model.Goal);
        Assert.False(model.RawData.ContainsKey("goal"));
        Assert.Null(model.Topic);
        Assert.False(model.RawData.ContainsKey("topic"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",

            // Null should be interpreted as omitted for these properties
            Goal = null,
            Topic = null,
        };

        Assert.Null(model.Goal);
        Assert.False(model.RawData.ContainsKey("goal"));
        Assert.Null(model.Topic);
        Assert.False(model.RawData.ContainsKey("topic"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",

            // Null should be interpreted as omitted for these properties
            Goal = null,
            Topic = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Draft
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Text = "Draft tweet about AI trends",
            Goal = "Engagement",
            Topic = "Technology",
        };

        Draft copied = new(model);

        Assert.Equal(model, copied);
    }
}
