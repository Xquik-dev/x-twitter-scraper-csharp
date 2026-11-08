// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(TweetAnalysisSettingsPresetConverter))]
public enum TweetAnalysisSettingsPreset
{
    Brand,
    Complaints,
    Competitors,
    PurchaseIntent,
    ProductFeedback,
    News,
    Sentiment,
    Market,
    ViralLite,
}

sealed class TweetAnalysisSettingsPresetConverter : JsonConverter<TweetAnalysisSettingsPreset>
{
    public override TweetAnalysisSettingsPreset Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "brand" => TweetAnalysisSettingsPreset.Brand,
            "complaints" => TweetAnalysisSettingsPreset.Complaints,
            "competitors" => TweetAnalysisSettingsPreset.Competitors,
            "purchase_intent" => TweetAnalysisSettingsPreset.PurchaseIntent,
            "product_feedback" => TweetAnalysisSettingsPreset.ProductFeedback,
            "news" => TweetAnalysisSettingsPreset.News,
            "sentiment" => TweetAnalysisSettingsPreset.Sentiment,
            "market" => TweetAnalysisSettingsPreset.Market,
            "viral_lite" => TweetAnalysisSettingsPreset.ViralLite,
            _ => (TweetAnalysisSettingsPreset)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TweetAnalysisSettingsPreset value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TweetAnalysisSettingsPreset.Brand => "brand",
                TweetAnalysisSettingsPreset.Complaints => "complaints",
                TweetAnalysisSettingsPreset.Competitors => "competitors",
                TweetAnalysisSettingsPreset.PurchaseIntent => "purchase_intent",
                TweetAnalysisSettingsPreset.ProductFeedback => "product_feedback",
                TweetAnalysisSettingsPreset.News => "news",
                TweetAnalysisSettingsPreset.Sentiment => "sentiment",
                TweetAnalysisSettingsPreset.Market => "market",
                TweetAnalysisSettingsPreset.ViralLite => "viral_lite",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<TweetAnalysisSettingsTargets, TweetAnalysisSettingsTargetsFromRaw>)
)]
public sealed record class TweetAnalysisSettingsTargets : JsonModel
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

    public IReadOnlyList<string>? Aliases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("aliases");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "aliases",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Aliases;
    }

    public TweetAnalysisSettingsTargets() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSettingsTargets(TweetAnalysisSettingsTargets tweetAnalysisSettingsTargets)
        : base(tweetAnalysisSettingsTargets) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSettingsTargets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSettingsTargets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSettingsTargetsFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSettingsTargets FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSettingsTargetsFromRaw : IFromRawJson<TweetAnalysisSettingsTargets>
{
    /// <inheritdoc/>
    public TweetAnalysisSettingsTargets FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSettingsTargets.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetAnalysisSettings, TweetAnalysisSettingsFromRaw>))]
public sealed record class TweetAnalysisSettings : JsonModel
{
    /// <summary>
    /// Your own questions, which replace the route's questions. Write question IDs &amp; category names in lower case without hyphens.
    /// </summary>
    public IReadOnlyList<global::XTwitterScraper.Models.TweetAnalysisQuestion>? Questions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetAnalysisQuestion>
            >("questions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetAnalysisQuestion>?>(
                "questions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A ready set of questions, used when questions is left out. complaints, competitors, purchase_intent &amp; product_feedback need targets. viral_lite scores how viral the wording reads.
    /// </summary>
    public ApiEnum<string, TweetAnalysisSettingsPreset>? Preset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TweetAnalysisSettingsPreset>>(
                "preset"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preset", value);
        }
    }

    /// <summary>
    /// Brands, people, assets or topics the questions are about, each with its aliases.
    /// </summary>
    public IReadOnlyList<TweetAnalysisSettingsTargets>? Targets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetAnalysisSettingsTargets>>(
                "targets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetAnalysisSettingsTargets>?>(
                "targets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Background the AI reads with every post.
    /// </summary>
    public string? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("context");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("context", value);
        }
    }

    /// <summary>
    /// Bytes of post, quote &amp; settings the AI reads. Xquik cuts longer posts to fit. Empty settings take 219 bytes, so a smaller value gets a 400.
    /// </summary>
    public long? MaxContextBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxContextBytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxContextBytes", value);
        }
    }

    /// <summary>
    /// Posts analyzed at the same time.
    /// </summary>
    public long? Concurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("concurrency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("concurrency", value);
        }
    }

    /// <summary>
    /// Reads up to 4 images per post with its text, at no extra cost. Images of posts X marks sensitive stay unread. Send false to analyze the text alone.
    /// </summary>
    public bool? Images
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("images");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("images", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Questions ?? [])
        {
            item.Validate();
        }
        this.Preset?.Validate();
        foreach (var item in this.Targets ?? [])
        {
            item.Validate();
        }
        _ = this.Context;
        _ = this.MaxContextBytes;
        _ = this.Concurrency;
        _ = this.Images;
    }

    public TweetAnalysisSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAnalysisSettings(TweetAnalysisSettings tweetAnalysisSettings)
        : base(tweetAnalysisSettings) { }
#pragma warning restore CS8618

    public TweetAnalysisSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAnalysisSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAnalysisSettingsFromRaw.FromRawUnchecked"/>
    public static TweetAnalysisSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAnalysisSettingsFromRaw : IFromRawJson<TweetAnalysisSettings>
{
    /// <inheritdoc/>
    public TweetAnalysisSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAnalysisSettings.FromRawUnchecked(rawData);
}
