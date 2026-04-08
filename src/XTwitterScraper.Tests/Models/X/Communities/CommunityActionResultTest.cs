using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityActionResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CommunityActionResult
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        string expectedCommunityID = "1500000000000000000";
        string expectedCommunityName = "Tesla Fans";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.Equal(expectedCommunityID, model.CommunityID);
        Assert.Equal(expectedCommunityName, model.CommunityName);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CommunityActionResult
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityActionResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CommunityActionResult
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityActionResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCommunityID = "1500000000000000000";
        string expectedCommunityName = "Tesla Fans";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.Equal(expectedCommunityID, deserialized.CommunityID);
        Assert.Equal(expectedCommunityName, deserialized.CommunityName);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CommunityActionResult
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CommunityActionResult
        {
            CommunityID = "1500000000000000000",
            CommunityName = "Tesla Fans",
        };

        CommunityActionResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
