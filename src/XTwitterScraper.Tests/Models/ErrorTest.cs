using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error { ErrorValue = ErrorError.InvalidInput };

        ApiEnum<string, ErrorError> expectedErrorValue = ErrorError.InvalidInput;

        Assert.Equal(expectedErrorValue, model.ErrorValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error { ErrorValue = ErrorError.InvalidInput };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error { ErrorValue = ErrorError.InvalidInput };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, ErrorError> expectedErrorValue = ErrorError.InvalidInput;

        Assert.Equal(expectedErrorValue, deserialized.ErrorValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error { ErrorValue = ErrorError.InvalidInput };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error { ErrorValue = ErrorError.InvalidInput };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorErrorTest : TestBase
{
    [Theory]
    [InlineData(ErrorError.InternalError)]
    [InlineData(ErrorError.InvalidFormat)]
    [InlineData(ErrorError.InvalidID)]
    [InlineData(ErrorError.InvalidInput)]
    [InlineData(ErrorError.InvalidParams)]
    [InlineData(ErrorError.InvalidToolType)]
    [InlineData(ErrorError.InvalidTweetID)]
    [InlineData(ErrorError.InvalidTweetUrl)]
    [InlineData(ErrorError.InvalidUsername)]
    [InlineData(ErrorError.InsufficientCredits)]
    [InlineData(ErrorError.MissingParams)]
    [InlineData(ErrorError.MissingQuery)]
    [InlineData(ErrorError.MonitorAlreadyExists)]
    [InlineData(ErrorError.MonitorLimitReached)]
    [InlineData(ErrorError.NoCredits)]
    [InlineData(ErrorError.NoSubscription)]
    [InlineData(ErrorError.NotFound)]
    [InlineData(ErrorError.SubscriptionInactive)]
    [InlineData(ErrorError.TweetNotFound)]
    [InlineData(ErrorError.Unauthenticated)]
    [InlineData(ErrorError.UserNotFound)]
    [InlineData(ErrorError.WebhookInactive)]
    [InlineData(ErrorError.XApiRateLimited)]
    [InlineData(ErrorError.XApiUnavailable)]
    [InlineData(ErrorError.XApiUnauthorized)]
    public void Validation_Works(ErrorError rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorError> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorError>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ErrorError.InternalError)]
    [InlineData(ErrorError.InvalidFormat)]
    [InlineData(ErrorError.InvalidID)]
    [InlineData(ErrorError.InvalidInput)]
    [InlineData(ErrorError.InvalidParams)]
    [InlineData(ErrorError.InvalidToolType)]
    [InlineData(ErrorError.InvalidTweetID)]
    [InlineData(ErrorError.InvalidTweetUrl)]
    [InlineData(ErrorError.InvalidUsername)]
    [InlineData(ErrorError.InsufficientCredits)]
    [InlineData(ErrorError.MissingParams)]
    [InlineData(ErrorError.MissingQuery)]
    [InlineData(ErrorError.MonitorAlreadyExists)]
    [InlineData(ErrorError.MonitorLimitReached)]
    [InlineData(ErrorError.NoCredits)]
    [InlineData(ErrorError.NoSubscription)]
    [InlineData(ErrorError.NotFound)]
    [InlineData(ErrorError.SubscriptionInactive)]
    [InlineData(ErrorError.TweetNotFound)]
    [InlineData(ErrorError.Unauthenticated)]
    [InlineData(ErrorError.UserNotFound)]
    [InlineData(ErrorError.WebhookInactive)]
    [InlineData(ErrorError.XApiRateLimited)]
    [InlineData(ErrorError.XApiUnavailable)]
    [InlineData(ErrorError.XApiUnauthorized)]
    public void SerializationRoundtrip_Works(ErrorError rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorError> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorError>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorError>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorError>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
