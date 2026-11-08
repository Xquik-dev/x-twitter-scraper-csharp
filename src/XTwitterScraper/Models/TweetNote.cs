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

[JsonConverter(typeof(JsonModelConverter<TweetNoteInlineMedia, TweetNoteInlineMediaFromRaw>))]
public sealed record class TweetNoteInlineMedia : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("index");
        }
        init { this._rawData.Set("index", value); }
    }

    public required string MediaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mediaId");
        }
        init { this._rawData.Set("mediaId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Index;
        _ = this.MediaID;
    }

    public TweetNoteInlineMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetNoteInlineMedia(TweetNoteInlineMedia tweetNoteInlineMedia)
        : base(tweetNoteInlineMedia) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetNoteInlineMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetNoteInlineMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetNoteInlineMediaFromRaw.FromRawUnchecked"/>
    public static TweetNoteInlineMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetNoteInlineMediaFromRaw : IFromRawJson<TweetNoteInlineMedia>
{
    /// <inheritdoc/>
    public TweetNoteInlineMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetNoteInlineMedia.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetNoteRichtextTags, TweetNoteRichtextTagsFromRaw>))]
public sealed record class TweetNoteRichtextTags : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long FromIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("fromIndex");
        }
        init { this._rawData.Set("fromIndex", value); }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long ToIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("toIndex");
        }
        init { this._rawData.Set("toIndex", value); }
    }

    public required IReadOnlyList<string> Types
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("types");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "types",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FromIndex;
        _ = this.ToIndex;
        _ = this.Types;
    }

    public TweetNoteRichtextTags() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetNoteRichtextTags(TweetNoteRichtextTags tweetNoteRichtextTags)
        : base(tweetNoteRichtextTags) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetNoteRichtextTags(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetNoteRichtextTags(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetNoteRichtextTagsFromRaw.FromRawUnchecked"/>
    public static TweetNoteRichtextTags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetNoteRichtextTagsFromRaw : IFromRawJson<TweetNoteRichtextTags>
{
    /// <inheritdoc/>
    public TweetNoteRichtextTags FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetNoteRichtextTags.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetNote, TweetNoteFromRaw>))]
public sealed record class TweetNote : JsonModel
{
    /// <summary>
    /// X's global ID of the Note, base64 of `NoteTweet:&lt;noteId&gt;`.
    /// </summary>
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
    /// The Note's own ID, apart from the post's.
    /// </summary>
    public string? NoteID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("noteId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("noteId", value);
        }
    }

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public bool? IsExpandable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isExpandable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isExpandable", value);
        }
    }

    /// <summary>
    /// Lists hashtags, symbols, links, and mentions from tweet text.
    /// </summary>
    public global::XTwitterScraper.Models.TweetEntities? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetEntities>(
                "entities"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entities", value);
        }
    }

    /// <summary>
    /// Inline media positions in the Note Tweet text.
    /// </summary>
    public IReadOnlyList<TweetNoteInlineMedia>? InlineMedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetNoteInlineMedia>>(
                "inlineMedia"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetNoteInlineMedia>?>(
                "inlineMedia",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<TweetNoteRichtextTags>? RichtextTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TweetNoteRichtextTags>>(
                "richtextTags"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetNoteRichtextTags>?>(
                "richtextTags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.NoteID;
        _ = this.Text;
        _ = this.IsExpandable;
        this.Entities?.Validate();
        foreach (var item in this.InlineMedia ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.RichtextTags ?? [])
        {
            item.Validate();
        }
    }

    public TweetNote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetNote(TweetNote tweetNote)
        : base(tweetNote) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetNoteFromRaw.FromRawUnchecked"/>
    public static TweetNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetNoteFromRaw : IFromRawJson<TweetNote>
{
    /// <inheritdoc/>
    public TweetNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetNote.FromRawUnchecked(rawData);
}
