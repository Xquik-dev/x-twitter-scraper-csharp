using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XTwitterScraper.Core;

namespace XTwitterScraper.Models.X.Tweets;

/// <summary>
/// Tweet author profile. The lookup route always includes follower count and verification
/// state. Other profile fields appear when available.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TweetAuthor, TweetAuthorFromRaw>))]
public sealed record class TweetAuthor : JsonModel
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

    public static implicit operator UserProfile(TweetAuthor tweetAuthor) =>
        new()
        {
            ID = tweetAuthor.ID,
            Name = tweetAuthor.Name,
            Username = tweetAuthor.Username,
            AffiliatesHighlightedLabel = tweetAuthor.AffiliatesHighlightedLabel,
            AutomatedBy = tweetAuthor.AutomatedBy,
            BusinessAccountAffiliatesCount = tweetAuthor.BusinessAccountAffiliatesCount,
            CommunityRole = tweetAuthor.CommunityRole,
            CoverPicture = tweetAuthor.CoverPicture,
            CreatedAt = tweetAuthor.CreatedAt,
            CreatorSubscriptionsCount = tweetAuthor.CreatorSubscriptionsCount,
            Description = tweetAuthor.Description,
            FavouritesCount = tweetAuthor.FavouritesCount,
            Followers = tweetAuthor.Followers,
            Following = tweetAuthor.Following,
            HasCustomTimelines = tweetAuthor.HasCustomTimelines,
            HasGraduatedAccess = tweetAuthor.HasGraduatedAccess,
            HasHiddenSubscriptionsOnProfile = tweetAuthor.HasHiddenSubscriptionsOnProfile,
            HighlightsInfo = tweetAuthor.HighlightsInfo,
            IdentityVerification = tweetAuthor.IdentityVerification,
            IsAutomated = tweetAuthor.IsAutomated,
            IsBlueVerified = tweetAuthor.IsBlueVerified,
            IsProfileTranslatable = tweetAuthor.IsProfileTranslatable,
            IsTranslator = tweetAuthor.IsTranslator,
            IsVerified = tweetAuthor.IsVerified,
            Location = tweetAuthor.Location,
            MediaCount = tweetAuthor.MediaCount,
            ParodyCommentaryFanLabel = tweetAuthor.ParodyCommentaryFanLabel,
            PinnedTweetIds = tweetAuthor.PinnedTweetIds,
            PossiblySensitive = tweetAuthor.PossiblySensitive,
            ProfileBio = tweetAuthor.ProfileBio,
            ProfileBannerUrl = tweetAuthor.ProfileBannerUrl,
            ProfileDescriptionLanguage = tweetAuthor.ProfileDescriptionLanguage,
            ProfileImageShape = tweetAuthor.ProfileImageShape,
            ProfileInterstitialType = tweetAuthor.ProfileInterstitialType,
            ProfilePicture = tweetAuthor.ProfilePicture,
            ProfileSortEnabled = tweetAuthor.ProfileSortEnabled,
            ProfileTranslatorType = tweetAuthor.ProfileTranslatorType,
            Protected = tweetAuthor.Protected,
            StatusesCount = tweetAuthor.StatusesCount,
            SuperFollowEligible = tweetAuthor.SuperFollowEligible,
            Unavailable = tweetAuthor.Unavailable,
            UnavailableReason = tweetAuthor.UnavailableReason,
            Url = tweetAuthor.Url,
            Verified = tweetAuthor.Verified,
            VerifiedType = tweetAuthor.VerifiedType,
            WithheldInCountries = tweetAuthor.WithheldInCountries,
        };

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
    public TweetAuthorUsernameChanges? UsernameChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetAuthorUsernameChanges>("usernameChanges");
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
    public TweetAuthorBirthdate? Birthdate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetAuthorBirthdate>("birthdate");
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
    public TweetAuthorVerificationReason? VerificationReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TweetAuthorVerificationReason>(
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
        _ = this.ProfilePictureOriginal;
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
        _ = this.WithheldScope;
        _ = this.Professional;
        _ = this.GrokTranslatedBio;
        _ = this.RedirectsToUsername;
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
    }

    public TweetAuthor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthor(TweetAuthor tweetAuthor)
        : base(tweetAuthor) { }
#pragma warning restore CS8618

    public TweetAuthor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAuthor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAuthorFromRaw.FromRawUnchecked"/>
    public static TweetAuthor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAuthorFromRaw : IFromRawJson<TweetAuthor>
{
    /// <inheritdoc/>
    public TweetAuthor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TweetAuthor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetAuthorRequirements, TweetAuthorRequirementsFromRaw>))]
public sealed record class TweetAuthorRequirements : JsonModel
{
    public required long Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("followers");
        }
        init { this._rawData.Set("followers", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Followers;
        _ = this.Verified;
    }

    public TweetAuthorRequirements() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthorRequirements(TweetAuthorRequirements tweetAuthorRequirements)
        : base(tweetAuthorRequirements) { }
#pragma warning restore CS8618

    public TweetAuthorRequirements(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAuthorRequirements(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAuthorRequirementsFromRaw.FromRawUnchecked"/>
    public static TweetAuthorRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAuthorRequirementsFromRaw : IFromRawJson<TweetAuthorRequirements>
{
    /// <inheritdoc/>
    public TweetAuthorRequirements FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAuthorRequirements.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetAuthorUsernameChanges, TweetAuthorUsernameChangesFromRaw>)
)]
public sealed record class TweetAuthorUsernameChanges : JsonModel
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

    public TweetAuthorUsernameChanges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthorUsernameChanges(TweetAuthorUsernameChanges tweetAuthorUsernameChanges)
        : base(tweetAuthorUsernameChanges) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthorUsernameChanges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAuthorUsernameChanges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAuthorUsernameChangesFromRaw.FromRawUnchecked"/>
    public static TweetAuthorUsernameChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAuthorUsernameChangesFromRaw : IFromRawJson<TweetAuthorUsernameChanges>
{
    /// <inheritdoc/>
    public TweetAuthorUsernameChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAuthorUsernameChanges.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TweetAuthorBirthdate, TweetAuthorBirthdateFromRaw>))]
public sealed record class TweetAuthorBirthdate : JsonModel
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

    public TweetAuthorBirthdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthorBirthdate(TweetAuthorBirthdate tweetAuthorBirthdate)
        : base(tweetAuthorBirthdate) { }
#pragma warning restore CS8618

    public TweetAuthorBirthdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAuthorBirthdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAuthorBirthdateFromRaw.FromRawUnchecked"/>
    public static TweetAuthorBirthdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAuthorBirthdateFromRaw : IFromRawJson<TweetAuthorBirthdate>
{
    /// <inheritdoc/>
    public TweetAuthorBirthdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAuthorBirthdate.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TweetAuthorVerificationReasonEntities,
        TweetAuthorVerificationReasonEntitiesFromRaw
    >)
)]
public sealed record class TweetAuthorVerificationReasonEntities : JsonModel
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

    public TweetAuthorVerificationReasonEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthorVerificationReasonEntities(
        TweetAuthorVerificationReasonEntities tweetAuthorVerificationReasonEntities
    )
        : base(tweetAuthorVerificationReasonEntities) { }
#pragma warning restore CS8618

    public TweetAuthorVerificationReasonEntities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAuthorVerificationReasonEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAuthorVerificationReasonEntitiesFromRaw.FromRawUnchecked"/>
    public static TweetAuthorVerificationReasonEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAuthorVerificationReasonEntitiesFromRaw
    : IFromRawJson<TweetAuthorVerificationReasonEntities>
{
    /// <inheritdoc/>
    public TweetAuthorVerificationReasonEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAuthorVerificationReasonEntities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TweetAuthorVerificationReason, TweetAuthorVerificationReasonFromRaw>)
)]
public sealed record class TweetAuthorVerificationReason : JsonModel
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
    public IReadOnlyList<TweetAuthorVerificationReasonEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<TweetAuthorVerificationReasonEntities>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TweetAuthorVerificationReasonEntities>?>(
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

    public TweetAuthorVerificationReason() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TweetAuthorVerificationReason(
        TweetAuthorVerificationReason tweetAuthorVerificationReason
    )
        : base(tweetAuthorVerificationReason) { }
#pragma warning restore CS8618

    public TweetAuthorVerificationReason(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TweetAuthorVerificationReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TweetAuthorVerificationReasonFromRaw.FromRawUnchecked"/>
    public static TweetAuthorVerificationReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TweetAuthorVerificationReasonFromRaw : IFromRawJson<TweetAuthorVerificationReason>
{
    /// <inheritdoc/>
    public TweetAuthorVerificationReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TweetAuthorVerificationReason.FromRawUnchecked(rawData);
}
