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

[JsonConverter(
    typeof(JsonModelConverter<IntegrationCreateResponse, IntegrationCreateResponseFromRaw>)
)]
public sealed record class IntegrationCreateResponse : JsonModel
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

    public required IReadOnlyList<ApiEnum<string, IntegrationCreateResponseEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, IntegrationCreateResponseEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, IntegrationCreateResponseEventType>>>(
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

    public required ApiEnum<string, IntegrationCreateResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IntegrationCreateResponseType>>(
                "type"
            );
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

    public IntegrationCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationCreateResponse(IntegrationCreateResponse integrationCreateResponse)
        : base(integrationCreateResponse) { }
#pragma warning restore CS8618

    public IntegrationCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationCreateResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationCreateResponseFromRaw : IFromRawJson<IntegrationCreateResponse>
{
    /// <inheritdoc/>
    public IntegrationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IntegrationCreateResponseEventTypeConverter))]
public enum IntegrationCreateResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class IntegrationCreateResponseEventTypeConverter
    : JsonConverter<IntegrationCreateResponseEventType>
{
    public override IntegrationCreateResponseEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => IntegrationCreateResponseEventType.TweetNew,
            "tweet.reply" => IntegrationCreateResponseEventType.TweetReply,
            "tweet.retweet" => IntegrationCreateResponseEventType.TweetRetweet,
            "tweet.quote" => IntegrationCreateResponseEventType.TweetQuote,
            "follower.gained" => IntegrationCreateResponseEventType.FollowerGained,
            "follower.lost" => IntegrationCreateResponseEventType.FollowerLost,
            _ => (IntegrationCreateResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationCreateResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationCreateResponseEventType.TweetNew => "tweet.new",
                IntegrationCreateResponseEventType.TweetReply => "tweet.reply",
                IntegrationCreateResponseEventType.TweetRetweet => "tweet.retweet",
                IntegrationCreateResponseEventType.TweetQuote => "tweet.quote",
                IntegrationCreateResponseEventType.FollowerGained => "follower.gained",
                IntegrationCreateResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(IntegrationCreateResponseTypeConverter))]
public enum IntegrationCreateResponseType
{
    Telegram,
}

sealed class IntegrationCreateResponseTypeConverter : JsonConverter<IntegrationCreateResponseType>
{
    public override IntegrationCreateResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telegram" => IntegrationCreateResponseType.Telegram,
            _ => (IntegrationCreateResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationCreateResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationCreateResponseType.Telegram => "telegram",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
