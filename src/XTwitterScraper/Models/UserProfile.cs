using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models;

/// <summary>
/// X user profile with bio, follower counts, and verification status.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserProfile, UserProfileFromRaw>))]
public sealed record class UserProfile : JsonModel
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

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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

    /// <summary>
    /// Organization affiliation label shown on an X profile.
    /// </summary>
    public AffiliatesHighlightedLabel? AffiliatesHighlightedLabel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AffiliatesHighlightedLabel>(
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
    public HighlightsInfo? HighlightsInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<HighlightsInfo>("highlightsInfo");
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
    /// Identity verification metadata displayed by X.
    /// </summary>
    public IdentityVerification? IdentityVerification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityVerification>("identityVerification");
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

    public IReadOnlyList<string>? PinnedTweetIds
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

    public string? Url
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Username;
        this.AffiliatesHighlightedLabel?.Validate();
        _ = this.AutomatedBy;
        _ = this.BusinessAccountAffiliatesCount;
        _ = this.CommunityRole;
        _ = this.CoverPicture;
        _ = this.CreatedAt;
        _ = this.CreatorSubscriptionsCount;
        _ = this.Description;
        _ = this.FavouritesCount;
        _ = this.Followers;
        _ = this.Following;
        _ = this.HasCustomTimelines;
        _ = this.HasGraduatedAccess;
        _ = this.HasHiddenSubscriptionsOnProfile;
        this.HighlightsInfo?.Validate();
        this.IdentityVerification?.Validate();
        _ = this.IsAutomated;
        _ = this.IsBlueVerified;
        _ = this.IsProfileTranslatable;
        _ = this.IsTranslator;
        _ = this.IsVerified;
        _ = this.Location;
        _ = this.MediaCount;
        _ = this.ParodyCommentaryFanLabel;
        _ = this.PinnedTweetIds;
        _ = this.PossiblySensitive;
        _ = this.ProfileBio;
        _ = this.ProfileBannerUrl;
        _ = this.ProfileDescriptionLanguage;
        _ = this.ProfileImageShape;
        _ = this.ProfileInterstitialType;
        _ = this.ProfilePicture;
        _ = this.ProfileSortEnabled;
        _ = this.ProfileTranslatorType;
        _ = this.Protected;
        _ = this.StatusesCount;
        _ = this.SuperFollowEligible;
        _ = this.Unavailable;
        _ = this.UnavailableReason;
        _ = this.Url;
        _ = this.Verified;
        _ = this.VerifiedType;
        _ = this.WithheldInCountries;
    }

    public UserProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfile(UserProfile userProfile)
        : base(userProfile) { }
#pragma warning restore CS8618

    public UserProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileFromRaw.FromRawUnchecked"/>
    public static UserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileFromRaw : IFromRawJson<UserProfile>
{
    /// <inheritdoc/>
    public UserProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// Organization affiliation label shown on an X profile.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AffiliatesHighlightedLabel, AffiliatesHighlightedLabelFromRaw>)
)]
public sealed record class AffiliatesHighlightedLabel : JsonModel
{
    public string? BadgeUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("badgeUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("badgeUrl", value);
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

    public string? Url
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

    public string? UserLabelDisplayType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userLabelDisplayType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userLabelDisplayType", value);
        }
    }

    public string? UserLabelType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("userLabelType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("userLabelType", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BadgeUrl;
        _ = this.Description;
        _ = this.Url;
        _ = this.UrlType;
        _ = this.UserLabelDisplayType;
        _ = this.UserLabelType;
    }

    public AffiliatesHighlightedLabel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AffiliatesHighlightedLabel(AffiliatesHighlightedLabel affiliatesHighlightedLabel)
        : base(affiliatesHighlightedLabel) { }
#pragma warning restore CS8618

    public AffiliatesHighlightedLabel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AffiliatesHighlightedLabel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AffiliatesHighlightedLabelFromRaw.FromRawUnchecked"/>
    public static AffiliatesHighlightedLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AffiliatesHighlightedLabelFromRaw : IFromRawJson<AffiliatesHighlightedLabel>
{
    /// <inheritdoc/>
    public AffiliatesHighlightedLabel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AffiliatesHighlightedLabel.FromRawUnchecked(rawData);
}

/// <summary>
/// Profile highlight availability and count metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<HighlightsInfo, HighlightsInfoFromRaw>))]
public sealed record class HighlightsInfo : JsonModel
{
    public bool? CanHighlightTweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("canHighlightTweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("canHighlightTweets", value);
        }
    }

    public string? HighlightedTweets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("highlightedTweets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("highlightedTweets", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanHighlightTweets;
        _ = this.HighlightedTweets;
    }

    public HighlightsInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HighlightsInfo(HighlightsInfo highlightsInfo)
        : base(highlightsInfo) { }
#pragma warning restore CS8618

    public HighlightsInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HighlightsInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HighlightsInfoFromRaw.FromRawUnchecked"/>
    public static HighlightsInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HighlightsInfoFromRaw : IFromRawJson<HighlightsInfo>
{
    /// <inheritdoc/>
    public HighlightsInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        HighlightsInfo.FromRawUnchecked(rawData);
}

/// <summary>
/// Identity verification metadata displayed by X.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IdentityVerification, IdentityVerificationFromRaw>))]
public sealed record class IdentityVerification : JsonModel
{
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

    public bool? IsIdentityVerified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isIdentityVerified");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isIdentityVerified", value);
        }
    }

    public string? VerifiedSinceMsec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("verifiedSinceMsec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("verifiedSinceMsec", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.IsIdentityVerified;
        _ = this.VerifiedSinceMsec;
    }

    public IdentityVerification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IdentityVerification(IdentityVerification identityVerification)
        : base(identityVerification) { }
#pragma warning restore CS8618

    public IdentityVerification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IdentityVerification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IdentityVerificationFromRaw.FromRawUnchecked"/>
    public static IdentityVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IdentityVerificationFromRaw : IFromRawJson<IdentityVerification>
{
    /// <inheritdoc/>
    public IdentityVerification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IdentityVerification.FromRawUnchecked(rawData);
}
