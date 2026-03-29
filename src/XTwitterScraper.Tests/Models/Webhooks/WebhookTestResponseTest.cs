using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookTestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookTestResponse
        {
            StatusCode = 0,
            Success = true,
            Error = "error",
        };

        long expectedStatusCode = 0;
        bool expectedSuccess = true;
        string expectedError = "error";

        Assert.Equal(expectedStatusCode, model.StatusCode);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookTestResponse
        {
            StatusCode = 0,
            Success = true,
            Error = "error",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookTestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookTestResponse
        {
            StatusCode = 0,
            Success = true,
            Error = "error",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookTestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedStatusCode = 0;
        bool expectedSuccess = true;
        string expectedError = "error";

        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookTestResponse
        {
            StatusCode = 0,
            Success = true,
            Error = "error",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookTestResponse { StatusCode = 0, Success = true };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookTestResponse { StatusCode = 0, Success = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookTestResponse
        {
            StatusCode = 0,
            Success = true,

            // Null should be interpreted as omitted for these properties
            Error = null,
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookTestResponse
        {
            StatusCode = 0,
            Success = true,

            // Null should be interpreted as omitted for these properties
            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookTestResponse
        {
            StatusCode = 0,
            Success = true,
            Error = "error",
        };

        WebhookTestResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
