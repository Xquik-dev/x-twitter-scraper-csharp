using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationSendTestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationSendTestResponse { };

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationSendTestResponse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationSendTestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationSendTestResponse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationSendTestResponse>(
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
        var model = new IntegrationSendTestResponse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationSendTestResponse { };

        IntegrationSendTestResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
