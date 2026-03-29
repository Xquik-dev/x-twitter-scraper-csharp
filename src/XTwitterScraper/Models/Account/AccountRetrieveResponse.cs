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

    public CurrentPeriod? CurrentPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CurrentPeriod>("currentPeriod");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentPeriod", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MonitorsAllowed;
        _ = this.MonitorsUsed;
        this.Plan.Validate();
        this.CurrentPeriod?.Validate();
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

[JsonConverter(typeof(JsonModelConverter<CurrentPeriod, CurrentPeriodFromRaw>))]
public sealed record class CurrentPeriod : JsonModel
{
    public required DateTimeOffset End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("end");
        }
        init { this._rawData.Set("end", value); }
    }

    public required DateTimeOffset Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    public required double UsagePercent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("usagePercent");
        }
        init { this._rawData.Set("usagePercent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.Start;
        _ = this.UsagePercent;
    }

    public CurrentPeriod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrentPeriod(CurrentPeriod currentPeriod)
        : base(currentPeriod) { }
#pragma warning restore CS8618

    public CurrentPeriod(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrentPeriod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrentPeriodFromRaw.FromRawUnchecked"/>
    public static CurrentPeriod FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrentPeriodFromRaw : IFromRawJson<CurrentPeriod>
{
    /// <inheritdoc/>
    public CurrentPeriod FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CurrentPeriod.FromRawUnchecked(rawData);
}
