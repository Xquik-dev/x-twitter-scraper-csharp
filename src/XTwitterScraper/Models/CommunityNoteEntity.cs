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

[JsonConverter(typeof(JsonModelConverter<CommunityNoteEntityRef, CommunityNoteEntityRefFromRaw>))]
public sealed record class CommunityNoteEntityRef : JsonModel
{
    /// <summary>
    /// X's kind, such as TimelineUrl.
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

    /// <summary>
    /// The link.
    /// </summary>
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

    /// <summary>
    /// How X opens the link, such as ExternalUrl.
    /// </summary>
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

    /// <summary>
    /// A hashtag's or cashtag's text.
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
    /// A mentioned account's username.
    /// </summary>
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

    public CommunityNoteEntityRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNoteEntityRef(CommunityNoteEntityRef communityNoteEntityRef)
        : base(communityNoteEntityRef) { }
#pragma warning restore CS8618

    public CommunityNoteEntityRef(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNoteEntityRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNoteEntityRefFromRaw.FromRawUnchecked"/>
    public static CommunityNoteEntityRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNoteEntityRefFromRaw : IFromRawJson<CommunityNoteEntityRef>
{
    /// <inheritdoc/>
    public CommunityNoteEntityRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityNoteEntityRef.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CommunityNoteEntity, CommunityNoteEntityFromRaw>))]
public sealed record class CommunityNoteEntity : JsonModel
{
    /// <summary>
    /// Where it starts in the text.
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
    /// Where it ends in the text.
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

    /// <summary>
    /// What it points at.
    /// </summary>
    public CommunityNoteEntityRef? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityNoteEntityRef>("ref");
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

    public CommunityNoteEntity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNoteEntity(CommunityNoteEntity communityNoteEntity)
        : base(communityNoteEntity) { }
#pragma warning restore CS8618

    public CommunityNoteEntity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNoteEntity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNoteEntityFromRaw.FromRawUnchecked"/>
    public static CommunityNoteEntity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNoteEntityFromRaw : IFromRawJson<CommunityNoteEntity>
{
    /// <inheritdoc/>
    public CommunityNoteEntity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CommunityNoteEntity.FromRawUnchecked(rawData);
}
