// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountCreateResponseTest : TestBase
{
    [Fact]
    public void SanitizedXAccountValidationWorks()
    {
        AccountCreateResponse value = new SanitizedXAccount()
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };
        value.Validate();
    }

    [Fact]
    public void XAccountConnectionAttemptPendingValidationWorks()
    {
        AccountCreateResponse value = new XAccountConnectionAttemptPending()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };
        value.Validate();
    }

    [Fact]
    public void XAccountConnectionChallengeValidationWorks()
    {
        AccountCreateResponse value = new XAccountConnectionChallenge()
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };
        value.Validate();
    }

    [Fact]
    public void SanitizedXAccountSerializationRoundtripWorks()
    {
        AccountCreateResponse value = new SanitizedXAccount()
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void XAccountConnectionAttemptPendingSerializationRoundtripWorks()
    {
        AccountCreateResponse value = new XAccountConnectionAttemptPending()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void XAccountConnectionChallengeSerializationRoundtripWorks()
    {
        AccountCreateResponse value = new XAccountConnectionChallenge()
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SanitizedXAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SanitizedXAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, SanitizedXAccountHealth> expectedHealth = SanitizedXAccountHealth.Healthy;
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("active");
        string expectedXUserID = "9876543210";
        string expectedXUsername = "elonmusk";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedHealth, model.Health);
        Assert.True(JsonElement.DeepEquals(expectedStatus, model.Status));
        Assert.Equal(expectedXUserID, model.XUserID);
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SanitizedXAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SanitizedXAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SanitizedXAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SanitizedXAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, SanitizedXAccountHealth> expectedHealth = SanitizedXAccountHealth.Healthy;
        JsonElement expectedStatus = JsonSerializer.SerializeToElement("active");
        string expectedXUserID = "9876543210";
        string expectedXUsername = "elonmusk";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedHealth, deserialized.Health);
        Assert.True(JsonElement.DeepEquals(expectedStatus, deserialized.Status));
        Assert.Equal(expectedXUserID, deserialized.XUserID);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SanitizedXAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SanitizedXAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        SanitizedXAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SanitizedXAccountHealthTest : TestBase
{
    [Theory]
    [InlineData(SanitizedXAccountHealth.Healthy)]
    [InlineData(SanitizedXAccountHealth.Locked)]
    [InlineData(SanitizedXAccountHealth.NeedsReauth)]
    [InlineData(SanitizedXAccountHealth.Recovering)]
    [InlineData(SanitizedXAccountHealth.Suspended)]
    [InlineData(SanitizedXAccountHealth.TemporaryIssue)]
    public void Validation_Works(SanitizedXAccountHealth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SanitizedXAccountHealth> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SanitizedXAccountHealth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SanitizedXAccountHealth.Healthy)]
    [InlineData(SanitizedXAccountHealth.Locked)]
    [InlineData(SanitizedXAccountHealth.NeedsReauth)]
    [InlineData(SanitizedXAccountHealth.Recovering)]
    [InlineData(SanitizedXAccountHealth.Suspended)]
    [InlineData(SanitizedXAccountHealth.TemporaryIssue)]
    public void SerializationRoundtrip_Works(SanitizedXAccountHealth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SanitizedXAccountHealth> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SanitizedXAccountHealth>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SanitizedXAccountHealth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SanitizedXAccountHealth>>(
            json,
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
        var model = new XAccountConnectionAttemptPending
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
        var model = new XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XAccountConnectionAttemptPending>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XAccountConnectionAttemptPending>(
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
        var model = new XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new XAccountConnectionAttemptPending
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };

        XAccountConnectionAttemptPending copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class XAccountConnectionChallengeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new XAccountConnectionChallenge
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
        var model = new XAccountConnectionChallenge
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XAccountConnectionChallenge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new XAccountConnectionChallenge
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XAccountConnectionChallenge>(
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
        var model = new XAccountConnectionChallenge
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
        var model = new XAccountConnectionChallenge
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };

        XAccountConnectionChallenge copied = new(model);

        Assert.Equal(model, copied);
    }
}
