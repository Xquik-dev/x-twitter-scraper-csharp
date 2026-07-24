// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class XAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, Health> expectedHealth = Health.Healthy;
        string expectedStatus = "active";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z");
        string expectedXUserID = "9876543210";
        string expectedXUsername = "elonmusk";
        DateTimeOffset expectedCookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedHealth, model.Health);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedXUserID, model.XUserID);
        Assert.Equal(expectedXUsername, model.XUsername);
        Assert.Equal(expectedCookiesObtainedAt, model.CookiesObtainedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XAccount>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "42";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z");
        ApiEnum<string, Health> expectedHealth = Health.Healthy;
        string expectedStatus = "active";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z");
        string expectedXUserID = "9876543210";
        string expectedXUsername = "elonmusk";
        DateTimeOffset expectedCookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedHealth, deserialized.Health);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedXUserID, deserialized.XUserID);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
        Assert.Equal(expectedCookiesObtainedAt, deserialized.CookiesObtainedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        Assert.Null(model.CookiesObtainedAt);
        Assert.False(model.RawData.ContainsKey("cookiesObtainedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",

            // Null should be interpreted as omitted for these properties
            CookiesObtainedAt = null,
        };

        Assert.Null(model.CookiesObtainedAt);
        Assert.False(model.RawData.ContainsKey("cookiesObtainedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",

            // Null should be interpreted as omitted for these properties
            CookiesObtainedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new XAccount
        {
            ID = "42",
            CreatedAt = DateTimeOffset.Parse("2025-01-15T12:00:00Z"),
            Health = Health.Healthy,
            Status = "active",
            UpdatedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
            XUserID = "9876543210",
            XUsername = "elonmusk",
            CookiesObtainedAt = DateTimeOffset.Parse("2025-03-10T08:30:00Z"),
        };

        XAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HealthTest : TestBase
{
    [Theory]
    [InlineData(Health.Healthy)]
    [InlineData(Health.Locked)]
    [InlineData(Health.NeedsReauth)]
    [InlineData(Health.Recovering)]
    [InlineData(Health.Suspended)]
    [InlineData(Health.TemporaryIssue)]
    public void Validation_Works(Health rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Health> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Health>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Health.Healthy)]
    [InlineData(Health.Locked)]
    [InlineData(Health.NeedsReauth)]
    [InlineData(Health.Recovering)]
    [InlineData(Health.Suspended)]
    [InlineData(Health.TemporaryIssue)]
    public void SerializationRoundtrip_Works(Health rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Health> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Health>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Health>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Health>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
