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

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2QuotedTweetPermalink,
        SearchTweet2QuotedTweetPermalinkFromRaw
    >)
)]
public sealed record class SearchTweet2QuotedTweetPermalink : JsonModel
{
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

    public string? ExpandedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expandedUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expandedUrl", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayUrl;
        _ = this.ExpandedUrl;
        _ = this.UrlValue;
    }

    public SearchTweet2QuotedTweetPermalink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2QuotedTweetPermalink(
        SearchTweet2QuotedTweetPermalink searchTweet2QuotedTweetPermalink
    )
        : base(searchTweet2QuotedTweetPermalink) { }
#pragma warning restore CS8618

    public SearchTweet2QuotedTweetPermalink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2QuotedTweetPermalink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2QuotedTweetPermalinkFromRaw.FromRawUnchecked"/>
    public static SearchTweet2QuotedTweetPermalink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2QuotedTweetPermalinkFromRaw : IFromRawJson<SearchTweet2QuotedTweetPermalink>
{
    /// <inheritdoc/>
    public SearchTweet2QuotedTweetPermalink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2QuotedTweetPermalink.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2QuotedTweetUnavailable,
        SearchTweet2QuotedTweetUnavailableFromRaw
    >)
)]
public sealed record class SearchTweet2QuotedTweetUnavailable : JsonModel
{
    /// <summary>
    /// X's reason, such as `Suspended` for a suspended author or `Protected` for an author who protects their posts.
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

    public SearchTweet2QuotedTweetUnavailable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2QuotedTweetUnavailable(
        SearchTweet2QuotedTweetUnavailable searchTweet2QuotedTweetUnavailable
    )
        : base(searchTweet2QuotedTweetUnavailable) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2QuotedTweetUnavailable(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2QuotedTweetUnavailable(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2QuotedTweetUnavailableFromRaw.FromRawUnchecked"/>
    public static SearchTweet2QuotedTweetUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2QuotedTweetUnavailableFromRaw : IFromRawJson<SearchTweet2QuotedTweetUnavailable>
{
    /// <inheritdoc/>
    public SearchTweet2QuotedTweetUnavailable FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2QuotedTweetUnavailable.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2ConversationControl,
        SearchTweet2ConversationControlFromRaw
    >)
)]
public sealed record class SearchTweet2ConversationControl : JsonModel
{
    /// <summary>
    /// Regions whose accounts may reply, as country codes. Sent with the `country_of_origin` mode.
    /// </summary>
    public IReadOnlyList<string>? AllowedCountryCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowedCountryCodes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "allowedCountryCodes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? InviteViaMention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inviteViaMention");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inviteViaMention", value);
        }
    }

    /// <summary>
    /// Reply policy from X's newer field, such as `my_network`, `premium` or `country_of_origin`. Omitted when X sends none.
    /// </summary>
    public string? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// The conversation owner's account ID.
    /// </summary>
    public string? OwnerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ownerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ownerId", value);
        }
    }

    public string? OwnerUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ownerUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ownerUsername", value);
        }
    }

    public string? Policy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("policy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("policy", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedCountryCodes;
        _ = this.InviteViaMention;
        _ = this.Mode;
        _ = this.OwnerID;
        _ = this.OwnerUsername;
        _ = this.Policy;
    }

    public SearchTweet2ConversationControl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2ConversationControl(
        SearchTweet2ConversationControl searchTweet2ConversationControl
    )
        : base(searchTweet2ConversationControl) { }
#pragma warning restore CS8618

    public SearchTweet2ConversationControl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2ConversationControl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2ConversationControlFromRaw.FromRawUnchecked"/>
    public static SearchTweet2ConversationControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2ConversationControlFromRaw : IFromRawJson<SearchTweet2ConversationControl>
{
    /// <inheritdoc/>
    public SearchTweet2ConversationControl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2ConversationControl.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2LimitedActionsPrompt,
        SearchTweet2LimitedActionsPromptFromRaw
    >)
)]
public sealed record class SearchTweet2LimitedActionsPrompt : JsonModel
{
    public string? CtaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ctaType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ctaType", value);
        }
    }

    public string? Headline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("headline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("headline", value);
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

    public string? Subtext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subtext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subtext", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CtaType;
        _ = this.Headline;
        _ = this.Metadata;
        _ = this.Subtext;
    }

    public SearchTweet2LimitedActionsPrompt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2LimitedActionsPrompt(
        SearchTweet2LimitedActionsPrompt searchTweet2LimitedActionsPrompt
    )
        : base(searchTweet2LimitedActionsPrompt) { }
#pragma warning restore CS8618

    public SearchTweet2LimitedActionsPrompt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2LimitedActionsPrompt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2LimitedActionsPromptFromRaw.FromRawUnchecked"/>
    public static SearchTweet2LimitedActionsPrompt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2LimitedActionsPromptFromRaw : IFromRawJson<SearchTweet2LimitedActionsPrompt>
{
    /// <inheritdoc/>
    public SearchTweet2LimitedActionsPrompt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2LimitedActionsPrompt.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweet2LimitedActions, SearchTweet2LimitedActionsFromRaw>)
)]
public sealed record class SearchTweet2LimitedActions : JsonModel
{
    public string? Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("action");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    public SearchTweet2LimitedActionsPrompt? Prompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2LimitedActionsPrompt>("prompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prompt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Action;
        this.Prompt?.Validate();
    }

    public SearchTweet2LimitedActions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2LimitedActions(SearchTweet2LimitedActions searchTweet2LimitedActions)
        : base(searchTweet2LimitedActions) { }
#pragma warning restore CS8618

    public SearchTweet2LimitedActions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2LimitedActions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2LimitedActionsFromRaw.FromRawUnchecked"/>
    public static SearchTweet2LimitedActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2LimitedActionsFromRaw : IFromRawJson<SearchTweet2LimitedActions>
{
    /// <inheritdoc/>
    public SearchTweet2LimitedActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2LimitedActions.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweet2TextHighlights, SearchTweet2TextHighlightsFromRaw>)
)]
public sealed record class SearchTweet2TextHighlights : JsonModel
{
    /// <summary>
    /// The first code point of the match.
    /// </summary>
    public required long StartIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("startIndex");
        }
        init { this._rawData.Set("startIndex", value); }
    }

    /// <summary>
    /// The first code point after the match.
    /// </summary>
    public required long EndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("endIndex");
        }
        init { this._rawData.Set("endIndex", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StartIndex;
        _ = this.EndIndex;
    }

    public SearchTweet2TextHighlights() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2TextHighlights(SearchTweet2TextHighlights searchTweet2TextHighlights)
        : base(searchTweet2TextHighlights) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2TextHighlights(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2TextHighlights(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2TextHighlightsFromRaw.FromRawUnchecked"/>
    public static SearchTweet2TextHighlights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2TextHighlightsFromRaw : IFromRawJson<SearchTweet2TextHighlights>
{
    /// <inheritdoc/>
    public SearchTweet2TextHighlights FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2TextHighlights.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2CashtagAttachments,
        SearchTweet2CashtagAttachmentsFromRaw
    >)
)]
public sealed record class SearchTweet2CashtagAttachments : JsonModel
{
    /// <summary>
    /// The cashtag with its `$`.
    /// </summary>
    public required string Cashtag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cashtag");
        }
        init { this._rawData.Set("cashtag", value); }
    }

    /// <summary>
    /// Span of each candle.
    /// </summary>
    public string? CandleSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("candleSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("candleSize", value);
        }
    }

    /// <summary>
    /// Span the chart covers.
    /// </summary>
    public string? Timeframe
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timeframe");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeframe", value);
        }
    }

    /// <summary>
    /// Time of the chart's first candle.
    /// </summary>
    public DateTimeOffset? StartTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("startTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startTime", value);
        }
    }

    /// <summary>
    /// Time of the chart's last price.
    /// </summary>
    public DateTimeOffset? EndTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("endTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("endTime", value);
        }
    }

    /// <summary>
    /// X's size for the chart.
    /// </summary>
    public long? SizeVariant
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sizeVariant");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizeVariant", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cashtag;
        _ = this.CandleSize;
        _ = this.Timeframe;
        _ = this.StartTime;
        _ = this.EndTime;
        _ = this.SizeVariant;
    }

    public SearchTweet2CashtagAttachments() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2CashtagAttachments(
        SearchTweet2CashtagAttachments searchTweet2CashtagAttachments
    )
        : base(searchTweet2CashtagAttachments) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2CashtagAttachments(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2CashtagAttachments(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2CashtagAttachmentsFromRaw.FromRawUnchecked"/>
    public static SearchTweet2CashtagAttachments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2CashtagAttachmentsFromRaw : IFromRawJson<SearchTweet2CashtagAttachments>
{
    /// <inheritdoc/>
    public SearchTweet2CashtagAttachments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2CashtagAttachments.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweet2ReactionContext, SearchTweet2ReactionContextFromRaw>)
)]
public sealed record class SearchTweet2ReactionContext : JsonModel
{
    /// <summary>
    /// The post this one reacts to, with the same fields. X often sends only its ID, author &amp; edit history. Then unknownFields lists text, and the flags X did not send are left out.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ReactedToPost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "reactedToPost"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "reactedToPost",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Referenced post ID.
    /// </summary>
    public string? ReactedToPostID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reactedToPostId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reactedToPostId", value);
        }
    }

    /// <summary>
    /// Public X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserProfile? ReactedToUser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserProfile>(
                "reactedToUser"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reactedToUser", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ReactedToPost;
        _ = this.ReactedToPostID;
        this.ReactedToUser?.Validate();
    }

    public SearchTweet2ReactionContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2ReactionContext(SearchTweet2ReactionContext searchTweet2ReactionContext)
        : base(searchTweet2ReactionContext) { }
#pragma warning restore CS8618

    public SearchTweet2ReactionContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2ReactionContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2ReactionContextFromRaw.FromRawUnchecked"/>
    public static SearchTweet2ReactionContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2ReactionContextFromRaw : IFromRawJson<SearchTweet2ReactionContext>
{
    /// <inheritdoc/>
    public SearchTweet2ReactionContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2ReactionContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2SportsContextCompetitors,
        SearchTweet2SportsContextCompetitorsFromRaw
    >)
)]
public sealed record class SearchTweet2SportsContextCompetitors : JsonModel
{
    /// <summary>
    /// Team ID.
    /// </summary>
    public string? TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("teamId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("teamId", value);
        }
    }

    /// <summary>
    /// Team display color.
    /// </summary>
    public string? Color
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("color");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("color", value);
        }
    }

    /// <summary>
    /// Active competitor.
    /// </summary>
    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isActive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isActive", value);
        }
    }

    /// <summary>
    /// Winning competitor.
    /// </summary>
    public bool? IsWinner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isWinner");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isWinner", value);
        }
    }

    /// <summary>
    /// Team abbreviation.
    /// </summary>
    public string? Abbreviation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("abbreviation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("abbreviation", value);
        }
    }

    /// <summary>
    /// Team name.
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
    /// Score display text.
    /// </summary>
    public string? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <summary>
    /// Logo for light backgrounds.
    /// </summary>
    public string? LogoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("logoUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("logoUrl", value);
        }
    }

    /// <summary>
    /// Logo for dark backgrounds.
    /// </summary>
    public string? DarkLogoUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("darkLogoUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("darkLogoUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TeamID;
        _ = this.Color;
        _ = this.IsActive;
        _ = this.IsWinner;
        _ = this.Abbreviation;
        _ = this.Name;
        _ = this.Score;
        _ = this.LogoUrl;
        _ = this.DarkLogoUrl;
    }

    public SearchTweet2SportsContextCompetitors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2SportsContextCompetitors(
        SearchTweet2SportsContextCompetitors searchTweet2SportsContextCompetitors
    )
        : base(searchTweet2SportsContextCompetitors) { }
#pragma warning restore CS8618

    public SearchTweet2SportsContextCompetitors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2SportsContextCompetitors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2SportsContextCompetitorsFromRaw.FromRawUnchecked"/>
    public static SearchTweet2SportsContextCompetitors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2SportsContextCompetitorsFromRaw
    : IFromRawJson<SearchTweet2SportsContextCompetitors>
{
    /// <inheritdoc/>
    public SearchTweet2SportsContextCompetitors FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2SportsContextCompetitors.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweet2SportsContext, SearchTweet2SportsContextFromRaw>)
)]
public sealed record class SearchTweet2SportsContext : JsonModel
{
    /// <summary>
    /// Game ID.
    /// </summary>
    public string? GameID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gameId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gameId", value);
        }
    }

    /// <summary>
    /// League ID.
    /// </summary>
    public string? League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("league");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("league", value);
        }
    }

    /// <summary>
    /// Game title.
    /// </summary>
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

    /// <summary>
    /// Game link.
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
    /// Reported game state.
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Game progress text.
    /// </summary>
    public string? StatusText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("statusText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("statusText", value);
        }
    }

    /// <summary>
    /// Scheduled Unix milliseconds, retaining the source type.
    /// </summary>
    public JsonElement? ScheduledAtMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("scheduledAtMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scheduledAtMs", value);
        }
    }

    /// <summary>
    /// Teams &amp; reported scores.
    /// </summary>
    public IReadOnlyList<SearchTweet2SportsContextCompetitors>? Competitors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SearchTweet2SportsContextCompetitors>
            >("competitors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweet2SportsContextCompetitors>?>(
                "competitors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GameID;
        _ = this.League;
        _ = this.Title;
        _ = this.UrlValue;
        _ = this.State;
        _ = this.StatusText;
        _ = this.ScheduledAtMs;
        foreach (var item in this.Competitors ?? [])
        {
            item.Validate();
        }
    }

    public SearchTweet2SportsContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2SportsContext(SearchTweet2SportsContext searchTweet2SportsContext)
        : base(searchTweet2SportsContext) { }
#pragma warning restore CS8618

    public SearchTweet2SportsContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2SportsContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2SportsContextFromRaw.FromRawUnchecked"/>
    public static SearchTweet2SportsContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2SportsContextFromRaw : IFromRawJson<SearchTweet2SportsContext>
{
    /// <inheritdoc/>
    public SearchTweet2SportsContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2SportsContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweet2LiveEventContext, SearchTweet2LiveEventContextFromRaw>)
)]
public sealed record class SearchTweet2LiveEventContext : JsonModel
{
    /// <summary>
    /// Event name.
    /// </summary>
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

    /// <summary>
    /// The event's page on X.
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
    /// The event's image.
    /// </summary>
    public string? ImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("imageUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("imageUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Title;
        _ = this.UrlValue;
        _ = this.ImageUrl;
    }

    public SearchTweet2LiveEventContext() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2LiveEventContext(SearchTweet2LiveEventContext searchTweet2LiveEventContext)
        : base(searchTweet2LiveEventContext) { }
#pragma warning restore CS8618

    public SearchTweet2LiveEventContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2LiveEventContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2LiveEventContextFromRaw.FromRawUnchecked"/>
    public static SearchTweet2LiveEventContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2LiveEventContextFromRaw : IFromRawJson<SearchTweet2LiveEventContext>
{
    /// <inheritdoc/>
    public SearchTweet2LiveEventContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2LiveEventContext.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2SoftInterventionTextEntitiesRef,
        SearchTweet2SoftInterventionTextEntitiesRefFromRaw
    >)
)]
public sealed record class SearchTweet2SoftInterventionTextEntitiesRef : JsonModel
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

    public SearchTweet2SoftInterventionTextEntitiesRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2SoftInterventionTextEntitiesRef(
        SearchTweet2SoftInterventionTextEntitiesRef searchTweet2SoftInterventionTextEntitiesRef
    )
        : base(searchTweet2SoftInterventionTextEntitiesRef) { }
#pragma warning restore CS8618

    public SearchTweet2SoftInterventionTextEntitiesRef(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2SoftInterventionTextEntitiesRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2SoftInterventionTextEntitiesRefFromRaw.FromRawUnchecked"/>
    public static SearchTweet2SoftInterventionTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2SoftInterventionTextEntitiesRefFromRaw
    : IFromRawJson<SearchTweet2SoftInterventionTextEntitiesRef>
{
    /// <inheritdoc/>
    public SearchTweet2SoftInterventionTextEntitiesRef FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2SoftInterventionTextEntitiesRef.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2SoftInterventionTextEntities,
        SearchTweet2SoftInterventionTextEntitiesFromRaw
    >)
)]
public sealed record class SearchTweet2SoftInterventionTextEntities : JsonModel
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

    public SearchTweet2SoftInterventionTextEntitiesRef? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2SoftInterventionTextEntitiesRef>(
                "ref"
            );
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

    public SearchTweet2SoftInterventionTextEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2SoftInterventionTextEntities(
        SearchTweet2SoftInterventionTextEntities searchTweet2SoftInterventionTextEntities
    )
        : base(searchTweet2SoftInterventionTextEntities) { }
#pragma warning restore CS8618

    public SearchTweet2SoftInterventionTextEntities(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2SoftInterventionTextEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2SoftInterventionTextEntitiesFromRaw.FromRawUnchecked"/>
    public static SearchTweet2SoftInterventionTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2SoftInterventionTextEntitiesFromRaw
    : IFromRawJson<SearchTweet2SoftInterventionTextEntities>
{
    /// <inheritdoc/>
    public SearchTweet2SoftInterventionTextEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2SoftInterventionTextEntities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2SoftInterventionText,
        SearchTweet2SoftInterventionTextFromRaw
    >)
)]
public sealed record class SearchTweet2SoftInterventionText : JsonModel
{
    /// <summary>
    /// The label's text.
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
    /// Whether the label reads right to left.
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

    /// <summary>
    /// Links inside the label, by character range.
    /// </summary>
    public IReadOnlyList<SearchTweet2SoftInterventionTextEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SearchTweet2SoftInterventionTextEntities>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweet2SoftInterventionTextEntities>?>(
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

    public SearchTweet2SoftInterventionText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2SoftInterventionText(
        SearchTweet2SoftInterventionText searchTweet2SoftInterventionText
    )
        : base(searchTweet2SoftInterventionText) { }
#pragma warning restore CS8618

    public SearchTweet2SoftInterventionText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2SoftInterventionText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2SoftInterventionTextFromRaw.FromRawUnchecked"/>
    public static SearchTweet2SoftInterventionText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2SoftInterventionTextFromRaw : IFromRawJson<SearchTweet2SoftInterventionText>
{
    /// <inheritdoc/>
    public SearchTweet2SoftInterventionText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2SoftInterventionText.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SearchTweet2SoftInterventionUrl,
        SearchTweet2SoftInterventionUrlFromRaw
    >)
)]
public sealed record class SearchTweet2SoftInterventionUrl : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UrlValue;
        _ = this.UrlType;
    }

    public SearchTweet2SoftInterventionUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2SoftInterventionUrl(
        SearchTweet2SoftInterventionUrl searchTweet2SoftInterventionUrl
    )
        : base(searchTweet2SoftInterventionUrl) { }
#pragma warning restore CS8618

    public SearchTweet2SoftInterventionUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2SoftInterventionUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2SoftInterventionUrlFromRaw.FromRawUnchecked"/>
    public static SearchTweet2SoftInterventionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2SoftInterventionUrlFromRaw : IFromRawJson<SearchTweet2SoftInterventionUrl>
{
    /// <inheritdoc/>
    public SearchTweet2SoftInterventionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2SoftInterventionUrl.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchTweet2SoftIntervention, SearchTweet2SoftInterventionFromRaw>)
)]
public sealed record class SearchTweet2SoftIntervention : JsonModel
{
    /// <summary>
    /// The label's kind. `Fosnr` marks a post X keeps up but shows to fewer people.
    /// </summary>
    public string? DisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayType", value);
        }
    }

    /// <summary>
    /// Whether X prompts people before they engage with the post.
    /// </summary>
    public bool? EngagementNudge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("engagementNudge");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("engagementNudge", value);
        }
    }

    public SearchTweet2SoftInterventionText? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2SoftInterventionText>("text");
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
    /// The page that explains the label.
    /// </summary>
    public SearchTweet2SoftInterventionUrl? UrlValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2SoftInterventionUrl>("url");
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
        _ = this.DisplayType;
        _ = this.EngagementNudge;
        this.Text?.Validate();
        this.UrlValue?.Validate();
    }

    public SearchTweet2SoftIntervention() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2SoftIntervention(SearchTweet2SoftIntervention searchTweet2SoftIntervention)
        : base(searchTweet2SoftIntervention) { }
#pragma warning restore CS8618

    public SearchTweet2SoftIntervention(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2SoftIntervention(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2SoftInterventionFromRaw.FromRawUnchecked"/>
    public static SearchTweet2SoftIntervention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2SoftInterventionFromRaw : IFromRawJson<SearchTweet2SoftIntervention>
{
    /// <inheritdoc/>
    public SearchTweet2SoftIntervention FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchTweet2SoftIntervention.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SearchTweet2UnknownFieldsConverter))]
public enum SearchTweet2UnknownFields
{
    Text,
}

sealed class SearchTweet2UnknownFieldsConverter : JsonConverter<SearchTweet2UnknownFields>
{
    public override SearchTweet2UnknownFields Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => SearchTweet2UnknownFields.Text,
            _ => (SearchTweet2UnknownFields)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SearchTweet2UnknownFields value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SearchTweet2UnknownFields.Text => "text",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SearchTweet2UnknownCountsConverter))]
public enum SearchTweet2UnknownCounts
{
    RetweetCount,
    ReplyCount,
    LikeCount,
    QuoteCount,
    ViewCount,
    BookmarkCount,
}

sealed class SearchTweet2UnknownCountsConverter : JsonConverter<SearchTweet2UnknownCounts>
{
    public override SearchTweet2UnknownCounts Read(
        ref Utf8JsonReader reader,
        global::System.Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retweetCount" => SearchTweet2UnknownCounts.RetweetCount,
            "replyCount" => SearchTweet2UnknownCounts.ReplyCount,
            "likeCount" => SearchTweet2UnknownCounts.LikeCount,
            "quoteCount" => SearchTweet2UnknownCounts.QuoteCount,
            "viewCount" => SearchTweet2UnknownCounts.ViewCount,
            "bookmarkCount" => SearchTweet2UnknownCounts.BookmarkCount,
            _ => (SearchTweet2UnknownCounts)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SearchTweet2UnknownCounts value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SearchTweet2UnknownCounts.RetweetCount => "retweetCount",
                SearchTweet2UnknownCounts.ReplyCount => "replyCount",
                SearchTweet2UnknownCounts.LikeCount => "likeCount",
                SearchTweet2UnknownCounts.QuoteCount => "quoteCount",
                SearchTweet2UnknownCounts.ViewCount => "viewCount",
                SearchTweet2UnknownCounts.BookmarkCount => "bookmarkCount",
                _ => throw new XTwitterScraperInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SearchTweet2, SearchTweet2FromRaw>))]
public sealed record class SearchTweet2 : JsonModel
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

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

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

    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("createdAt");
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

    public string? Lang
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lang");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lang", value);
        }
    }

    public bool? IsReply
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isReply");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isReply", value);
        }
    }

    public bool? IsLimitedReply
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isLimitedReply");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isLimitedReply", value);
        }
    }

    public bool? IsNoteTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isNoteTweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isNoteTweet", value);
        }
    }

    public bool? IsPinned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPinned");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPinned", value);
        }
    }

    public bool? IsQuoteStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isQuoteStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isQuoteStatus", value);
        }
    }

    public bool? IsRetweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isRetweet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isRetweet", value);
        }
    }

    public string? QuotedTweetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("quotedTweetId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quotedTweetId", value);
        }
    }

    /// <summary>
    /// The quoted post's link, kept when X withholds that post.
    /// </summary>
    public SearchTweet2QuotedTweetPermalink? QuotedTweetPermalink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2QuotedTweetPermalink>(
                "quotedTweetPermalink"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quotedTweetPermalink", value);
        }
    }

    /// <summary>
    /// Why X shows no quoted post. Omitted when X names no reason.
    /// </summary>
    public SearchTweet2QuotedTweetUnavailable? QuotedTweetUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2QuotedTweetUnavailable>(
                "quotedTweetUnavailable"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quotedTweetUnavailable", value);
        }
    }

    /// <summary>
    /// Repost event time in UTC. Null when unavailable. Omitted for other posts.
    /// </summary>
    public DateTimeOffset? RetweetedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("retweetedAt");
        }
        init { this._rawData.Set("retweetedAt", value); }
    }

    public string? InReplyToID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inReplyToId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inReplyToId", value);
        }
    }

    public string? InReplyToUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inReplyToUserId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inReplyToUserId", value);
        }
    }

    public string? InReplyToUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inReplyToUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inReplyToUsername", value);
        }
    }

    public string? ConversationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("conversationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conversationId", value);
        }
    }

    /// <summary>
    /// Reply policy &amp; conversation owner.
    /// </summary>
    public SearchTweet2ConversationControl? ConversationControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2ConversationControl>(
                "conversationControl"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conversationControl", value);
        }
    }

    /// <summary>
    /// Public restrictions &amp; prompts.
    /// </summary>
    public IReadOnlyList<SearchTweet2LimitedActions>? LimitedActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweet2LimitedActions>>(
                "limitedActions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweet2LimitedActions>?>(
                "limitedActions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The app the post was sent from, as X labels it. X sends it for some posts only.
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public IReadOnlyList<long>? DisplayTextRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("displayTextRange");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "displayTextRange",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Where `text` matches the search, on each row a search read. Offsets count code points of `text`, as `displayTextRange` does. Empty when the post holds no marked match. Highlights cover a post's first 280 characters.
    /// </summary>
    public IReadOnlyList<SearchTweet2TextHighlights>? TextHighlights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweet2TextHighlights>>(
                "textHighlights"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweet2TextHighlights>?>(
                "textHighlights",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Content disclosure metadata X shows on a labeled tweet. X labels paid partnership content and AI-generated media.
    /// </summary>
    public global::XTwitterScraper.Models.ContentDisclosure? ContentDisclosure
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.ContentDisclosure>(
                "contentDisclosure"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contentDisclosure", value);
        }
    }

    /// <summary>
    /// An X Article preview and its lifecycle metadata.
    /// </summary>
    public global::XTwitterScraper.Models.TweetArticleMetadata? Article
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetArticleMetadata>(
                "article"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("article", value);
        }
    }

    /// <summary>
    /// Why the tweet has no author. X serves a suspended or deleted account as an unavailable user with a reason such as Suspended or NotFound. Omitted when the author is available.
    /// </summary>
    public global::XTwitterScraper.Models.TweetAuthorUnavailable? AuthorUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetAuthorUnavailable>(
                "authorUnavailable"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("authorUnavailable", value);
        }
    }

    /// <summary>
    /// The author's ID when X withholds the author's profile.
    /// </summary>
    public string? UnavailableAuthorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unavailableAuthorId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unavailableAuthorId", value);
        }
    }

    /// <summary>
    /// A public card and the profiles it references.
    /// </summary>
    public global::XTwitterScraper.Models.TweetCard? Card
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetCard>("card");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("card", value);
        }
    }

    /// <summary>
    /// Price charts the author attached under the post, 1 per cashtag. Absent when the post has none. X may send a cashtag without a chart window.
    /// </summary>
    public IReadOnlyList<SearchTweet2CashtagAttachments>? CashtagAttachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SearchTweet2CashtagAttachments>>(
                "cashtagAttachments"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SearchTweet2CashtagAttachments>?>(
                "cashtagAttachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Community ID.
    /// </summary>
    public string? CommunityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityId", value);
        }
    }

    /// <summary>
    /// Community name. Present when X sends it with the post.
    /// </summary>
    public string? CommunityName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityName", value);
        }
    }

    /// <summary>
    /// Community Note presentation metadata returned by X.
    /// </summary>
    public global::XTwitterScraper.Models.TweetCommunityNote? CommunityNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetCommunityNote>(
                "communityNote"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityNote", value);
        }
    }

    /// <summary>
    /// Whether X holds Community Notes on the post, shown or not.
    /// </summary>
    public bool? HasCommunityNotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasCommunityNotes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasCommunityNotes", value);
        }
    }

    /// <summary>
    /// Lists edit-chain identifiers and the remaining edit window.
    /// </summary>
    public global::XTwitterScraper.Models.TweetEdit? Edit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetEdit>("edit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("edit", value);
        }
    }

    /// <summary>
    /// Marks a subscriber-only post with the creator whose subscription unlocks it. Non-subscribers get the preview text &amp; the subscribe link. Omitted on public posts.
    /// </summary>
    public global::XTwitterScraper.Models.TweetExclusiveContent? ExclusiveContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetExclusiveContent>(
                "exclusiveContent"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exclusiveContent", value);
        }
    }

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
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? GrokShareAttachment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "grokShareAttachment"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "grokShareAttachment",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Grok's translation of the post, as X shows it.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? GrokTranslatedPost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "grokTranslatedPost"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "grokTranslatedPost",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? JetfuelAttachment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "jetfuelAttachment"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "jetfuelAttachment",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Complete Note Tweet content and rich-text metadata.
    /// </summary>
    public global::XTwitterScraper.Models.TweetNote? NoteTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetNote>(
                "noteTweet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("noteTweet", value);
        }
    }

    /// <summary>
    /// Public place metadata on a geotagged tweet.
    /// </summary>
    public global::XTwitterScraper.Models.TweetPlace? Place
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetPlace>(
                "place"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("place", value);
        }
    }

    /// <summary>
    /// Author-published point, with longitude before latitude.
    /// </summary>
    public global::XTwitterScraper.Models.TweetPoint? Coordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetPoint>(
                "coordinates"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("coordinates", value);
        }
    }

    /// <summary>
    /// Author-published point, with latitude before longitude.
    /// </summary>
    public global::XTwitterScraper.Models.TweetPoint? Geo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetPoint>("geo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("geo", value);
        }
    }

    /// <summary>
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? PostCta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("postCta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "postCta",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public bool? PossiblySensitive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("possiblySensitive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("possiblySensitive", value);
        }
    }

    /// <summary>
    /// Engagement counts retained from a prior tweet edit.
    /// </summary>
    public global::XTwitterScraper.Models.TweetPreviousCounts? PreviousCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetPreviousCounts>(
                "previousCounts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("previousCounts", value);
        }
    }

    /// <summary>
    /// Public post &amp; user this reaction references.
    /// </summary>
    public SearchTweet2ReactionContext? ReactionContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2ReactionContext>("reactionContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reactionContext", value);
        }
    }

    /// <summary>
    /// Game metadata attached to this post.
    /// </summary>
    public SearchTweet2SportsContext? SportsContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2SportsContext>("sportsContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sportsContext", value);
        }
    }

    /// <summary>
    /// The live event the post belongs to, such as an election.
    /// </summary>
    public SearchTweet2LiveEventContext? LiveEventContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2LiveEventContext>("liveEventContext");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("liveEventContext", value);
        }
    }

    /// <summary>
    /// The Subscriber badge X shows on a reply. The reply's author subscribes to the creator who started the conversation. Omitted on a post without the badge.
    /// </summary>
    public global::XTwitterScraper.Models.TweetSubscriberBadge? SubscriberBadge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetSubscriberBadge>(
                "subscriberBadge"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscriberBadge", value);
        }
    }

    /// <summary>
    /// Public visibility notice attached to an available tweet.
    /// </summary>
    public global::XTwitterScraper.Models.TweetTombstone? Tombstone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetTombstone>(
                "tombstone"
            );
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
    /// The notice x.com covers the post with until someone chooses to view it, such as X's public interest notice on a post that broke its rules but stays up.
    /// </summary>
    public global::XTwitterScraper.Models.TweetInterstitial? Interstitial
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.TweetInterstitial>(
                "interstitial"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("interstitial", value);
        }
    }

    /// <summary>
    /// The label X shows under a post whose reach it limits. It links to the page that explains it.
    /// </summary>
    public SearchTweet2SoftIntervention? SoftIntervention
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SearchTweet2SoftIntervention>("softIntervention");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("softIntervention", value);
        }
    }

    /// <summary>
    /// User IDs that left this conversation.
    /// </summary>
    public IReadOnlyList<string>? UnmentionedUserIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("unmentionedUserIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "unmentionedUserIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ViewState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("viewState");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("viewState", value);
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
    /// Public metadata whose fields X defines.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Scopes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("scopes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "scopes",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Media, omitted when unavailable.
    /// </summary>
    public IReadOnlyList<global::XTwitterScraper.Models.TweetMedia>? Media
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.TweetMedia>
            >("media");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.TweetMedia>?>(
                "media",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long RetweetCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("retweetCount");
        }
        init { this._rawData.Set("retweetCount", value); }
    }

    public required long ReplyCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("replyCount");
        }
        init { this._rawData.Set("replyCount", value); }
    }

    public required long LikeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("likeCount");
        }
        init { this._rawData.Set("likeCount", value); }
    }

    public required long QuoteCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("quoteCount");
        }
        init { this._rawData.Set("quoteCount", value); }
    }

    public required long ViewCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("viewCount");
        }
        init { this._rawData.Set("viewCount", value); }
    }

    public required long BookmarkCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("bookmarkCount");
        }
        init { this._rawData.Set("bookmarkCount", value); }
    }

    /// <summary>
    /// The fields X did not send for this post. text reads empty, so treat it as unknown rather than empty. Left out when X sent the text.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, SearchTweet2UnknownFields>>? UnknownFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, SearchTweet2UnknownFields>>
            >("unknownFields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, SearchTweet2UnknownFields>>?>(
                "unknownFields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The counts X did not send for this post. Each one reads 0, so treat it as unknown rather than none. Names follow the response's key style, so `xquik-api-contract: 2026-04-29` lists bookmark_count. Posts from before X counted views, &amp; new posts X has not counted views for yet, list viewCount. Left out when X sent every count. Counts X didn't send are listed in `unknownCounts`, never shown as 0.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, SearchTweet2UnknownCounts>>? UnknownCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, SearchTweet2UnknownCounts>>
            >("unknownCounts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, SearchTweet2UnknownCounts>>?>(
                "unknownCounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A parent, quoted or retweeted tweet. It has the TweetPublicData fields and an author. Nesting stops after 4 levels.
    /// </summary>
    public global::XTwitterScraper.Models.EmbeddedTweet? ParentTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.EmbeddedTweet>(
                "parentTweet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("parentTweet", value);
        }
    }

    /// <summary>
    /// A parent, quoted or retweeted tweet. It has the TweetPublicData fields and an author. Nesting stops after 4 levels.
    /// </summary>
    public global::XTwitterScraper.Models.EmbeddedTweet? QuotedTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.EmbeddedTweet>(
                "quoted_tweet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quoted_tweet", value);
        }
    }

    /// <summary>
    /// A parent, quoted or retweeted tweet. It has the TweetPublicData fields and an author. Nesting stops after 4 levels.
    /// </summary>
    public global::XTwitterScraper.Models.EmbeddedTweet? RetweetedTweet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.EmbeddedTweet>(
                "retweeted_tweet"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retweeted_tweet", value);
        }
    }

    /// <summary>
    /// Public X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserProfile? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserProfile>(
                "author"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("author", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Text;
        _ = this.Type;
        _ = this.CreatedAt;
        _ = this.UrlValue;
        _ = this.Lang;
        _ = this.IsReply;
        _ = this.IsLimitedReply;
        _ = this.IsNoteTweet;
        _ = this.IsPinned;
        _ = this.IsQuoteStatus;
        _ = this.IsRetweet;
        _ = this.QuotedTweetID;
        this.QuotedTweetPermalink?.Validate();
        this.QuotedTweetUnavailable?.Validate();
        _ = this.RetweetedAt;
        _ = this.InReplyToID;
        _ = this.InReplyToUserID;
        _ = this.InReplyToUsername;
        _ = this.ConversationID;
        this.ConversationControl?.Validate();
        foreach (var item in this.LimitedActions ?? [])
        {
            item.Validate();
        }
        _ = this.Source;
        _ = this.DisplayTextRange;
        foreach (var item in this.TextHighlights ?? [])
        {
            item.Validate();
        }
        this.ContentDisclosure?.Validate();
        this.Article?.Validate();
        this.AuthorUnavailable?.Validate();
        _ = this.UnavailableAuthorID;
        this.Card?.Validate();
        foreach (var item in this.CashtagAttachments ?? [])
        {
            item.Validate();
        }
        _ = this.CommunityID;
        _ = this.CommunityName;
        this.CommunityNote?.Validate();
        _ = this.HasCommunityNotes;
        this.Edit?.Validate();
        this.ExclusiveContent?.Validate();
        _ = this.IsTranslatable;
        _ = this.GrokShareAttachment;
        _ = this.GrokTranslatedPost;
        _ = this.JetfuelAttachment;
        this.NoteTweet?.Validate();
        this.Place?.Validate();
        this.Coordinates?.Validate();
        this.Geo?.Validate();
        _ = this.PostCta;
        _ = this.PossiblySensitive;
        this.PreviousCounts?.Validate();
        this.ReactionContext?.Validate();
        this.SportsContext?.Validate();
        this.LiveEventContext?.Validate();
        this.SubscriberBadge?.Validate();
        this.Tombstone?.Validate();
        this.Interstitial?.Validate();
        this.SoftIntervention?.Validate();
        _ = this.UnmentionedUserIDs;
        _ = this.ViewState;
        this.Entities?.Validate();
        _ = this.Scopes;
        foreach (var item in this.Media ?? [])
        {
            item.Validate();
        }
        _ = this.RetweetCount;
        _ = this.ReplyCount;
        _ = this.LikeCount;
        _ = this.QuoteCount;
        _ = this.ViewCount;
        _ = this.BookmarkCount;
        foreach (var item in this.UnknownFields ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.UnknownCounts ?? [])
        {
            item.Validate();
        }
        this.ParentTweet?.Validate();
        this.QuotedTweet?.Validate();
        this.RetweetedTweet?.Validate();
        this.Author?.Validate();
    }

    public SearchTweet2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2(SearchTweet2 searchTweet2)
        : base(searchTweet2) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchTweet2(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchTweet2(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchTweet2FromRaw.FromRawUnchecked"/>
    public static SearchTweet2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchTweet2FromRaw : IFromRawJson<SearchTweet2>
{
    /// <inheritdoc/>
    public SearchTweet2 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SearchTweet2.FromRawUnchecked(rawData);
}
