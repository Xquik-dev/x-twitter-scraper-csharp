// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountReauthResponseTest : TestBase
{
    [Fact]
    public void SanitizedXAccountValidationWorks()
    {
        AccountReauthResponse value = new SanitizedXAccount()
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
        AccountReauthResponse value = new XAccountConnectionAttemptPending()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };
        value.Validate();
    }

    [Fact]
    public void XAccountConnectionChallengeValidationWorks()
    {
        AccountReauthResponse value = new XAccountConnectionChallenge()
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
        AccountReauthResponse value = new SanitizedXAccount()
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountReauthResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void XAccountConnectionAttemptPendingSerializationRoundtripWorks()
    {
        AccountReauthResponse value = new XAccountConnectionAttemptPending()
        {
            ID = "xatt_0123456789abcdef0123456789abcdef",
            PollAfterMs = 3000,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountReauthResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void XAccountConnectionChallengeSerializationRoundtripWorks()
    {
        AccountReauthResponse value = new XAccountConnectionChallenge()
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountReauthResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
