using System;
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
    public UserProfileUsernameChanges? UsernameChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserProfileUsernameChanges>("usernameChanges");
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
    public UserProfileBirthdate? Birthdate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserProfileBirthdate>("birthdate");
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
    public UserProfileVerificationReason? VerificationReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserProfileVerificationReason>(
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

    /// <summary>
    /// More labels X shows beside the affiliation, such as an automated account's owner.
    /// </summary>
    public IReadOnlyList<global::XTwitterScraper.Models.UserAuxiliaryLabel>? AuxiliaryLabels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<global::XTwitterScraper.Models.UserAuxiliaryLabel>
            >("auxiliaryLabels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<global::XTwitterScraper.Models.UserAuxiliaryLabel>?>(
                "auxiliaryLabels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Public text, ranges, references, and mention data.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? LongDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "longDescription"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "longDescription",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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
        foreach (var item in this.AuxiliaryLabels ?? [])
        {
            item.Validate();
        }
        _ = this.LongDescription;
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

    /// <summary>
    /// The year X shows as the start of verification, in place of verifiedSinceMsec.
    /// </summary>
    public long? OverrideVerifiedYear
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("overrideVerifiedYear");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("overrideVerifiedYear", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.IsIdentityVerified;
        _ = this.VerifiedSinceMsec;
        _ = this.OverrideVerifiedYear;
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

[JsonConverter(
    typeof(JsonModelConverter<UserProfileUsernameChanges, UserProfileUsernameChangesFromRaw>)
)]
public sealed record class UserProfileUsernameChanges : JsonModel
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

    public UserProfileUsernameChanges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileUsernameChanges(UserProfileUsernameChanges userProfileUsernameChanges)
        : base(userProfileUsernameChanges) { }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileUsernameChanges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileUsernameChanges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileUsernameChangesFromRaw.FromRawUnchecked"/>
    public static UserProfileUsernameChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileUsernameChangesFromRaw : IFromRawJson<UserProfileUsernameChanges>
{
    /// <inheritdoc/>
    public UserProfileUsernameChanges FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileUsernameChanges.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UserProfileBirthdate, UserProfileBirthdateFromRaw>))]
public sealed record class UserProfileBirthdate : JsonModel
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

    public UserProfileBirthdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileBirthdate(UserProfileBirthdate userProfileBirthdate)
        : base(userProfileBirthdate) { }
#pragma warning restore CS8618

    public UserProfileBirthdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileBirthdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileBirthdateFromRaw.FromRawUnchecked"/>
    public static UserProfileBirthdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileBirthdateFromRaw : IFromRawJson<UserProfileBirthdate>
{
    /// <inheritdoc/>
    public UserProfileBirthdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileBirthdate.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UserProfileVerificationReasonEntities,
        UserProfileVerificationReasonEntitiesFromRaw
    >)
)]
public sealed record class UserProfileVerificationReasonEntities : JsonModel
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

    public UserProfileVerificationReasonEntities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileVerificationReasonEntities(
        UserProfileVerificationReasonEntities userProfileVerificationReasonEntities
    )
        : base(userProfileVerificationReasonEntities) { }
#pragma warning restore CS8618

    public UserProfileVerificationReasonEntities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileVerificationReasonEntities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileVerificationReasonEntitiesFromRaw.FromRawUnchecked"/>
    public static UserProfileVerificationReasonEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileVerificationReasonEntitiesFromRaw
    : IFromRawJson<UserProfileVerificationReasonEntities>
{
    /// <inheritdoc/>
    public UserProfileVerificationReasonEntities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileVerificationReasonEntities.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<UserProfileVerificationReason, UserProfileVerificationReasonFromRaw>)
)]
public sealed record class UserProfileVerificationReason : JsonModel
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
    public IReadOnlyList<UserProfileVerificationReasonEntities>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<UserProfileVerificationReasonEntities>
            >("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UserProfileVerificationReasonEntities>?>(
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

    public UserProfileVerificationReason() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileVerificationReason(
        UserProfileVerificationReason userProfileVerificationReason
    )
        : base(userProfileVerificationReason) { }
#pragma warning restore CS8618

    public UserProfileVerificationReason(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileVerificationReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileVerificationReasonFromRaw.FromRawUnchecked"/>
    public static UserProfileVerificationReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileVerificationReasonFromRaw : IFromRawJson<UserProfileVerificationReason>
{
    /// <inheritdoc/>
    public UserProfileVerificationReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileVerificationReason.FromRawUnchecked(rawData);
}
