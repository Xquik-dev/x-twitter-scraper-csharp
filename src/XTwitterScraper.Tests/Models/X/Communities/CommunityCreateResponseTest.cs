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
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        string expectedCommunityID = "communityId";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedCommunityName = "communityName";

        Assert.Equal(expectedCommunityID, model.CommunityID);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
        Assert.Equal(expectedCommunityName, model.CommunityName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "communityId",
            CommunityName = "communityName",
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
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCommunityID = "communityId";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedCommunityName = "communityName";

        Assert.Equal(expectedCommunityID, deserialized.CommunityID);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
        Assert.Equal(expectedCommunityName, deserialized.CommunityName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CommunityCreateResponse { CommunityID = "communityId" };

        Assert.Null(model.CommunityName);
        Assert.False(model.RawData.ContainsKey("communityName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CommunityCreateResponse { CommunityID = "communityId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CommunityCreateResponse
        {
            CommunityID = "communityId",

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
            CommunityID = "communityId",

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
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        CommunityCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
