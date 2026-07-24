// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.GuestWallets;

namespace XTwitterScraper.Tests.Models.GuestWallets;

public class GuestWalletTopupResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",
            ApiKey = "xq_example_returned_once",
            Authorization = new()
            {
                Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
                Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
            },
            CredentialNotice =
                CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable,
        };

        JsonElement expectedAccountRequired = JsonSerializer.SerializeToElement(false);
        GuestWalletAmount expectedAmount = new(1000);
        string expectedCheckoutUrl = "https://buy.stripe.com/example";
        string expectedCredits = "66666";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z");
        JsonElement expectedInstructions = JsonSerializer.SerializeToElement(
            "Give checkout_url to the user. They must complete payment on Stripe. Never submit payment for them. After payment, poll status_url every poll_after_seconds until latest_purchase.status is no longer pending."
        );
        JsonElement expectedPollAfterSeconds = JsonSerializer.SerializeToElement(2);
        string expectedPurchaseID = "gp_example";
        JsonElement expectedRequiresUserInteraction = JsonSerializer.SerializeToElement(true);
        ApiEnum<string, GuestWalletTopupResponseStatus> expectedStatus =
            GuestWalletTopupResponseStatus.Pending;
        JsonElement expectedStatusUrl = JsonSerializer.SerializeToElement(
            "https://xquik.com/api/v1/guest-wallets/status"
        );
        string expectedWalletID = "gw_example";
        string expectedApiKey = "xq_example_returned_once";
        GuestWalletTopupResponseAuthorization expectedAuthorization = new()
        {
            Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
            Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
        };
        ApiEnum<string, CredentialNotice> expectedCredentialNotice =
            CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable;

        Assert.True(JsonElement.DeepEquals(expectedAccountRequired, model.AccountRequired));
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCheckoutUrl, model.CheckoutUrl);
        Assert.Equal(expectedCredits, model.Credits);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.True(JsonElement.DeepEquals(expectedInstructions, model.Instructions));
        Assert.True(JsonElement.DeepEquals(expectedPollAfterSeconds, model.PollAfterSeconds));
        Assert.Equal(expectedPurchaseID, model.PurchaseID);
        Assert.True(
            JsonElement.DeepEquals(expectedRequiresUserInteraction, model.RequiresUserInteraction)
        );
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedStatusUrl, model.StatusUrl));
        Assert.Equal(expectedWalletID, model.WalletID);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedAuthorization, model.Authorization);
        Assert.Equal(expectedCredentialNotice, model.CredentialNotice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",
            ApiKey = "xq_example_returned_once",
            Authorization = new()
            {
                Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
                Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
            },
            CredentialNotice =
                CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletTopupResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",
            ApiKey = "xq_example_returned_once",
            Authorization = new()
            {
                Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
                Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
            },
            CredentialNotice =
                CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletTopupResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedAccountRequired = JsonSerializer.SerializeToElement(false);
        GuestWalletAmount expectedAmount = new(1000);
        string expectedCheckoutUrl = "https://buy.stripe.com/example";
        string expectedCredits = "66666";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z");
        JsonElement expectedInstructions = JsonSerializer.SerializeToElement(
            "Give checkout_url to the user. They must complete payment on Stripe. Never submit payment for them. After payment, poll status_url every poll_after_seconds until latest_purchase.status is no longer pending."
        );
        JsonElement expectedPollAfterSeconds = JsonSerializer.SerializeToElement(2);
        string expectedPurchaseID = "gp_example";
        JsonElement expectedRequiresUserInteraction = JsonSerializer.SerializeToElement(true);
        ApiEnum<string, GuestWalletTopupResponseStatus> expectedStatus =
            GuestWalletTopupResponseStatus.Pending;
        JsonElement expectedStatusUrl = JsonSerializer.SerializeToElement(
            "https://xquik.com/api/v1/guest-wallets/status"
        );
        string expectedWalletID = "gw_example";
        string expectedApiKey = "xq_example_returned_once";
        GuestWalletTopupResponseAuthorization expectedAuthorization = new()
        {
            Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
            Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
        };
        ApiEnum<string, CredentialNotice> expectedCredentialNotice =
            CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable;

        Assert.True(JsonElement.DeepEquals(expectedAccountRequired, deserialized.AccountRequired));
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCheckoutUrl, deserialized.CheckoutUrl);
        Assert.Equal(expectedCredits, deserialized.Credits);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.True(JsonElement.DeepEquals(expectedInstructions, deserialized.Instructions));
        Assert.True(
            JsonElement.DeepEquals(expectedPollAfterSeconds, deserialized.PollAfterSeconds)
        );
        Assert.Equal(expectedPurchaseID, deserialized.PurchaseID);
        Assert.True(
            JsonElement.DeepEquals(
                expectedRequiresUserInteraction,
                deserialized.RequiresUserInteraction
            )
        );
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedStatusUrl, deserialized.StatusUrl));
        Assert.Equal(expectedWalletID, deserialized.WalletID);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedAuthorization, deserialized.Authorization);
        Assert.Equal(expectedCredentialNotice, deserialized.CredentialNotice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",
            ApiKey = "xq_example_returned_once",
            Authorization = new()
            {
                Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
                Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
            },
            CredentialNotice =
                CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.Authorization);
        Assert.False(model.RawData.ContainsKey("authorization"));
        Assert.Null(model.CredentialNotice);
        Assert.False(model.RawData.ContainsKey("credential_notice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            Authorization = null,
            CredentialNotice = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.Authorization);
        Assert.False(model.RawData.ContainsKey("authorization"));
        Assert.Null(model.CredentialNotice);
        Assert.False(model.RawData.ContainsKey("credential_notice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            Authorization = null,
            CredentialNotice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GuestWalletTopupResponse
        {
            Amount = new(1000),
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = GuestWalletTopupResponseStatus.Pending,
            WalletID = "gw_example",
            ApiKey = "xq_example_returned_once",
            Authorization = new()
            {
                Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
                Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
            },
            CredentialNotice =
                CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable,
        };

        GuestWalletTopupResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GuestWalletTopupResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(GuestWalletTopupResponseStatus.Creating)]
    [InlineData(GuestWalletTopupResponseStatus.Pending)]
    [InlineData(GuestWalletTopupResponseStatus.Paid)]
    [InlineData(GuestWalletTopupResponseStatus.Expired)]
    [InlineData(GuestWalletTopupResponseStatus.Failed)]
    [InlineData(GuestWalletTopupResponseStatus.Refunded)]
    [InlineData(GuestWalletTopupResponseStatus.Disputed)]
    public void Validation_Works(GuestWalletTopupResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GuestWalletTopupResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GuestWalletTopupResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GuestWalletTopupResponseStatus.Creating)]
    [InlineData(GuestWalletTopupResponseStatus.Pending)]
    [InlineData(GuestWalletTopupResponseStatus.Paid)]
    [InlineData(GuestWalletTopupResponseStatus.Expired)]
    [InlineData(GuestWalletTopupResponseStatus.Failed)]
    [InlineData(GuestWalletTopupResponseStatus.Refunded)]
    [InlineData(GuestWalletTopupResponseStatus.Disputed)]
    public void SerializationRoundtrip_Works(GuestWalletTopupResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GuestWalletTopupResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GuestWalletTopupResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GuestWalletTopupResponseAuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GuestWalletTopupResponseAuthorization
        {
            Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
            Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
        };

        ApiEnum<string, GuestWalletTopupResponseAuthorizationHeader> expectedHeader =
            GuestWalletTopupResponseAuthorizationHeader.Authorization;
        ApiEnum<string, GuestWalletTopupResponseAuthorizationScheme> expectedScheme =
            GuestWalletTopupResponseAuthorizationScheme.Bearer;

        Assert.Equal(expectedHeader, model.Header);
        Assert.Equal(expectedScheme, model.Scheme);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GuestWalletTopupResponseAuthorization
        {
            Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
            Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletTopupResponseAuthorization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GuestWalletTopupResponseAuthorization
        {
            Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
            Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletTopupResponseAuthorization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, GuestWalletTopupResponseAuthorizationHeader> expectedHeader =
            GuestWalletTopupResponseAuthorizationHeader.Authorization;
        ApiEnum<string, GuestWalletTopupResponseAuthorizationScheme> expectedScheme =
            GuestWalletTopupResponseAuthorizationScheme.Bearer;

        Assert.Equal(expectedHeader, deserialized.Header);
        Assert.Equal(expectedScheme, deserialized.Scheme);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GuestWalletTopupResponseAuthorization
        {
            Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
            Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GuestWalletTopupResponseAuthorization
        {
            Header = GuestWalletTopupResponseAuthorizationHeader.Authorization,
            Scheme = GuestWalletTopupResponseAuthorizationScheme.Bearer,
        };

        GuestWalletTopupResponseAuthorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GuestWalletTopupResponseAuthorizationHeaderTest : TestBase
{
    [Theory]
    [InlineData(GuestWalletTopupResponseAuthorizationHeader.Authorization)]
    public void Validation_Works(GuestWalletTopupResponseAuthorizationHeader rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GuestWalletTopupResponseAuthorizationHeader> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseAuthorizationHeader>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GuestWalletTopupResponseAuthorizationHeader.Authorization)]
    public void SerializationRoundtrip_Works(GuestWalletTopupResponseAuthorizationHeader rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GuestWalletTopupResponseAuthorizationHeader> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseAuthorizationHeader>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseAuthorizationHeader>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseAuthorizationHeader>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GuestWalletTopupResponseAuthorizationSchemeTest : TestBase
{
    [Theory]
    [InlineData(GuestWalletTopupResponseAuthorizationScheme.Bearer)]
    public void Validation_Works(GuestWalletTopupResponseAuthorizationScheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GuestWalletTopupResponseAuthorizationScheme> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseAuthorizationScheme>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GuestWalletTopupResponseAuthorizationScheme.Bearer)]
    public void SerializationRoundtrip_Works(GuestWalletTopupResponseAuthorizationScheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GuestWalletTopupResponseAuthorizationScheme> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseAuthorizationScheme>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseAuthorizationScheme>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletTopupResponseAuthorizationScheme>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CredentialNoticeTest : TestBase
{
    [Theory]
    [InlineData(
        CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable
    )]
    public void Validation_Works(CredentialNotice rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CredentialNotice> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CredentialNotice>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable
    )]
    public void SerializationRoundtrip_Works(CredentialNotice rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CredentialNotice> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CredentialNotice>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CredentialNotice>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CredentialNotice>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
