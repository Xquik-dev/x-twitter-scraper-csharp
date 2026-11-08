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

[JsonConverter(
    typeof(JsonModelConverter<CommunityNote2PostUnavailable, CommunityNote2PostUnavailableFromRaw>)
)]
public sealed record class CommunityNote2PostUnavailable : JsonModel
{
    /// <summary>
    /// Why X shows no post, as X names it.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
    }

    public CommunityNote2PostUnavailable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNote2PostUnavailable(
        CommunityNote2PostUnavailable communityNote2PostUnavailable
    )
        : base(communityNote2PostUnavailable) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNote2PostUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNote2PostUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNote2PostUnavailableFromRaw.FromRawUnchecked"/>
    public static CommunityNote2PostUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNote2PostUnavailableFromRaw : IFromRawJson<CommunityNote2PostUnavailable>
{
    /// <inheritdoc/>
    public CommunityNote2PostUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityNote2PostUnavailable.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CommunityNote2, CommunityNote2FromRaw>))]
public sealed record class CommunityNote2 : JsonModel
{
    /// <summary>
    /// Note ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// When the contributor wrote the note.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Language code of the note.
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// What the writer says of the post, such as MisinformedOrPotentiallyMisleading or NotMisleading.
    /// </summary>
    public string? Classification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("classification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("classification", value);
        }
    }

    /// <summary>
    /// What the note says.
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
    /// The note's writer, with the counts X sends beside a note. GET /x/community-notes/contributors/{alias} serves every count.
    /// </summary>
    public global::XTwitterScraper.Models.CommunityNotesContributor? Contributor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.CommunityNotesContributor>(
                "contributor"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contributor", value);
        }
    }

    /// <summary>
    /// Links, tags &amp; accounts inside the text, by character range.
    /// </summary>
    public IReadOnlyList<global::XTwitterScraper.Models.CommunityNoteEntity>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.CommunityNoteEntity>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.CommunityNoteEntity>?>(
                "entities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// X's current rating, such as NeedsMoreRatings, CurrentlyRatedHelpful or CurrentlyRatedNotHelpful. x.com shows only helpful notes under posts.
    /// </summary>
    public string? RatingStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ratingStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ratingStatus", value);
        }
    }

    /// <summary>
    /// Why raters called the note helpful.
    /// </summary>
    public IReadOnlyList<string>? HelpfulTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("helpfulTags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "helpfulTags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Why raters called the note not helpful.
    /// </summary>
    public IReadOnlyList<string>? NotHelpfulTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("notHelpfulTags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "notHelpfulTags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The X scoring model that set the rating.
    /// </summary>
    public string? DecidedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("decidedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("decidedBy", value);
        }
    }

    /// <summary>
    /// Whether X marks that scoring model as fully visible.
    /// </summary>
    public bool? FullyVisibleModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("fullyVisibleModel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fullyVisibleModel", value);
        }
    }

    /// <summary>
    /// Whether the note scores above X's bar for a possible helpful rating.
    /// </summary>
    public bool? AbovePcrhThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("abovePcrhThreshold");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("abovePcrhThreshold", value);
        }
    }

    /// <summary>
    /// Whether the rating is under appeal.
    /// </summary>
    public string? AppealStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("appealStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("appealStatus", value);
        }
    }

    /// <summary>
    /// Whether the writer deleted the note.
    /// </summary>
    public bool? Deleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("deleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deleted", value);
        }
    }

    /// <summary>
    /// X's notice in place of a deleted note.
    /// </summary>
    public string? Tombstone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tombstone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tombstone", value);
        }
    }

    /// <summary>
    /// Whether the note came through X's API.
    /// </summary>
    public bool? IsApiAuthor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isApiAuthor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isApiAuthor", value);
        }
    }

    /// <summary>
    /// Whether the note is about the post's media. X can show such a note on other posts.
    /// </summary>
    public bool? IsMediaNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isMediaNote");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isMediaNote", value);
        }
    }

    /// <summary>
    /// Other posts X matched a media note to.
    /// </summary>
    public long? MediaNoteMatchCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("mediaNoteMatchCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaNoteMatchCount", value);
        }
    }

    /// <summary>
    /// Whether the note is on a link.
    /// </summary>
    public bool? IsUrlNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isUrlNote");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isUrlNote", value);
        }
    }

    /// <summary>
    /// The link a link note is on, as X shows it.
    /// </summary>
    public string? DisplayUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayUrl", value);
        }
    }

    /// <summary>
    /// Whether X offers a translation of the note.
    /// </summary>
    public bool? IsTranslatable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTranslatable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTranslatable", value);
        }
    }

    /// <summary>
    /// Milliseconds from the note's creation to its helpful rating.
    /// </summary>
    public long? TimeToHelpfulFromNoteMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timeToHelpfulFromNoteMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeToHelpfulFromNoteMs", value);
        }
    }

    /// <summary>
    /// Milliseconds from the post's creation to the note's helpful rating.
    /// </summary>
    public long? TimeToHelpfulFromPostMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timeToHelpfulFromPostMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeToHelpfulFromPostMs", value);
        }
    }

    /// <summary>
    /// Views of the note, when X shares them.
    /// </summary>
    public long? ImpressionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("impressionCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("impressionCount", value);
        }
    }

    /// <summary>
    /// ID of the post the note is on.
    /// </summary>
    public string? PostID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postId", value);
        }
    }

    /// <summary>
    /// The post the note is on. Null when X no longer shows it.
    /// </summary>
    public global::XTwitterScraper.Models.SearchTweet2? Post
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.SearchTweet2>(
                "post"
            );
        }
        init { this._rawData.Set("post", value); }
    }

    /// <summary>
    /// Why X shows no post, when X says.
    /// </summary>
    public CommunityNote2PostUnavailable? PostUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityNote2PostUnavailable>("postUnavailable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postUnavailable", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Language;
        _ = this.Classification;
        _ = this.Text;
        this.Contributor?.Validate();
        foreach (var item in this.Entities ?? [])
        {
            item.Validate();
        }
        _ = this.RatingStatus;
        _ = this.HelpfulTags;
        _ = this.NotHelpfulTags;
        _ = this.DecidedBy;
        _ = this.FullyVisibleModel;
        _ = this.AbovePcrhThreshold;
        _ = this.AppealStatus;
        _ = this.Deleted;
        _ = this.Tombstone;
        _ = this.IsApiAuthor;
        _ = this.IsMediaNote;
        _ = this.MediaNoteMatchCount;
        _ = this.IsUrlNote;
        _ = this.DisplayUrl;
        _ = this.IsTranslatable;
        _ = this.TimeToHelpfulFromNoteMs;
        _ = this.TimeToHelpfulFromPostMs;
        _ = this.ImpressionCount;
        _ = this.PostID;
        this.Post?.Validate();
        this.PostUnavailable?.Validate();
    }

    public CommunityNote2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNote2(CommunityNote2 communityNote2)
        : base(communityNote2) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityNote2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityNote2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityNote2FromRaw.FromRawUnchecked"/>
    public static CommunityNote2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityNote2FromRaw : IFromRawJson<CommunityNote2>
{
    /// <inheritdoc/>
    public CommunityNote2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CommunityNote2.FromRawUnchecked(rawData);
}
