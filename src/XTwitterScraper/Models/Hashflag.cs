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

namespace XTwitterScraper.Models;

[JsonConverter(typeof(JsonModelConverter<HashflagAnimations, HashflagAnimationsFromRaw>))]
public sealed record class HashflagAnimations : JsonModel
{
    /// <summary>
    /// What plays the animation, such as Like.
    /// </summary>
    public required string? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("context");
        }
        init { this._rawData.Set("context", value); }
    }

    /// <summary>
    /// Animation file.
    /// </summary>
    public required string AssetUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("assetUrl");
        }
        init { this._rawData.Set("assetUrl", value); }
    }

    /// <summary>
    /// X's order among the animations of a hashtag.
    /// </summary>
    public required double? Priority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("priority");
        }
        init { this._rawData.Set("priority", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Context;
        _ = this.AssetUrl;
        _ = this.Priority;
    }

    public HashflagAnimations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HashflagAnimations(HashflagAnimations hashflagAnimations)
        : base(hashflagAnimations) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HashflagAnimations(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HashflagAnimations(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HashflagAnimationsFromRaw.FromRawUnchecked"/>
    public static HashflagAnimations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HashflagAnimationsFromRaw : IFromRawJson<HashflagAnimations>
{
    /// <inheritdoc/>
    public HashflagAnimations FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HashflagAnimations.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Hashflag, HashflagFromRaw>))]
public sealed record class Hashflag : JsonModel
{
    /// <summary>
    /// Hashtag text without the hash sign. X also lists some plain phrases.
    /// </summary>
    public required string Hashtag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("hashtag");
        }
        init { this._rawData.Set("hashtag", value); }
    }

    /// <summary>
    /// Image of the emoji.
    /// </summary>
    public required string AssetUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("assetUrl");
        }
        init { this._rawData.Set("assetUrl", value); }
    }

    /// <summary>
    /// When X starts showing the emoji, in UTC.
    /// </summary>
    public required DateTimeOffset StartsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("startsAt");
        }
        init { this._rawData.Set("startsAt", value); }
    }

    /// <summary>
    /// When X stops showing the emoji, in UTC.
    /// </summary>
    public required DateTimeOffset EndsAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("endsAt");
        }
        init { this._rawData.Set("endsAt", value); }
    }

    /// <summary>
    /// Whether X marks the hashflag for its hashfetti effect.
    /// </summary>
    public required bool IsHashfettiEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isHashfettiEnabled");
        }
        init { this._rawData.Set("isHashfettiEnabled", value); }
    }

    /// <summary>
    /// Animations X plays for the hashtag, such as on a like. Often empty.
    /// </summary>
    public required IReadOnlyList<HashflagAnimations> Animations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<HashflagAnimations>>("animations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<HashflagAnimations>>(
                "animations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Hashtag;
        _ = this.AssetUrl;
        _ = this.StartsAt;
        _ = this.EndsAt;
        _ = this.IsHashfettiEnabled;
        foreach (var item in this.Animations)
        {
            item.Validate();
        }
    }

    public Hashflag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Hashflag(Hashflag hashflag)
        : base(hashflag) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Hashflag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Hashflag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HashflagFromRaw.FromRawUnchecked"/>
    public static Hashflag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HashflagFromRaw : IFromRawJson<Hashflag>
{
    /// <inheritdoc/>
    public Hashflag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Hashflag.FromRawUnchecked(rawData);
}
