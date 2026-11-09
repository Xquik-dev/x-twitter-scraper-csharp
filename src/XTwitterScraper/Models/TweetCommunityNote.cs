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

[JsonConverter(typeof(JsonModelConverter<TweetCommunityNote, TweetCommunityNoteFromRaw>))]
public sealed record class TweetCommunityNote : JsonModel
{
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

    public string? ShortTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shortTitle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shortTitle", value);
        }
    }

    public string? Subtitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subtitle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subtitle", value);
        }
    }

    public string? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("footer", value);
        }
    }

    public string? FooterIconType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footerIconType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("footerIconType", value);
        }
    }

    public string? DestinationUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destinationUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destinationUrl", value);
        }
    }

    public string? IconType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("iconType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("iconType", value);
        }
    }

    public string? VisualStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("visualStyle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("visualStyle", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Title;
        _ = this.ShortTitle;
        _ = this.Subtitle;
        _ = this.Footer;
        _ = this.FooterIconType;
        _ = this.DestinationUrl;
        _ = this.IconType;
        _ = this.VisualStyle;
        _ = this.Metadata;
    }

    public TweetCommunityNote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetCommunityNote(TweetCommunityNote tweetCommunityNote)
        : base(tweetCommunityNote) { }
#pragma warning restore CS8618

    public TweetCommunityNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetCommunityNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetCommunityNoteFromRaw.FromRawUnchecked"/>
    public static TweetCommunityNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetCommunityNoteFromRaw : IFromRawJson<TweetCommunityNote>
{
    /// <inheritdoc/>
    public TweetCommunityNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetCommunityNote.FromRawUnchecked(rawData);
}
