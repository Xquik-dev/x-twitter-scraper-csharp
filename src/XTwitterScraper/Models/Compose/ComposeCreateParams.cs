using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models.Compose;

/// <summary>
/// Compose, refine, or score a tweet
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ComposeCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Workflow step
    /// </summary>
    public required ApiEnum<string, Step> Step
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Step>>("step");
        }
        init { this._rawBodyData.Set("step", value); }
    }

    /// <summary>
    /// Extra context or URLs (refine)
    /// </summary>
    public string? AdditionalContext
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("additionalContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("additionalContext", value);
        }
    }

    /// <summary>
    /// Desired call to action (refine)
    /// </summary>
    public string? CallToAction
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("callToAction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("callToAction", value);
        }
    }

    /// <summary>
    /// Tweet draft text to evaluate (score)
    /// </summary>
    public string? Draft
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("draft");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("draft", value);
        }
    }

    /// <summary>
    /// Optimization goal
    /// </summary>
    public ApiEnum<string, Goal>? Goal
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Goal>>("goal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("goal", value);
        }
    }

    /// <summary>
    /// Whether a link is attached (score)
    /// </summary>
    public bool? HasLink
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("hasLink");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hasLink", value);
        }
    }

    /// <summary>
    /// Whether media is attached (score)
    /// </summary>
    public bool? HasMedia
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("hasMedia");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("hasMedia", value);
        }
    }

    /// <summary>
    /// Media type (refine)
    /// </summary>
    public ApiEnum<string, MediaType>? MediaType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MediaType>>("mediaType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("mediaType", value);
        }
    }

    /// <summary>
    /// Cached style username for voice matching (compose)
    /// </summary>
    public string? StyleUsername
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("styleUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("styleUsername", value);
        }
    }

    /// <summary>
    /// Desired tone (refine)
    /// </summary>
    public string? Tone
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tone", value);
        }
    }

    /// <summary>
    /// Tweet topic (compose, refine)
    /// </summary>
    public string? Topic
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("topic");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("topic", value);
        }
    }

    public ComposeCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComposeCreateParams(ComposeCreateParams composeCreateParams)
        : base(composeCreateParams)
    {
        this._rawBodyData = new(composeCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ComposeCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComposeCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ComposeCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ComposeCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/compose")
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Workflow step
/// </summary>
[JsonConverter(typeof(StepConverter))]
public enum Step
{
    Compose,
    Refine,
    Score,
}

sealed class StepConverter : JsonConverter<Step>
{
    public override Step Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "compose" => Step.Compose,
            "refine" => Step.Refine,
            "score" => Step.Score,
            _ => (Step)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Step.Compose => "compose",
                Step.Refine => "refine",
                Step.Score => "score",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Optimization goal
/// </summary>
[JsonConverter(typeof(GoalConverter))]
public enum Goal
{
    Engagement,
    Followers,
    Authority,
    Conversation,
}

sealed class GoalConverter : JsonConverter<Goal>
{
    public override Goal Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "engagement" => Goal.Engagement,
            "followers" => Goal.Followers,
            "authority" => Goal.Authority,
            "conversation" => Goal.Conversation,
            _ => (Goal)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Goal.Engagement => "engagement",
                Goal.Followers => "followers",
                Goal.Authority => "authority",
                Goal.Conversation => "conversation",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Media type (refine)
/// </summary>
[JsonConverter(typeof(MediaTypeConverter))]
public enum MediaType
{
    Photo,
    Video,
    None,
}

sealed class MediaTypeConverter : JsonConverter<MediaType>
{
    public override MediaType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "photo" => MediaType.Photo,
            "video" => MediaType.Video,
            "none" => MediaType.None,
            _ => (MediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MediaType.Photo => "photo",
                MediaType.Video => "video",
                MediaType.None => "none",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
