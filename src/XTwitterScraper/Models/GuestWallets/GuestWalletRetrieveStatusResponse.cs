// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

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
/// Current balance, usability, and latest guest purchase state.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        GuestWalletRetrieveStatusResponse,
        GuestWalletRetrieveStatusResponseFromRaw
    >)
)]
public sealed record class GuestWalletRetrieveStatusResponse : JsonModel
{
    public required string Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    /// <summary>
    /// Latest guest wallet purchase fulfillment state.
    /// </summary>
    public required LatestPurchase? LatestPurchase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LatestPurchase>("latest_purchase");
        }
        init { this._rawData.Set("latest_purchase", value); }
    }

    /// <summary>
    /// Polling delay while payment is pending. Null means stop.
    /// </summary>
    public required ApiEnum<long, PollAfterSeconds>? PollAfterSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<long, PollAfterSeconds>>(
                "poll_after_seconds"
            );
        }
        init { this._rawData.Set("poll_after_seconds", value); }
    }

    public JsonElement Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("scope");
        }
        init { this._rawData.Set("scope", value); }
    }

    /// <summary>
    /// Combined wallet and pending-checkout state. A pending top-up can coexist
    /// with usable true. Terminal expired or failed states require a new guest wallet.
    /// </summary>
    public required ApiEnum<string, GuestWalletRetrieveStatusResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, GuestWalletRetrieveStatusResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Top-up action when usable and no checkout is pending.
    /// </summary>
    public required TopUp? TopUp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TopUp>("top_up");
        }
        init { this._rawData.Set("top_up", value); }
    }

    /// <summary>
    /// Authoritative paid-read readiness. Use instead of status.
    /// </summary>
    public required bool Usable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("usable");
        }
        init { this._rawData.Set("usable", value); }
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
        _ = this.Balance;
        this.LatestPurchase?.Validate();
        this.PollAfterSeconds?.Validate();
        if (!JsonElement.DeepEquals(this.Scope, JsonSerializer.SerializeToElement("paid_reads")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        this.Status.Validate();
        this.TopUp?.Validate();
        _ = this.Usable;
        _ = this.WalletID;
    }

    public GuestWalletRetrieveStatusResponse()
    {
        this.Scope = JsonSerializer.SerializeToElement("paid_reads");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GuestWalletRetrieveStatusResponse(
        GuestWalletRetrieveStatusResponse guestWalletRetrieveStatusResponse
    )
        : base(guestWalletRetrieveStatusResponse) { }
#pragma warning restore CS8618

    public GuestWalletRetrieveStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Scope = JsonSerializer.SerializeToElement("paid_reads");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GuestWalletRetrieveStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GuestWalletRetrieveStatusResponseFromRaw.FromRawUnchecked"/>
    public static GuestWalletRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GuestWalletRetrieveStatusResponseFromRaw : IFromRawJson<GuestWalletRetrieveStatusResponse>
{
    /// <inheritdoc/>
    public GuestWalletRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GuestWalletRetrieveStatusResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Latest guest wallet purchase fulfillment state.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LatestPurchase, LatestPurchaseFromRaw>))]
public sealed record class LatestPurchase : JsonModel
{
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
    /// Present only while the purchase is pending.
    /// </summary>
    public required string? CheckoutUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checkout_url");
        }
        init { this._rawData.Set("checkout_url", value); }
    }

    public required string Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credits");
        }
        init { this._rawData.Set("credits", value); }
    }

    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
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

    public required ApiEnum<string, LatestPurchaseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LatestPurchaseStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Amount.Validate();
        _ = this.CheckoutUrl;
        _ = this.Credits;
        _ = this.ExpiresAt;
        _ = this.PurchaseID;
        this.Status.Validate();
    }

    public LatestPurchase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LatestPurchase(LatestPurchase latestPurchase)
        : base(latestPurchase) { }
#pragma warning restore CS8618

    public LatestPurchase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LatestPurchase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LatestPurchaseFromRaw.FromRawUnchecked"/>
    public static LatestPurchase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LatestPurchaseFromRaw : IFromRawJson<LatestPurchase>
{
    /// <inheritdoc/>
    public LatestPurchase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LatestPurchase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LatestPurchaseStatusConverter))]
public enum LatestPurchaseStatus
{
    Creating,
    Pending,
    Paid,
    Expired,
    Failed,
    Refunded,
    Disputed,
}

sealed class LatestPurchaseStatusConverter : JsonConverter<LatestPurchaseStatus>
{
    public override LatestPurchaseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "creating" => LatestPurchaseStatus.Creating,
            "pending" => LatestPurchaseStatus.Pending,
            "paid" => LatestPurchaseStatus.Paid,
            "expired" => LatestPurchaseStatus.Expired,
            "failed" => LatestPurchaseStatus.Failed,
            "refunded" => LatestPurchaseStatus.Refunded,
            "disputed" => LatestPurchaseStatus.Disputed,
            _ => (LatestPurchaseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LatestPurchaseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LatestPurchaseStatus.Creating => "creating",
                LatestPurchaseStatus.Pending => "pending",
                LatestPurchaseStatus.Paid => "paid",
                LatestPurchaseStatus.Expired => "expired",
                LatestPurchaseStatus.Failed => "failed",
                LatestPurchaseStatus.Refunded => "refunded",
                LatestPurchaseStatus.Disputed => "disputed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Polling delay while payment is pending. Null means stop.
/// </summary>
[JsonConverter(typeof(PollAfterSecondsConverter))]
public enum PollAfterSeconds
{
    V2,
}

sealed class PollAfterSecondsConverter : JsonConverter<PollAfterSeconds>
{
    public override PollAfterSeconds Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            2L => PollAfterSeconds.V2,
            _ => (PollAfterSeconds)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PollAfterSeconds value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PollAfterSeconds.V2 => 2L,
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Combined wallet and pending-checkout state. A pending top-up can coexist with
/// usable true. Terminal expired or failed states require a new guest wallet.
/// </summary>
[JsonConverter(typeof(GuestWalletRetrieveStatusResponseStatusConverter))]
public enum GuestWalletRetrieveStatusResponseStatus
{
    Active,
    Pending,
    Expired,
    Failed,
    Frozen,
    Closed,
}

sealed class GuestWalletRetrieveStatusResponseStatusConverter
    : JsonConverter<GuestWalletRetrieveStatusResponseStatus>
{
    public override GuestWalletRetrieveStatusResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => GuestWalletRetrieveStatusResponseStatus.Active,
            "pending" => GuestWalletRetrieveStatusResponseStatus.Pending,
            "expired" => GuestWalletRetrieveStatusResponseStatus.Expired,
            "failed" => GuestWalletRetrieveStatusResponseStatus.Failed,
            "frozen" => GuestWalletRetrieveStatusResponseStatus.Frozen,
            "closed" => GuestWalletRetrieveStatusResponseStatus.Closed,
            _ => (GuestWalletRetrieveStatusResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GuestWalletRetrieveStatusResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GuestWalletRetrieveStatusResponseStatus.Active => "active",
                GuestWalletRetrieveStatusResponseStatus.Pending => "pending",
                GuestWalletRetrieveStatusResponseStatus.Expired => "expired",
                GuestWalletRetrieveStatusResponseStatus.Failed => "failed",
                GuestWalletRetrieveStatusResponseStatus.Frozen => "frozen",
                GuestWalletRetrieveStatusResponseStatus.Closed => "closed",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Top-up action when usable and no checkout is pending.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopUp, TopUpFromRaw>))]
public sealed record class TopUp : JsonModel
{
    public JsonElement Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    public JsonElement Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Method, JsonSerializer.SerializeToElement("POST")))
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Path,
                JsonSerializer.SerializeToElement("/api/v1/guest-wallets/topups")
            )
        )
        {
            throw new XTwitterScraperInvalidDataException("Invalid value given for constant");
        }
    }

    public TopUp()
    {
        this.Method = JsonSerializer.SerializeToElement("POST");
        this.Path = JsonSerializer.SerializeToElement("/api/v1/guest-wallets/topups");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopUp(TopUp topUp)
        : base(topUp) { }
#pragma warning restore CS8618

    public TopUp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Method = JsonSerializer.SerializeToElement("POST");
        this.Path = JsonSerializer.SerializeToElement("/api/v1/guest-wallets/topups");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUpFromRaw.FromRawUnchecked"/>
    public static TopUp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUpFromRaw : IFromRawJson<TopUp>
{
    /// <inheritdoc/>
    public TopUp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopUp.FromRawUnchecked(rawData);
}
