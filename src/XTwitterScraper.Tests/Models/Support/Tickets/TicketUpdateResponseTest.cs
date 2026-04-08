using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketUpdateResponse { PublicID = "tk_abc123", Status = "resolved" };

        string expectedPublicID = "tk_abc123";
        string expectedStatus = "resolved";

        Assert.Equal(expectedPublicID, model.PublicID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketUpdateResponse { PublicID = "tk_abc123", Status = "resolved" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketUpdateResponse { PublicID = "tk_abc123", Status = "resolved" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPublicID = "tk_abc123";
        string expectedStatus = "resolved";

        Assert.Equal(expectedPublicID, deserialized.PublicID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketUpdateResponse { PublicID = "tk_abc123", Status = "resolved" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TicketUpdateResponse { };

        Assert.Null(model.PublicID);
        Assert.False(model.RawData.ContainsKey("publicId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TicketUpdateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TicketUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            PublicID = null,
            Status = null,
        };

        Assert.Null(model.PublicID);
        Assert.False(model.RawData.ContainsKey("publicId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TicketUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            PublicID = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketUpdateResponse { PublicID = "tk_abc123", Status = "resolved" };

        TicketUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
