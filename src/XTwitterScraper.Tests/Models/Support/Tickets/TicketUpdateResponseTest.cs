using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Support.Tickets;

namespace XTwitterScraper.Tests.Models.Support.Tickets;

public class TicketUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketUpdateResponse
        {
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketUpdateResponseStatus.Resolved,
        };

        string expectedPublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, TicketUpdateResponseStatus> expectedStatus =
            TicketUpdateResponseStatus.Resolved;

        Assert.Equal(expectedPublicID, model.PublicID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketUpdateResponse
        {
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketUpdateResponseStatus.Resolved,
        };

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
        var model = new TicketUpdateResponse
        {
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketUpdateResponseStatus.Resolved,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6";
        ApiEnum<string, TicketUpdateResponseStatus> expectedStatus =
            TicketUpdateResponseStatus.Resolved;

        Assert.Equal(expectedPublicID, deserialized.PublicID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketUpdateResponse
        {
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketUpdateResponseStatus.Resolved,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketUpdateResponse
        {
            PublicID = "tkt_a1b2c3d4e5f6a1b2c3d4e5f6",
            Status = TicketUpdateResponseStatus.Resolved,
        };

        TicketUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TicketUpdateResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(TicketUpdateResponseStatus.Open)]
    [InlineData(TicketUpdateResponseStatus.Resolved)]
    [InlineData(TicketUpdateResponseStatus.Closed)]
    public void Validation_Works(TicketUpdateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketUpdateResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TicketUpdateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TicketUpdateResponseStatus.Open)]
    [InlineData(TicketUpdateResponseStatus.Resolved)]
    [InlineData(TicketUpdateResponseStatus.Closed)]
    public void SerializationRoundtrip_Works(TicketUpdateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketUpdateResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TicketUpdateResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TicketUpdateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TicketUpdateResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
