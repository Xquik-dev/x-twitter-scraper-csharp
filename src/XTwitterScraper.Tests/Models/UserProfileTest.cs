using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class UserProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfile
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AutomatedBy = "example_user",
            CanDm = false,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            IsAutomated = false,
            IsBlueVerified = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            Protected = false,
            StatusesCount = 35000,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            ViewerFollowedBy = false,
            ViewerFollowing = true,
            WithheldInCountries = ["DE"],
        };

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        string expectedAutomatedBy = "example_user";
        bool expectedCanDm = false;
        string expectedCommunityRole = "Member";
        string expectedCoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg";
        string expectedCreatedAt = "2009-06-02T20:12:29Z";
        string expectedDescription = "CEO of Tesla, SpaceX, and X";
        long expectedFavouritesCount = 18000;
        long expectedFollowers = 150000000;
        long expectedFollowing = 500;
        bool expectedHasCustomTimelines = true;
        bool expectedIsAutomated = false;
        bool expectedIsBlueVerified = true;
        bool expectedIsTranslator = false;
        bool expectedIsVerified = true;
        string expectedLocation = "Austin, TX";
        long expectedMediaCount = 1200;
        List<string> expectedPinnedTweetIds = ["1234567890"];
        bool expectedPossiblySensitive = false;
        Dictionary<string, JsonElement> expectedProfileBio = new()
        {
            { "description", JsonSerializer.SerializeToElement("bar") },
            { "entities", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg";
        string expectedProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg";
        bool expectedProtected = false;
        long expectedStatusesCount = 35000;
        bool expectedUnavailable = false;
        string expectedUnavailableReason = "suspended";
        string expectedUrl = "https://xquik.com";
        bool expectedVerified = true;
        string expectedVerifiedType = "Business";
        bool expectedViewerFollowedBy = false;
        bool expectedViewerFollowing = true;
        List<string> expectedWithheldInCountries = ["DE"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedAutomatedBy, model.AutomatedBy);
        Assert.Equal(expectedCanDm, model.CanDm);
        Assert.Equal(expectedCommunityRole, model.CommunityRole);
        Assert.Equal(expectedCoverPicture, model.CoverPicture);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFavouritesCount, model.FavouritesCount);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedFollowing, model.Following);
        Assert.Equal(expectedHasCustomTimelines, model.HasCustomTimelines);
        Assert.Equal(expectedIsAutomated, model.IsAutomated);
        Assert.Equal(expectedIsBlueVerified, model.IsBlueVerified);
        Assert.Equal(expectedIsTranslator, model.IsTranslator);
        Assert.Equal(expectedIsVerified, model.IsVerified);
        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedMediaCount, model.MediaCount);
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
        Assert.Equal(expectedProfilePicture, model.ProfilePicture);
        Assert.Equal(expectedProtected, model.Protected);
        Assert.Equal(expectedStatusesCount, model.StatusesCount);
        Assert.Equal(expectedUnavailable, model.Unavailable);
        Assert.Equal(expectedUnavailableReason, model.UnavailableReason);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedVerified, model.Verified);
        Assert.Equal(expectedVerifiedType, model.VerifiedType);
        Assert.Equal(expectedViewerFollowedBy, model.ViewerFollowedBy);
        Assert.Equal(expectedViewerFollowing, model.ViewerFollowing);
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
        var model = new UserProfile
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AutomatedBy = "example_user",
            CanDm = false,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            IsAutomated = false,
            IsBlueVerified = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            Protected = false,
            StatusesCount = 35000,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            ViewerFollowedBy = false,
            ViewerFollowing = true,
            WithheldInCountries = ["DE"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfile
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AutomatedBy = "example_user",
            CanDm = false,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            IsAutomated = false,
            IsBlueVerified = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            Protected = false,
            StatusesCount = 35000,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            ViewerFollowedBy = false,
            ViewerFollowing = true,
            WithheldInCountries = ["DE"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        string expectedAutomatedBy = "example_user";
        bool expectedCanDm = false;
        string expectedCommunityRole = "Member";
        string expectedCoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg";
        string expectedCreatedAt = "2009-06-02T20:12:29Z";
        string expectedDescription = "CEO of Tesla, SpaceX, and X";
        long expectedFavouritesCount = 18000;
        long expectedFollowers = 150000000;
        long expectedFollowing = 500;
        bool expectedHasCustomTimelines = true;
        bool expectedIsAutomated = false;
        bool expectedIsBlueVerified = true;
        bool expectedIsTranslator = false;
        bool expectedIsVerified = true;
        string expectedLocation = "Austin, TX";
        long expectedMediaCount = 1200;
        List<string> expectedPinnedTweetIds = ["1234567890"];
        bool expectedPossiblySensitive = false;
        Dictionary<string, JsonElement> expectedProfileBio = new()
        {
            { "description", JsonSerializer.SerializeToElement("bar") },
            { "entities", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg";
        string expectedProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg";
        bool expectedProtected = false;
        long expectedStatusesCount = 35000;
        bool expectedUnavailable = false;
        string expectedUnavailableReason = "suspended";
        string expectedUrl = "https://xquik.com";
        bool expectedVerified = true;
        string expectedVerifiedType = "Business";
        bool expectedViewerFollowedBy = false;
        bool expectedViewerFollowing = true;
        List<string> expectedWithheldInCountries = ["DE"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedAutomatedBy, deserialized.AutomatedBy);
        Assert.Equal(expectedCanDm, deserialized.CanDm);
        Assert.Equal(expectedCommunityRole, deserialized.CommunityRole);
        Assert.Equal(expectedCoverPicture, deserialized.CoverPicture);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFavouritesCount, deserialized.FavouritesCount);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedFollowing, deserialized.Following);
        Assert.Equal(expectedHasCustomTimelines, deserialized.HasCustomTimelines);
        Assert.Equal(expectedIsAutomated, deserialized.IsAutomated);
        Assert.Equal(expectedIsBlueVerified, deserialized.IsBlueVerified);
        Assert.Equal(expectedIsTranslator, deserialized.IsTranslator);
        Assert.Equal(expectedIsVerified, deserialized.IsVerified);
        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedMediaCount, deserialized.MediaCount);
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
        Assert.Equal(expectedProfilePicture, deserialized.ProfilePicture);
        Assert.Equal(expectedProtected, deserialized.Protected);
        Assert.Equal(expectedStatusesCount, deserialized.StatusesCount);
        Assert.Equal(expectedUnavailable, deserialized.Unavailable);
        Assert.Equal(expectedUnavailableReason, deserialized.UnavailableReason);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedVerified, deserialized.Verified);
        Assert.Equal(expectedVerifiedType, deserialized.VerifiedType);
        Assert.Equal(expectedViewerFollowedBy, deserialized.ViewerFollowedBy);
        Assert.Equal(expectedViewerFollowing, deserialized.ViewerFollowing);
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
        var model = new UserProfile
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AutomatedBy = "example_user",
            CanDm = false,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            IsAutomated = false,
            IsBlueVerified = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            Protected = false,
            StatusesCount = 35000,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            ViewerFollowedBy = false,
            ViewerFollowing = true,
            WithheldInCountries = ["DE"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserProfile
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
        };

        Assert.Null(model.AutomatedBy);
        Assert.False(model.RawData.ContainsKey("automatedBy"));
        Assert.Null(model.CanDm);
        Assert.False(model.RawData.ContainsKey("canDm"));
        Assert.Null(model.CommunityRole);
        Assert.False(model.RawData.ContainsKey("communityRole"));
        Assert.Null(model.CoverPicture);
        Assert.False(model.RawData.ContainsKey("coverPicture"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
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
        Assert.Null(model.IsAutomated);
        Assert.False(model.RawData.ContainsKey("isAutomated"));
        Assert.Null(model.IsBlueVerified);
        Assert.False(model.RawData.ContainsKey("isBlueVerified"));
        Assert.Null(model.IsTranslator);
        Assert.False(model.RawData.ContainsKey("isTranslator"));
        Assert.Null(model.IsVerified);
        Assert.False(model.RawData.ContainsKey("isVerified"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.MediaCount);
        Assert.False(model.RawData.ContainsKey("mediaCount"));
        Assert.Null(model.PinnedTweetIds);
        Assert.False(model.RawData.ContainsKey("pinnedTweetIds"));
        Assert.Null(model.PossiblySensitive);
        Assert.False(model.RawData.ContainsKey("possiblySensitive"));
        Assert.Null(model.ProfileBio);
        Assert.False(model.RawData.ContainsKey("profile_bio"));
        Assert.Null(model.ProfileBannerUrl);
        Assert.False(model.RawData.ContainsKey("profileBannerUrl"));
        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
        Assert.Null(model.Protected);
        Assert.False(model.RawData.ContainsKey("protected"));
        Assert.Null(model.StatusesCount);
        Assert.False(model.RawData.ContainsKey("statusesCount"));
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
        Assert.Null(model.ViewerFollowedBy);
        Assert.False(model.RawData.ContainsKey("viewerFollowedBy"));
        Assert.Null(model.ViewerFollowing);
        Assert.False(model.RawData.ContainsKey("viewerFollowing"));
        Assert.Null(model.WithheldInCountries);
        Assert.False(model.RawData.ContainsKey("withheldInCountries"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserProfile
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
        var model = new UserProfile
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            AutomatedBy = null,
            CanDm = null,
            CommunityRole = null,
            CoverPicture = null,
            CreatedAt = null,
            Description = null,
            FavouritesCount = null,
            Followers = null,
            Following = null,
            HasCustomTimelines = null,
            IsAutomated = null,
            IsBlueVerified = null,
            IsTranslator = null,
            IsVerified = null,
            Location = null,
            MediaCount = null,
            PinnedTweetIds = null,
            PossiblySensitive = null,
            ProfileBio = null,
            ProfileBannerUrl = null,
            ProfilePicture = null,
            Protected = null,
            StatusesCount = null,
            Unavailable = null,
            UnavailableReason = null,
            Url = null,
            Verified = null,
            VerifiedType = null,
            ViewerFollowedBy = null,
            ViewerFollowing = null,
            WithheldInCountries = null,
        };

        Assert.Null(model.AutomatedBy);
        Assert.False(model.RawData.ContainsKey("automatedBy"));
        Assert.Null(model.CanDm);
        Assert.False(model.RawData.ContainsKey("canDm"));
        Assert.Null(model.CommunityRole);
        Assert.False(model.RawData.ContainsKey("communityRole"));
        Assert.Null(model.CoverPicture);
        Assert.False(model.RawData.ContainsKey("coverPicture"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
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
        Assert.Null(model.IsAutomated);
        Assert.False(model.RawData.ContainsKey("isAutomated"));
        Assert.Null(model.IsBlueVerified);
        Assert.False(model.RawData.ContainsKey("isBlueVerified"));
        Assert.Null(model.IsTranslator);
        Assert.False(model.RawData.ContainsKey("isTranslator"));
        Assert.Null(model.IsVerified);
        Assert.False(model.RawData.ContainsKey("isVerified"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.MediaCount);
        Assert.False(model.RawData.ContainsKey("mediaCount"));
        Assert.Null(model.PinnedTweetIds);
        Assert.False(model.RawData.ContainsKey("pinnedTweetIds"));
        Assert.Null(model.PossiblySensitive);
        Assert.False(model.RawData.ContainsKey("possiblySensitive"));
        Assert.Null(model.ProfileBio);
        Assert.False(model.RawData.ContainsKey("profile_bio"));
        Assert.Null(model.ProfileBannerUrl);
        Assert.False(model.RawData.ContainsKey("profileBannerUrl"));
        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
        Assert.Null(model.Protected);
        Assert.False(model.RawData.ContainsKey("protected"));
        Assert.Null(model.StatusesCount);
        Assert.False(model.RawData.ContainsKey("statusesCount"));
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
        Assert.Null(model.ViewerFollowedBy);
        Assert.False(model.RawData.ContainsKey("viewerFollowedBy"));
        Assert.Null(model.ViewerFollowing);
        Assert.False(model.RawData.ContainsKey("viewerFollowing"));
        Assert.Null(model.WithheldInCountries);
        Assert.False(model.RawData.ContainsKey("withheldInCountries"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserProfile
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            AutomatedBy = null,
            CanDm = null,
            CommunityRole = null,
            CoverPicture = null,
            CreatedAt = null,
            Description = null,
            FavouritesCount = null,
            Followers = null,
            Following = null,
            HasCustomTimelines = null,
            IsAutomated = null,
            IsBlueVerified = null,
            IsTranslator = null,
            IsVerified = null,
            Location = null,
            MediaCount = null,
            PinnedTweetIds = null,
            PossiblySensitive = null,
            ProfileBio = null,
            ProfileBannerUrl = null,
            ProfilePicture = null,
            Protected = null,
            StatusesCount = null,
            Unavailable = null,
            UnavailableReason = null,
            Url = null,
            Verified = null,
            VerifiedType = null,
            ViewerFollowedBy = null,
            ViewerFollowing = null,
            WithheldInCountries = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfile
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            AutomatedBy = "example_user",
            CanDm = false,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            HasCustomTimelines = true,
            IsAutomated = false,
            IsBlueVerified = true,
            IsTranslator = false,
            IsVerified = true,
            Location = "Austin, TX",
            MediaCount = 1200,
            PinnedTweetIds = ["1234567890"],
            PossiblySensitive = false,
            ProfileBio = new Dictionary<string, JsonElement>()
            {
                { "description", JsonSerializer.SerializeToElement("bar") },
                { "entities", JsonSerializer.SerializeToElement("bar") },
            },
            ProfileBannerUrl = "https://pbs.twimg.com/profile_banners/example.jpg",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            Protected = false,
            StatusesCount = 35000,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            ViewerFollowedBy = false,
            ViewerFollowing = true,
            WithheldInCountries = ["DE"],
        };

        UserProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
