// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.GuestWallets;

namespace XTwitterScraper.Tests.Models.GuestWallets;

public class GuestWalletRetrieveStatusResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GuestWalletRetrieveStatusResponse
        {
            Balance = "66666",
            LatestPurchase = new()
            {
                Amount = new(1000),
                CheckoutUrl = null,
                Credits = "66666",
                ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
                PurchaseID = "gp_example",
                Status = LatestPurchaseStatus.Paid,
            },
            PollAfterSeconds = PollAfterSeconds.V2,
            Status = GuestWalletRetrieveStatusResponseStatus.Active,
            TopUp = new(),
            Usable = true,
            WalletID = "gw_example",
        };

        string expectedBalance = "66666";
        LatestPurchase expectedLatestPurchase = new()
        {
            Amount = new(1000),
            CheckoutUrl = null,
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = LatestPurchaseStatus.Paid,
        };
        ApiEnum<long, PollAfterSeconds> expectedPollAfterSeconds = PollAfterSeconds.V2;
        JsonElement expectedScope = JsonSerializer.SerializeToElement("paid_reads");
        ApiEnum<string, GuestWalletRetrieveStatusResponseStatus> expectedStatus =
            GuestWalletRetrieveStatusResponseStatus.Active;
        TopUp expectedTopUp = new();
        bool expectedUsable = true;
        string expectedWalletID = "gw_example";

        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedLatestPurchase, model.LatestPurchase);
        Assert.Equal(expectedPollAfterSeconds, model.PollAfterSeconds);
        Assert.True(JsonElement.DeepEquals(expectedScope, model.Scope));
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTopUp, model.TopUp);
        Assert.Equal(expectedUsable, model.Usable);
        Assert.Equal(expectedWalletID, model.WalletID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GuestWalletRetrieveStatusResponse
        {
            Balance = "66666",
            LatestPurchase = new()
            {
                Amount = new(1000),
                CheckoutUrl = null,
                Credits = "66666",
                ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
                PurchaseID = "gp_example",
                Status = LatestPurchaseStatus.Paid,
            },
            PollAfterSeconds = PollAfterSeconds.V2,
            Status = GuestWalletRetrieveStatusResponseStatus.Active,
            TopUp = new(),
            Usable = true,
            WalletID = "gw_example",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletRetrieveStatusResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GuestWalletRetrieveStatusResponse
        {
            Balance = "66666",
            LatestPurchase = new()
            {
                Amount = new(1000),
                CheckoutUrl = null,
                Credits = "66666",
                ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
                PurchaseID = "gp_example",
                Status = LatestPurchaseStatus.Paid,
            },
            PollAfterSeconds = PollAfterSeconds.V2,
            Status = GuestWalletRetrieveStatusResponseStatus.Active,
            TopUp = new(),
            Usable = true,
            WalletID = "gw_example",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletRetrieveStatusResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBalance = "66666";
        LatestPurchase expectedLatestPurchase = new()
        {
            Amount = new(1000),
            CheckoutUrl = null,
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = LatestPurchaseStatus.Paid,
        };
        ApiEnum<long, PollAfterSeconds> expectedPollAfterSeconds = PollAfterSeconds.V2;
        JsonElement expectedScope = JsonSerializer.SerializeToElement("paid_reads");
        ApiEnum<string, GuestWalletRetrieveStatusResponseStatus> expectedStatus =
            GuestWalletRetrieveStatusResponseStatus.Active;
        TopUp expectedTopUp = new();
        bool expectedUsable = true;
        string expectedWalletID = "gw_example";

        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedLatestPurchase, deserialized.LatestPurchase);
        Assert.Equal(expectedPollAfterSeconds, deserialized.PollAfterSeconds);
        Assert.True(JsonElement.DeepEquals(expectedScope, deserialized.Scope));
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTopUp, deserialized.TopUp);
        Assert.Equal(expectedUsable, deserialized.Usable);
        Assert.Equal(expectedWalletID, deserialized.WalletID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GuestWalletRetrieveStatusResponse
        {
            Balance = "66666",
            LatestPurchase = new()
            {
                Amount = new(1000),
                CheckoutUrl = null,
                Credits = "66666",
                ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
                PurchaseID = "gp_example",
                Status = LatestPurchaseStatus.Paid,
            },
            PollAfterSeconds = PollAfterSeconds.V2,
            Status = GuestWalletRetrieveStatusResponseStatus.Active,
            TopUp = new(),
            Usable = true,
            WalletID = "gw_example",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GuestWalletRetrieveStatusResponse
        {
            Balance = "66666",
            LatestPurchase = new()
            {
                Amount = new(1000),
                CheckoutUrl = null,
                Credits = "66666",
                ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
                PurchaseID = "gp_example",
                Status = LatestPurchaseStatus.Paid,
            },
            PollAfterSeconds = PollAfterSeconds.V2,
            Status = GuestWalletRetrieveStatusResponseStatus.Active,
            TopUp = new(),
            Usable = true,
            WalletID = "gw_example",
        };

        GuestWalletRetrieveStatusResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LatestPurchaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LatestPurchase
        {
            Amount = new(1000),
            CheckoutUrl = null,
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = LatestPurchaseStatus.Paid,
        };

        GuestWalletAmount expectedAmount = new(1000);
        string expectedCredits = "66666";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z");
        string expectedPurchaseID = "gp_example";
        ApiEnum<string, LatestPurchaseStatus> expectedStatus = LatestPurchaseStatus.Paid;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Null(model.CheckoutUrl);
        Assert.Equal(expectedCredits, model.Credits);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedPurchaseID, model.PurchaseID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LatestPurchase
        {
            Amount = new(1000),
            CheckoutUrl = null,
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = LatestPurchaseStatus.Paid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LatestPurchase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LatestPurchase
        {
            Amount = new(1000),
            CheckoutUrl = null,
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = LatestPurchaseStatus.Paid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LatestPurchase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        GuestWalletAmount expectedAmount = new(1000);
        string expectedCredits = "66666";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z");
        string expectedPurchaseID = "gp_example";
        ApiEnum<string, LatestPurchaseStatus> expectedStatus = LatestPurchaseStatus.Paid;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Null(deserialized.CheckoutUrl);
        Assert.Equal(expectedCredits, deserialized.Credits);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedPurchaseID, deserialized.PurchaseID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LatestPurchase
        {
            Amount = new(1000),
            CheckoutUrl = null,
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = LatestPurchaseStatus.Paid,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LatestPurchase
        {
            Amount = new(1000),
            CheckoutUrl = null,
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = LatestPurchaseStatus.Paid,
        };

        LatestPurchase copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LatestPurchaseStatusTest : TestBase
{
    [Theory]
    [InlineData(LatestPurchaseStatus.Creating)]
    [InlineData(LatestPurchaseStatus.Pending)]
    [InlineData(LatestPurchaseStatus.Paid)]
    [InlineData(LatestPurchaseStatus.Expired)]
    [InlineData(LatestPurchaseStatus.Failed)]
    [InlineData(LatestPurchaseStatus.Refunded)]
    [InlineData(LatestPurchaseStatus.Disputed)]
    public void Validation_Works(LatestPurchaseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LatestPurchaseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LatestPurchaseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LatestPurchaseStatus.Creating)]
    [InlineData(LatestPurchaseStatus.Pending)]
    [InlineData(LatestPurchaseStatus.Paid)]
    [InlineData(LatestPurchaseStatus.Expired)]
    [InlineData(LatestPurchaseStatus.Failed)]
    [InlineData(LatestPurchaseStatus.Refunded)]
    [InlineData(LatestPurchaseStatus.Disputed)]
    public void SerializationRoundtrip_Works(LatestPurchaseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LatestPurchaseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LatestPurchaseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LatestPurchaseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LatestPurchaseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PollAfterSecondsTest : TestBase
{
    [Theory]
    [InlineData(PollAfterSeconds.V2)]
    public void Validation_Works(PollAfterSeconds rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<long, PollAfterSeconds> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<long, PollAfterSeconds>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PollAfterSeconds.V2)]
    public void SerializationRoundtrip_Works(PollAfterSeconds rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<long, PollAfterSeconds> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<long, PollAfterSeconds>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<long, PollAfterSeconds>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<long, PollAfterSeconds>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GuestWalletRetrieveStatusResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Active)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Pending)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Expired)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Failed)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Frozen)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Closed)]
    public void Validation_Works(GuestWalletRetrieveStatusResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GuestWalletRetrieveStatusResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletRetrieveStatusResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Active)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Pending)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Expired)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Failed)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Frozen)]
    [InlineData(GuestWalletRetrieveStatusResponseStatus.Closed)]
    public void SerializationRoundtrip_Works(GuestWalletRetrieveStatusResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GuestWalletRetrieveStatusResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletRetrieveStatusResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletRetrieveStatusResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GuestWalletRetrieveStatusResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TopUpTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUp { };

        JsonElement expectedMethod = JsonSerializer.SerializeToElement("POST");
        JsonElement expectedPath = JsonSerializer.SerializeToElement(
            "/api/v1/guest-wallets/topups"
        );

        Assert.True(JsonElement.DeepEquals(expectedMethod, model.Method));
        Assert.True(JsonElement.DeepEquals(expectedPath, model.Path));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopUp { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUp>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopUp { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopUp>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedMethod = JsonSerializer.SerializeToElement("POST");
        JsonElement expectedPath = JsonSerializer.SerializeToElement(
            "/api/v1/guest-wallets/topups"
        );

        Assert.True(JsonElement.DeepEquals(expectedMethod, deserialized.Method));
        Assert.True(JsonElement.DeepEquals(expectedPath, deserialized.Path));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopUp { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopUp { };

        TopUp copied = new(model);

        Assert.Equal(model, copied);
    }
}
