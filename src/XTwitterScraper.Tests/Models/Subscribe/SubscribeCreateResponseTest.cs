using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.Subscribe;

namespace XTwitterScraper.Tests.Models.Subscribe;

public class SubscribeCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Url = "https://example.com",
            Message = "message",
            Status = Status.CheckoutCreated,
        };

        string expectedUrl = "https://example.com";
        string expectedMessage = "message";
        ApiEnum<string, Status> expectedStatus = Status.CheckoutCreated;

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Url = "https://example.com",
            Message = "message",
            Status = Status.CheckoutCreated,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscribeCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Url = "https://example.com",
            Message = "message",
            Status = Status.CheckoutCreated,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscribeCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUrl = "https://example.com";
        string expectedMessage = "message";
        ApiEnum<string, Status> expectedStatus = Status.CheckoutCreated;

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Url = "https://example.com",
            Message = "message",
            Status = Status.CheckoutCreated,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscribeCreateResponse { Url = "https://example.com" };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscribeCreateResponse { Url = "https://example.com" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Message = null,
            Status = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Message = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscribeCreateResponse
        {
            Url = "https://example.com",
            Message = "message",
            Status = Status.CheckoutCreated,
        };

        SubscribeCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.CheckoutCreated)]
    [InlineData(Status.AlreadySubscribed)]
    [InlineData(Status.PaymentIssue)]
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
    [InlineData(Status.CheckoutCreated)]
    [InlineData(Status.AlreadySubscribed)]
    [InlineData(Status.PaymentIssue)]
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
