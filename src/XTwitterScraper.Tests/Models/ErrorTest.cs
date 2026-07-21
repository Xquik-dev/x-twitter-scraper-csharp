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
        var model = new Error
        {
            ErrorValue = LegacyErrorCode.InvalidInput,
            Message = "message",
            Reason = "reason",
            RetryAfter = 1,
            RetryAfterMs = 1,
        };

        ErrorError expectedErrorValue = LegacyErrorCode.InvalidInput;
        string expectedMessage = "message";
        string expectedReason = "reason";
        long expectedRetryAfter = 1;
        long expectedRetryAfterMs = 1;

        Assert.Equal(expectedErrorValue, model.ErrorValue);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRetryAfter, model.RetryAfter);
        Assert.Equal(expectedRetryAfterMs, model.RetryAfterMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error
        {
            ErrorValue = LegacyErrorCode.InvalidInput,
            Message = "message",
            Reason = "reason",
            RetryAfter = 1,
            RetryAfterMs = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error
        {
            ErrorValue = LegacyErrorCode.InvalidInput,
            Message = "message",
            Reason = "reason",
            RetryAfter = 1,
            RetryAfterMs = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ErrorError expectedErrorValue = LegacyErrorCode.InvalidInput;
        string expectedMessage = "message";
        string expectedReason = "reason";
        long expectedRetryAfter = 1;
        long expectedRetryAfterMs = 1;

        Assert.Equal(expectedErrorValue, deserialized.ErrorValue);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRetryAfter, deserialized.RetryAfter);
        Assert.Equal(expectedRetryAfterMs, deserialized.RetryAfterMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error
        {
            ErrorValue = LegacyErrorCode.InvalidInput,
            Message = "message",
            Reason = "reason",
            RetryAfter = 1,
            RetryAfterMs = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Error { ErrorValue = LegacyErrorCode.InvalidInput };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RetryAfter);
        Assert.False(model.RawData.ContainsKey("retryAfter"));
        Assert.Null(model.RetryAfterMs);
        Assert.False(model.RawData.ContainsKey("retryAfterMs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Error { ErrorValue = LegacyErrorCode.InvalidInput };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Error
        {
            ErrorValue = LegacyErrorCode.InvalidInput,

            // Null should be interpreted as omitted for these properties
            Message = null,
            Reason = null,
            RetryAfter = null,
            RetryAfterMs = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.RetryAfter);
        Assert.False(model.RawData.ContainsKey("retryAfter"));
        Assert.Null(model.RetryAfterMs);
        Assert.False(model.RawData.ContainsKey("retryAfterMs"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Error
        {
            ErrorValue = LegacyErrorCode.InvalidInput,

            // Null should be interpreted as omitted for these properties
            Message = null,
            Reason = null,
            RetryAfter = null,
            RetryAfterMs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error
        {
            ErrorValue = LegacyErrorCode.InvalidInput,
            Message = "message",
            Reason = "reason",
            RetryAfter = 1,
            RetryAfterMs = 1,
        };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorErrorTest : TestBase
{
    [Fact]
    public void LegacyErrorCodeValidationWorks()
    {
        ErrorError value = LegacyErrorCode.InvalidInput;
        value.Validate();
    }

    [Fact]
    public void StructuredValidationWorks()
    {
        ErrorError value = new StructuredError()
        {
            Code = Code.InvalidInput,
            Message = "Invalid input. Check the request body.",
            Type = Type.InvalidRequestError,
        };
        value.Validate();
    }

    [Fact]
    public void LegacyErrorCodeSerializationRoundtripWorks()
    {
        ErrorError value = LegacyErrorCode.InvalidInput;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StructuredSerializationRoundtripWorks()
    {
        ErrorError value = new StructuredError()
        {
            Code = Code.InvalidInput,
            Message = "Invalid input. Check the request body.",
            Type = Type.InvalidRequestError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorError>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LegacyErrorCodeTest : TestBase
{
    [Theory]
    [InlineData(LegacyErrorCode.InternalError)]
    [InlineData(LegacyErrorCode.AccountAlreadyConnected)]
    [InlineData(LegacyErrorCode.AccountNeedsReauth)]
    [InlineData(LegacyErrorCode.AccountNotFound)]
    [InlineData(LegacyErrorCode.AccountRequired)]
    [InlineData(LegacyErrorCode.AccountRestricted)]
    [InlineData(LegacyErrorCode.ApiKeyLimitReached)]
    [InlineData(LegacyErrorCode.ArticleNotFound)]
    [InlineData(LegacyErrorCode.DmNotPermitted)]
    [InlineData(LegacyErrorCode.InvalidFormat)]
    [InlineData(LegacyErrorCode.InvalidID)]
    [InlineData(LegacyErrorCode.InvalidInput)]
    [InlineData(LegacyErrorCode.InvalidParams)]
    [InlineData(LegacyErrorCode.InvalidToolType)]
    [InlineData(LegacyErrorCode.InvalidTweetID)]
    [InlineData(LegacyErrorCode.InvalidTweetUrl)]
    [InlineData(LegacyErrorCode.InvalidUserID)]
    [InlineData(LegacyErrorCode.InvalidUserIds)]
    [InlineData(LegacyErrorCode.InvalidUsername)]
    [InlineData(LegacyErrorCode.InvalidJson)]
    [InlineData(LegacyErrorCode.InsufficientCredits)]
    [InlineData(LegacyErrorCode.LoginCooldown)]
    [InlineData(LegacyErrorCode.LoginFailed)]
    [InlineData(LegacyErrorCode.MediaDownloadFailed)]
    [InlineData(LegacyErrorCode.MissingParams)]
    [InlineData(LegacyErrorCode.MissingQuery)]
    [InlineData(LegacyErrorCode.MonitorAlreadyExists)]
    [InlineData(LegacyErrorCode.NoMedia)]
    [InlineData(LegacyErrorCode.NoCredits)]
    [InlineData(LegacyErrorCode.NoSubscription)]
    [InlineData(LegacyErrorCode.NotFound)]
    [InlineData(LegacyErrorCode.PaymentFailed)]
    [InlineData(LegacyErrorCode.RateLimitExceeded)]
    [InlineData(LegacyErrorCode.ServiceUnavailable)]
    [InlineData(LegacyErrorCode.StyleNotFound)]
    [InlineData(LegacyErrorCode.SubscriptionInactive)]
    [InlineData(LegacyErrorCode.TweetNotFound)]
    [InlineData(LegacyErrorCode.Unauthenticated)]
    [InlineData(LegacyErrorCode.UnsupportedField)]
    [InlineData(LegacyErrorCode.UserNotFound)]
    [InlineData(LegacyErrorCode.XAccountFeatureRequired)]
    [InlineData(LegacyErrorCode.XAccountProtected)]
    [InlineData(LegacyErrorCode.XAccountSuspended)]
    [InlineData(LegacyErrorCode.XApiRateLimited)]
    [InlineData(LegacyErrorCode.XApiUnavailable)]
    [InlineData(LegacyErrorCode.XApiUnauthorized)]
    [InlineData(LegacyErrorCode.XAuthFailure)]
    [InlineData(LegacyErrorCode.XContentTooLong)]
    [InlineData(LegacyErrorCode.XDailyLimit)]
    [InlineData(LegacyErrorCode.XDmNotAllowed)]
    [InlineData(LegacyErrorCode.XDuplicateAction)]
    [InlineData(LegacyErrorCode.XLoginAuthFailed)]
    [InlineData(LegacyErrorCode.XLoginChallenge)]
    [InlineData(LegacyErrorCode.XLoginDenied)]
    [InlineData(LegacyErrorCode.XLoginFailed)]
    [InlineData(LegacyErrorCode.XLoginProxyError)]
    [InlineData(LegacyErrorCode.XLoginRateLimited)]
    [InlineData(LegacyErrorCode.XLoginServiceUnavailable)]
    [InlineData(LegacyErrorCode.XLoginSuspended)]
    [InlineData(LegacyErrorCode.XRateLimited)]
    [InlineData(LegacyErrorCode.XRejected)]
    [InlineData(LegacyErrorCode.XTargetNotFound)]
    [InlineData(LegacyErrorCode.XTransientError)]
    [InlineData(LegacyErrorCode.XUserLookupFailed)]
    [InlineData(LegacyErrorCode.XWriteAmbiguous)]
    [InlineData(LegacyErrorCode.XWriteFailed)]
    public void Validation_Works(LegacyErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LegacyErrorCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LegacyErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LegacyErrorCode.InternalError)]
    [InlineData(LegacyErrorCode.AccountAlreadyConnected)]
    [InlineData(LegacyErrorCode.AccountNeedsReauth)]
    [InlineData(LegacyErrorCode.AccountNotFound)]
    [InlineData(LegacyErrorCode.AccountRequired)]
    [InlineData(LegacyErrorCode.AccountRestricted)]
    [InlineData(LegacyErrorCode.ApiKeyLimitReached)]
    [InlineData(LegacyErrorCode.ArticleNotFound)]
    [InlineData(LegacyErrorCode.DmNotPermitted)]
    [InlineData(LegacyErrorCode.InvalidFormat)]
    [InlineData(LegacyErrorCode.InvalidID)]
    [InlineData(LegacyErrorCode.InvalidInput)]
    [InlineData(LegacyErrorCode.InvalidParams)]
    [InlineData(LegacyErrorCode.InvalidToolType)]
    [InlineData(LegacyErrorCode.InvalidTweetID)]
    [InlineData(LegacyErrorCode.InvalidTweetUrl)]
    [InlineData(LegacyErrorCode.InvalidUserID)]
    [InlineData(LegacyErrorCode.InvalidUserIds)]
    [InlineData(LegacyErrorCode.InvalidUsername)]
    [InlineData(LegacyErrorCode.InvalidJson)]
    [InlineData(LegacyErrorCode.InsufficientCredits)]
    [InlineData(LegacyErrorCode.LoginCooldown)]
    [InlineData(LegacyErrorCode.LoginFailed)]
    [InlineData(LegacyErrorCode.MediaDownloadFailed)]
    [InlineData(LegacyErrorCode.MissingParams)]
    [InlineData(LegacyErrorCode.MissingQuery)]
    [InlineData(LegacyErrorCode.MonitorAlreadyExists)]
    [InlineData(LegacyErrorCode.NoMedia)]
    [InlineData(LegacyErrorCode.NoCredits)]
    [InlineData(LegacyErrorCode.NoSubscription)]
    [InlineData(LegacyErrorCode.NotFound)]
    [InlineData(LegacyErrorCode.PaymentFailed)]
    [InlineData(LegacyErrorCode.RateLimitExceeded)]
    [InlineData(LegacyErrorCode.ServiceUnavailable)]
    [InlineData(LegacyErrorCode.StyleNotFound)]
    [InlineData(LegacyErrorCode.SubscriptionInactive)]
    [InlineData(LegacyErrorCode.TweetNotFound)]
    [InlineData(LegacyErrorCode.Unauthenticated)]
    [InlineData(LegacyErrorCode.UnsupportedField)]
    [InlineData(LegacyErrorCode.UserNotFound)]
    [InlineData(LegacyErrorCode.XAccountFeatureRequired)]
    [InlineData(LegacyErrorCode.XAccountProtected)]
    [InlineData(LegacyErrorCode.XAccountSuspended)]
    [InlineData(LegacyErrorCode.XApiRateLimited)]
    [InlineData(LegacyErrorCode.XApiUnavailable)]
    [InlineData(LegacyErrorCode.XApiUnauthorized)]
    [InlineData(LegacyErrorCode.XAuthFailure)]
    [InlineData(LegacyErrorCode.XContentTooLong)]
    [InlineData(LegacyErrorCode.XDailyLimit)]
    [InlineData(LegacyErrorCode.XDmNotAllowed)]
    [InlineData(LegacyErrorCode.XDuplicateAction)]
    [InlineData(LegacyErrorCode.XLoginAuthFailed)]
    [InlineData(LegacyErrorCode.XLoginChallenge)]
    [InlineData(LegacyErrorCode.XLoginDenied)]
    [InlineData(LegacyErrorCode.XLoginFailed)]
    [InlineData(LegacyErrorCode.XLoginProxyError)]
    [InlineData(LegacyErrorCode.XLoginRateLimited)]
    [InlineData(LegacyErrorCode.XLoginServiceUnavailable)]
    [InlineData(LegacyErrorCode.XLoginSuspended)]
    [InlineData(LegacyErrorCode.XRateLimited)]
    [InlineData(LegacyErrorCode.XRejected)]
    [InlineData(LegacyErrorCode.XTargetNotFound)]
    [InlineData(LegacyErrorCode.XTransientError)]
    [InlineData(LegacyErrorCode.XUserLookupFailed)]
    [InlineData(LegacyErrorCode.XWriteAmbiguous)]
    [InlineData(LegacyErrorCode.XWriteFailed)]
    public void SerializationRoundtrip_Works(LegacyErrorCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LegacyErrorCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LegacyErrorCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LegacyErrorCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LegacyErrorCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StructuredErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StructuredError
        {
            Code = Code.InvalidInput,
            Message = "Invalid input. Check the request body.",
            Type = Type.InvalidRequestError,
        };

        ApiEnum<string, Code> expectedCode = Code.InvalidInput;
        string expectedMessage = "Invalid input. Check the request body.";
        ApiEnum<string, Type> expectedType = Type.InvalidRequestError;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StructuredError
        {
            Code = Code.InvalidInput,
            Message = "Invalid input. Check the request body.",
            Type = Type.InvalidRequestError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StructuredError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StructuredError
        {
            Code = Code.InvalidInput,
            Message = "Invalid input. Check the request body.",
            Type = Type.InvalidRequestError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StructuredError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Code> expectedCode = Code.InvalidInput;
        string expectedMessage = "Invalid input. Check the request body.";
        ApiEnum<string, Type> expectedType = Type.InvalidRequestError;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StructuredError
        {
            Code = Code.InvalidInput,
            Message = "Invalid input. Check the request body.",
            Type = Type.InvalidRequestError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StructuredError
        {
            Code = Code.InvalidInput,
            Message = "Invalid input. Check the request body.",
            Type = Type.InvalidRequestError,
        };

        StructuredError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CodeTest : TestBase
{
    [Theory]
    [InlineData(Code.InternalError)]
    [InlineData(Code.AccountAlreadyConnected)]
    [InlineData(Code.AccountNeedsReauth)]
    [InlineData(Code.AccountNotFound)]
    [InlineData(Code.AccountRequired)]
    [InlineData(Code.AccountRestricted)]
    [InlineData(Code.ApiKeyLimitReached)]
    [InlineData(Code.ArticleNotFound)]
    [InlineData(Code.DmNotPermitted)]
    [InlineData(Code.InvalidFormat)]
    [InlineData(Code.InvalidID)]
    [InlineData(Code.InvalidInput)]
    [InlineData(Code.InvalidParams)]
    [InlineData(Code.InvalidToolType)]
    [InlineData(Code.InvalidTweetID)]
    [InlineData(Code.InvalidTweetUrl)]
    [InlineData(Code.InvalidUserID)]
    [InlineData(Code.InvalidUserIds)]
    [InlineData(Code.InvalidUsername)]
    [InlineData(Code.InvalidJson)]
    [InlineData(Code.InsufficientCredits)]
    [InlineData(Code.LoginCooldown)]
    [InlineData(Code.LoginFailed)]
    [InlineData(Code.MediaDownloadFailed)]
    [InlineData(Code.MissingParams)]
    [InlineData(Code.MissingQuery)]
    [InlineData(Code.MonitorAlreadyExists)]
    [InlineData(Code.NoMedia)]
    [InlineData(Code.NoCredits)]
    [InlineData(Code.NoSubscription)]
    [InlineData(Code.NotFound)]
    [InlineData(Code.PaymentFailed)]
    [InlineData(Code.RateLimitExceeded)]
    [InlineData(Code.ServiceUnavailable)]
    [InlineData(Code.StyleNotFound)]
    [InlineData(Code.SubscriptionInactive)]
    [InlineData(Code.TweetNotFound)]
    [InlineData(Code.Unauthenticated)]
    [InlineData(Code.UnsupportedField)]
    [InlineData(Code.UserNotFound)]
    [InlineData(Code.XAccountFeatureRequired)]
    [InlineData(Code.XAccountProtected)]
    [InlineData(Code.XAccountSuspended)]
    [InlineData(Code.XApiRateLimited)]
    [InlineData(Code.XApiUnavailable)]
    [InlineData(Code.XApiUnauthorized)]
    [InlineData(Code.XAuthFailure)]
    [InlineData(Code.XContentTooLong)]
    [InlineData(Code.XDailyLimit)]
    [InlineData(Code.XDmNotAllowed)]
    [InlineData(Code.XDuplicateAction)]
    [InlineData(Code.XLoginAuthFailed)]
    [InlineData(Code.XLoginChallenge)]
    [InlineData(Code.XLoginDenied)]
    [InlineData(Code.XLoginFailed)]
    [InlineData(Code.XLoginProxyError)]
    [InlineData(Code.XLoginRateLimited)]
    [InlineData(Code.XLoginServiceUnavailable)]
    [InlineData(Code.XLoginSuspended)]
    [InlineData(Code.XRateLimited)]
    [InlineData(Code.XRejected)]
    [InlineData(Code.XTargetNotFound)]
    [InlineData(Code.XTransientError)]
    [InlineData(Code.XUserLookupFailed)]
    [InlineData(Code.XWriteAmbiguous)]
    [InlineData(Code.XWriteFailed)]
    public void Validation_Works(Code rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Code> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Code>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Code.InternalError)]
    [InlineData(Code.AccountAlreadyConnected)]
    [InlineData(Code.AccountNeedsReauth)]
    [InlineData(Code.AccountNotFound)]
    [InlineData(Code.AccountRequired)]
    [InlineData(Code.AccountRestricted)]
    [InlineData(Code.ApiKeyLimitReached)]
    [InlineData(Code.ArticleNotFound)]
    [InlineData(Code.DmNotPermitted)]
    [InlineData(Code.InvalidFormat)]
    [InlineData(Code.InvalidID)]
    [InlineData(Code.InvalidInput)]
    [InlineData(Code.InvalidParams)]
    [InlineData(Code.InvalidToolType)]
    [InlineData(Code.InvalidTweetID)]
    [InlineData(Code.InvalidTweetUrl)]
    [InlineData(Code.InvalidUserID)]
    [InlineData(Code.InvalidUserIds)]
    [InlineData(Code.InvalidUsername)]
    [InlineData(Code.InvalidJson)]
    [InlineData(Code.InsufficientCredits)]
    [InlineData(Code.LoginCooldown)]
    [InlineData(Code.LoginFailed)]
    [InlineData(Code.MediaDownloadFailed)]
    [InlineData(Code.MissingParams)]
    [InlineData(Code.MissingQuery)]
    [InlineData(Code.MonitorAlreadyExists)]
    [InlineData(Code.NoMedia)]
    [InlineData(Code.NoCredits)]
    [InlineData(Code.NoSubscription)]
    [InlineData(Code.NotFound)]
    [InlineData(Code.PaymentFailed)]
    [InlineData(Code.RateLimitExceeded)]
    [InlineData(Code.ServiceUnavailable)]
    [InlineData(Code.StyleNotFound)]
    [InlineData(Code.SubscriptionInactive)]
    [InlineData(Code.TweetNotFound)]
    [InlineData(Code.Unauthenticated)]
    [InlineData(Code.UnsupportedField)]
    [InlineData(Code.UserNotFound)]
    [InlineData(Code.XAccountFeatureRequired)]
    [InlineData(Code.XAccountProtected)]
    [InlineData(Code.XAccountSuspended)]
    [InlineData(Code.XApiRateLimited)]
    [InlineData(Code.XApiUnavailable)]
    [InlineData(Code.XApiUnauthorized)]
    [InlineData(Code.XAuthFailure)]
    [InlineData(Code.XContentTooLong)]
    [InlineData(Code.XDailyLimit)]
    [InlineData(Code.XDmNotAllowed)]
    [InlineData(Code.XDuplicateAction)]
    [InlineData(Code.XLoginAuthFailed)]
    [InlineData(Code.XLoginChallenge)]
    [InlineData(Code.XLoginDenied)]
    [InlineData(Code.XLoginFailed)]
    [InlineData(Code.XLoginProxyError)]
    [InlineData(Code.XLoginRateLimited)]
    [InlineData(Code.XLoginServiceUnavailable)]
    [InlineData(Code.XLoginSuspended)]
    [InlineData(Code.XRateLimited)]
    [InlineData(Code.XRejected)]
    [InlineData(Code.XTargetNotFound)]
    [InlineData(Code.XTransientError)]
    [InlineData(Code.XUserLookupFailed)]
    [InlineData(Code.XWriteAmbiguous)]
    [InlineData(Code.XWriteFailed)]
    public void SerializationRoundtrip_Works(Code rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Code> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Code>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Code>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Code>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.ApiError)]
    [InlineData(Type.AuthenticationError)]
    [InlineData(Type.BillingError)]
    [InlineData(Type.DependencyError)]
    [InlineData(Type.InvalidRequestError)]
    [InlineData(Type.PermissionError)]
    [InlineData(Type.RateLimitError)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.ApiError)]
    [InlineData(Type.AuthenticationError)]
    [InlineData(Type.BillingError)]
    [InlineData(Type.DependencyError)]
    [InlineData(Type.InvalidRequestError)]
    [InlineData(Type.PermissionError)]
    [InlineData(Type.RateLimitError)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
