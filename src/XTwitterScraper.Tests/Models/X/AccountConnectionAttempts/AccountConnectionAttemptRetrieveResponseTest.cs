// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.AccountConnectionAttempts;

namespace XTwitterScraper.Tests.Models.X.AccountConnectionAttempts;

public class AccountConnectionAttemptRetrieveResponseTest : TestBase
{
    [Fact]
    public void PendingValidationWorks()
    {
        AccountConnectionAttemptRetrieveResponse value = new Pending()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };
        value.Validate();
    }

    [Fact]
    public void SuccessValidationWorks()
    {
        AccountConnectionAttemptRetrieveResponse value = new Success(
            "xatt_0123456789abcdef0123456789abcdef"
        );
        value.Validate();
    }

    [Fact]
    public void FailedValidationWorks()
    {
        AccountConnectionAttemptRetrieveResponse value = new Failed()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };
        value.Validate();
    }

    [Fact]
    public void RequiresEmailCodeValidationWorks()
    {
        AccountConnectionAttemptRetrieveResponse value = new RequiresEmailCode()
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };
        value.Validate();
    }

    [Fact]
    public void PendingSerializationRoundtripWorks()
    {
        AccountConnectionAttemptRetrieveResponse value = new Pending()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountConnectionAttemptRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SuccessSerializationRoundtripWorks()
    {
        AccountConnectionAttemptRetrieveResponse value = new Success(
            "xatt_0123456789abcdef0123456789abcdef"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountConnectionAttemptRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailedSerializationRoundtripWorks()
    {
        AccountConnectionAttemptRetrieveResponse value = new Failed()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountConnectionAttemptRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RequiresEmailCodeSerializationRoundtripWorks()
    {
        AccountConnectionAttemptRetrieveResponse value = new RequiresEmailCode()
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountConnectionAttemptRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PendingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pending
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
        var model = new Pending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pending>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pending>(
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
        var model = new Pending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        Pending copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SuccessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Success { ID = "xatt_0123456789abcdef0123456789abcdef" };

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
        var model = new Success { ID = "xatt_0123456789abcdef0123456789abcdef" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Success>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Success { ID = "xatt_0123456789abcdef0123456789abcdef" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Success>(
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
        var model = new Success { ID = "xatt_0123456789abcdef0123456789abcdef" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Success { ID = "xatt_0123456789abcdef0123456789abcdef" };

        Success copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FailedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Failed
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
        var model = new Failed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Failed>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Failed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Failed>(element, ModelBase.SerializerOptions);
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
        var model = new Failed
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
        var model = new Failed
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
        var model = new Failed
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
        var model = new Failed
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
        var model = new Failed
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
        var model = new Failed
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            Error = "service_unavailable",
            Retryable = true,
            Reason = "wrong_password",
        };

        Failed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RequiresEmailCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RequiresEmailCode
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };

        string expectedID = "xch_8vGd8Y9JvH6dV0xA";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z");
        string expectedMessage = "Enter the email verification code to continue.";
        JsonElement expectedObject = JsonSerializer.SerializeToElement(
            "x_account_connection_challenge"
        );
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("requires_email_code");
        string expectedUsername = "elonmusk";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedMessage, model.Message);
        Assert.True(JsonElement.DeepEquals(expectedObject, model.Object));
        Assert.True(JsonElement.DeepEquals(expectedStatus, model.Status));
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RequiresEmailCode
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequiresEmailCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RequiresEmailCode
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequiresEmailCode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "xch_8vGd8Y9JvH6dV0xA";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z");
        string expectedMessage = "Enter the email verification code to continue.";
        JsonElement expectedObject = JsonSerializer.SerializeToElement(
            "x_account_connection_challenge"
        );
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("requires_email_code");
        string expectedUsername = "elonmusk";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.True(JsonElement.DeepEquals(expectedObject, deserialized.Object));
        Assert.True(JsonElement.DeepEquals(expectedStatus, deserialized.Status));
        Assert.Equal(expectedUsername, deserialized.Username);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RequiresEmailCode
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RequiresEmailCode
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };

        RequiresEmailCode copied = new(model);

        Assert.Equal(model, copied);
    }
}
