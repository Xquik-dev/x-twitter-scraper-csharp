// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(ActivityRecordObjectConverter))]
public enum ActivityRecordObject
{
    Activity,
}

sealed class ActivityRecordObjectConverter : JsonConverter<ActivityRecordObject>
{
    public override ActivityRecordObject Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "activity" => ActivityRecordObject.Activity,
            _ => (ActivityRecordObject)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivityRecordObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivityRecordObject.Activity => "activity",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ActivityRecordKindConverter))]
public enum ActivityRecordKind
{
    WriteAction,
    Extraction,
    MonitorChange,
    ApiKey,
    Billing,
    GiveawayDraw,
    MonitorEvent,
    MediaDownload,
    MediaShare,
    SupportTicket,
    WebhookDelivery,
    WebhookEndpoint,
    XAccountConnection,
}

sealed class ActivityRecordKindConverter : JsonConverter<ActivityRecordKind>
{
    public override ActivityRecordKind Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "write_action" => ActivityRecordKind.WriteAction,
            "extraction" => ActivityRecordKind.Extraction,
            "monitor_change" => ActivityRecordKind.MonitorChange,
            "api_key" => ActivityRecordKind.ApiKey,
            "billing" => ActivityRecordKind.Billing,
            "giveaway_draw" => ActivityRecordKind.GiveawayDraw,
            "monitor_event" => ActivityRecordKind.MonitorEvent,
            "media_download" => ActivityRecordKind.MediaDownload,
            "media_share" => ActivityRecordKind.MediaShare,
            "support_ticket" => ActivityRecordKind.SupportTicket,
            "webhook_delivery" => ActivityRecordKind.WebhookDelivery,
            "webhook_endpoint" => ActivityRecordKind.WebhookEndpoint,
            "x_account_connection" => ActivityRecordKind.XAccountConnection,
            _ => (ActivityRecordKind)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivityRecordKind value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivityRecordKind.WriteAction => "write_action",
                ActivityRecordKind.Extraction => "extraction",
                ActivityRecordKind.MonitorChange => "monitor_change",
                ActivityRecordKind.ApiKey => "api_key",
                ActivityRecordKind.Billing => "billing",
                ActivityRecordKind.GiveawayDraw => "giveaway_draw",
                ActivityRecordKind.MonitorEvent => "monitor_event",
                ActivityRecordKind.MediaDownload => "media_download",
                ActivityRecordKind.MediaShare => "media_share",
                ActivityRecordKind.SupportTicket => "support_ticket",
                ActivityRecordKind.WebhookDelivery => "webhook_delivery",
                ActivityRecordKind.WebhookEndpoint => "webhook_endpoint",
                ActivityRecordKind.XAccountConnection => "x_account_connection",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ActivityRecordStatusConverter))]
public enum ActivityRecordStatus
{
    Completed,
    Running,
    Failed,
    Canceled,
}

sealed class ActivityRecordStatusConverter : JsonConverter<ActivityRecordStatus>
{
    public override ActivityRecordStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed" => ActivityRecordStatus.Completed,
            "running" => ActivityRecordStatus.Running,
            "failed" => ActivityRecordStatus.Failed,
            "canceled" => ActivityRecordStatus.Canceled,
            _ => (ActivityRecordStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivityRecordStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivityRecordStatus.Completed => "completed",
                ActivityRecordStatus.Running => "running",
                ActivityRecordStatus.Failed => "failed",
                ActivityRecordStatus.Canceled => "canceled",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ActivityRecordTimestamps, ActivityRecordTimestampsFromRaw>)
)]
public sealed record class ActivityRecordTimestamps : JsonModel
{
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    public DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completedAt", value);
        }
    }

    public DateTimeOffset? ConfirmedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("confirmedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confirmedAt", value);
        }
    }

    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expiresAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiresAt", value);
        }
    }

    public DateTimeOffset? OccurredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("occurredAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("occurredAt", value);
        }
    }

    public DateTimeOffset? DiscoveredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("discoveredAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discoveredAt", value);
        }
    }

    public DateTimeOffset? PostedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("postedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postedAt", value);
        }
    }

    public DateTimeOffset? FirstAttemptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("firstAttemptedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("firstAttemptedAt", value);
        }
    }

    public DateTimeOffset? DeliveredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("deliveredAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deliveredAt", value);
        }
    }

    public DateTimeOffset? NextRetryAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("nextRetryAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextRetryAt", value);
        }
    }

    public DateTimeOffset? ExhaustedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("exhaustedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exhaustedAt", value);
        }
    }

    public DateTimeOffset? DrawnAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("drawnAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("drawnAt", value);
        }
    }

    public DateTimeOffset? LastUsedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastUsedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastUsedAt", value);
        }
    }

    public DateTimeOffset? PausedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("pausedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pausedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
        _ = this.CompletedAt;
        _ = this.ConfirmedAt;
        _ = this.ExpiresAt;
        _ = this.OccurredAt;
        _ = this.DiscoveredAt;
        _ = this.PostedAt;
        _ = this.FirstAttemptedAt;
        _ = this.DeliveredAt;
        _ = this.NextRetryAt;
        _ = this.ExhaustedAt;
        _ = this.DrawnAt;
        _ = this.LastUsedAt;
        _ = this.PausedAt;
    }

    public ActivityRecordTimestamps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordTimestamps(ActivityRecordTimestamps activityRecordTimestamps)
        : base(activityRecordTimestamps) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordTimestamps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityRecordTimestamps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityRecordTimestampsFromRaw.FromRawUnchecked"/>
    public static ActivityRecordTimestamps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityRecordTimestampsFromRaw : IFromRawJson<ActivityRecordTimestamps>
{
    /// <inheritdoc/>
    public ActivityRecordTimestamps FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ActivityRecordTimestamps.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActivityRecordRequestMethodConverter))]
public enum ActivityRecordRequestMethod
{
    DELETE,
    PATCH,
    POST,
    PUT,
}

sealed class ActivityRecordRequestMethodConverter : JsonConverter<ActivityRecordRequestMethod>
{
    public override ActivityRecordRequestMethod Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DELETE" => ActivityRecordRequestMethod.DELETE,
            "PATCH" => ActivityRecordRequestMethod.PATCH,
            "POST" => ActivityRecordRequestMethod.POST,
            "PUT" => ActivityRecordRequestMethod.PUT,
            _ => (ActivityRecordRequestMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivityRecordRequestMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivityRecordRequestMethod.DELETE => "DELETE",
                ActivityRecordRequestMethod.PATCH => "PATCH",
                ActivityRecordRequestMethod.POST => "POST",
                ActivityRecordRequestMethod.PUT => "PUT",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ActivityRecordRequest, ActivityRecordRequestFromRaw>))]
public sealed record class ActivityRecordRequest : JsonModel
{
    public required ApiEnum<string, ActivityRecordRequestMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ActivityRecordRequestMethod>>(
                "method"
            );
        }
        init { this._rawData.Set("method", value); }
    }

    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public required long HttpStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("httpStatus");
        }
        init { this._rawData.Set("httpStatus", value); }
    }

    public required long DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("durationMs");
        }
        init { this._rawData.Set("durationMs", value); }
    }

    public required string? IpAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ipAddress");
        }
        init { this._rawData.Set("ipAddress", value); }
    }

    public required string? UserAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userAgent");
        }
        init { this._rawData.Set("userAgent", value); }
    }

    public required DateTimeOffset At
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("at");
        }
        init { this._rawData.Set("at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Method.Validate();
        _ = this.Path;
        _ = this.HttpStatus;
        _ = this.DurationMs;
        _ = this.IpAddress;
        _ = this.UserAgent;
        _ = this.At;
    }

    public ActivityRecordRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordRequest(ActivityRecordRequest activityRecordRequest)
        : base(activityRecordRequest) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityRecordRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityRecordRequestFromRaw.FromRawUnchecked"/>
    public static ActivityRecordRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityRecordRequestFromRaw : IFromRawJson<ActivityRecordRequest>
{
    /// <inheritdoc/>
    public ActivityRecordRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ActivityRecordRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActivityRecordCallerAuthMethodConverter))]
public enum ActivityRecordCallerAuthMethod
{
    ApiKey,
    Oauth,
    Session,
}

sealed class ActivityRecordCallerAuthMethodConverter : JsonConverter<ActivityRecordCallerAuthMethod>
{
    public override ActivityRecordCallerAuthMethod Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api_key" => ActivityRecordCallerAuthMethod.ApiKey,
            "oauth" => ActivityRecordCallerAuthMethod.Oauth,
            "session" => ActivityRecordCallerAuthMethod.Session,
            _ => (ActivityRecordCallerAuthMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivityRecordCallerAuthMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivityRecordCallerAuthMethod.ApiKey => "api_key",
                ActivityRecordCallerAuthMethod.Oauth => "oauth",
                ActivityRecordCallerAuthMethod.Session => "session",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ActivityRecordCallerApiKey, ActivityRecordCallerApiKeyFromRaw>)
)]
public sealed record class ActivityRecordCallerApiKey : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Prefix;
    }

    public ActivityRecordCallerApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordCallerApiKey(ActivityRecordCallerApiKey activityRecordCallerApiKey)
        : base(activityRecordCallerApiKey) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordCallerApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityRecordCallerApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityRecordCallerApiKeyFromRaw.FromRawUnchecked"/>
    public static ActivityRecordCallerApiKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityRecordCallerApiKeyFromRaw : IFromRawJson<ActivityRecordCallerApiKey>
{
    /// <inheritdoc/>
    public ActivityRecordCallerApiKey FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ActivityRecordCallerApiKey.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ActivityRecordCallerOauthClient,
        ActivityRecordCallerOauthClientFromRaw
    >)
)]
public sealed record class ActivityRecordCallerOauthClient : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public ActivityRecordCallerOauthClient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordCallerOauthClient(
        ActivityRecordCallerOauthClient activityRecordCallerOauthClient
    )
        : base(activityRecordCallerOauthClient) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordCallerOauthClient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityRecordCallerOauthClient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityRecordCallerOauthClientFromRaw.FromRawUnchecked"/>
    public static ActivityRecordCallerOauthClient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityRecordCallerOauthClientFromRaw : IFromRawJson<ActivityRecordCallerOauthClient>
{
    /// <inheritdoc/>
    public ActivityRecordCallerOauthClient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ActivityRecordCallerOauthClient.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActivityRecordCaller, ActivityRecordCallerFromRaw>))]
public sealed record class ActivityRecordCaller : JsonModel
{
    public required ApiEnum<string, ActivityRecordCallerAuthMethod>? AuthMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ActivityRecordCallerAuthMethod>>(
                "authMethod"
            );
        }
        init { this._rawData.Set("authMethod", value); }
    }

    /// <summary>
    /// Name and prefix of the API key used. Never its value.
    /// </summary>
    public required ActivityRecordCallerApiKey? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActivityRecordCallerApiKey>("apiKey");
        }
        init { this._rawData.Set("apiKey", value); }
    }

    public required ActivityRecordCallerOauthClient? OauthClient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActivityRecordCallerOauthClient>("oauthClient");
        }
        init { this._rawData.Set("oauthClient", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AuthMethod?.Validate();
        this.ApiKey?.Validate();
        this.OauthClient?.Validate();
    }

    public ActivityRecordCaller() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordCaller(ActivityRecordCaller activityRecordCaller)
        : base(activityRecordCaller) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordCaller(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityRecordCaller(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityRecordCallerFromRaw.FromRawUnchecked"/>
    public static ActivityRecordCaller FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityRecordCallerFromRaw : IFromRawJson<ActivityRecordCaller>
{
    /// <inheritdoc/>
    public ActivityRecordCaller FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ActivityRecordCaller.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActivityRecordCharge, ActivityRecordChargeFromRaw>))]
public sealed record class ActivityRecordCharge : JsonModel
{
    public required long Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("credits");
        }
        init { this._rawData.Set("credits", value); }
    }

    public required long BalanceAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("balanceAfter");
        }
        init { this._rawData.Set("balanceAfter", value); }
    }

    public required DateTimeOffset At
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("at");
        }
        init { this._rawData.Set("at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Credits;
        _ = this.BalanceAfter;
        _ = this.At;
    }

    public ActivityRecordCharge() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordCharge(ActivityRecordCharge activityRecordCharge)
        : base(activityRecordCharge) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordCharge(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityRecordCharge(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityRecordChargeFromRaw.FromRawUnchecked"/>
    public static ActivityRecordCharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityRecordChargeFromRaw : IFromRawJson<ActivityRecordCharge>
{
    /// <inheritdoc/>
    public ActivityRecordCharge FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ActivityRecordCharge.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActivityRecordRelatedStatusConverter))]
public enum ActivityRecordRelatedStatus
{
    Completed,
    Running,
    Failed,
    Canceled,
}

sealed class ActivityRecordRelatedStatusConverter : JsonConverter<ActivityRecordRelatedStatus>
{
    public override ActivityRecordRelatedStatus Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed" => ActivityRecordRelatedStatus.Completed,
            "running" => ActivityRecordRelatedStatus.Running,
            "failed" => ActivityRecordRelatedStatus.Failed,
            "canceled" => ActivityRecordRelatedStatus.Canceled,
            _ => (ActivityRecordRelatedStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivityRecordRelatedStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ActivityRecordRelatedStatus.Completed => "completed",
                ActivityRecordRelatedStatus.Running => "running",
                ActivityRecordRelatedStatus.Failed => "failed",
                ActivityRecordRelatedStatus.Canceled => "canceled",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ActivityRecordRelated, ActivityRecordRelatedFromRaw>))]
public sealed record class ActivityRecordRelated : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required ApiEnum<string, ActivityRecordRelatedStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ActivityRecordRelatedStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        this.Status.Validate();
        _ = this.CreatedAt;
        _ = this.UrlValue;
    }

    public ActivityRecordRelated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordRelated(ActivityRecordRelated activityRecordRelated)
        : base(activityRecordRelated) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecordRelated(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityRecordRelated(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityRecordRelatedFromRaw.FromRawUnchecked"/>
    public static ActivityRecordRelated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityRecordRelatedFromRaw : IFromRawJson<ActivityRecordRelated>
{
    /// <inheritdoc/>
    public ActivityRecordRelated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ActivityRecordRelated.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActivityRecord, ActivityRecordFromRaw>))]
public sealed record class ActivityRecord : JsonModel
{
    public required ApiEnum<string, ActivityRecordObject> Object
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ActivityRecordObject>>("object");
        }
        init { this._rawData.Set("object", value); }
    }

    /// <summary>
    /// Activity ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Kind of the activity. Only a signed-in dashboard session sees an `api_key` record.
    /// </summary>
    public required ApiEnum<string, ActivityRecordKind> Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ActivityRecordKind>>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// Type of the activity within its kind, the same as the type of its Activity log row. Examples are a write action type, an extraction tool type, a monitor change, a monitor event type or a ledger entry type.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required ApiEnum<string, ActivityRecordStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ActivityRecordStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Dashboard page of this activity.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// ID of the API request behind this activity.
    /// </summary>
    public required string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("requestId");
        }
        init { this._rawData.Set("requestId", value); }
    }

    public required ActivityRecordTimestamps Timestamps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ActivityRecordTimestamps>("timestamps");
        }
        init { this._rawData.Set("timestamps", value); }
    }

    /// <summary>
    /// The API request behind this activity. Null for activity from before Oct 30, 2026, and for activity no API request starts, such as a monitor event, a webhook delivery or a credit grant.
    /// </summary>
    public required ActivityRecordRequest? Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActivityRecordRequest>("request");
        }
        init { this._rawData.Set("request", value); }
    }

    public required ActivityRecordCaller Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ActivityRecordCaller>("caller");
        }
        init { this._rawData.Set("caller", value); }
    }

    /// <summary>
    /// Credits charged for this activity.
    /// </summary>
    public required ActivityRecordCharge? Charge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActivityRecordCharge>("charge");
        }
        init { this._rawData.Set("charge", value); }
    }

    /// <summary>
    /// Fields of this kind of activity, such as its target. A field can hold JSON, such as the data of a monitor event or the payload of a webhook delivery.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Details
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("details");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "details",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Up to 5 other activities on the same subject within 7 days, newest first.
    /// </summary>
    public required IReadOnlyList<ActivityRecordRelated> Related
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ActivityRecordRelated>>("related");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ActivityRecordRelated>>(
                "related",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Object.Validate();
        _ = this.ID;
        this.Kind.Validate();
        _ = this.Type;
        this.Status.Validate();
        _ = this.UrlValue;
        _ = this.RequestID;
        this.Timestamps.Validate();
        this.Request?.Validate();
        this.Caller.Validate();
        this.Charge?.Validate();
        _ = this.Details;
        foreach (var item in this.Related)
        {
            item.Validate();
        }
    }

    public ActivityRecord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecord(ActivityRecord activityRecord)
        : base(activityRecord) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivityRecord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivityRecord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActivityRecordFromRaw.FromRawUnchecked"/>
    public static ActivityRecord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ActivityRecordFromRaw : IFromRawJson<ActivityRecord>
{
    /// <inheritdoc/>
    public ActivityRecord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ActivityRecord.FromRawUnchecked(rawData);
}
