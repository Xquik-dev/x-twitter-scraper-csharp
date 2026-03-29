using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Tests.Models.Bot.PlatformLinks;

public class PlatformLinkDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlatformLinkDeleteResponse { Success = true };

        bool expectedSuccess = true;

        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlatformLinkDeleteResponse { Success = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlatformLinkDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlatformLinkDeleteResponse { Success = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlatformLinkDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSuccess = true;

        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlatformLinkDeleteResponse { Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlatformLinkDeleteResponse { };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlatformLinkDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PlatformLinkDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            Success = null,
        };

        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlatformLinkDeleteResponse
        {
            // Null should be interpreted as omitted for these properties
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlatformLinkDeleteResponse { Success = true };

        PlatformLinkDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
