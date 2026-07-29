using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using AccountConnectionAttempts = XTwitterScraper.Models.X.AccountConnectionAttempts;

namespace XTwitterScraper.Tests.Models.X.AccountConnectionAttempts;

public class AccountConnectionAttemptRetrieveResponseTest : TestBase
{
    [Fact]
    public void XAccountConnectionAttemptPendingValidationWorks()
    {
        AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse value =
            new AccountConnectionAttempts::XAccountConnectionAttemptPending()
            {
                ID = "xatt_0123456789abcdef0123456789abcdef",
                PollAfterMs = 3000,
            };
        value.Validate();
    }

    [Fact]
    public void XAccountConnectionAttemptSuccessValidationWorks()
    {
        AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse value =
            new AccountConnectionAttempts::XAccountConnectionAttemptSuccess(
                "xatt_0123456789abcdef0123456789abcdef"
            );
        value.Validate();
    }

    [Fact]
    public void XAccountConnectionAttemptFailedValidationWorks()
    {
        AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse value =
            new AccountConnectionAttempts::XAccountConnectionAttemptFailed()
            {
                ID = "xatt_0123456789abcdef0123456789abcdef",
                Error = "service_unavailable",
                Retryable = true,
                Reason = "wrong_password",
            };
        value.Validate();
    }

    [Fact]
    public void XAccountConnectionChallengeValidationWorks()
    {
        AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse value =
            new AccountConnectionAttempts::XAccountConnectionChallenge()
            {
                ID = "xch_8vGd8Y9JvH6dV0xA",
                ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
                Message = "Enter the email verification code to continue.",
                Object = AccountConnectionAttempts::Object.XAccountConnectionChallenge,
                Status = AccountConnectionAttempts::Status.RequiresEmailCode,
                Username = "elonmusk",
            };
        value.Validate();
    }

    [Fact]
    public void XAccountConnectionAttemptPendingSerializationRoundtripWorks()
    {
        AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse value =
            new AccountConnectionAttempts::XAccountConnectionAttemptPending()
            {
                ID = "xatt_0123456789abcdef0123456789abcdef",
                PollAfterMs = 3000,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void XAccountConnectionAttemptSuccessSerializationRoundtripWorks()
    {
        AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse value =
            new AccountConnectionAttempts::XAccountConnectionAttemptSuccess(
                "xatt_0123456789abcdef0123456789abcdef"
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void XAccountConnectionAttemptFailedSerializationRoundtripWorks()
    {
        AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse value =
            new AccountConnectionAttempts::XAccountConnectionAttemptFailed()
            {
                ID = "xatt_0123456789abcdef0123456789abcdef",
                Error = "service_unavailable",
                Retryable = true,
                Reason = "wrong_password",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void XAccountConnectionChallengeSerializationRoundtripWorks()
    {
        AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse value =
            new AccountConnectionAttempts::XAccountConnectionChallenge()
            {
                ID = "xch_8vGd8Y9JvH6dV0xA",
                ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
                Message = "Enter the email verification code to continue.",
                Object = AccountConnectionAttempts::Object.XAccountConnectionChallenge,
                Status = AccountConnectionAttempts::Status.RequiresEmailCode,
                Username = "elonmusk",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::AccountConnectionAttemptRetrieveResponse>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class XAccountConnectionAttemptPendingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        string expectedID = "xatt_0123456789abcdef0123456789abcdef";
        JsonElement expectedObject = JsonSerializer.SerializeToElement(
            "x_account_connection_attempt"
        );
        long expectedPollAfterMs = 3000;
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("pending");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedObject, model.Object));
        Assert.Equal(expectedPollAfterMs, model.PollAfterMs);
        Assert.True(JsonElement.DeepEquals(expectedStatus, model.Status));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::XAccountConnectionAttemptPending>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::XAccountConnectionAttemptPending>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "xatt_0123456789abcdef0123456789abcdef";
        JsonElement expectedObject = JsonSerializer.SerializeToElement(
            "x_account_connection_attempt"
        );
        long expectedPollAfterMs = 3000;
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("pending");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedObject, deserialized.Object));
        Assert.Equal(expectedPollAfterMs, deserialized.PollAfterMs);
        Assert.True(JsonElement.DeepEquals(expectedStatus, deserialized.Status));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        AccountConnectionAttempts::XAccountConnectionAttemptPending copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class XAccountConnectionAttemptSuccessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptSuccess
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
        };

        string expectedID = "xatt_0123456789abcdef0123456789abcdef";
        JsonElement expectedObject = JsonSerializer.SerializeToElement(
            "x_account_connection_attempt"
        );
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("success");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedObject, model.Object));
        Assert.True(JsonElement.DeepEquals(expectedStatus, model.Status));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptSuccess
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::XAccountConnectionAttemptSuccess>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptSuccess
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::XAccountConnectionAttemptSuccess>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "xatt_0123456789abcdef0123456789abcdef";
        JsonElement expectedObject = JsonSerializer.SerializeToElement(
            "x_account_connection_attempt"
        );
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("success");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedObject, deserialized.Object));
        Assert.True(JsonElement.DeepEquals(expectedStatus, deserialized.Status));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptSuccess
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptSuccess
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
        };

        AccountConnectionAttempts::XAccountConnectionAttemptSuccess copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class XAccountConnectionAttemptFailedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };

        string expectedID = "xatt_0123456789abcdef0123456789abcdef";
        string expectedError = "service_unavailable";
        JsonElement expectedObject = JsonSerializer.SerializeToElement(
            "x_account_connection_attempt"
        );
        bool expectedRetryable = true;
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("failed");
        string expectedReason = "wrong_password";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedError, model.Error);
        Assert.True(JsonElement.DeepEquals(expectedObject, model.Object));
        Assert.Equal(expectedRetryable, model.Retryable);
        Assert.True(JsonElement.DeepEquals(expectedStatus, model.Status));
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::XAccountConnectionAttemptFailed>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::XAccountConnectionAttemptFailed>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "xatt_0123456789abcdef0123456789abcdef";
        string expectedError = "service_unavailable";
        JsonElement expectedObject = JsonSerializer.SerializeToElement(
            "x_account_connection_attempt"
        );
        bool expectedRetryable = true;
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("failed");
        string expectedReason = "wrong_password";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.True(JsonElement.DeepEquals(expectedObject, deserialized.Object));
        Assert.Equal(expectedRetryable, deserialized.Retryable);
        Assert.True(JsonElement.DeepEquals(expectedStatus, deserialized.Status));
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionAttemptFailed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };

        AccountConnectionAttempts::XAccountConnectionAttemptFailed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class XAccountConnectionChallengeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionChallenge
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Object = AccountConnectionAttempts::Object.XAccountConnectionChallenge,
            Status = AccountConnectionAttempts::Status.RequiresEmailCode,
            Username = "elonmusk",
        };

        string expectedID = "xch_8vGd8Y9JvH6dV0xA";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z");
        string expectedMessage = "Enter the email verification code to continue.";
        ApiEnum<string, AccountConnectionAttempts::Object> expectedObject =
            AccountConnectionAttempts::Object.XAccountConnectionChallenge;
        ApiEnum<string, AccountConnectionAttempts::Status> expectedStatus =
            AccountConnectionAttempts::Status.RequiresEmailCode;
        string expectedUsername = "elonmusk";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionChallenge
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Object = AccountConnectionAttempts::Object.XAccountConnectionChallenge,
            Status = AccountConnectionAttempts::Status.RequiresEmailCode,
            Username = "elonmusk",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::XAccountConnectionChallenge>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionChallenge
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Object = AccountConnectionAttempts::Object.XAccountConnectionChallenge,
            Status = AccountConnectionAttempts::Status.RequiresEmailCode,
            Username = "elonmusk",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountConnectionAttempts::XAccountConnectionChallenge>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "xch_8vGd8Y9JvH6dV0xA";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z");
        string expectedMessage = "Enter the email verification code to continue.";
        ApiEnum<string, AccountConnectionAttempts::Object> expectedObject =
            AccountConnectionAttempts::Object.XAccountConnectionChallenge;
        ApiEnum<string, AccountConnectionAttempts::Status> expectedStatus =
            AccountConnectionAttempts::Status.RequiresEmailCode;
        string expectedUsername = "elonmusk";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUsername, deserialized.Username);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionChallenge
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Object = AccountConnectionAttempts::Object.XAccountConnectionChallenge,
            Status = AccountConnectionAttempts::Status.RequiresEmailCode,
            Username = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountConnectionAttempts::XAccountConnectionChallenge
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Object = AccountConnectionAttempts::Object.XAccountConnectionChallenge,
            Status = AccountConnectionAttempts::Status.RequiresEmailCode,
            Username = "elonmusk",
        };

        AccountConnectionAttempts::XAccountConnectionChallenge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ObjectTest : TestBase
{
    [Theory]
    [InlineData(AccountConnectionAttempts::Object.XAccountConnectionChallenge)]
    public void Validation_Works(AccountConnectionAttempts::Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountConnectionAttempts::Object> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountConnectionAttempts::Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountConnectionAttempts::Object.XAccountConnectionChallenge)]
    public void SerializationRoundtrip_Works(AccountConnectionAttempts::Object rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountConnectionAttempts::Object> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountConnectionAttempts::Object>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountConnectionAttempts::Object>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountConnectionAttempts::Object>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(AccountConnectionAttempts::Status.RequiresEmailCode)]
    public void Validation_Works(AccountConnectionAttempts::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountConnectionAttempts::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountConnectionAttempts::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountConnectionAttempts::Status.RequiresEmailCode)]
    public void SerializationRoundtrip_Works(AccountConnectionAttempts::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountConnectionAttempts::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountConnectionAttempts::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountConnectionAttempts::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountConnectionAttempts::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
