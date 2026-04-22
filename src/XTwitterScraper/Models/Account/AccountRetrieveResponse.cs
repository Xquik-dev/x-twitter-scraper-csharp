using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Account;

[JsonConverter(typeof(JsonModelConverter<AccountRetrieveResponse, AccountRetrieveResponseFromRaw>))]
public sealed record class AccountRetrieveResponse : JsonModel
{
    public required long MonitorsAllowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("monitorsAllowed");
        }
        init { this._rawData.Set("monitorsAllowed", value); }
    }

    public required long MonitorsUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("monitorsUsed");
        }
        init { this._rawData.Set("monitorsUsed", value); }
    }

    public required ApiEnum<string, Plan> Plan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Plan>>("plan");
        }
        init { this._rawData.Set("plan", value); }
    }

    public CreditInfo? CreditInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditInfo>("creditInfo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditInfo", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MonitorsAllowed;
        _ = this.MonitorsUsed;
        this.Plan.Validate();
        this.CreditInfo?.Validate();
    }

    public AccountRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountRetrieveResponse(AccountRetrieveResponse accountRetrieveResponse)
        : base(accountRetrieveResponse) { }
#pragma warning restore CS8618

    public AccountRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountRetrieveResponseFromRaw : IFromRawJson<AccountRetrieveResponse>
{
    /// <inheritdoc/>
    public AccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanConverter))]
public enum Plan
{
    Active,
    Inactive,
}

sealed class PlanConverter : JsonConverter<Plan>
{
    public override Plan Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Plan.Active,
            "inactive" => Plan.Inactive,
            _ => (Plan)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Plan value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Plan.Active => "active",
                Plan.Inactive => "inactive",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CreditInfo, CreditInfoFromRaw>))]
public sealed record class CreditInfo : JsonModel
{
    public required bool AutoTopupEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("autoTopupEnabled");
        }
        init { this._rawData.Set("autoTopupEnabled", value); }
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
            return this._rawData.GetNotNullStruct<long>("lifetimePurchased");
        }
        init { this._rawData.Set("lifetimePurchased", value); }
    }

    public required long LifetimeUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("lifetimeUsed");
        }
        init { this._rawData.Set("lifetimeUsed", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AutoTopupEnabled;
        _ = this.Balance;
        _ = this.LifetimePurchased;
        _ = this.LifetimeUsed;
    }

    public CreditInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditInfo(CreditInfo creditInfo)
        : base(creditInfo) { }
#pragma warning restore CS8618

    public CreditInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditInfoFromRaw.FromRawUnchecked"/>
    public static CreditInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditInfoFromRaw : IFromRawJson<CreditInfo>
{
    /// <inheritdoc/>
    public CreditInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditInfo.FromRawUnchecked(rawData);
}
