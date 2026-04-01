using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using System = System;

namespace XTwitterScraper.Models.Integrations;

[JsonConverter(typeof(JsonModelConverter<IntegrationListResponse, IntegrationListResponseFromRaw>))]
public sealed record class IntegrationListResponse : JsonModel
{
    public required IReadOnlyList<IntegrationListResponseIntegration> Integrations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<IntegrationListResponseIntegration>
            >("integrations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<IntegrationListResponseIntegration>>(
                "integrations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Integrations)
        {
            item.Validate();
        }
    }

    public IntegrationListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationListResponse(IntegrationListResponse integrationListResponse)
        : base(integrationListResponse) { }
#pragma warning restore CS8618

    public IntegrationListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationListResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntegrationListResponse(IReadOnlyList<IntegrationListResponseIntegration> integrations)
        : this()
    {
        this.Integrations = integrations;
    }
}

class IntegrationListResponseFromRaw : IFromRawJson<IntegrationListResponse>
{
    /// <inheritdoc/>
    public IntegrationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        IntegrationListResponseIntegration,
        IntegrationListResponseIntegrationFromRaw
    >)
)]
public sealed record class IntegrationListResponseIntegration : JsonModel
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

    public required IReadOnlyDictionary<string, JsonElement> Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("config");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "config",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required IReadOnlyList<
        ApiEnum<string, IntegrationListResponseIntegrationEventType>
    > EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, IntegrationListResponseIntegrationEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, IntegrationListResponseIntegrationEventType>>
            >("eventTypes", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isActive");
        }
        init { this._rawData.Set("isActive", value); }
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

    public required ApiEnum<string, IntegrationListResponseIntegrationType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, IntegrationListResponseIntegrationType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("filters");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "filters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? MessageTemplate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("messageTemplate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("messageTemplate", value);
        }
    }

    public bool? ScopeAllMonitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("scopeAllMonitors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scopeAllMonitors", value);
        }
    }

    public bool? SilentPush
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("silentPush");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("silentPush", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Config;
        _ = this.CreatedAt;
        foreach (var item in this.EventTypes)
        {
            item.Validate();
        }
        _ = this.IsActive;
        _ = this.Name;
        this.Type.Validate();
        _ = this.Filters;
        _ = this.MessageTemplate;
        _ = this.ScopeAllMonitors;
        _ = this.SilentPush;
    }

    public IntegrationListResponseIntegration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationListResponseIntegration(
        IntegrationListResponseIntegration integrationListResponseIntegration
    )
        : base(integrationListResponseIntegration) { }
#pragma warning restore CS8618

    public IntegrationListResponseIntegration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationListResponseIntegration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationListResponseIntegrationFromRaw.FromRawUnchecked"/>
    public static IntegrationListResponseIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationListResponseIntegrationFromRaw : IFromRawJson<IntegrationListResponseIntegration>
{
    /// <inheritdoc/>
    public IntegrationListResponseIntegration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationListResponseIntegration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IntegrationListResponseIntegrationEventTypeConverter))]
public enum IntegrationListResponseIntegrationEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class IntegrationListResponseIntegrationEventTypeConverter
    : JsonConverter<IntegrationListResponseIntegrationEventType>
{
    public override IntegrationListResponseIntegrationEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => IntegrationListResponseIntegrationEventType.TweetNew,
            "tweet.reply" => IntegrationListResponseIntegrationEventType.TweetReply,
            "tweet.retweet" => IntegrationListResponseIntegrationEventType.TweetRetweet,
            "tweet.quote" => IntegrationListResponseIntegrationEventType.TweetQuote,
            "follower.gained" => IntegrationListResponseIntegrationEventType.FollowerGained,
            "follower.lost" => IntegrationListResponseIntegrationEventType.FollowerLost,
            _ => (IntegrationListResponseIntegrationEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationListResponseIntegrationEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationListResponseIntegrationEventType.TweetNew => "tweet.new",
                IntegrationListResponseIntegrationEventType.TweetReply => "tweet.reply",
                IntegrationListResponseIntegrationEventType.TweetRetweet => "tweet.retweet",
                IntegrationListResponseIntegrationEventType.TweetQuote => "tweet.quote",
                IntegrationListResponseIntegrationEventType.FollowerGained => "follower.gained",
                IntegrationListResponseIntegrationEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(IntegrationListResponseIntegrationTypeConverter))]
public enum IntegrationListResponseIntegrationType
{
    Telegram,
}

sealed class IntegrationListResponseIntegrationTypeConverter
    : JsonConverter<IntegrationListResponseIntegrationType>
{
    public override IntegrationListResponseIntegrationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telegram" => IntegrationListResponseIntegrationType.Telegram,
            _ => (IntegrationListResponseIntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationListResponseIntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationListResponseIntegrationType.Telegram => "telegram",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
