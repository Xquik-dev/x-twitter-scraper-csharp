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

[JsonConverter(typeof(JsonModelConverter<Integration, IntegrationFromRaw>))]
public sealed record class Integration : JsonModel
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

    /// <summary>
    /// Integration config — shape varies by type (JSON)
    /// </summary>
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

    public required IReadOnlyList<ApiEnum<string, IntegrationEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, IntegrationEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, IntegrationEventType>>>(
                "eventTypes",
                ImmutableArray.ToImmutableArray(value)
            );
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

    public required ApiEnum<string, IntegrationType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IntegrationType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Event filter rules (JSON)
    /// </summary>
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

    public Integration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Integration(Integration integration)
        : base(integration) { }
#pragma warning restore CS8618

    public Integration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Integration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationFromRaw.FromRawUnchecked"/>
    public static Integration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationFromRaw : IFromRawJson<Integration>
{
    /// <inheritdoc/>
    public Integration FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Integration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IntegrationEventTypeConverter))]
public enum IntegrationEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class IntegrationEventTypeConverter : JsonConverter<IntegrationEventType>
{
    public override IntegrationEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => IntegrationEventType.TweetNew,
            "tweet.reply" => IntegrationEventType.TweetReply,
            "tweet.retweet" => IntegrationEventType.TweetRetweet,
            "tweet.quote" => IntegrationEventType.TweetQuote,
            "follower.gained" => IntegrationEventType.FollowerGained,
            "follower.lost" => IntegrationEventType.FollowerLost,
            _ => (IntegrationEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationEventType.TweetNew => "tweet.new",
                IntegrationEventType.TweetReply => "tweet.reply",
                IntegrationEventType.TweetRetweet => "tweet.retweet",
                IntegrationEventType.TweetQuote => "tweet.quote",
                IntegrationEventType.FollowerGained => "follower.gained",
                IntegrationEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(IntegrationTypeConverter))]
public enum IntegrationType
{
    Telegram,
}

sealed class IntegrationTypeConverter : JsonConverter<IntegrationType>
{
    public override IntegrationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telegram" => IntegrationType.Telegram,
            _ => (IntegrationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationType.Telegram => "telegram",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
