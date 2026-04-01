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
    typeof(JsonModelConverter<IntegrationUpdateResponse, IntegrationUpdateResponseFromRaw>)
)]
public sealed record class IntegrationUpdateResponse : JsonModel
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

    public required IReadOnlyList<ApiEnum<string, IntegrationUpdateResponseEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, IntegrationUpdateResponseEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, IntegrationUpdateResponseEventType>>>(
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

    public required ApiEnum<string, IntegrationUpdateResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IntegrationUpdateResponseType>>(
                "type"
            );
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

    public IntegrationUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationUpdateResponse(IntegrationUpdateResponse integrationUpdateResponse)
        : base(integrationUpdateResponse) { }
#pragma warning restore CS8618

    public IntegrationUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationUpdateResponseFromRaw : IFromRawJson<IntegrationUpdateResponse>
{
    /// <inheritdoc/>
    public IntegrationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationUpdateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IntegrationUpdateResponseEventTypeConverter))]
public enum IntegrationUpdateResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class IntegrationUpdateResponseEventTypeConverter
    : JsonConverter<IntegrationUpdateResponseEventType>
{
    public override IntegrationUpdateResponseEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => IntegrationUpdateResponseEventType.TweetNew,
            "tweet.reply" => IntegrationUpdateResponseEventType.TweetReply,
            "tweet.retweet" => IntegrationUpdateResponseEventType.TweetRetweet,
            "tweet.quote" => IntegrationUpdateResponseEventType.TweetQuote,
            "follower.gained" => IntegrationUpdateResponseEventType.FollowerGained,
            "follower.lost" => IntegrationUpdateResponseEventType.FollowerLost,
            _ => (IntegrationUpdateResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationUpdateResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationUpdateResponseEventType.TweetNew => "tweet.new",
                IntegrationUpdateResponseEventType.TweetReply => "tweet.reply",
                IntegrationUpdateResponseEventType.TweetRetweet => "tweet.retweet",
                IntegrationUpdateResponseEventType.TweetQuote => "tweet.quote",
                IntegrationUpdateResponseEventType.FollowerGained => "follower.gained",
                IntegrationUpdateResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(IntegrationUpdateResponseTypeConverter))]
public enum IntegrationUpdateResponseType
{
    Telegram,
}

sealed class IntegrationUpdateResponseTypeConverter : JsonConverter<IntegrationUpdateResponseType>
{
    public override IntegrationUpdateResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telegram" => IntegrationUpdateResponseType.Telegram,
            _ => (IntegrationUpdateResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationUpdateResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationUpdateResponseType.Telegram => "telegram",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
