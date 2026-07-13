using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",
            WriteActionID = "42",
        };

        bool expectedCharged = true;
        string expectedChargedCredits = "32";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedTweetID = "1234567890";
        string expectedWriteActionID = "42";

        Assert.Equal(expectedCharged, model.Charged);
        Assert.Equal(expectedChargedCredits, model.ChargedCredits);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
        Assert.Equal(expectedTweetID, model.TweetID);
        Assert.Equal(expectedWriteActionID, model.WriteActionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",
            WriteActionID = "42",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",
            WriteActionID = "42",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCharged = true;
        string expectedChargedCredits = "32";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedTweetID = "1234567890";
        string expectedWriteActionID = "42";

        Assert.Equal(expectedCharged, deserialized.Charged);
        Assert.Equal(expectedChargedCredits, deserialized.ChargedCredits);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
        Assert.Equal(expectedTweetID, deserialized.TweetID);
        Assert.Equal(expectedWriteActionID, deserialized.WriteActionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",
            WriteActionID = "42",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",
        };

        Assert.Null(model.WriteActionID);
        Assert.False(model.RawData.ContainsKey("writeActionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",

            // Null should be interpreted as omitted for these properties
            WriteActionID = null,
        };

        Assert.Null(model.WriteActionID);
        Assert.False(model.RawData.ContainsKey("writeActionId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",

            // Null should be interpreted as omitted for these properties
            WriteActionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetCreateResponse
        {
            Charged = true,
            ChargedCredits = "32",
            TweetID = "1234567890",
            WriteActionID = "42",
        };

        TweetCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
