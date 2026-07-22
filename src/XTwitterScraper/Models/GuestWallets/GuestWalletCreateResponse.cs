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
/// Initial guest wallet response containing the one-time key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GuestWalletCreateResponse, GuestWalletCreateResponseFromRaw>)
)]
public sealed record class GuestWalletCreateResponse : JsonModel
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
    /// Paid-read bearer credential returned only by initial creation. Store it as
    /// a secret. Never place it in a URL or log.
    /// </summary>
    public required string ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_key");
        }
        init { this._rawData.Set("api_key", value); }
    }

    public required Authorization Authorization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Authorization>("authorization");
        }
        init { this._rawData.Set("authorization", value); }
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

    public JsonElement CredentialNotice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("credential_notice");
        }
        init { this._rawData.Set("credential_notice", value); }
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

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.AccountRequired, JsonSerializer.SerializeToElement(false)))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        this.Amount.Validate();
        _ = this.ApiKey;
        this.Authorization.Validate();
        _ = this.CheckoutUrl;
        if (
            !JsonElement.DeepEquals(
                this.CredentialNotice,
                JsonSerializer.SerializeToElement(
                    "Store api_key and the Idempotency-Key securely before sharing checkout_url. No email recovery is available."
                )
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
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
    }

    public GuestWalletCreateResponse()
    {
        this.AccountRequired = JsonSerializer.SerializeToElement(false);
        this.CredentialNotice = JsonSerializer.SerializeToElement(
            "Store api_key and the Idempotency-Key securely before sharing checkout_url. No email recovery is available."
        );
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
    public GuestWalletCreateResponse(GuestWalletCreateResponse guestWalletCreateResponse)
        : base(guestWalletCreateResponse) { }
#pragma warning restore CS8618

    public GuestWalletCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.AccountRequired = JsonSerializer.SerializeToElement(false);
        this.CredentialNotice = JsonSerializer.SerializeToElement(
            "Store api_key and the Idempotency-Key securely before sharing checkout_url. No email recovery is available."
        );
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
    GuestWalletCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GuestWalletCreateResponseFromRaw.FromRawUnchecked"/>
    public static GuestWalletCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GuestWalletCreateResponseFromRaw : IFromRawJson<GuestWalletCreateResponse>
{
    /// <inheritdoc/>
    public GuestWalletCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GuestWalletCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Authorization, AuthorizationFromRaw>))]
public sealed record class Authorization : JsonModel
{
    public required ApiEnum<string, Header> Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Header>>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    public required ApiEnum<string, Scheme> Scheme
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Scheme>>("scheme");
        }
        init { this._rawData.Set("scheme", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Header.Validate();
        this.Scheme.Validate();
    }

    public Authorization() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Authorization(Authorization authorization)
        : base(authorization) { }
#pragma warning restore CS8618

    public Authorization(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(typeof(HeaderConverter))]
public enum Header
{
    Authorization,
}

sealed class HeaderConverter : JsonConverter<Header>
{
    public override Header Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Authorization" => Header.Authorization,
            _ => (Header)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Header value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Header.Authorization => "Authorization",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SchemeConverter))]
public enum Scheme
{
    Bearer,
}

sealed class SchemeConverter : JsonConverter<Scheme>
{
    public override Scheme Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Bearer" => Scheme.Bearer,
            _ => (Scheme)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scheme value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scheme.Bearer => "Bearer",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Creating,
    Pending,
    Paid,
    Expired,
    Failed,
    Refunded,
    Disputed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "creating" => Status.Creating,
            "pending" => Status.Pending,
            "paid" => Status.Paid,
            "expired" => Status.Expired,
            "failed" => Status.Failed,
            "refunded" => Status.Refunded,
            "disputed" => Status.Disputed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Creating => "creating",
                Status.Pending => "pending",
                Status.Paid => "paid",
                Status.Expired => "expired",
                Status.Failed => "failed",
                Status.Refunded => "refunded",
                Status.Disputed => "disputed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
