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

[JsonConverter(typeof(JsonModelConverter<TweetArticleMetadata, TweetArticleMetadataFromRaw>))]
public sealed record class TweetArticleMetadata : JsonModel
{
    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? CoverMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "coverMedia"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "coverMedia",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? LifecycleState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "lifecycleState"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "lifecycleState",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    public string? PreviewText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previewText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("previewText", value);
        }
    }

    public string? CoverMediaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("coverMediaUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("coverMediaUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CoverMedia;
        _ = this.ID;
        _ = this.LifecycleState;
        _ = this.Metadata;
        _ = this.Title;
        _ = this.PreviewText;
        _ = this.CoverMediaUrl;
    }

    public TweetArticleMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetArticleMetadata(TweetArticleMetadata tweetArticleMetadata)
        : base(tweetArticleMetadata) { }
#pragma warning restore CS8618

    public TweetArticleMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetArticleMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetArticleMetadataFromRaw.FromRawUnchecked"/>
    public static TweetArticleMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetArticleMetadataFromRaw : IFromRawJson<TweetArticleMetadata>
{
    /// <inheritdoc/>
    public TweetArticleMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetArticleMetadata.FromRawUnchecked(rawData);
}
