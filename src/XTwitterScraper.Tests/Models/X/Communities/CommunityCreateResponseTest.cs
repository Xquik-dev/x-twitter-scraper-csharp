using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        string expectedCommunityID = "1500000000000000000";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedCommunityName = "Tesla Fans";

        Assert.Equal(expectedCommunityID, model.CommunityID);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
        Assert.Equal(expectedCommunityName, model.CommunityName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCommunityID = "1500000000000000000";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedCommunityName = "Tesla Fans";

        Assert.Equal(expectedCommunityID, deserialized.CommunityID);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
        Assert.Equal(expectedCommunityName, deserialized.CommunityName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CommunityCreateResponse { CommunityID = "1500000000000000000" };

        Assert.Null(model.CommunityName);
        Assert.False(model.RawData.ContainsKey("communityName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CommunityCreateResponse { CommunityID = "1500000000000000000" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "1500000000000000000",

            // Null should be interpreted as omitted for these properties
            CommunityName = null,
        };

        Assert.Null(model.CommunityName);
        Assert.False(model.RawData.ContainsKey("communityName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "1500000000000000000",

            // Null should be interpreted as omitted for these properties
            CommunityName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        CommunityCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
