// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

/// <summary>
/// Content disclosure metadata shown by X when a tweet is labeled as paid partnership
/// content or AI-generated media.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContentDisclosure, ContentDisclosureFromRaw>))]
public sealed record class ContentDisclosure : JsonModel
{
    public Advertising? Advertising
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Advertising>("advertising");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("advertising", value);
        }
    }

    public AIGenerated? AIGenerated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AIGenerated>("aiGenerated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiGenerated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Advertising?.Validate();
        this.AIGenerated?.Validate();
    }

    public ContentDisclosure() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContentDisclosure(ContentDisclosure contentDisclosure)
        : base(contentDisclosure) { }
#pragma warning restore CS8618

    public ContentDisclosure(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContentDisclosure(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContentDisclosureFromRaw.FromRawUnchecked"/>
    public static ContentDisclosure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContentDisclosureFromRaw : IFromRawJson<ContentDisclosure>
{
    /// <inheritdoc/>
    public ContentDisclosure FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContentDisclosure.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Advertising, AdvertisingFromRaw>))]
public sealed record class Advertising : JsonModel
{
    /// <summary>
    /// True when X labels the tweet as paid promotion content.
    /// </summary>
    public bool? IsPaidPromotion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPaidPromotion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPaidPromotion", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsPaidPromotion;
    }

    public Advertising() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Advertising(Advertising advertising)
        : base(advertising) { }
#pragma warning restore CS8618

    public Advertising(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Advertising(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AdvertisingFromRaw.FromRawUnchecked"/>
    public static Advertising FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdvertisingFromRaw : IFromRawJson<Advertising>
{
    /// <inheritdoc/>
    public Advertising FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Advertising.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AIGenerated, AIGeneratedFromRaw>))]
public sealed record class AIGenerated : JsonModel
{
    /// <summary>
    /// Whether the disclosure can be edited on X.
    /// </summary>
    public bool? CanEdit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("canEdit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("canEdit", value);
        }
    }

    /// <summary>
    /// Source of the AI-generated media disclosure.
    /// </summary>
    public string? DetectionSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("detectionSource");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("detectionSource", value);
        }
    }

    /// <summary>
    /// True when X labels the tweet as containing AI-generated media.
    /// </summary>
    public bool? HasAIGeneratedMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasAiGeneratedMedia");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasAiGeneratedMedia", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanEdit;
        _ = this.DetectionSource;
        _ = this.HasAIGeneratedMedia;
    }

    public AIGenerated() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AIGenerated(AIGenerated aiGenerated)
        : base(aiGenerated) { }
#pragma warning restore CS8618

    public AIGenerated(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AIGenerated(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AIGeneratedFromRaw.FromRawUnchecked"/>
    public static AIGenerated FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AIGeneratedFromRaw : IFromRawJson<AIGenerated>
{
    /// <inheritdoc/>
    public AIGenerated FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AIGenerated.FromRawUnchecked(rawData);
}
