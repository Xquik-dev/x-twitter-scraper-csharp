using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models.GuestWallets;

namespace XTwitterScraper.Tests.Models.GuestWallets;

public class GuestWalletCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GuestWalletCreateResponse
        {
            Amount = new(1000),
            ApiKey = "xq_example_returned_once",
            Authorization = new() { Header = Header.Authorization, Scheme = Scheme.Bearer },
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = Status.Pending,
            WalletID = "gw_example",
        };

        JsonElement expectedAccountRequired = JsonSerializer.SerializeToElement(false);
        GuestWalletAmount expectedAmount = new(1000);
        string expectedApiKey = "xq_example_returned_once";
        Authorization expectedAuthorization = new()
        {
            Header = Header.Authorization,
            Scheme = Scheme.Bearer,
        };
        string expectedCheckoutUrl = "https://buy.stripe.com/example";
        JsonElement expectedCredentialNotice = JsonSerializer.SerializeToElement(
            "Store api_key and the Idempotency-Key securely before sharing checkout_url. No email recovery is available."
        );
        string expectedCredits = "66666";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z");
        JsonElement expectedInstructions = JsonSerializer.SerializeToElement(
            "Give checkout_url to the user. They must complete payment on Stripe. Never submit payment for them. After payment, poll status_url every poll_after_seconds until latest_purchase.status is no longer pending."
        );
        JsonElement expectedPollAfterSeconds = JsonSerializer.SerializeToElement(2);
        string expectedPurchaseID = "gp_example";
        JsonElement expectedRequiresUserInteraction = JsonSerializer.SerializeToElement(true);
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        JsonElement expectedStatusUrl = JsonSerializer.SerializeToElement(
            "https://xquik.com/api/v1/guest-wallets/status"
        );
        string expectedWalletID = "gw_example";

        Assert.True(JsonElement.DeepEquals(expectedAccountRequired, model.AccountRequired));
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedAuthorization, model.Authorization);
        Assert.Equal(expectedCheckoutUrl, model.CheckoutUrl);
        Assert.True(JsonElement.DeepEquals(expectedCredentialNotice, model.CredentialNotice));
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GuestWalletCreateResponse
        {
            Amount = new(1000),
            ApiKey = "xq_example_returned_once",
            Authorization = new() { Header = Header.Authorization, Scheme = Scheme.Bearer },
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = Status.Pending,
            WalletID = "gw_example",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GuestWalletCreateResponse
        {
            Amount = new(1000),
            ApiKey = "xq_example_returned_once",
            Authorization = new() { Header = Header.Authorization, Scheme = Scheme.Bearer },
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = Status.Pending,
            WalletID = "gw_example",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GuestWalletCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedAccountRequired = JsonSerializer.SerializeToElement(false);
        GuestWalletAmount expectedAmount = new(1000);
        string expectedApiKey = "xq_example_returned_once";
        Authorization expectedAuthorization = new()
        {
            Header = Header.Authorization,
            Scheme = Scheme.Bearer,
        };
        string expectedCheckoutUrl = "https://buy.stripe.com/example";
        JsonElement expectedCredentialNotice = JsonSerializer.SerializeToElement(
            "Store api_key and the Idempotency-Key securely before sharing checkout_url. No email recovery is available."
        );
        string expectedCredits = "66666";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z");
        JsonElement expectedInstructions = JsonSerializer.SerializeToElement(
            "Give checkout_url to the user. They must complete payment on Stripe. Never submit payment for them. After payment, poll status_url every poll_after_seconds until latest_purchase.status is no longer pending."
        );
        JsonElement expectedPollAfterSeconds = JsonSerializer.SerializeToElement(2);
        string expectedPurchaseID = "gp_example";
        JsonElement expectedRequiresUserInteraction = JsonSerializer.SerializeToElement(true);
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        JsonElement expectedStatusUrl = JsonSerializer.SerializeToElement(
            "https://xquik.com/api/v1/guest-wallets/status"
        );
        string expectedWalletID = "gw_example";

        Assert.True(JsonElement.DeepEquals(expectedAccountRequired, deserialized.AccountRequired));
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedAuthorization, deserialized.Authorization);
        Assert.Equal(expectedCheckoutUrl, deserialized.CheckoutUrl);
        Assert.True(
            JsonElement.DeepEquals(expectedCredentialNotice, deserialized.CredentialNotice)
        );
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GuestWalletCreateResponse
        {
            Amount = new(1000),
            ApiKey = "xq_example_returned_once",
            Authorization = new() { Header = Header.Authorization, Scheme = Scheme.Bearer },
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = Status.Pending,
            WalletID = "gw_example",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GuestWalletCreateResponse
        {
            Amount = new(1000),
            ApiKey = "xq_example_returned_once",
            Authorization = new() { Header = Header.Authorization, Scheme = Scheme.Bearer },
            CheckoutUrl = "https://buy.stripe.com/example",
            Credits = "66666",
            ExpiresAt = DateTimeOffset.Parse("2026-07-13T13:00:00.000Z"),
            PurchaseID = "gp_example",
            Status = Status.Pending,
            WalletID = "gw_example",
        };

        GuestWalletCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Authorization { Header = Header.Authorization, Scheme = Scheme.Bearer };

        ApiEnum<string, Header> expectedHeader = Header.Authorization;
        ApiEnum<string, Scheme> expectedScheme = Scheme.Bearer;

        Assert.Equal(expectedHeader, model.Header);
        Assert.Equal(expectedScheme, model.Scheme);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Authorization { Header = Header.Authorization, Scheme = Scheme.Bearer };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Authorization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Authorization { Header = Header.Authorization, Scheme = Scheme.Bearer };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Authorization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Header> expectedHeader = Header.Authorization;
        ApiEnum<string, Scheme> expectedScheme = Scheme.Bearer;

        Assert.Equal(expectedHeader, deserialized.Header);
        Assert.Equal(expectedScheme, deserialized.Scheme);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Authorization { Header = Header.Authorization, Scheme = Scheme.Bearer };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Authorization { Header = Header.Authorization, Scheme = Scheme.Bearer };

        Authorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HeaderTest : TestBase
{
    [Theory]
    [InlineData(Header.Authorization)]
    public void Validation_Works(Header rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Header> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Header>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Header.Authorization)]
    public void SerializationRoundtrip_Works(Header rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Header> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Header>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Header>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Header>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SchemeTest : TestBase
{
    [Theory]
    [InlineData(Scheme.Bearer)]
    public void Validation_Works(Scheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scheme> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scheme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Scheme.Bearer)]
    public void SerializationRoundtrip_Works(Scheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scheme> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scheme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scheme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scheme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Creating)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Paid)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Refunded)]
    [InlineData(Status.Disputed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Creating)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Paid)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Refunded)]
    [InlineData(Status.Disputed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
