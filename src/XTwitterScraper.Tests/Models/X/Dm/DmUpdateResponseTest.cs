using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Dm;

namespace XTwitterScraper.Tests.Models.X.Dm;

public class DmUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DmUpdateResponse { MessageID = "messageId" };

        string expectedMessageID = "messageId";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DmUpdateResponse { MessageID = "messageId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DmUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DmUpdateResponse { MessageID = "messageId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DmUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessageID = "messageId";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DmUpdateResponse { MessageID = "messageId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DmUpdateResponse { MessageID = "messageId" };

        DmUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
