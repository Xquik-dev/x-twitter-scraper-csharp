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

namespace XTwitterScraper.Models;

[JsonConverter(
    typeof(JsonModelConverter<TweetTombstoneTextEntitiesRef, TweetTombstoneTextEntitiesRefFromRaw>)
)]
public sealed record class TweetTombstoneTextEntitiesRef : JsonModel
{
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public string? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    public string? UrlType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("urlType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("urlType", value);
        }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public string? ScreenName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("screenName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("screenName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.UrlValue;
        _ = this.UrlType;
        _ = this.Text;
        _ = this.ScreenName;
    }

    public TweetTombstoneTextEntitiesRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetTombstoneTextEntitiesRef(
        TweetTombstoneTextEntitiesRef tweetTombstoneTextEntitiesRef
    )
        : base(tweetTombstoneTextEntitiesRef) { }
#pragma warning restore CS8618

    public TweetTombstoneTextEntitiesRef(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetTombstoneTextEntitiesRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetTombstoneTextEntitiesRefFromRaw.FromRawUnchecked"/>
    public static TweetTombstoneTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetTombstoneTextEntitiesRefFromRaw : IFromRawJson<TweetTombstoneTextEntitiesRef>
{
    /// <inheritdoc/>
    public TweetTombstoneTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetTombstoneTextEntitiesRef.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetTombstoneTextEntities, TweetTombstoneTextEntitiesFromRaw>)
)]
public sealed record class TweetTombstoneTextEntities : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? FromIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fromIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fromIndex", value);
        }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? ToIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("toIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("toIndex", value);
        }
    }

    public TweetTombstoneTextEntitiesRef? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetTombstoneTextEntitiesRef>("ref");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ref", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FromIndex;
        _ = this.ToIndex;
        this.Ref?.Validate();
    }

    public TweetTombstoneTextEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetTombstoneTextEntities(TweetTombstoneTextEntities tweetTombstoneTextEntities)
        : base(tweetTombstoneTextEntities) { }
#pragma warning restore CS8618

    public TweetTombstoneTextEntities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetTombstoneTextEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetTombstoneTextEntitiesFromRaw.FromRawUnchecked"/>
    public static TweetTombstoneTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetTombstoneTextEntitiesFromRaw : IFromRawJson<TweetTombstoneTextEntities>
{
    /// <inheritdoc/>
    public TweetTombstoneTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetTombstoneTextEntities.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetTombstoneText, TweetTombstoneTextFromRaw>))]
public sealed record class TweetTombstoneText : JsonModel
{
    /// <summary>
    /// Human-readable notice text.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// Right-to-left text direction.
    /// </summary>
    public bool? Rtl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("rtl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rtl", value);
        }
    }

    public IReadOnlyList<TweetTombstoneTextEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetTombstoneTextEntities>>(
                "entities"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetTombstoneTextEntities>?>(
                "entities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Rtl;
        foreach (var item in this.Entities ?? [])
        {
            item.Validate();
        }
    }

    public TweetTombstoneText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetTombstoneText(TweetTombstoneText tweetTombstoneText)
        : base(tweetTombstoneText) { }
#pragma warning restore CS8618

    public TweetTombstoneText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetTombstoneText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetTombstoneTextFromRaw.FromRawUnchecked"/>
    public static TweetTombstoneText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetTombstoneTextFromRaw : IFromRawJson<TweetTombstoneText>
{
    /// <inheritdoc/>
    public TweetTombstoneText FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetTombstoneText.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetTombstone, TweetTombstoneFromRaw>))]
public sealed record class TweetTombstone : JsonModel
{
    /// <summary>
    /// Visibility notice type.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public TweetTombstoneText? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetTombstoneText>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        this.Text?.Validate();
    }

    public TweetTombstone() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetTombstone(TweetTombstone tweetTombstone)
        : base(tweetTombstone) { }
#pragma warning restore CS8618

    public TweetTombstone(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetTombstone(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetTombstoneFromRaw.FromRawUnchecked"/>
    public static TweetTombstone FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetTombstoneFromRaw : IFromRawJson<TweetTombstone>
{
    /// <inheritdoc/>
    public TweetTombstone FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetTombstone.FromRawUnchecked(rawData);
}
