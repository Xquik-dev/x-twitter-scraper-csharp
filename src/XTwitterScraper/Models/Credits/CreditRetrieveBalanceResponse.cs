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
    public required bool AutoTopupEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("auto_topup_enabled");
        }
        init { this._rawData.Set("auto_topup_enabled", value); }
    }

    public required long Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    public required long LifetimePurchased
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("lifetime_purchased");
        }
        init { this._rawData.Set("lifetime_purchased", value); }
    }

    public required long LifetimeUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("lifetime_used");
        }
        init { this._rawData.Set("lifetime_used", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AutoTopupEnabled;
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
