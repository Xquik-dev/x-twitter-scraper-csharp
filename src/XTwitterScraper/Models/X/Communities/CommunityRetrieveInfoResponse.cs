using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Communities;

[JsonConverter(
    typeof(JsonModelConverter<CommunityRetrieveInfoResponse, CommunityRetrieveInfoResponseFromRaw>)
)]
public sealed record class CommunityRetrieveInfoResponse : JsonModel
{
    /// <summary>
    /// Community info object
    /// </summary>
    public required Community Community
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Community>("community");
        }
        init { this._rawData.Set("community", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Community.Validate();
    }

    public CommunityRetrieveInfoResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityRetrieveInfoResponse(
        CommunityRetrieveInfoResponse communityRetrieveInfoResponse
    )
        : base(communityRetrieveInfoResponse) { }
#pragma warning restore CS8618

    public CommunityRetrieveInfoResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityRetrieveInfoResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityRetrieveInfoResponseFromRaw.FromRawUnchecked"/>
    public static CommunityRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CommunityRetrieveInfoResponse(Community community)
        : this()
    {
        this.Community = community;
    }
}

class CommunityRetrieveInfoResponseFromRaw : IFromRawJson<CommunityRetrieveInfoResponse>
{
    /// <inheritdoc/>
    public CommunityRetrieveInfoResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityRetrieveInfoResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Community info object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Community, CommunityFromRaw>))]
public sealed record class Community : JsonModel
{
    /// <summary>
    /// Unique community identifier
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
    /// Community banner image URL
    /// </summary>
    public string? BannerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("banner_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("banner_url", value);
        }
    }

    /// <summary>
    /// Community creation timestamp
    /// </summary>
    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public Creator? Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Creator>("creator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creator", value);
        }
    }

    /// <summary>
    /// About text for the community
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Invitation policy
    /// </summary>
    public string? InvitesPolicy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invites_policy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("invites_policy", value);
        }
    }

    /// <summary>
    /// Whether the community is marked sensitive
    /// </summary>
    public bool? IsNsfw
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_nsfw");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_nsfw", value);
        }
    }

    /// <summary>
    /// Join policy (open or restricted)
    /// </summary>
    public string? JoinPolicy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("join_policy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("join_policy", value);
        }
    }

    /// <summary>
    /// Total member count
    /// </summary>
    public long? MemberCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("member_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("member_count", value);
        }
    }

    /// <summary>
    /// Total moderator count
    /// </summary>
    public long? ModeratorCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("moderator_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("moderator_count", value);
        }
    }

    /// <summary>
    /// Display name of the community
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
    /// Primary topic
    /// </summary>
    public PrimaryTopic? PrimaryTopic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PrimaryTopic>("primary_topic");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_topic", value);
        }
    }

    /// <summary>
    /// Community rules
    /// </summary>
    public IReadOnlyList<Rule>? Rules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Rule>>("rules");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Rule>?>(
                "rules",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// What the community asks a user who joins
    /// </summary>
    public string? Question
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("question");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("question", value);
        }
    }

    /// <summary>
    /// Tags X finds the community by
    /// </summary>
    public IReadOnlyList<string>? SearchTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("searchTags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "searchTags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Public X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserProfile? Admin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserProfile>(
                "admin"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("admin", value);
        }
    }

    /// <summary>
    /// The members X previews beside the member count. A keyword or topic result gives each member's ID &amp; picture only.
    /// </summary>
    public IReadOnlyList<CommunityMembersFacepile>? MembersFacepile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CommunityMembersFacepile>>(
                "membersFacepile"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CommunityMembersFacepile>?>(
                "membersFacepile",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The banner X shows for a community, with its size &amp; colors.
    /// </summary>
    public global::XTwitterScraper.Models.CommunityBanner? Banner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.CommunityBanner>(
                "banner"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("banner", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BannerUrl;
        _ = this.CreatedAt;
        this.Creator?.Validate();
        _ = this.Description;
        _ = this.InvitesPolicy;
        _ = this.IsNsfw;
        _ = this.JoinPolicy;
        _ = this.MemberCount;
        _ = this.ModeratorCount;
        _ = this.Name;
        this.PrimaryTopic?.Validate();
        foreach (var item in this.Rules ?? [])
        {
            item.Validate();
        }
        _ = this.Question;
        _ = this.SearchTags;
        this.Admin?.Validate();
        foreach (var item in this.MembersFacepile ?? [])
        {
            item.Validate();
        }
        this.Banner?.Validate();
    }

    public Community() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Community(Community community)
        : base(community) { }
#pragma warning restore CS8618

    public Community(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Community(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityFromRaw.FromRawUnchecked"/>
    public static Community FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Community(string id)
        : this()
    {
        this.ID = id;
    }
}

class CommunityFromRaw : IFromRawJson<Community>
{
    /// <inheritdoc/>
    public Community FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Community.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Creator, CreatorFromRaw>))]
public sealed record class Creator : JsonModel
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

    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    public required bool Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("verified");
        }
        init { this._rawData.Set("verified", value); }
    }

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

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Omitted when X sends no count, as for the account that first posted reused media.
    /// </summary>
    public long? Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("followers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("followers", value);
        }
    }

    public long? Following
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("following");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("following", value);
        }
    }

    /// <summary>
    /// Whether X shows a blue verification badge
    /// </summary>
    public bool? IsBlueVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isBlueVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isBlueVerified", value);
        }
    }

    /// <summary>
    /// Whether X marks the profile as verified
    /// </summary>
    public bool? IsVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isVerified", value);
        }
    }

    /// <summary>
    /// Profile picture at 48 px, as X sends it.
    /// </summary>
    public string? ProfilePicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePicture", value);
        }
    }

    /// <summary>
    /// The same profile picture at full size, as the account uploaded it. Download this one for the image.
    /// </summary>
    public string? ProfilePictureOriginal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePictureOriginal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePictureOriginal", value);
        }
    }

    public string? CoverPicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("coverPicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("coverPicture", value);
        }
    }

    /// <summary>
    /// Original X profile banner field when available
    /// </summary>
    public string? ProfileBannerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileBannerUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileBannerUrl", value);
        }
    }

    /// <summary>
    /// Account owner's public profile location text
    /// </summary>
    public string? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <summary>
    /// Null when X shows no label.
    /// </summary>
    public global::XTwitterScraper.Models.AccountBasedIn? AccountBasedIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.AccountBasedIn>(
                "accountBasedIn"
            );
        }
        init { this._rawData.Set("accountBasedIn", value); }
    }

    /// <summary>
    /// True when X withheld accountBasedIn from this read. Retry later.
    /// </summary>
    public bool? AccountBasedInUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("accountBasedInUnavailable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accountBasedInUnavailable", value);
        }
    }

    /// <summary>
    /// False when X notes accountBasedIn may be inaccurate.
    /// </summary>
    public bool? AccountBasedInAccurate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("accountBasedInAccurate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accountBasedInAccurate", value);
        }
    }

    /// <summary>
    /// How the account first connected to X.
    /// </summary>
    public string? ConnectedVia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connectedVia");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectedVia", value);
        }
    }

    /// <summary>
    /// False when X notes that country may be inaccurate.
    /// </summary>
    public bool? ConnectedViaAccurate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("connectedViaAccurate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectedViaAccurate", value);
        }
    }

    /// <summary>
    /// Handle of the organization X shows the account is affiliated with, from its About page.
    /// </summary>
    public string? AffiliateUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("affiliateUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("affiliateUsername", value);
        }
    }

    /// <summary>
    /// First email the account publishes on its profile, lowercased. Omitted when it publishes none.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// Emails, phone numbers &amp; links the account publishes on its own profile. Omitted when it publishes none.
    /// </summary>
    public global::XTwitterScraper.Models.ProfileContactInfo? ContactInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.ProfileContactInfo>(
                "contactInfo"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contactInfo", value);
        }
    }

    /// <summary>
    /// How often the account changed its username.
    /// </summary>
    public CreatorUsernameChanges? UsernameChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatorUsernameChanges>("usernameChanges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usernameChanges", value);
        }
    }

    /// <summary>
    /// The parts of the birthday the account made public.
    /// </summary>
    public CreatorBirthdate? Birthdate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatorBirthdate>("birthdate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("birthdate", value);
        }
    }

    /// <summary>
    /// UTC repost time with includeRetweetTimestamp. Null when Xquik found no repost time. Otherwise omitted.
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

    /// <summary>
    /// Account creation time.
    /// </summary>
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

    public long? StatusesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("statusesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("statusesCount", value);
        }
    }

    public long? MediaCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("mediaCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaCount", value);
        }
    }

    /// <summary>
    /// Whether the profile protects its posts
    /// </summary>
    public bool? Protected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("protected");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("protected", value);
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

    public long? FavouritesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("favouritesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("favouritesCount", value);
        }
    }

    public bool? HasCustomTimelines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasCustomTimelines");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasCustomTimelines", value);
        }
    }

    public bool? IsTranslator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTranslator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTranslator", value);
        }
    }

    public IReadOnlyList<string>? WithheldInCountries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("withheldInCountries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "withheldInCountries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether X withholds a post or user
    /// </summary>
    public string? WithheldScope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("withheldScope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("withheldScope", value);
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
    /// Professional metadata with category display settings
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Professional
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "professional"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "professional",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public profile bio translation returned by X
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? GrokTranslatedBio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "grokTranslatedBio"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "grokTranslatedBio",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyList<string>? PinnedTweetIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("pinnedTweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "pinnedTweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? IsAutomated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isAutomated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isAutomated", value);
        }
    }

    public string? AutomatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("automatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("automatedBy", value);
        }
    }

    public bool? Unavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("unavailable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unavailable", value);
        }
    }

    public string? UnavailableReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unavailableReason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unavailableReason", value);
        }
    }

    public string? VerifiedType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verifiedType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verifiedType", value);
        }
    }

    /// <summary>
    /// Organization affiliation label shown on an X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserAffiliateLabel? AffiliatesHighlightedLabel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserAffiliateLabel>(
                "affiliatesHighlightedLabel"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("affiliatesHighlightedLabel", value);
        }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? BusinessAccountAffiliatesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("businessAccountAffiliatesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("businessAccountAffiliatesCount", value);
        }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? CreatorSubscriptionsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("creatorSubscriptionsCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creatorSubscriptionsCount", value);
        }
    }

    public bool? HasGraduatedAccess
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasGraduatedAccess");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasGraduatedAccess", value);
        }
    }

    public bool? HasHiddenSubscriptionsOnProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasHiddenSubscriptionsOnProfile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasHiddenSubscriptionsOnProfile", value);
        }
    }

    /// <summary>
    /// Profile highlight availability and count metadata.
    /// </summary>
    public global::XTwitterScraper.Models.UserHighlightsInfo? HighlightsInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserHighlightsInfo>(
                "highlightsInfo"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("highlightsInfo", value);
        }
    }

    /// <summary>
    /// Identity verification X shows on the profile &amp; its About page.
    /// </summary>
    public global::XTwitterScraper.Models.UserIdentityVerification? IdentityVerification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserIdentityVerification>(
                "identityVerification"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("identityVerification", value);
        }
    }

    public bool? IsProfileTranslatable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isProfileTranslatable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isProfileTranslatable", value);
        }
    }

    public string? ParodyCommentaryFanLabel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parodyCommentaryFanLabel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("parodyCommentaryFanLabel", value);
        }
    }

    public string? ProfileDescriptionLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileDescriptionLanguage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileDescriptionLanguage", value);
        }
    }

    public string? ProfileImageShape
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileImageShape");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileImageShape", value);
        }
    }

    public string? ProfileInterstitialType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileInterstitialType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileInterstitialType", value);
        }
    }

    public bool? ProfileSortEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("profileSortEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileSortEnabled", value);
        }
    }

    public string? ProfileTranslatorType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileTranslatorType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileTranslatorType", value);
        }
    }

    /// <summary>
    /// Handle x.com sends this profile's visitors to, such as the new handle of a renamed account whose old handle now holds a placeholder. Missing when x.com shows the profile itself.
    /// </summary>
    public string? RedirectsToUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("redirectsToUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("redirectsToUsername", value);
        }
    }

    public bool? SuperFollowEligible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("superFollowEligible");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("superFollowEligible", value);
        }
    }

    /// <summary>
    /// Whether X marks the subscription profile as active.
    /// </summary>
    public bool? SuperFollowsUserProfileActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("superFollowsUserProfileActive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("superFollowsUserProfileActive", value);
        }
    }

    /// <summary>
    /// Public payment and creator-support handles shown on X.
    /// </summary>
    public global::XTwitterScraper.Models.UserTipJar? TipJar
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserTipJar>(
                "tipJar"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tipJar", value);
        }
    }

    /// <summary>
    /// Public lists that include the profile.
    /// </summary>
    public long? ListedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("listedCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("listedCount", value);
        }
    }

    /// <summary>
    /// Followers X counts as fast followers.
    /// </summary>
    public long? FastFollowersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fastFollowersCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fastFollowersCount", value);
        }
    }

    /// <summary>
    /// Followers minus fast followers.
    /// </summary>
    public long? NormalFollowersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("normalFollowersCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("normalFollowersCount", value);
        }
    }

    /// <summary>
    /// Whether the profile keeps X's default theme.
    /// </summary>
    public bool? DefaultProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defaultProfile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultProfile", value);
        }
    }

    /// <summary>
    /// Whether the profile keeps X's default avatar.
    /// </summary>
    public bool? DefaultProfileImage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defaultProfileImage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultProfileImage", value);
        }
    }

    /// <summary>
    /// Whether the profile filled X's extended fields, such as a birth date. True or false.
    /// </summary>
    public bool? HasExtendedProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasExtendedProfile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasExtendedProfile", value);
        }
    }

    /// <summary>
    /// Whether the account turned on X's translation of its posts. True or false.
    /// </summary>
    public bool? IsTranslationEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTranslationEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTranslationEnabled", value);
        }
    }

    /// <summary>
    /// Whether the profile may add a location to posts.
    /// </summary>
    public bool? GeoEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("geoEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("geoEnabled", value);
        }
    }

    /// <summary>
    /// The account's X Ads type. `none` for an account without ads, or `promotable_user` for one that may run them.
    /// </summary>
    public string? AdvertiserAccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("advertiserAccountType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("advertiserAccountType", value);
        }
    }

    /// <summary>
    /// X Ads services the account uses, such as `analytics`, `media_studio` or `smb`. Empty for an account without ads.
    /// </summary>
    public IReadOnlyList<string>? AdvertiserAccountServiceLevels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "advertiserAccountServiceLevels"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "advertiserAccountServiceLevels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether X treats the profile as a business profile. `none` or `enabled`.
    /// </summary>
    public string? BusinessProfileState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("businessProfileState");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("businessProfileState", value);
        }
    }

    /// <summary>
    /// Accounts subscribed to the profile's paid Subscriptions. 0 when it has none.
    /// </summary>
    public long? SubscribersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("subscribersCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscribersCount", value);
        }
    }

    /// <summary>
    /// X's text on why the profile is verified, with its links.
    /// </summary>
    public CreatorVerificationReason? VerificationReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatorVerificationReason>("verificationReason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verificationReason", value);
        }
    }

    /// <summary>
    /// Community role when returned by community member reads
    /// </summary>
    public string? CommunityRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityRole");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityRole", value);
        }
    }

    /// <summary>
    /// Structured profile bio with entity annotations
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ProfileBio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "profile_bio"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "profile_bio",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
        _ = this.Verified;
        _ = this.Name;
        _ = this.Description;
        _ = this.Followers;
        _ = this.Following;
        _ = this.IsBlueVerified;
        _ = this.IsVerified;
        _ = this.ProfilePicture;
        _ = this.ProfilePictureOriginal;
        _ = this.CoverPicture;
        _ = this.ProfileBannerUrl;
        _ = this.Location;
        this.AccountBasedIn?.Validate();
        _ = this.AccountBasedInUnavailable;
        _ = this.AccountBasedInAccurate;
        _ = this.ConnectedVia;
        _ = this.ConnectedViaAccurate;
        _ = this.AffiliateUsername;
        _ = this.Email;
        this.ContactInfo?.Validate();
        this.UsernameChanges?.Validate();
        this.Birthdate?.Validate();
        _ = this.RetweetedAt;
        _ = this.CreatedAt;
        _ = this.StatusesCount;
        _ = this.MediaCount;
        _ = this.Protected;
        _ = this.UrlValue;
        _ = this.FavouritesCount;
        _ = this.HasCustomTimelines;
        _ = this.IsTranslator;
        _ = this.WithheldInCountries;
        _ = this.WithheldScope;
        _ = this.PossiblySensitive;
        _ = this.Professional;
        _ = this.GrokTranslatedBio;
        _ = this.PinnedTweetIDs;
        _ = this.IsAutomated;
        _ = this.AutomatedBy;
        _ = this.Unavailable;
        _ = this.UnavailableReason;
        _ = this.VerifiedType;
        this.AffiliatesHighlightedLabel?.Validate();
        _ = this.BusinessAccountAffiliatesCount;
        _ = this.CreatorSubscriptionsCount;
        _ = this.HasGraduatedAccess;
        _ = this.HasHiddenSubscriptionsOnProfile;
        this.HighlightsInfo?.Validate();
        this.IdentityVerification?.Validate();
        _ = this.IsProfileTranslatable;
        _ = this.ParodyCommentaryFanLabel;
        _ = this.ProfileDescriptionLanguage;
        _ = this.ProfileImageShape;
        _ = this.ProfileInterstitialType;
        _ = this.ProfileSortEnabled;
        _ = this.ProfileTranslatorType;
        _ = this.RedirectsToUsername;
        _ = this.SuperFollowEligible;
        _ = this.SuperFollowsUserProfileActive;
        this.TipJar?.Validate();
        _ = this.ListedCount;
        _ = this.FastFollowersCount;
        _ = this.NormalFollowersCount;
        _ = this.DefaultProfile;
        _ = this.DefaultProfileImage;
        _ = this.HasExtendedProfile;
        _ = this.IsTranslationEnabled;
        _ = this.GeoEnabled;
        _ = this.AdvertiserAccountType;
        _ = this.AdvertiserAccountServiceLevels;
        _ = this.BusinessProfileState;
        _ = this.SubscribersCount;
        this.VerificationReason?.Validate();
        _ = this.CommunityRole;
        _ = this.ProfileBio;
    }

    public Creator() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Creator(Creator creator)
        : base(creator) { }
#pragma warning restore CS8618

    public Creator(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Creator(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatorFromRaw.FromRawUnchecked"/>
    public static Creator FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatorFromRaw : IFromRawJson<Creator>
{
    /// <inheritdoc/>
    public Creator FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Creator.FromRawUnchecked(rawData);
}

/// <summary>
/// Primary topic
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PrimaryTopic, PrimaryTopicFromRaw>))]
public sealed record class PrimaryTopic : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public PrimaryTopic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrimaryTopic(PrimaryTopic primaryTopic)
        : base(primaryTopic) { }
#pragma warning restore CS8618

    public PrimaryTopic(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PrimaryTopic(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrimaryTopicFromRaw.FromRawUnchecked"/>
    public static PrimaryTopic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrimaryTopicFromRaw : IFromRawJson<PrimaryTopic>
{
    /// <inheritdoc/>
    public PrimaryTopic FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PrimaryTopic.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Rule, RuleFromRaw>))]
public sealed record class Rule : JsonModel
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

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Name;
    }

    public Rule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rule(Rule rule)
        : base(rule) { }
#pragma warning restore CS8618

    public Rule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleFromRaw.FromRawUnchecked"/>
    public static Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleFromRaw : IFromRawJson<Rule>
{
    /// <inheritdoc/>
    public Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rule.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CommunityMembersFacepileUsernameChanges,
        CommunityMembersFacepileUsernameChangesFromRaw
    >)
)]
public sealed record class CommunityMembersFacepileUsernameChanges : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Time of the latest change, omitted when there is none.
    /// </summary>
    public DateTimeOffset? LastChangedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastChangedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastChangedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.LastChangedAt;
    }

    public CommunityMembersFacepileUsernameChanges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityMembersFacepileUsernameChanges(
        CommunityMembersFacepileUsernameChanges communityMembersFacepileUsernameChanges
    )
        : base(communityMembersFacepileUsernameChanges) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityMembersFacepileUsernameChanges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityMembersFacepileUsernameChanges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityMembersFacepileUsernameChangesFromRaw.FromRawUnchecked"/>
    public static CommunityMembersFacepileUsernameChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityMembersFacepileUsernameChangesFromRaw
    : IFromRawJson<CommunityMembersFacepileUsernameChanges>
{
    /// <inheritdoc/>
    public CommunityMembersFacepileUsernameChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityMembersFacepileUsernameChanges.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CommunityMembersFacepileBirthdate,
        CommunityMembersFacepileBirthdateFromRaw
    >)
)]
public sealed record class CommunityMembersFacepileBirthdate : JsonModel
{
    public long? Day
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("day");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("day", value);
        }
    }

    public long? Month
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("month");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("month", value);
        }
    }

    public long? Year
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("year");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("year", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Day;
        _ = this.Month;
        _ = this.Year;
    }

    public CommunityMembersFacepileBirthdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityMembersFacepileBirthdate(
        CommunityMembersFacepileBirthdate communityMembersFacepileBirthdate
    )
        : base(communityMembersFacepileBirthdate) { }
#pragma warning restore CS8618

    public CommunityMembersFacepileBirthdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityMembersFacepileBirthdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityMembersFacepileBirthdateFromRaw.FromRawUnchecked"/>
    public static CommunityMembersFacepileBirthdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityMembersFacepileBirthdateFromRaw : IFromRawJson<CommunityMembersFacepileBirthdate>
{
    /// <inheritdoc/>
    public CommunityMembersFacepileBirthdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityMembersFacepileBirthdate.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CommunityMembersFacepileVerificationReasonEntities,
        CommunityMembersFacepileVerificationReasonEntitiesFromRaw
    >)
)]
public sealed record class CommunityMembersFacepileVerificationReasonEntities : JsonModel
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
        _ = this.FromIndex;
        _ = this.ToIndex;
        _ = this.UrlValue;
        _ = this.UrlType;
    }

    public CommunityMembersFacepileVerificationReasonEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityMembersFacepileVerificationReasonEntities(
        CommunityMembersFacepileVerificationReasonEntities communityMembersFacepileVerificationReasonEntities
    )
        : base(communityMembersFacepileVerificationReasonEntities) { }
#pragma warning restore CS8618

    public CommunityMembersFacepileVerificationReasonEntities(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityMembersFacepileVerificationReasonEntities(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityMembersFacepileVerificationReasonEntitiesFromRaw.FromRawUnchecked"/>
    public static CommunityMembersFacepileVerificationReasonEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityMembersFacepileVerificationReasonEntitiesFromRaw
    : IFromRawJson<CommunityMembersFacepileVerificationReasonEntities>
{
    /// <inheritdoc/>
    public CommunityMembersFacepileVerificationReasonEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityMembersFacepileVerificationReasonEntities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CommunityMembersFacepileVerificationReason,
        CommunityMembersFacepileVerificationReasonFromRaw
    >)
)]
public sealed record class CommunityMembersFacepileVerificationReason : JsonModel
{
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
    /// Links inside the text, by character range.
    /// </summary>
    public IReadOnlyList<CommunityMembersFacepileVerificationReasonEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CommunityMembersFacepileVerificationReasonEntities>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CommunityMembersFacepileVerificationReasonEntities>?>(
                "entities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        foreach (var item in this.Entities ?? [])
        {
            item.Validate();
        }
    }

    public CommunityMembersFacepileVerificationReason() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityMembersFacepileVerificationReason(
        CommunityMembersFacepileVerificationReason communityMembersFacepileVerificationReason
    )
        : base(communityMembersFacepileVerificationReason) { }
#pragma warning restore CS8618

    public CommunityMembersFacepileVerificationReason(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityMembersFacepileVerificationReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityMembersFacepileVerificationReasonFromRaw.FromRawUnchecked"/>
    public static CommunityMembersFacepileVerificationReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityMembersFacepileVerificationReasonFromRaw
    : IFromRawJson<CommunityMembersFacepileVerificationReason>
{
    /// <inheritdoc/>
    public CommunityMembersFacepileVerificationReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityMembersFacepileVerificationReason.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<CommunityMembersFacepile, CommunityMembersFacepileFromRaw>)
)]
public sealed record class CommunityMembersFacepile : JsonModel
{
    /// <summary>
    /// Numeric X user ID of the member
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

    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("username", value);
        }
    }

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

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Omitted when X sends no count, as for the account that first posted reused media.
    /// </summary>
    public long? Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("followers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("followers", value);
        }
    }

    public long? Following
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("following");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("following", value);
        }
    }

    public bool? Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("verified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verified", value);
        }
    }

    /// <summary>
    /// Whether X shows a blue verification badge
    /// </summary>
    public bool? IsBlueVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isBlueVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isBlueVerified", value);
        }
    }

    /// <summary>
    /// Whether X marks the profile as verified
    /// </summary>
    public bool? IsVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isVerified", value);
        }
    }

    /// <summary>
    /// Profile picture at 48 px, as X sends it.
    /// </summary>
    public string? ProfilePicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePicture", value);
        }
    }

    /// <summary>
    /// The same profile picture at full size, as the account uploaded it. Download this one for the image.
    /// </summary>
    public string? ProfilePictureOriginal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePictureOriginal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePictureOriginal", value);
        }
    }

    public string? CoverPicture
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("coverPicture");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("coverPicture", value);
        }
    }

    /// <summary>
    /// Original X profile banner field when available
    /// </summary>
    public string? ProfileBannerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileBannerUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileBannerUrl", value);
        }
    }

    /// <summary>
    /// Account owner's public profile location text
    /// </summary>
    public string? Location
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("location");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <summary>
    /// Null when X shows no label.
    /// </summary>
    public global::XTwitterScraper.Models.AccountBasedIn? AccountBasedIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.AccountBasedIn>(
                "accountBasedIn"
            );
        }
        init { this._rawData.Set("accountBasedIn", value); }
    }

    /// <summary>
    /// True when X withheld accountBasedIn from this read. Retry later.
    /// </summary>
    public bool? AccountBasedInUnavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("accountBasedInUnavailable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accountBasedInUnavailable", value);
        }
    }

    /// <summary>
    /// False when X notes accountBasedIn may be inaccurate.
    /// </summary>
    public bool? AccountBasedInAccurate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("accountBasedInAccurate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("accountBasedInAccurate", value);
        }
    }

    /// <summary>
    /// How the account first connected to X.
    /// </summary>
    public string? ConnectedVia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connectedVia");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectedVia", value);
        }
    }

    /// <summary>
    /// False when X notes that country may be inaccurate.
    /// </summary>
    public bool? ConnectedViaAccurate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("connectedViaAccurate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectedViaAccurate", value);
        }
    }

    /// <summary>
    /// Handle of the organization X shows the account is affiliated with, from its About page.
    /// </summary>
    public string? AffiliateUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("affiliateUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("affiliateUsername", value);
        }
    }

    /// <summary>
    /// First email the account publishes on its profile, lowercased. Omitted when it publishes none.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// Emails, phone numbers &amp; links the account publishes on its own profile. Omitted when it publishes none.
    /// </summary>
    public global::XTwitterScraper.Models.ProfileContactInfo? ContactInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.ProfileContactInfo>(
                "contactInfo"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contactInfo", value);
        }
    }

    /// <summary>
    /// How often the account changed its username.
    /// </summary>
    public CommunityMembersFacepileUsernameChanges? UsernameChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityMembersFacepileUsernameChanges>(
                "usernameChanges"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usernameChanges", value);
        }
    }

    /// <summary>
    /// The parts of the birthday the account made public.
    /// </summary>
    public CommunityMembersFacepileBirthdate? Birthdate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityMembersFacepileBirthdate>("birthdate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("birthdate", value);
        }
    }

    /// <summary>
    /// UTC repost time with includeRetweetTimestamp. Null when Xquik found no repost time. Otherwise omitted.
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

    /// <summary>
    /// Account creation time.
    /// </summary>
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

    public long? StatusesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("statusesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("statusesCount", value);
        }
    }

    public long? MediaCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("mediaCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaCount", value);
        }
    }

    /// <summary>
    /// Whether the profile protects its posts
    /// </summary>
    public bool? Protected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("protected");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("protected", value);
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

    public long? FavouritesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("favouritesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("favouritesCount", value);
        }
    }

    public bool? HasCustomTimelines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasCustomTimelines");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasCustomTimelines", value);
        }
    }

    public bool? IsTranslator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTranslator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTranslator", value);
        }
    }

    public IReadOnlyList<string>? WithheldInCountries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("withheldInCountries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "withheldInCountries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether X withholds a post or user
    /// </summary>
    public string? WithheldScope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("withheldScope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("withheldScope", value);
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
    /// Professional metadata with category display settings
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Professional
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "professional"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "professional",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Public profile bio translation returned by X
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? GrokTranslatedBio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "grokTranslatedBio"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "grokTranslatedBio",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyList<string>? PinnedTweetIDs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("pinnedTweetIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "pinnedTweetIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? IsAutomated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isAutomated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isAutomated", value);
        }
    }

    public string? AutomatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("automatedBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("automatedBy", value);
        }
    }

    public bool? Unavailable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("unavailable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unavailable", value);
        }
    }

    public string? UnavailableReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unavailableReason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unavailableReason", value);
        }
    }

    public string? VerifiedType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verifiedType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verifiedType", value);
        }
    }

    /// <summary>
    /// Organization affiliation label shown on an X profile.
    /// </summary>
    public global::XTwitterScraper.Models.UserAffiliateLabel? AffiliatesHighlightedLabel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserAffiliateLabel>(
                "affiliatesHighlightedLabel"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("affiliatesHighlightedLabel", value);
        }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? BusinessAccountAffiliatesCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("businessAccountAffiliatesCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("businessAccountAffiliatesCount", value);
        }
    }

    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public long? CreatorSubscriptionsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("creatorSubscriptionsCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creatorSubscriptionsCount", value);
        }
    }

    public bool? HasGraduatedAccess
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasGraduatedAccess");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasGraduatedAccess", value);
        }
    }

    public bool? HasHiddenSubscriptionsOnProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasHiddenSubscriptionsOnProfile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasHiddenSubscriptionsOnProfile", value);
        }
    }

    /// <summary>
    /// Profile highlight availability and count metadata.
    /// </summary>
    public global::XTwitterScraper.Models.UserHighlightsInfo? HighlightsInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserHighlightsInfo>(
                "highlightsInfo"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("highlightsInfo", value);
        }
    }

    /// <summary>
    /// Identity verification X shows on the profile &amp; its About page.
    /// </summary>
    public global::XTwitterScraper.Models.UserIdentityVerification? IdentityVerification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserIdentityVerification>(
                "identityVerification"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("identityVerification", value);
        }
    }

    public bool? IsProfileTranslatable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isProfileTranslatable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isProfileTranslatable", value);
        }
    }

    public string? ParodyCommentaryFanLabel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parodyCommentaryFanLabel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("parodyCommentaryFanLabel", value);
        }
    }

    public string? ProfileDescriptionLanguage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileDescriptionLanguage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileDescriptionLanguage", value);
        }
    }

    public string? ProfileImageShape
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileImageShape");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileImageShape", value);
        }
    }

    public string? ProfileInterstitialType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileInterstitialType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileInterstitialType", value);
        }
    }

    public bool? ProfileSortEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("profileSortEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileSortEnabled", value);
        }
    }

    public string? ProfileTranslatorType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileTranslatorType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profileTranslatorType", value);
        }
    }

    /// <summary>
    /// Handle x.com sends this profile's visitors to, such as the new handle of a renamed account whose old handle now holds a placeholder. Missing when x.com shows the profile itself.
    /// </summary>
    public string? RedirectsToUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("redirectsToUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("redirectsToUsername", value);
        }
    }

    public bool? SuperFollowEligible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("superFollowEligible");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("superFollowEligible", value);
        }
    }

    /// <summary>
    /// Whether X marks the subscription profile as active.
    /// </summary>
    public bool? SuperFollowsUserProfileActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("superFollowsUserProfileActive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("superFollowsUserProfileActive", value);
        }
    }

    /// <summary>
    /// Public payment and creator-support handles shown on X.
    /// </summary>
    public global::XTwitterScraper.Models.UserTipJar? TipJar
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::XTwitterScraper.Models.UserTipJar>(
                "tipJar"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tipJar", value);
        }
    }

    /// <summary>
    /// Public lists that include the profile.
    /// </summary>
    public long? ListedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("listedCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("listedCount", value);
        }
    }

    /// <summary>
    /// Followers X counts as fast followers.
    /// </summary>
    public long? FastFollowersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fastFollowersCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fastFollowersCount", value);
        }
    }

    /// <summary>
    /// Followers minus fast followers.
    /// </summary>
    public long? NormalFollowersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("normalFollowersCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("normalFollowersCount", value);
        }
    }

    /// <summary>
    /// Whether the profile keeps X's default theme.
    /// </summary>
    public bool? DefaultProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defaultProfile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultProfile", value);
        }
    }

    /// <summary>
    /// Whether the profile keeps X's default avatar.
    /// </summary>
    public bool? DefaultProfileImage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defaultProfileImage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultProfileImage", value);
        }
    }

    /// <summary>
    /// Whether the profile filled X's extended fields, such as a birth date. True or false.
    /// </summary>
    public bool? HasExtendedProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasExtendedProfile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasExtendedProfile", value);
        }
    }

    /// <summary>
    /// Whether the account turned on X's translation of its posts. True or false.
    /// </summary>
    public bool? IsTranslationEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isTranslationEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isTranslationEnabled", value);
        }
    }

    /// <summary>
    /// Whether the profile may add a location to posts.
    /// </summary>
    public bool? GeoEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("geoEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("geoEnabled", value);
        }
    }

    /// <summary>
    /// The account's X Ads type. `none` for an account without ads, or `promotable_user` for one that may run them.
    /// </summary>
    public string? AdvertiserAccountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("advertiserAccountType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("advertiserAccountType", value);
        }
    }

    /// <summary>
    /// X Ads services the account uses, such as `analytics`, `media_studio` or `smb`. Empty for an account without ads.
    /// </summary>
    public IReadOnlyList<string>? AdvertiserAccountServiceLevels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "advertiserAccountServiceLevels"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "advertiserAccountServiceLevels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether X treats the profile as a business profile. `none` or `enabled`.
    /// </summary>
    public string? BusinessProfileState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("businessProfileState");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("businessProfileState", value);
        }
    }

    /// <summary>
    /// Accounts subscribed to the profile's paid Subscriptions. 0 when it has none.
    /// </summary>
    public long? SubscribersCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("subscribersCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscribersCount", value);
        }
    }

    /// <summary>
    /// X's text on why the profile is verified, with its links.
    /// </summary>
    public CommunityMembersFacepileVerificationReason? VerificationReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CommunityMembersFacepileVerificationReason>(
                "verificationReason"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verificationReason", value);
        }
    }

    /// <summary>
    /// Community role when returned by community member reads
    /// </summary>
    public string? CommunityRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("communityRole");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("communityRole", value);
        }
    }

    /// <summary>
    /// Structured profile bio with entity annotations
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ProfileBio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "profile_bio"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "profile_bio",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Username;
        _ = this.Name;
        _ = this.Description;
        _ = this.Followers;
        _ = this.Following;
        _ = this.Verified;
        _ = this.IsBlueVerified;
        _ = this.IsVerified;
        _ = this.ProfilePicture;
        _ = this.ProfilePictureOriginal;
        _ = this.CoverPicture;
        _ = this.ProfileBannerUrl;
        _ = this.Location;
        this.AccountBasedIn?.Validate();
        _ = this.AccountBasedInUnavailable;
        _ = this.AccountBasedInAccurate;
        _ = this.ConnectedVia;
        _ = this.ConnectedViaAccurate;
        _ = this.AffiliateUsername;
        _ = this.Email;
        this.ContactInfo?.Validate();
        this.UsernameChanges?.Validate();
        this.Birthdate?.Validate();
        _ = this.RetweetedAt;
        _ = this.CreatedAt;
        _ = this.StatusesCount;
        _ = this.MediaCount;
        _ = this.Protected;
        _ = this.UrlValue;
        _ = this.FavouritesCount;
        _ = this.HasCustomTimelines;
        _ = this.IsTranslator;
        _ = this.WithheldInCountries;
        _ = this.WithheldScope;
        _ = this.PossiblySensitive;
        _ = this.Professional;
        _ = this.GrokTranslatedBio;
        _ = this.PinnedTweetIDs;
        _ = this.IsAutomated;
        _ = this.AutomatedBy;
        _ = this.Unavailable;
        _ = this.UnavailableReason;
        _ = this.VerifiedType;
        this.AffiliatesHighlightedLabel?.Validate();
        _ = this.BusinessAccountAffiliatesCount;
        _ = this.CreatorSubscriptionsCount;
        _ = this.HasGraduatedAccess;
        _ = this.HasHiddenSubscriptionsOnProfile;
        this.HighlightsInfo?.Validate();
        this.IdentityVerification?.Validate();
        _ = this.IsProfileTranslatable;
        _ = this.ParodyCommentaryFanLabel;
        _ = this.ProfileDescriptionLanguage;
        _ = this.ProfileImageShape;
        _ = this.ProfileInterstitialType;
        _ = this.ProfileSortEnabled;
        _ = this.ProfileTranslatorType;
        _ = this.RedirectsToUsername;
        _ = this.SuperFollowEligible;
        _ = this.SuperFollowsUserProfileActive;
        this.TipJar?.Validate();
        _ = this.ListedCount;
        _ = this.FastFollowersCount;
        _ = this.NormalFollowersCount;
        _ = this.DefaultProfile;
        _ = this.DefaultProfileImage;
        _ = this.HasExtendedProfile;
        _ = this.IsTranslationEnabled;
        _ = this.GeoEnabled;
        _ = this.AdvertiserAccountType;
        _ = this.AdvertiserAccountServiceLevels;
        _ = this.BusinessProfileState;
        _ = this.SubscribersCount;
        this.VerificationReason?.Validate();
        _ = this.CommunityRole;
        _ = this.ProfileBio;
    }

    public CommunityMembersFacepile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityMembersFacepile(CommunityMembersFacepile communityMembersFacepile)
        : base(communityMembersFacepile) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CommunityMembersFacepile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CommunityMembersFacepile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CommunityMembersFacepileFromRaw.FromRawUnchecked"/>
    public static CommunityMembersFacepile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CommunityMembersFacepileFromRaw : IFromRawJson<CommunityMembersFacepile>
{
    /// <inheritdoc/>
    public CommunityMembersFacepile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CommunityMembersFacepile.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CreatorUsernameChanges, CreatorUsernameChangesFromRaw>))]
public sealed record class CreatorUsernameChanges : JsonModel
{
    /// <summary>
    /// Whole number from 0.
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Time of the latest change, omitted when there is none.
    /// </summary>
    public DateTimeOffset? LastChangedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastChangedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastChangedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.LastChangedAt;
    }

    public CreatorUsernameChanges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatorUsernameChanges(CreatorUsernameChanges creatorUsernameChanges)
        : base(creatorUsernameChanges) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatorUsernameChanges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatorUsernameChanges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatorUsernameChangesFromRaw.FromRawUnchecked"/>
    public static CreatorUsernameChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatorUsernameChangesFromRaw : IFromRawJson<CreatorUsernameChanges>
{
    /// <inheritdoc/>
    public CreatorUsernameChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreatorUsernameChanges.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CreatorBirthdate, CreatorBirthdateFromRaw>))]
public sealed record class CreatorBirthdate : JsonModel
{
    public long? Day
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("day");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("day", value);
        }
    }

    public long? Month
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("month");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("month", value);
        }
    }

    public long? Year
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("year");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("year", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Day;
        _ = this.Month;
        _ = this.Year;
    }

    public CreatorBirthdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatorBirthdate(CreatorBirthdate creatorBirthdate)
        : base(creatorBirthdate) { }
#pragma warning restore CS8618

    public CreatorBirthdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatorBirthdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatorBirthdateFromRaw.FromRawUnchecked"/>
    public static CreatorBirthdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatorBirthdateFromRaw : IFromRawJson<CreatorBirthdate>
{
    /// <inheritdoc/>
    public CreatorBirthdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatorBirthdate.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CreatorVerificationReasonEntities,
        CreatorVerificationReasonEntitiesFromRaw
    >)
)]
public sealed record class CreatorVerificationReasonEntities : JsonModel
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
        _ = this.FromIndex;
        _ = this.ToIndex;
        _ = this.UrlValue;
        _ = this.UrlType;
    }

    public CreatorVerificationReasonEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatorVerificationReasonEntities(
        CreatorVerificationReasonEntities creatorVerificationReasonEntities
    )
        : base(creatorVerificationReasonEntities) { }
#pragma warning restore CS8618

    public CreatorVerificationReasonEntities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatorVerificationReasonEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatorVerificationReasonEntitiesFromRaw.FromRawUnchecked"/>
    public static CreatorVerificationReasonEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatorVerificationReasonEntitiesFromRaw : IFromRawJson<CreatorVerificationReasonEntities>
{
    /// <inheritdoc/>
    public CreatorVerificationReasonEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreatorVerificationReasonEntities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<CreatorVerificationReason, CreatorVerificationReasonFromRaw>)
)]
public sealed record class CreatorVerificationReason : JsonModel
{
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
    /// Links inside the text, by character range.
    /// </summary>
    public IReadOnlyList<CreatorVerificationReasonEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CreatorVerificationReasonEntities>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CreatorVerificationReasonEntities>?>(
                "entities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        foreach (var item in this.Entities ?? [])
        {
            item.Validate();
        }
    }

    public CreatorVerificationReason() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatorVerificationReason(CreatorVerificationReason creatorVerificationReason)
        : base(creatorVerificationReason) { }
#pragma warning restore CS8618

    public CreatorVerificationReason(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatorVerificationReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatorVerificationReasonFromRaw.FromRawUnchecked"/>
    public static CreatorVerificationReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatorVerificationReasonFromRaw : IFromRawJson<CreatorVerificationReason>
{
    /// <inheritdoc/>
    public CreatorVerificationReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreatorVerificationReason.FromRawUnchecked(rawData);
}
