// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.AccountConnectionChallenges;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.AccountConnectionChallenges;

public class AccountConnectionChallengeSubmitResponseTest : TestBase
{
    [Fact]
    public void SanitizedXAccountValidationWorks()
    {
        AccountConnectionChallengeSubmitResponse value = new SanitizedXAccount()
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
    public void XAccountConnectionChallengeValidationWorks()
    {
        AccountConnectionChallengeSubmitResponse value = new XAccountConnectionChallenge()
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
        AccountConnectionChallengeSubmitResponse value = new SanitizedXAccount()
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = SanitizedXAccountHealth.Healthy,
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountConnectionChallengeSubmitResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void XAccountConnectionChallengeSerializationRoundtripWorks()
    {
        AccountConnectionChallengeSubmitResponse value = new XAccountConnectionChallenge()
        {
            ID = "xch_8vGd8Y9JvH6dV0xA",
            ExpiresAt = DateTimeOffset.Parse("2026-05-08T12:10:00Z"),
            Message = "Enter the email verification code to continue.",
            Username = "elonmusk",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountConnectionChallengeSubmitResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
