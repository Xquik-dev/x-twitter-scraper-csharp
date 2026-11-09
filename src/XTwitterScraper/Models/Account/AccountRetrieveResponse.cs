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

namespace XTwitterScraper.Models.Account;

[JsonConverter(typeof(JsonModelConverter<AccountRetrieveResponse, AccountRetrieveResponseFromRaw>))]
public sealed record class AccountRetrieveResponse : JsonModel
{
    public required MonitorBilling MonitorBilling
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MonitorBilling>("monitorBilling");
        }
        init { this._rawData.Set("monitorBilling", value); }
    }

    /// <summary>
    /// Deprecated. Monitor slots are unlimited, so this is always Number.MAX_SAFE_INTEGER.
    /// </summary>
    [System::Obsolete("Monitor slots are unlimited. Use monitorBilling.unlimitedSlots instead.")]
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

    /// <summary>
    /// Linked X username, omitted when no X account is connected.
    /// </summary>
    public string? XUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("xUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("xUsername", value);
        }
    }

    /// <summary>
    /// Subscription state without billing provider identifiers.
    /// </summary>
    public AccountRetrieveResponseSubscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountRetrieveResponseSubscription>(
                "subscription"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscription", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MonitorBilling.Validate();
        _ = this.MonitorsAllowed;
        _ = this.MonitorsUsed;
        this.Plan.Validate();
        this.CreditInfo?.Validate();
        _ = this.XUsername;
        this.Subscription?.Validate();
    }

    [System::Obsolete("Required properties are deprecated: monitorsAllowed")]
    public AccountRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [System::Obsolete("Required properties are deprecated: monitorsAllowed")]
    public AccountRetrieveResponse(AccountRetrieveResponse accountRetrieveResponse)
        : base(accountRetrieveResponse) { }
#pragma warning restore CS8618

    [System::Obsolete("Required properties are deprecated: monitorsAllowed")]
    public AccountRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: monitorsAllowed")]
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

[JsonConverter(typeof(JsonModelConverter<MonitorBilling, MonitorBillingFromRaw>))]
public sealed record class MonitorBilling : JsonModel
{
    /// <summary>
    /// Estimated daily credits for currently active monitors.
    /// </summary>
    public required string ActiveDailyEstimate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("activeDailyEstimate");
        }
        init { this._rawData.Set("activeDailyEstimate", value); }
    }

    /// <summary>
    /// Credits charged each hour for currently active monitors.
    /// </summary>
    public required string ActiveHourlyBurn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("activeHourlyBurn");
        }
        init { this._rawData.Set("activeHourlyBurn", value); }
    }

    /// <summary>
    /// Rounded daily estimate for 1 active monitor.
    /// </summary>
    public required string CreditsPerActiveMonitorDay
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditsPerActiveMonitorDay");
        }
        init { this._rawData.Set("creditsPerActiveMonitorDay", value); }
    }

    /// <summary>
    /// Hourly credits charged for 1 active monitor.
    /// </summary>
    public required string CreditsPerActiveMonitorHour
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditsPerActiveMonitorHour");
        }
        init { this._rawData.Set("creditsPerActiveMonitorHour", value); }
    }

    /// <summary>
    /// Webhook and event deliveries are included in monitor billing.
    /// </summary>
    public required bool EventsIncluded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("eventsIncluded");
        }
        init { this._rawData.Set("eventsIncluded", value); }
    }

    /// <summary>
    /// Active monitors check every 1 second.
    /// </summary>
    public required long InstantCheckIntervalSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("instantCheckIntervalSeconds");
        }
        init { this._rawData.Set("instantCheckIntervalSeconds", value); }
    }

    /// <summary>
    /// Monitor slot count is unlimited.
    /// </summary>
    public required bool UnlimitedSlots
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("unlimitedSlots");
        }
        init { this._rawData.Set("unlimitedSlots", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveDailyEstimate;
        _ = this.ActiveHourlyBurn;
        _ = this.CreditsPerActiveMonitorDay;
        _ = this.CreditsPerActiveMonitorHour;
        _ = this.EventsIncluded;
        _ = this.InstantCheckIntervalSeconds;
        _ = this.UnlimitedSlots;
    }

    public MonitorBilling() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonitorBilling(MonitorBilling monitorBilling)
        : base(monitorBilling) { }
#pragma warning restore CS8618

    public MonitorBilling(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonitorBilling(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonitorBillingFromRaw.FromRawUnchecked"/>
    public static MonitorBilling FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MonitorBillingFromRaw : IFromRawJson<MonitorBilling>
{
    /// <inheritdoc/>
    public MonitorBilling FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MonitorBilling.FromRawUnchecked(rawData);
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
        System::Type typeToConvert,
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
    /// <summary>
    /// Dollar amount charged when automatic top-up runs.
    /// </summary>
    public required double AutoTopupAmountDollars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("autoTopupAmountDollars");
        }
        init { this._rawData.Set("autoTopupAmountDollars", value); }
    }

    public required bool AutoTopupEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("autoTopupEnabled");
        }
        init { this._rawData.Set("autoTopupEnabled", value); }
    }

    /// <summary>
    /// Bigint string threshold that triggers automatic top-up when enabled.
    /// </summary>
    public required string AutoTopupThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("autoTopupThreshold");
        }
        init { this._rawData.Set("autoTopupThreshold", value); }
    }

    /// <summary>
    /// Bigint string to preserve precision above Number.MAX_SAFE_INTEGER.
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
    /// Total purchased credits as a bigint string.
    /// </summary>
    public required string LifetimePurchased
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("lifetimePurchased");
        }
        init { this._rawData.Set("lifetimePurchased", value); }
    }

    /// <summary>
    /// Total consumed credits as a bigint string.
    /// </summary>
    public required string LifetimeUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("lifetimeUsed");
        }
        init { this._rawData.Set("lifetimeUsed", value); }
    }

    /// <summary>
    /// True when 3 declined charges in a row on 1 card stopped automatic top-up. The setting stays enabled. A paid top-up, a paid plan renewal, or the next automatic top-up on a new card clears it.
    /// </summary>
    public bool? AutoTopupStopped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("autoTopupStopped");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("autoTopupStopped", value);
        }
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
        _ = this.AutoTopupStopped;
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

[JsonConverter(typeof(AccountRetrieveResponseSubscriptionStatusConverter))]
public enum AccountRetrieveResponseSubscriptionStatus
{
    None,
    Active,
    PastDue,
    Canceling,
    Incomplete,
}

sealed class AccountRetrieveResponseSubscriptionStatusConverter
    : JsonConverter<AccountRetrieveResponseSubscriptionStatus>
{
    public override AccountRetrieveResponseSubscriptionStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => AccountRetrieveResponseSubscriptionStatus.None,
            "active" => AccountRetrieveResponseSubscriptionStatus.Active,
            "past_due" => AccountRetrieveResponseSubscriptionStatus.PastDue,
            "canceling" => AccountRetrieveResponseSubscriptionStatus.Canceling,
            "incomplete" => AccountRetrieveResponseSubscriptionStatus.Incomplete,
            _ => (AccountRetrieveResponseSubscriptionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountRetrieveResponseSubscriptionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountRetrieveResponseSubscriptionStatus.None => "none",
                AccountRetrieveResponseSubscriptionStatus.Active => "active",
                AccountRetrieveResponseSubscriptionStatus.PastDue => "past_due",
                AccountRetrieveResponseSubscriptionStatus.Canceling => "canceling",
                AccountRetrieveResponseSubscriptionStatus.Incomplete => "incomplete",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AccountRetrieveResponseSubscriptionTierConverter))]
public enum AccountRetrieveResponseSubscriptionTier
{
    Starter,
    Pro,
    Business,
}

sealed class AccountRetrieveResponseSubscriptionTierConverter
    : JsonConverter<AccountRetrieveResponseSubscriptionTier>
{
    public override AccountRetrieveResponseSubscriptionTier Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "starter" => AccountRetrieveResponseSubscriptionTier.Starter,
            "pro" => AccountRetrieveResponseSubscriptionTier.Pro,
            "business" => AccountRetrieveResponseSubscriptionTier.Business,
            _ => (AccountRetrieveResponseSubscriptionTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountRetrieveResponseSubscriptionTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountRetrieveResponseSubscriptionTier.Starter => "starter",
                AccountRetrieveResponseSubscriptionTier.Pro => "pro",
                AccountRetrieveResponseSubscriptionTier.Business => "business",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        AccountRetrieveResponseSubscription,
        AccountRetrieveResponseSubscriptionFromRaw
    >)
)]
public sealed record class AccountRetrieveResponseSubscription : JsonModel
{
    public required ApiEnum<string, AccountRetrieveResponseSubscriptionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AccountRetrieveResponseSubscriptionStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public ApiEnum<string, AccountRetrieveResponseSubscriptionTier>? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AccountRetrieveResponseSubscriptionTier>
            >("tier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tier", value);
        }
    }

    public System::DateTimeOffset? CurrentPeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("currentPeriodStart");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentPeriodStart", value);
        }
    }

    /// <summary>
    /// Renewal date, or the end date when canceling.
    /// </summary>
    public System::DateTimeOffset? CurrentPeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("currentPeriodEnd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currentPeriodEnd", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        this.Tier?.Validate();
        _ = this.CurrentPeriodStart;
        _ = this.CurrentPeriodEnd;
    }

    public AccountRetrieveResponseSubscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountRetrieveResponseSubscription(
        AccountRetrieveResponseSubscription accountRetrieveResponseSubscription
    )
        : base(accountRetrieveResponseSubscription) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountRetrieveResponseSubscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountRetrieveResponseSubscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountRetrieveResponseSubscriptionFromRaw.FromRawUnchecked"/>
    public static AccountRetrieveResponseSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountRetrieveResponseSubscriptionFromRaw : IFromRawJson<AccountRetrieveResponseSubscription>
{
    /// <inheritdoc/>
    public AccountRetrieveResponseSubscription FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountRetrieveResponseSubscription.FromRawUnchecked(rawData);
}
