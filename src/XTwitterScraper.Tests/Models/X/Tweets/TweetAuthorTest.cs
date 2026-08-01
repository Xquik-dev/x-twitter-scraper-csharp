using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetAuthorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AffiliatesHighlightedLabel = new()
            {
                BadgeUrl = "badgeUrl",
                Description = "description",
                Url = "url",
                UrlType = "urlType",
                UserLabelDisplayType = "userLabelDisplayType",
                UserLabelType = "userLabelType",
            },
            AutomatedBy = "example_user",
            BusinessAccountAffiliatesCount = 0,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            CreatorSubscriptionsCount = 0,
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            HasGraduatedAccess = true,
            HasHiddenSubscriptionsOnProfile = true,
            HighlightsInfo = new()
            {
                CanHighlightTweets = true,
                HighlightedTweets = "highlightedTweets",
            },
            IdentityVerification = new()
            {
                Description = "description",
                IsIdentityVerified = true,
                VerifiedSinceMsec = "verifiedSinceMsec",
            },
            IsAutomated = false,
            IsBlueVerified = true,
            IsProfileTranslatable = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            ParodyCommentaryFanLabel = "parodyCommentaryFanLabel",
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfileDescriptionLanguage = "profileDescriptionLanguage",
            ProfileImageShape = "profileImageShape",
            ProfileInterstitialType = "profileInterstitialType",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            ProfileSortEnabled = true,
            ProfileTranslatorType = "profileTranslatorType",
            Protected = false,
            StatusesCount = 35000,
            SuperFollowEligible = true,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            WithheldInCountries = ["DE"],
        };

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        AffiliatesHighlightedLabel expectedAffiliatesHighlightedLabel = new()
        {
            BadgeUrl = "badgeUrl",
            Description = "description",
            Url = "url",
            UrlType = "urlType",
            UserLabelDisplayType = "userLabelDisplayType",
            UserLabelType = "userLabelType",
        };
        string expectedAutomatedBy = "example_user";
        long expectedBusinessAccountAffiliatesCount = 0;
        string expectedCommunityRole = "Member";
        string expectedCoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg";
        string expectedCreatedAt = "2009-06-02T20:12:29Z";
        long expectedCreatorSubscriptionsCount = 0;
        string expectedDescription = "CEO of Tesla, SpaceX, and X";
        long expectedFavouritesCount = 18000;
        long expectedFollowers = 150000000;
        long expectedFollowing = 500;
        bool expectedHasCustomTimelines = true;
        bool expectedHasGraduatedAccess = true;
        bool expectedHasHiddenSubscriptionsOnProfile = true;
        HighlightsInfo expectedHighlightsInfo = new()
        {
            CanHighlightTweets = true,
            HighlightedTweets = "highlightedTweets",
        };
        IdentityVerification expectedIdentityVerification = new()
        {
            Description = "description",
            IsIdentityVerified = true,
            VerifiedSinceMsec = "verifiedSinceMsec",
        };
        bool expectedIsAutomated = false;
        bool expectedIsBlueVerified = true;
        bool expectedIsProfileTranslatable = true;
        bool expectedIsTranslator = false;
        bool expectedIsVerified = true;
        string expectedLocation = "Austin, TX";
        long expectedMediaCount = 1200;
        string expectedParodyCommentaryFanLabel = "parodyCommentaryFanLabel";
        List<string> expectedPinnedTweetIds = ["1234567890"];
        bool expectedPossiblySensitive = false;
        Dictionary<string, JsonElement> expectedProfileBio = new()
        {
            { "description", JsonSerializer.SerializeToElement("bar") },
            { "entities", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg";
        string expectedProfileDescriptionLanguage = "profileDescriptionLanguage";
        string expectedProfileImageShape = "profileImageShape";
        string expectedProfileInterstitialType = "profileInterstitialType";
        string expectedProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg";
        bool expectedProfileSortEnabled = true;
        string expectedProfileTranslatorType = "profileTranslatorType";
        bool expectedProtected = false;
        long expectedStatusesCount = 35000;
        bool expectedSuperFollowEligible = true;
        bool expectedUnavailable = false;
        string expectedUnavailableReason = "suspended";
        string expectedUrl = "https://xquik.com";
        bool expectedVerified = true;
        string expectedVerifiedType = "Business";
        List<string> expectedWithheldInCountries = ["DE"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedAffiliatesHighlightedLabel, model.AffiliatesHighlightedLabel);
        Assert.Equal(expectedAutomatedBy, model.AutomatedBy);
        Assert.Equal(expectedBusinessAccountAffiliatesCount, model.BusinessAccountAffiliatesCount);
        Assert.Equal(expectedCommunityRole, model.CommunityRole);
        Assert.Equal(expectedCoverPicture, model.CoverPicture);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatorSubscriptionsCount, model.CreatorSubscriptionsCount);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFavouritesCount, model.FavouritesCount);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedFollowing, model.Following);
        Assert.Equal(expectedHasCustomTimelines, model.HasCustomTimelines);
        Assert.Equal(expectedHasGraduatedAccess, model.HasGraduatedAccess);
        Assert.Equal(
            expectedHasHiddenSubscriptionsOnProfile,
            model.HasHiddenSubscriptionsOnProfile
        );
        Assert.Equal(expectedHighlightsInfo, model.HighlightsInfo);
        Assert.Equal(expectedIdentityVerification, model.IdentityVerification);
        Assert.Equal(expectedIsAutomated, model.IsAutomated);
        Assert.Equal(expectedIsBlueVerified, model.IsBlueVerified);
        Assert.Equal(expectedIsProfileTranslatable, model.IsProfileTranslatable);
        Assert.Equal(expectedIsTranslator, model.IsTranslator);
        Assert.Equal(expectedIsVerified, model.IsVerified);
        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedMediaCount, model.MediaCount);
        Assert.Equal(expectedParodyCommentaryFanLabel, model.ParodyCommentaryFanLabel);
        Assert.NotNull(model.PinnedTweetIds);
        Assert.Equal(expectedPinnedTweetIds.Count, model.PinnedTweetIds.Count);
        for (int i = 0; i < expectedPinnedTweetIds.Count; i++)
        {
            Assert.Equal(expectedPinnedTweetIds[i], model.PinnedTweetIds[i]);
        }
        Assert.Equal(expectedPossiblySensitive, model.PossiblySensitive);
        Assert.NotNull(model.ProfileBio);
        Assert.Equal(expectedProfileBio.Count, model.ProfileBio.Count);
        foreach (var item in expectedProfileBio)
        {
            Assert.True(model.ProfileBio.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ProfileBio[item.Key]));
        }
        Assert.Equal(expectedProfileBannerUrl, model.ProfileBannerUrl);
        Assert.Equal(expectedProfileDescriptionLanguage, model.ProfileDescriptionLanguage);
        Assert.Equal(expectedProfileImageShape, model.ProfileImageShape);
        Assert.Equal(expectedProfileInterstitialType, model.ProfileInterstitialType);
        Assert.Equal(expectedProfilePicture, model.ProfilePicture);
        Assert.Equal(expectedProfileSortEnabled, model.ProfileSortEnabled);
        Assert.Equal(expectedProfileTranslatorType, model.ProfileTranslatorType);
        Assert.Equal(expectedProtected, model.Protected);
        Assert.Equal(expectedStatusesCount, model.StatusesCount);
        Assert.Equal(expectedSuperFollowEligible, model.SuperFollowEligible);
        Assert.Equal(expectedUnavailable, model.Unavailable);
        Assert.Equal(expectedUnavailableReason, model.UnavailableReason);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVerified, model.Verified);
        Assert.Equal(expectedVerifiedType, model.VerifiedType);
        Assert.NotNull(model.WithheldInCountries);
        Assert.Equal(expectedWithheldInCountries.Count, model.WithheldInCountries.Count);
        for (int i = 0; i < expectedWithheldInCountries.Count; i++)
        {
            Assert.Equal(expectedWithheldInCountries[i], model.WithheldInCountries[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AffiliatesHighlightedLabel = new()
            {
                BadgeUrl = "badgeUrl",
                Description = "description",
                Url = "url",
                UrlType = "urlType",
                UserLabelDisplayType = "userLabelDisplayType",
                UserLabelType = "userLabelType",
            },
            AutomatedBy = "example_user",
            BusinessAccountAffiliatesCount = 0,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            CreatorSubscriptionsCount = 0,
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            HasGraduatedAccess = true,
            HasHiddenSubscriptionsOnProfile = true,
            HighlightsInfo = new()
            {
                CanHighlightTweets = true,
                HighlightedTweets = "highlightedTweets",
            },
            IdentityVerification = new()
            {
                Description = "description",
                IsIdentityVerified = true,
                VerifiedSinceMsec = "verifiedSinceMsec",
            },
            IsAutomated = false,
            IsBlueVerified = true,
            IsProfileTranslatable = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            ParodyCommentaryFanLabel = "parodyCommentaryFanLabel",
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfileDescriptionLanguage = "profileDescriptionLanguage",
            ProfileImageShape = "profileImageShape",
            ProfileInterstitialType = "profileInterstitialType",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            ProfileSortEnabled = true,
            ProfileTranslatorType = "profileTranslatorType",
            Protected = false,
            StatusesCount = 35000,
            SuperFollowEligible = true,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            WithheldInCountries = ["DE"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetAuthor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AffiliatesHighlightedLabel = new()
            {
                BadgeUrl = "badgeUrl",
                Description = "description",
                Url = "url",
                UrlType = "urlType",
                UserLabelDisplayType = "userLabelDisplayType",
                UserLabelType = "userLabelType",
            },
            AutomatedBy = "example_user",
            BusinessAccountAffiliatesCount = 0,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            CreatorSubscriptionsCount = 0,
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            HasGraduatedAccess = true,
            HasHiddenSubscriptionsOnProfile = true,
            HighlightsInfo = new()
            {
                CanHighlightTweets = true,
                HighlightedTweets = "highlightedTweets",
            },
            IdentityVerification = new()
            {
                Description = "description",
                IsIdentityVerified = true,
                VerifiedSinceMsec = "verifiedSinceMsec",
            },
            IsAutomated = false,
            IsBlueVerified = true,
            IsProfileTranslatable = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            ParodyCommentaryFanLabel = "parodyCommentaryFanLabel",
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfileDescriptionLanguage = "profileDescriptionLanguage",
            ProfileImageShape = "profileImageShape",
            ProfileInterstitialType = "profileInterstitialType",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            ProfileSortEnabled = true,
            ProfileTranslatorType = "profileTranslatorType",
            Protected = false,
            StatusesCount = 35000,
            SuperFollowEligible = true,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            WithheldInCountries = ["DE"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetAuthor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        AffiliatesHighlightedLabel expectedAffiliatesHighlightedLabel = new()
        {
            BadgeUrl = "badgeUrl",
            Description = "description",
            Url = "url",
            UrlType = "urlType",
            UserLabelDisplayType = "userLabelDisplayType",
            UserLabelType = "userLabelType",
        };
        string expectedAutomatedBy = "example_user";
        long expectedBusinessAccountAffiliatesCount = 0;
        string expectedCommunityRole = "Member";
        string expectedCoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg";
        string expectedCreatedAt = "2009-06-02T20:12:29Z";
        long expectedCreatorSubscriptionsCount = 0;
        string expectedDescription = "CEO of Tesla, SpaceX, and X";
        long expectedFavouritesCount = 18000;
        long expectedFollowers = 150000000;
        long expectedFollowing = 500;
        bool expectedHasCustomTimelines = true;
        bool expectedHasGraduatedAccess = true;
        bool expectedHasHiddenSubscriptionsOnProfile = true;
        HighlightsInfo expectedHighlightsInfo = new()
        {
            CanHighlightTweets = true,
            HighlightedTweets = "highlightedTweets",
        };
        IdentityVerification expectedIdentityVerification = new()
        {
            Description = "description",
            IsIdentityVerified = true,
            VerifiedSinceMsec = "verifiedSinceMsec",
        };
        bool expectedIsAutomated = false;
        bool expectedIsBlueVerified = true;
        bool expectedIsProfileTranslatable = true;
        bool expectedIsTranslator = false;
        bool expectedIsVerified = true;
        string expectedLocation = "Austin, TX";
        long expectedMediaCount = 1200;
        string expectedParodyCommentaryFanLabel = "parodyCommentaryFanLabel";
        List<string> expectedPinnedTweetIds = ["1234567890"];
        bool expectedPossiblySensitive = false;
        Dictionary<string, JsonElement> expectedProfileBio = new()
        {
            { "description", JsonSerializer.SerializeToElement("bar") },
            { "entities", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg";
        string expectedProfileDescriptionLanguage = "profileDescriptionLanguage";
        string expectedProfileImageShape = "profileImageShape";
        string expectedProfileInterstitialType = "profileInterstitialType";
        string expectedProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg";
        bool expectedProfileSortEnabled = true;
        string expectedProfileTranslatorType = "profileTranslatorType";
        bool expectedProtected = false;
        long expectedStatusesCount = 35000;
        bool expectedSuperFollowEligible = true;
        bool expectedUnavailable = false;
        string expectedUnavailableReason = "suspended";
        string expectedUrl = "https://xquik.com";
        bool expectedVerified = true;
        string expectedVerifiedType = "Business";
        List<string> expectedWithheldInCountries = ["DE"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedAffiliatesHighlightedLabel, deserialized.AffiliatesHighlightedLabel);
        Assert.Equal(expectedAutomatedBy, deserialized.AutomatedBy);
        Assert.Equal(
            expectedBusinessAccountAffiliatesCount,
            deserialized.BusinessAccountAffiliatesCount
        );
        Assert.Equal(expectedCommunityRole, deserialized.CommunityRole);
        Assert.Equal(expectedCoverPicture, deserialized.CoverPicture);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatorSubscriptionsCount, deserialized.CreatorSubscriptionsCount);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFavouritesCount, deserialized.FavouritesCount);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedFollowing, deserialized.Following);
        Assert.Equal(expectedHasCustomTimelines, deserialized.HasCustomTimelines);
        Assert.Equal(expectedHasGraduatedAccess, deserialized.HasGraduatedAccess);
        Assert.Equal(
            expectedHasHiddenSubscriptionsOnProfile,
            deserialized.HasHiddenSubscriptionsOnProfile
        );
        Assert.Equal(expectedHighlightsInfo, deserialized.HighlightsInfo);
        Assert.Equal(expectedIdentityVerification, deserialized.IdentityVerification);
        Assert.Equal(expectedIsAutomated, deserialized.IsAutomated);
        Assert.Equal(expectedIsBlueVerified, deserialized.IsBlueVerified);
        Assert.Equal(expectedIsProfileTranslatable, deserialized.IsProfileTranslatable);
        Assert.Equal(expectedIsTranslator, deserialized.IsTranslator);
        Assert.Equal(expectedIsVerified, deserialized.IsVerified);
        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedMediaCount, deserialized.MediaCount);
        Assert.Equal(expectedParodyCommentaryFanLabel, deserialized.ParodyCommentaryFanLabel);
        Assert.NotNull(deserialized.PinnedTweetIds);
        Assert.Equal(expectedPinnedTweetIds.Count, deserialized.PinnedTweetIds.Count);
        for (int i = 0; i < expectedPinnedTweetIds.Count; i++)
        {
            Assert.Equal(expectedPinnedTweetIds[i], deserialized.PinnedTweetIds[i]);
        }
        Assert.Equal(expectedPossiblySensitive, deserialized.PossiblySensitive);
        Assert.NotNull(deserialized.ProfileBio);
        Assert.Equal(expectedProfileBio.Count, deserialized.ProfileBio.Count);
        foreach (var item in expectedProfileBio)
        {
            Assert.True(deserialized.ProfileBio.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ProfileBio[item.Key]));
        }
        Assert.Equal(expectedProfileBannerUrl, deserialized.ProfileBannerUrl);
        Assert.Equal(expectedProfileDescriptionLanguage, deserialized.ProfileDescriptionLanguage);
        Assert.Equal(expectedProfileImageShape, deserialized.ProfileImageShape);
        Assert.Equal(expectedProfileInterstitialType, deserialized.ProfileInterstitialType);
        Assert.Equal(expectedProfilePicture, deserialized.ProfilePicture);
        Assert.Equal(expectedProfileSortEnabled, deserialized.ProfileSortEnabled);
        Assert.Equal(expectedProfileTranslatorType, deserialized.ProfileTranslatorType);
        Assert.Equal(expectedProtected, deserialized.Protected);
        Assert.Equal(expectedStatusesCount, deserialized.StatusesCount);
        Assert.Equal(expectedSuperFollowEligible, deserialized.SuperFollowEligible);
        Assert.Equal(expectedUnavailable, deserialized.Unavailable);
        Assert.Equal(expectedUnavailableReason, deserialized.UnavailableReason);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVerified, deserialized.Verified);
        Assert.Equal(expectedVerifiedType, deserialized.VerifiedType);
        Assert.NotNull(deserialized.WithheldInCountries);
        Assert.Equal(expectedWithheldInCountries.Count, deserialized.WithheldInCountries.Count);
        for (int i = 0; i < expectedWithheldInCountries.Count; i++)
        {
            Assert.Equal(expectedWithheldInCountries[i], deserialized.WithheldInCountries[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AffiliatesHighlightedLabel = new()
            {
                BadgeUrl = "badgeUrl",
                Description = "description",
                Url = "url",
                UrlType = "urlType",
                UserLabelDisplayType = "userLabelDisplayType",
                UserLabelType = "userLabelType",
            },
            AutomatedBy = "example_user",
            BusinessAccountAffiliatesCount = 0,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            CreatorSubscriptionsCount = 0,
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            HasGraduatedAccess = true,
            HasHiddenSubscriptionsOnProfile = true,
            HighlightsInfo = new()
            {
                CanHighlightTweets = true,
                HighlightedTweets = "highlightedTweets",
            },
            IdentityVerification = new()
            {
                Description = "description",
                IsIdentityVerified = true,
                VerifiedSinceMsec = "verifiedSinceMsec",
            },
            IsAutomated = false,
            IsBlueVerified = true,
            IsProfileTranslatable = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            ParodyCommentaryFanLabel = "parodyCommentaryFanLabel",
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfileDescriptionLanguage = "profileDescriptionLanguage",
            ProfileImageShape = "profileImageShape",
            ProfileInterstitialType = "profileInterstitialType",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            ProfileSortEnabled = true,
            ProfileTranslatorType = "profileTranslatorType",
            Protected = false,
            StatusesCount = 35000,
            SuperFollowEligible = true,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            WithheldInCountries = ["DE"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
        };

        Assert.Null(model.AffiliatesHighlightedLabel);
        Assert.False(model.RawData.ContainsKey("affiliatesHighlightedLabel"));
        Assert.Null(model.AutomatedBy);
        Assert.False(model.RawData.ContainsKey("automatedBy"));
        Assert.Null(model.BusinessAccountAffiliatesCount);
        Assert.False(model.RawData.ContainsKey("businessAccountAffiliatesCount"));
        Assert.Null(model.CommunityRole);
        Assert.False(model.RawData.ContainsKey("communityRole"));
        Assert.Null(model.CoverPicture);
        Assert.False(model.RawData.ContainsKey("coverPicture"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CreatorSubscriptionsCount);
        Assert.False(model.RawData.ContainsKey("creatorSubscriptionsCount"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FavouritesCount);
        Assert.False(model.RawData.ContainsKey("favouritesCount"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Following);
        Assert.False(model.RawData.ContainsKey("following"));
        Assert.Null(model.HasCustomTimelines);
        Assert.False(model.RawData.ContainsKey("hasCustomTimelines"));
        Assert.Null(model.HasGraduatedAccess);
        Assert.False(model.RawData.ContainsKey("hasGraduatedAccess"));
        Assert.Null(model.HasHiddenSubscriptionsOnProfile);
        Assert.False(model.RawData.ContainsKey("hasHiddenSubscriptionsOnProfile"));
        Assert.Null(model.HighlightsInfo);
        Assert.False(model.RawData.ContainsKey("highlightsInfo"));
        Assert.Null(model.IdentityVerification);
        Assert.False(model.RawData.ContainsKey("identityVerification"));
        Assert.Null(model.IsAutomated);
        Assert.False(model.RawData.ContainsKey("isAutomated"));
        Assert.Null(model.IsBlueVerified);
        Assert.False(model.RawData.ContainsKey("isBlueVerified"));
        Assert.Null(model.IsProfileTranslatable);
        Assert.False(model.RawData.ContainsKey("isProfileTranslatable"));
        Assert.Null(model.IsTranslator);
        Assert.False(model.RawData.ContainsKey("isTranslator"));
        Assert.Null(model.IsVerified);
        Assert.False(model.RawData.ContainsKey("isVerified"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.MediaCount);
        Assert.False(model.RawData.ContainsKey("mediaCount"));
        Assert.Null(model.ParodyCommentaryFanLabel);
        Assert.False(model.RawData.ContainsKey("parodyCommentaryFanLabel"));
        Assert.Null(model.PinnedTweetIds);
        Assert.False(model.RawData.ContainsKey("pinnedTweetIds"));
        Assert.Null(model.PossiblySensitive);
        Assert.False(model.RawData.ContainsKey("possiblySensitive"));
        Assert.Null(model.ProfileBio);
        Assert.False(model.RawData.ContainsKey("profile_bio"));
        Assert.Null(model.ProfileBannerUrl);
        Assert.False(model.RawData.ContainsKey("profileBannerUrl"));
        Assert.Null(model.ProfileDescriptionLanguage);
        Assert.False(model.RawData.ContainsKey("profileDescriptionLanguage"));
        Assert.Null(model.ProfileImageShape);
        Assert.False(model.RawData.ContainsKey("profileImageShape"));
        Assert.Null(model.ProfileInterstitialType);
        Assert.False(model.RawData.ContainsKey("profileInterstitialType"));
        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
        Assert.Null(model.ProfileSortEnabled);
        Assert.False(model.RawData.ContainsKey("profileSortEnabled"));
        Assert.Null(model.ProfileTranslatorType);
        Assert.False(model.RawData.ContainsKey("profileTranslatorType"));
        Assert.Null(model.Protected);
        Assert.False(model.RawData.ContainsKey("protected"));
        Assert.Null(model.StatusesCount);
        Assert.False(model.RawData.ContainsKey("statusesCount"));
        Assert.Null(model.SuperFollowEligible);
        Assert.False(model.RawData.ContainsKey("superFollowEligible"));
        Assert.Null(model.Unavailable);
        Assert.False(model.RawData.ContainsKey("unavailable"));
        Assert.Null(model.UnavailableReason);
        Assert.False(model.RawData.ContainsKey("unavailableReason"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
        Assert.Null(model.VerifiedType);
        Assert.False(model.RawData.ContainsKey("verifiedType"));
        Assert.Null(model.WithheldInCountries);
        Assert.False(model.RawData.ContainsKey("withheldInCountries"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            AffiliatesHighlightedLabel = null,
            AutomatedBy = null,
            BusinessAccountAffiliatesCount = null,
            CommunityRole = null,
            CoverPicture = null,
            CreatedAt = null,
            CreatorSubscriptionsCount = null,
            Description = null,
            FavouritesCount = null,
            Followers = null,
            Following = null,
            HasCustomTimelines = null,
            HasGraduatedAccess = null,
            HasHiddenSubscriptionsOnProfile = null,
            HighlightsInfo = null,
            IdentityVerification = null,
            IsAutomated = null,
            IsBlueVerified = null,
            IsProfileTranslatable = null,
            IsTranslator = null,
            IsVerified = null,
            Location = null,
            MediaCount = null,
            ParodyCommentaryFanLabel = null,
            PinnedTweetIds = null,
            PossiblySensitive = null,
            ProfileBio = null,
            ProfileBannerUrl = null,
            ProfileDescriptionLanguage = null,
            ProfileImageShape = null,
            ProfileInterstitialType = null,
            ProfilePicture = null,
            ProfileSortEnabled = null,
            ProfileTranslatorType = null,
            Protected = null,
            StatusesCount = null,
            SuperFollowEligible = null,
            Unavailable = null,
            UnavailableReason = null,
            Url = null,
            Verified = null,
            VerifiedType = null,
            WithheldInCountries = null,
        };

        Assert.Null(model.AffiliatesHighlightedLabel);
        Assert.False(model.RawData.ContainsKey("affiliatesHighlightedLabel"));
        Assert.Null(model.AutomatedBy);
        Assert.False(model.RawData.ContainsKey("automatedBy"));
        Assert.Null(model.BusinessAccountAffiliatesCount);
        Assert.False(model.RawData.ContainsKey("businessAccountAffiliatesCount"));
        Assert.Null(model.CommunityRole);
        Assert.False(model.RawData.ContainsKey("communityRole"));
        Assert.Null(model.CoverPicture);
        Assert.False(model.RawData.ContainsKey("coverPicture"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.CreatorSubscriptionsCount);
        Assert.False(model.RawData.ContainsKey("creatorSubscriptionsCount"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FavouritesCount);
        Assert.False(model.RawData.ContainsKey("favouritesCount"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Following);
        Assert.False(model.RawData.ContainsKey("following"));
        Assert.Null(model.HasCustomTimelines);
        Assert.False(model.RawData.ContainsKey("hasCustomTimelines"));
        Assert.Null(model.HasGraduatedAccess);
        Assert.False(model.RawData.ContainsKey("hasGraduatedAccess"));
        Assert.Null(model.HasHiddenSubscriptionsOnProfile);
        Assert.False(model.RawData.ContainsKey("hasHiddenSubscriptionsOnProfile"));
        Assert.Null(model.HighlightsInfo);
        Assert.False(model.RawData.ContainsKey("highlightsInfo"));
        Assert.Null(model.IdentityVerification);
        Assert.False(model.RawData.ContainsKey("identityVerification"));
        Assert.Null(model.IsAutomated);
        Assert.False(model.RawData.ContainsKey("isAutomated"));
        Assert.Null(model.IsBlueVerified);
        Assert.False(model.RawData.ContainsKey("isBlueVerified"));
        Assert.Null(model.IsProfileTranslatable);
        Assert.False(model.RawData.ContainsKey("isProfileTranslatable"));
        Assert.Null(model.IsTranslator);
        Assert.False(model.RawData.ContainsKey("isTranslator"));
        Assert.Null(model.IsVerified);
        Assert.False(model.RawData.ContainsKey("isVerified"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.MediaCount);
        Assert.False(model.RawData.ContainsKey("mediaCount"));
        Assert.Null(model.ParodyCommentaryFanLabel);
        Assert.False(model.RawData.ContainsKey("parodyCommentaryFanLabel"));
        Assert.Null(model.PinnedTweetIds);
        Assert.False(model.RawData.ContainsKey("pinnedTweetIds"));
        Assert.Null(model.PossiblySensitive);
        Assert.False(model.RawData.ContainsKey("possiblySensitive"));
        Assert.Null(model.ProfileBio);
        Assert.False(model.RawData.ContainsKey("profile_bio"));
        Assert.Null(model.ProfileBannerUrl);
        Assert.False(model.RawData.ContainsKey("profileBannerUrl"));
        Assert.Null(model.ProfileDescriptionLanguage);
        Assert.False(model.RawData.ContainsKey("profileDescriptionLanguage"));
        Assert.Null(model.ProfileImageShape);
        Assert.False(model.RawData.ContainsKey("profileImageShape"));
        Assert.Null(model.ProfileInterstitialType);
        Assert.False(model.RawData.ContainsKey("profileInterstitialType"));
        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
        Assert.Null(model.ProfileSortEnabled);
        Assert.False(model.RawData.ContainsKey("profileSortEnabled"));
        Assert.Null(model.ProfileTranslatorType);
        Assert.False(model.RawData.ContainsKey("profileTranslatorType"));
        Assert.Null(model.Protected);
        Assert.False(model.RawData.ContainsKey("protected"));
        Assert.Null(model.StatusesCount);
        Assert.False(model.RawData.ContainsKey("statusesCount"));
        Assert.Null(model.SuperFollowEligible);
        Assert.False(model.RawData.ContainsKey("superFollowEligible"));
        Assert.Null(model.Unavailable);
        Assert.False(model.RawData.ContainsKey("unavailable"));
        Assert.Null(model.UnavailableReason);
        Assert.False(model.RawData.ContainsKey("unavailableReason"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
        Assert.Null(model.VerifiedType);
        Assert.False(model.RawData.ContainsKey("verifiedType"));
        Assert.Null(model.WithheldInCountries);
        Assert.False(model.RawData.ContainsKey("withheldInCountries"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            AffiliatesHighlightedLabel = null,
            AutomatedBy = null,
            BusinessAccountAffiliatesCount = null,
            CommunityRole = null,
            CoverPicture = null,
            CreatedAt = null,
            CreatorSubscriptionsCount = null,
            Description = null,
            FavouritesCount = null,
            Followers = null,
            Following = null,
            HasCustomTimelines = null,
            HasGraduatedAccess = null,
            HasHiddenSubscriptionsOnProfile = null,
            HighlightsInfo = null,
            IdentityVerification = null,
            IsAutomated = null,
            IsBlueVerified = null,
            IsProfileTranslatable = null,
            IsTranslator = null,
            IsVerified = null,
            Location = null,
            MediaCount = null,
            ParodyCommentaryFanLabel = null,
            PinnedTweetIds = null,
            PossiblySensitive = null,
            ProfileBio = null,
            ProfileBannerUrl = null,
            ProfileDescriptionLanguage = null,
            ProfileImageShape = null,
            ProfileInterstitialType = null,
            ProfilePicture = null,
            ProfileSortEnabled = null,
            ProfileTranslatorType = null,
            Protected = null,
            StatusesCount = null,
            SuperFollowEligible = null,
            Unavailable = null,
            UnavailableReason = null,
            Url = null,
            Verified = null,
            VerifiedType = null,
            WithheldInCountries = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AffiliatesHighlightedLabel = new()
            {
                BadgeUrl = "badgeUrl",
                Description = "description",
                Url = "url",
                UrlType = "urlType",
                UserLabelDisplayType = "userLabelDisplayType",
                UserLabelType = "userLabelType",
            },
            AutomatedBy = "example_user",
            BusinessAccountAffiliatesCount = 0,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            CreatorSubscriptionsCount = 0,
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            HasGraduatedAccess = true,
            HasHiddenSubscriptionsOnProfile = true,
            HighlightsInfo = new()
            {
                CanHighlightTweets = true,
                HighlightedTweets = "highlightedTweets",
            },
            IdentityVerification = new()
            {
                Description = "description",
                IsIdentityVerified = true,
                VerifiedSinceMsec = "verifiedSinceMsec",
            },
            IsAutomated = false,
            IsBlueVerified = true,
            IsProfileTranslatable = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            ParodyCommentaryFanLabel = "parodyCommentaryFanLabel",
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfileDescriptionLanguage = "profileDescriptionLanguage",
            ProfileImageShape = "profileImageShape",
            ProfileInterstitialType = "profileInterstitialType",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            ProfileSortEnabled = true,
            ProfileTranslatorType = "profileTranslatorType",
            Protected = false,
            StatusesCount = 35000,
            SuperFollowEligible = true,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            WithheldInCountries = ["DE"],
        };

        TweetAuthor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TweetAuthorRequirementsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetAuthorRequirements { Followers = 150000000, Verified = true };

        long expectedFollowers = 150000000;
        bool expectedVerified = true;

        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedVerified, model.Verified);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetAuthorRequirements { Followers = 150000000, Verified = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetAuthorRequirements>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetAuthorRequirements { Followers = 150000000, Verified = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetAuthorRequirements>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedFollowers = 150000000;
        bool expectedVerified = true;

        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedVerified, deserialized.Verified);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetAuthorRequirements { Followers = 150000000, Verified = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetAuthorRequirements { Followers = 150000000, Verified = true };

        TweetAuthorRequirements copied = new(model);

        Assert.Equal(model, copied);
    }
}
