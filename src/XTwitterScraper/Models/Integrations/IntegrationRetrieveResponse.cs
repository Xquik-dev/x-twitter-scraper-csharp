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
    typeof(JsonModelConverter<IntegrationRetrieveResponse, IntegrationRetrieveResponseFromRaw>)
)]
public sealed record class IntegrationRetrieveResponse : JsonModel
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

    public required IReadOnlyList<ApiEnum<string, IntegrationRetrieveResponseEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, IntegrationRetrieveResponseEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, IntegrationRetrieveResponseEventType>>
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

    public required ApiEnum<string, IntegrationRetrieveResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IntegrationRetrieveResponseType>>(
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

    public IntegrationRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationRetrieveResponse(IntegrationRetrieveResponse integrationRetrieveResponse)
        : base(integrationRetrieveResponse) { }
#pragma warning restore CS8618

    public IntegrationRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntegrationRetrieveResponseFromRaw : IFromRawJson<IntegrationRetrieveResponse>
{
    /// <inheritdoc/>
    public IntegrationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntegrationRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IntegrationRetrieveResponseEventTypeConverter))]
public enum IntegrationRetrieveResponseEventType
{
    TweetNew,
    TweetReply,
    TweetRetweet,
    TweetQuote,
    FollowerGained,
    FollowerLost,
}

sealed class IntegrationRetrieveResponseEventTypeConverter
    : JsonConverter<IntegrationRetrieveResponseEventType>
{
    public override IntegrationRetrieveResponseEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tweet.new" => IntegrationRetrieveResponseEventType.TweetNew,
            "tweet.reply" => IntegrationRetrieveResponseEventType.TweetReply,
            "tweet.retweet" => IntegrationRetrieveResponseEventType.TweetRetweet,
            "tweet.quote" => IntegrationRetrieveResponseEventType.TweetQuote,
            "follower.gained" => IntegrationRetrieveResponseEventType.FollowerGained,
            "follower.lost" => IntegrationRetrieveResponseEventType.FollowerLost,
            _ => (IntegrationRetrieveResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationRetrieveResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationRetrieveResponseEventType.TweetNew => "tweet.new",
                IntegrationRetrieveResponseEventType.TweetReply => "tweet.reply",
                IntegrationRetrieveResponseEventType.TweetRetweet => "tweet.retweet",
                IntegrationRetrieveResponseEventType.TweetQuote => "tweet.quote",
                IntegrationRetrieveResponseEventType.FollowerGained => "follower.gained",
                IntegrationRetrieveResponseEventType.FollowerLost => "follower.lost",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(IntegrationRetrieveResponseTypeConverter))]
public enum IntegrationRetrieveResponseType
{
    Telegram,
}

sealed class IntegrationRetrieveResponseTypeConverter
    : JsonConverter<IntegrationRetrieveResponseType>
{
    public override IntegrationRetrieveResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telegram" => IntegrationRetrieveResponseType.Telegram,
            _ => (IntegrationRetrieveResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntegrationRetrieveResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntegrationRetrieveResponseType.Telegram => "telegram",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
