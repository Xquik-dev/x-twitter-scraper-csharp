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
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Models;

[JsonConverter(typeof(PostMonitorAuthorVerifiedConverter))]
public enum PostMonitorAuthorVerified
{
    Blue,
    Business,
    Government,
}

sealed class PostMonitorAuthorVerifiedConverter : JsonConverter<PostMonitorAuthorVerified>
{
    public override PostMonitorAuthorVerified Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "blue" => PostMonitorAuthorVerified.Blue,
            "business" => PostMonitorAuthorVerified.Business,
            "government" => PostMonitorAuthorVerified.Government,
            _ => (PostMonitorAuthorVerified)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PostMonitorAuthorVerified value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PostMonitorAuthorVerified.Blue => "blue",
                PostMonitorAuthorVerified.Business => "business",
                PostMonitorAuthorVerified.Government => "government",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<PostMonitorAuthorAffiliate, PostMonitorAuthorAffiliateFromRaw>)
)]
public sealed record class PostMonitorAuthorAffiliate : JsonModel
{
    /// <summary>
    /// The organization's badge image.
    /// </summary>
    public required string BadgeUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("badgeUrl");
        }
        init { this._rawData.Set("badgeUrl", value); }
    }

    /// <summary>
    /// The organization's name, as X shows it.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The organization's X profile, when X links one.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BadgeUrl;
        _ = this.Description;
        _ = this.UrlValue;
    }

    public PostMonitorAuthorAffiliate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorAuthorAffiliate(PostMonitorAuthorAffiliate postMonitorAuthorAffiliate)
        : base(postMonitorAuthorAffiliate) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorAuthorAffiliate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMonitorAuthorAffiliate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMonitorAuthorAffiliateFromRaw.FromRawUnchecked"/>
    public static PostMonitorAuthorAffiliate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMonitorAuthorAffiliateFromRaw : IFromRawJson<PostMonitorAuthorAffiliate>
{
    /// <inheritdoc/>
    public PostMonitorAuthorAffiliate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PostMonitorAuthorAffiliate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PostMonitorMediaKindConverter))]
public enum PostMonitorMediaKind
{
    Gif,
    Photo,
    Video,
}

sealed class PostMonitorMediaKindConverter : JsonConverter<PostMonitorMediaKind>
{
    public override PostMonitorMediaKind Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gif" => PostMonitorMediaKind.Gif,
            "photo" => PostMonitorMediaKind.Photo,
            "video" => PostMonitorMediaKind.Video,
            _ => (PostMonitorMediaKind)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PostMonitorMediaKind value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PostMonitorMediaKind.Gif => "gif",
                PostMonitorMediaKind.Photo => "photo",
                PostMonitorMediaKind.Video => "video",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<PostMonitorMedia, PostMonitorMediaFromRaw>))]
public sealed record class PostMonitorMedia : JsonModel
{
    public required ApiEnum<string, PostMonitorMediaKind> Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PostMonitorMediaKind>>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// The image URL. For a video or GIF, its preview image.
    /// </summary>
    public required string UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Kind.Validate();
        _ = this.UrlValue;
    }

    public PostMonitorMedia() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorMedia(PostMonitorMedia postMonitorMedia)
        : base(postMonitorMedia) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorMedia(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMonitorMedia(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMonitorMediaFromRaw.FromRawUnchecked"/>
    public static PostMonitorMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMonitorMediaFromRaw : IFromRawJson<PostMonitorMedia>
{
    /// <inheritdoc/>
    public PostMonitorMedia FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostMonitorMedia.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PostMonitorBaseline, PostMonitorBaselineFromRaw>))]
public sealed record class PostMonitorBaseline : JsonModel
{
    /// <summary>
    /// When Xquik read these counts from X.
    /// </summary>
    public required DateTimeOffset At
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("at");
        }
        init { this._rawData.Set("at", value); }
    }

    public required long? Views
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("views");
        }
        init { this._rawData.Set("views", value); }
    }

    public required long Likes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("likes");
        }
        init { this._rawData.Set("likes", value); }
    }

    public required long Retweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("retweets");
        }
        init { this._rawData.Set("retweets", value); }
    }

    public required long Replies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("replies");
        }
        init { this._rawData.Set("replies", value); }
    }

    public required long Quotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("quotes");
        }
        init { this._rawData.Set("quotes", value); }
    }

    public required long Bookmarks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("bookmarks");
        }
        init { this._rawData.Set("bookmarks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.At;
        _ = this.Views;
        _ = this.Likes;
        _ = this.Retweets;
        _ = this.Replies;
        _ = this.Quotes;
        _ = this.Bookmarks;
    }

    public PostMonitorBaseline() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorBaseline(PostMonitorBaseline postMonitorBaseline)
        : base(postMonitorBaseline) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitorBaseline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMonitorBaseline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMonitorBaselineFromRaw.FromRawUnchecked"/>
    public static PostMonitorBaseline FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMonitorBaselineFromRaw : IFromRawJson<PostMonitorBaseline>
{
    /// <inheritdoc/>
    public PostMonitorBaseline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostMonitorBaseline.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PostMonitorPausedReasonConverter))]
public enum PostMonitorPausedReason
{
    InsufficientCredits,
    XPostDeleted,
    XPostProtected,
    XPostUnavailable,
}

sealed class PostMonitorPausedReasonConverter : JsonConverter<PostMonitorPausedReason>
{
    public override PostMonitorPausedReason Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "insufficient_credits" => PostMonitorPausedReason.InsufficientCredits,
            "x_post_deleted" => PostMonitorPausedReason.XPostDeleted,
            "x_post_protected" => PostMonitorPausedReason.XPostProtected,
            "x_post_unavailable" => PostMonitorPausedReason.XPostUnavailable,
            _ => (PostMonitorPausedReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PostMonitorPausedReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PostMonitorPausedReason.InsufficientCredits => "insufficient_credits",
                PostMonitorPausedReason.XPostDeleted => "x_post_deleted",
                PostMonitorPausedReason.XPostProtected => "x_post_protected",
                PostMonitorPausedReason.XPostUnavailable => "x_post_unavailable",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<PostMonitor, PostMonitorFromRaw>))]
public sealed record class PostMonitor : JsonModel
{
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
    /// Customer-set label of the post monitor, when set.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// ID of the post you gave.
    /// </summary>
    public required string PostID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postId");
        }
        init { this._rawData.Set("postId", value); }
    }

    public required string PostUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postUrl");
        }
        init { this._rawData.Set("postUrl", value); }
    }

    /// <summary>
    /// Permanent X user ID of the post's author.
    /// </summary>
    public required string AuthorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorId");
        }
        init { this._rawData.Set("authorId", value); }
    }

    public required string AuthorUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorUsername");
        }
        init { this._rawData.Set("authorUsername", value); }
    }

    public required string AuthorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("authorName");
        }
        init { this._rawData.Set("authorName", value); }
    }

    /// <summary>
    /// The author's profile picture. Omitted when X shows none.
    /// </summary>
    public string? AuthorAvatarUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("authorAvatarUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorAvatarUrl", value);
        }
    }

    /// <summary>
    /// The author's verified badge on X. Omitted when the author has none.
    /// </summary>
    public ApiEnum<string, PostMonitorAuthorVerified>? AuthorVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PostMonitorAuthorVerified>>(
                "authorVerified"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorVerified", value);
        }
    }

    /// <summary>
    /// The organization badge X shows beside the author's name. Omitted when X shows none.
    /// </summary>
    public PostMonitorAuthorAffiliate? AuthorAffiliate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PostMonitorAuthorAffiliate>("authorAffiliate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorAffiliate", value);
        }
    }

    /// <summary>
    /// Photos, videos &amp; GIFs on the post, in X's order.
    /// </summary>
    public required IReadOnlyList<PostMonitorMedia> Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PostMonitorMedia>>("media");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PostMonitorMedia>>(
                "media",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Text of the newest version Xquik read.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    public required DateTimeOffset PostedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("postedAt");
        }
        init { this._rawData.Set("postedAt", value); }
    }

    /// <summary>
    /// Post event types to send. Without it, a monitor sends new replies, new quotes, like &amp; retweet changes, edits &amp; deletion.
    /// </summary>
    public required IReadOnlyList<
        ApiEnum<string, global::XTwitterScraper.Models.PostEventType>
    > EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, global::XTwitterScraper.Models.PostEventType>>
            >("eventTypes");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ApiEnum<string, global::XTwitterScraper.Models.PostEventType>>
            >("eventTypes", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required bool IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isActive");
        }
        init { this._rawData.Set("isActive", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Next hourly credit charge time for this post monitor.
    /// </summary>
    public required DateTimeOffset NextBillingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("nextBillingAt");
        }
        init { this._rawData.Set("nextBillingAt", value); }
    }

    /// <summary>
    /// Counts Xquik read when tracking began. Each metric's gain counts from here. views is null when X showed no view count.
    /// </summary>
    public required PostMonitorBaseline Baseline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PostMonitorBaseline>("baseline");
        }
        init { this._rawData.Set("baseline", value); }
    }

    /// <summary>
    /// Why Xquik paused this post monitor. insufficient_credits means the balance could not pay an hour, so add credits &amp; resume. The other 3 mean X stopped showing the post. Absent when the monitor is active or you paused it yourself.
    /// </summary>
    public ApiEnum<string, PostMonitorPausedReason>? PausedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PostMonitorPausedReason>>(
                "pausedReason"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pausedReason", value);
        }
    }

    /// <summary>
    /// When Xquik paused this post monitor.
    /// </summary>
    public DateTimeOffset? PausedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("pausedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pausedAt", value);
        }
    }

    /// <summary>
    /// The 6 metrics of a post.
    /// </summary>
    public required global::XTwitterScraper.Models.PostMetrics Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::XTwitterScraper.Models.PostMetrics>(
                "metrics"
            );
        }
        init { this._rawData.Set("metrics", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.PostID;
        _ = this.PostUrl;
        _ = this.AuthorID;
        _ = this.AuthorUsername;
        _ = this.AuthorName;
        _ = this.AuthorAvatarUrl;
        this.AuthorVerified?.Validate();
        this.AuthorAffiliate?.Validate();
        foreach (var item in this.Media)
        {
            item.Validate();
        }
        _ = this.Text;
        _ = this.PostedAt;
        foreach (var item in this.EventTypes)
        {
            item.Validate();
        }
        _ = this.IsActive;
        _ = this.CreatedAt;
        _ = this.NextBillingAt;
        this.Baseline.Validate();
        this.PausedReason?.Validate();
        _ = this.PausedAt;
        this.Metrics.Validate();
    }

    public PostMonitor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitor(PostMonitor postMonitor)
        : base(postMonitor) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostMonitor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostMonitor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostMonitorFromRaw.FromRawUnchecked"/>
    public static PostMonitor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostMonitorFromRaw : IFromRawJson<PostMonitor>
{
    /// <inheritdoc/>
    public PostMonitor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostMonitor.FromRawUnchecked(rawData);
}
