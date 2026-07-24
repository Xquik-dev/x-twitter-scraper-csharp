// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Health = Health.Healthy,
                    Status = "active",
                    UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                    XUserID = "9876543210",
                    XUsername = "elonmusk",
                    CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                },
            ],
        };

        List<XAccount> expectedAccounts =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Health = Health.Healthy,
                Status = "active",
                UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                XUserID = "9876543210",
                XUsername = "elonmusk",
                CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            },
        ];

        Assert.Equal(expectedAccounts.Count, model.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], model.Accounts[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Health = Health.Healthy,
                    Status = "active",
                    UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                    XUserID = "9876543210",
                    XUsername = "elonmusk",
                    CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Health = Health.Healthy,
                    Status = "active",
                    UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                    XUserID = "9876543210",
                    XUsername = "elonmusk",
                    CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<XAccount> expectedAccounts =
        [
            new()
            {
                ID = "42",
                CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                Health = Health.Healthy,
                Status = "active",
                UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                XUserID = "9876543210",
                XUsername = "elonmusk",
                CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            },
        ];

        Assert.Equal(expectedAccounts.Count, deserialized.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], deserialized.Accounts[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Health = Health.Healthy,
                    Status = "active",
                    UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                    XUserID = "9876543210",
                    XUsername = "elonmusk",
                    CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "42",
                    CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
                    Health = Health.Healthy,
                    Status = "active",
                    UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                    XUserID = "9876543210",
                    XUsername = "elonmusk",
                    CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
                },
            ],
        };

        AccountListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
