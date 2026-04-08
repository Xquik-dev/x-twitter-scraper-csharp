using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketCreateResponse { PublicID = "tk_abc123" };

        string expectedPublicID = "tk_abc123";

        Assert.Equal(expectedPublicID, model.PublicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketCreateResponse { PublicID = "tk_abc123" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketCreateResponse { PublicID = "tk_abc123" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPublicID = "tk_abc123";

        Assert.Equal(expectedPublicID, deserialized.PublicID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketCreateResponse { PublicID = "tk_abc123" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TicketCreateResponse { };

        Assert.Null(model.PublicID);
        Assert.False(model.RawData.ContainsKey("publicId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TicketCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TicketCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            PublicID = null,
        };

        Assert.Null(model.PublicID);
        Assert.False(model.RawData.ContainsKey("publicId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TicketCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            PublicID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketCreateResponse { PublicID = "tk_abc123" };

        TicketCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
