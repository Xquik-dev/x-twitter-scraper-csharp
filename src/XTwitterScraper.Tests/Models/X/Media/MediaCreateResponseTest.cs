using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Tests.Models.X.Media;

public class MediaCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MediaCreateResponse { MediaID = "mediaId" };

        string expectedMediaID = "mediaId";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.Equal(expectedMediaID, model.MediaID);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MediaCreateResponse { MediaID = "mediaId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MediaCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MediaCreateResponse { MediaID = "mediaId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MediaCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaID = "mediaId";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.Equal(expectedMediaID, deserialized.MediaID);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MediaCreateResponse { MediaID = "mediaId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MediaCreateResponse { MediaID = "mediaId" };

        MediaCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
