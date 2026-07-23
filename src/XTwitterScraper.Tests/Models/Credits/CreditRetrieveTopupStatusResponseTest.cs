using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Tests.Models.Credits;

public class CreditRetrieveTopupStatusResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,
            Credits = "166666",
        };

        ApiEnum<string, Status> expectedStatus = Status.Paid;
        long expectedAmountDollars = 25;
        string expectedCredits = "166666";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAmountDollars, model.AmountDollars);
        Assert.Equal(expectedCredits, model.Credits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,
            Credits = "166666",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditRetrieveTopupStatusResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,
            Credits = "166666",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditRetrieveTopupStatusResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.Paid;
        long expectedAmountDollars = 25;
        string expectedCredits = "166666";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAmountDollars, deserialized.AmountDollars);
        Assert.Equal(expectedCredits, deserialized.Credits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,
            Credits = "166666",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,
        };

        Assert.Null(model.Credits);
        Assert.False(model.RawData.ContainsKey("credits"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,

            // Null should be interpreted as omitted for these properties
            Credits = null,
        };

        Assert.Null(model.Credits);
        Assert.False(model.RawData.ContainsKey("credits"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,

            // Null should be interpreted as omitted for these properties
            Credits = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            Credits = "166666",
        };

        Assert.Null(model.AmountDollars);
        Assert.False(model.RawData.ContainsKey("amount_dollars"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            Credits = "166666",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            Credits = "166666",

            AmountDollars = null,
        };

        Assert.Null(model.AmountDollars);
        Assert.True(model.RawData.ContainsKey("amount_dollars"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            Credits = "166666",

            AmountDollars = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditRetrieveTopupStatusResponse
        {
            Status = Status.Paid,
            AmountDollars = 25,
            Credits = "166666",
        };

        CreditRetrieveTopupStatusResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Paid)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Expired)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Paid)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Expired)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
