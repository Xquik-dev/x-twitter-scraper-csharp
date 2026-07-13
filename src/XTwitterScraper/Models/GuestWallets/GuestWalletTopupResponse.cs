using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.GuestWallets;

/// <summary>
/// Pending Stripe checkout and guest wallet purchase details.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GuestWalletTopupResponse, GuestWalletTopupResponseFromRaw>)
)]
public sealed record class GuestWalletTopupResponse : JsonModel
{
    public JsonElement AccountRequired
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("account_required");
        }
        init { this._rawData.Set("account_required", value); }
    }

    /// <summary>
    /// Confirmed USD amount for a guest wallet purchase.
    /// </summary>
    public required GuestWalletAmount Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GuestWalletAmount>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Raw Stripe-hosted checkout URL for user interaction.
    /// </summary>
    public required string CheckoutUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("checkout_url");
        }
        init { this._rawData.Set("checkout_url", value); }
    }

    /// <summary>
    /// Credits granted after verified payment.
    /// </summary>
    public required string Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credits");
        }
        init { this._rawData.Set("credits", value); }
    }

    /// <summary>
    /// Time when the pending checkout expires.
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    public JsonElement Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// Wait at least this long before polling status_url.
    /// </summary>
    public JsonElement PollAfterSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("poll_after_seconds");
        }
        init { this._rawData.Set("poll_after_seconds", value); }
    }

    public required string PurchaseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("purchase_id");
        }
        init { this._rawData.Set("purchase_id", value); }
    }

    public JsonElement RequiresUserInteraction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("requires_user_interaction");
        }
        init { this._rawData.Set("requires_user_interaction", value); }
    }

    public required ApiEnum<string, GuestWalletTopupResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GuestWalletTopupResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public JsonElement StatusUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("status_url");
        }
        init { this._rawData.Set("status_url", value); }
    }

    public required string WalletID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("wallet_id");
        }
        init { this._rawData.Set("wallet_id", value); }
    }

    /// <summary>
    /// Paid-read bearer credential returned only by initial creation. Store it as
    /// a secret. Never place it in a URL or log.
    /// </summary>
    public string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("api_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("api_key", value);
        }
    }

    public Authorization? Authorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Authorization>("authorization");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorization", value);
        }
    }

    public ApiEnum<string, CredentialNotice>? CredentialNotice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CredentialNotice>>(
                "credential_notice"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("credential_notice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.AccountRequired, JsonSerializer.SerializeToElement(false)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        this.Amount.Validate();
        _ = this.CheckoutUrl;
        _ = this.Credits;
        _ = this.ExpiresAt;
        if (
            !JsonElement.DeepEquals(
                this.Instructions,
                JsonSerializer.SerializeToElement(
                    "Give checkout_url to the user. They must complete payment on Stripe. Never submit payment for them. After payment, poll status_url every poll_after_seconds until latest_purchase.status is no longer pending."
                )
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.PollAfterSeconds, JsonSerializer.SerializeToElement(2)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.PurchaseID;
        if (
            !JsonElement.DeepEquals(
                this.RequiresUserInteraction,
                JsonSerializer.SerializeToElement(true)
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        this.Status.Validate();
        if (
            !JsonElement.DeepEquals(
                this.StatusUrl,
                JsonSerializer.SerializeToElement("https://xquik.com/api/v1/guest-wallets/status")
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        _ = this.WalletID;
        _ = this.ApiKey;
        this.Authorization?.Validate();
        this.CredentialNotice?.Validate();
    }

    public GuestWalletTopupResponse()
    {
        this.AccountRequired = JsonSerializer.SerializeToElement(false);
        this.Instructions = JsonSerializer.SerializeToElement(
            "Give checkout_url to the user. They must complete payment on Stripe. Never submit payment for them. After payment, poll status_url every poll_after_seconds until latest_purchase.status is no longer pending."
        );
        this.PollAfterSeconds = JsonSerializer.SerializeToElement(2);
        this.RequiresUserInteraction = JsonSerializer.SerializeToElement(true);
        this.StatusUrl = JsonSerializer.SerializeToElement(
            "https://xquik.com/api/v1/guest-wallets/status"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GuestWalletTopupResponse(GuestWalletTopupResponse guestWalletTopupResponse)
        : base(guestWalletTopupResponse) { }
#pragma warning restore CS8618

    public GuestWalletTopupResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.AccountRequired = JsonSerializer.SerializeToElement(false);
        this.Instructions = JsonSerializer.SerializeToElement(
            "Give checkout_url to the user. They must complete payment on Stripe. Never submit payment for them. After payment, poll status_url every poll_after_seconds until latest_purchase.status is no longer pending."
        );
        this.PollAfterSeconds = JsonSerializer.SerializeToElement(2);
        this.RequiresUserInteraction = JsonSerializer.SerializeToElement(true);
        this.StatusUrl = JsonSerializer.SerializeToElement(
            "https://xquik.com/api/v1/guest-wallets/status"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GuestWalletTopupResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GuestWalletTopupResponseFromRaw.FromRawUnchecked"/>
    public static GuestWalletTopupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GuestWalletTopupResponseFromRaw : IFromRawJson<GuestWalletTopupResponse>
{
    /// <inheritdoc/>
    public GuestWalletTopupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GuestWalletTopupResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(GuestWalletTopupResponseStatusConverter))]
public enum GuestWalletTopupResponseStatus
{
    Creating,
    Pending,
    Paid,
    Expired,
    Failed,
    Refunded,
    Disputed,
}

sealed class GuestWalletTopupResponseStatusConverter : JsonConverter<GuestWalletTopupResponseStatus>
{
    public override GuestWalletTopupResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "creating" => GuestWalletTopupResponseStatus.Creating,
            "pending" => GuestWalletTopupResponseStatus.Pending,
            "paid" => GuestWalletTopupResponseStatus.Paid,
            "expired" => GuestWalletTopupResponseStatus.Expired,
            "failed" => GuestWalletTopupResponseStatus.Failed,
            "refunded" => GuestWalletTopupResponseStatus.Refunded,
            "disputed" => GuestWalletTopupResponseStatus.Disputed,
            _ => (GuestWalletTopupResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GuestWalletTopupResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GuestWalletTopupResponseStatus.Creating => "creating",
                GuestWalletTopupResponseStatus.Pending => "pending",
                GuestWalletTopupResponseStatus.Paid => "paid",
                GuestWalletTopupResponseStatus.Expired => "expired",
                GuestWalletTopupResponseStatus.Failed => "failed",
                GuestWalletTopupResponseStatus.Refunded => "refunded",
                GuestWalletTopupResponseStatus.Disputed => "disputed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Authorization, AuthorizationFromRaw>))]
public sealed record class Authorization : JsonModel
{
    public JsonElement Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    public JsonElement Scheme
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("scheme");
        }
        init { this._rawData.Set("scheme", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(this.Header, JsonSerializer.SerializeToElement("Authorization"))
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Scheme, JsonSerializer.SerializeToElement("Bearer")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public Authorization()
    {
        this.Header = JsonSerializer.SerializeToElement("Authorization");
        this.Scheme = JsonSerializer.SerializeToElement("Bearer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Authorization(Authorization authorization)
        : base(authorization) { }
#pragma warning restore CS8618

    public Authorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Header = JsonSerializer.SerializeToElement("Authorization");
        this.Scheme = JsonSerializer.SerializeToElement("Bearer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Authorization(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthorizationFromRaw.FromRawUnchecked"/>
    public static Authorization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuthorizationFromRaw : IFromRawJson<Authorization>
{
    /// <inheritdoc/>
    public Authorization FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Authorization.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CredentialNoticeConverter))]
public enum CredentialNotice
{
    StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable,
}

sealed class CredentialNoticeConverter : JsonConverter<CredentialNotice>
{
    public override CredentialNotice Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Store api_key and the Idempotency-Key securely before sharing checkout_url. No email recovery is available." =>
                CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable,
            _ => (CredentialNotice)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CredentialNotice value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CredentialNotice.StoreApiKeyAndTheIdempotencyKeySecurelyBeforeSharingCheckoutUrlNoEmailRecoveryIsAvailable =>
                    "Store api_key and the Idempotency-Key securely before sharing checkout_url. No email recovery is available.",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
