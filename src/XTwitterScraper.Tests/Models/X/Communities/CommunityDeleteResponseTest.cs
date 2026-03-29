using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CommunityDeleteResponse { };

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CommunityDeleteResponse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CommunityDeleteResponse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CommunityDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CommunityDeleteResponse { };

        CommunityDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
