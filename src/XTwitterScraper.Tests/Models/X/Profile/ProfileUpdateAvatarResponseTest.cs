using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Tests.Models.X.Profile;

public class ProfileUpdateAvatarResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileUpdateAvatarResponse { };

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileUpdateAvatarResponse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateAvatarResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileUpdateAvatarResponse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProfileUpdateAvatarResponse>(
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
        var model = new ProfileUpdateAvatarResponse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProfileUpdateAvatarResponse { };

        ProfileUpdateAvatarResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
