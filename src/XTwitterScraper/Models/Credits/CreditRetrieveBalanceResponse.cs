// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.Credits;

[JsonConverter(
    typeof(JsonModelConverter<CreditRetrieveBalanceResponse, CreditRetrieveBalanceResponseFromRaw>)
)]
public sealed record class CreditRetrieveBalanceResponse : JsonModel
{
    /// <summary>
    /// Configured dollar amount for each automatic top-up.
    /// </summary>
    public required double AutoTopupAmountDollars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("auto_topup_amount_dollars");
        }
        init { this._rawData.Set("auto_topup_amount_dollars", value); }
    }

    public required bool AutoTopupEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("auto_topup_enabled");
        }
        init { this._rawData.Set("auto_topup_enabled", value); }
    }

    /// <summary>
    /// Credit balance threshold that triggers automatic top-up when enabled, represented
    /// as a bigint string.
    /// </summary>
    public required string AutoTopupThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("auto_topup_threshold");
        }
        init { this._rawData.Set("auto_topup_threshold", value); }
    }

    /// <summary>
    /// Current credit balance as a bigint string to preserve precision above Number.MAX_SAFE_INTEGER.
    /// </summary>
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
    /// Lifetime purchased credits as a bigint string.
    /// </summary>
    public required string LifetimePurchased
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("lifetime_purchased");
        }
        init { this._rawData.Set("lifetime_purchased", value); }
    }

    /// <summary>
    /// Lifetime consumed credits as a bigint string.
    /// </summary>
    public required string LifetimeUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("lifetime_used");
        }
        init { this._rawData.Set("lifetime_used", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AutoTopupAmountDollars;
        _ = this.AutoTopupEnabled;
        _ = this.AutoTopupThreshold;
        _ = this.Balance;
        _ = this.LifetimePurchased;
        _ = this.LifetimeUsed;
    }

    public CreditRetrieveBalanceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditRetrieveBalanceResponse(
        CreditRetrieveBalanceResponse creditRetrieveBalanceResponse
    )
        : base(creditRetrieveBalanceResponse) { }
#pragma warning restore CS8618

    public CreditRetrieveBalanceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditRetrieveBalanceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditRetrieveBalanceResponseFromRaw.FromRawUnchecked"/>
    public static CreditRetrieveBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditRetrieveBalanceResponseFromRaw : IFromRawJson<CreditRetrieveBalanceResponse>
{
    /// <inheritdoc/>
    public CreditRetrieveBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditRetrieveBalanceResponse.FromRawUnchecked(rawData);
}
