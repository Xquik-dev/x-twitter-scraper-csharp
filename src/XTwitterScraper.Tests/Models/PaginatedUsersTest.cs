using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class PaginatedUsersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
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
                },
            ],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<UserProfile> expectedUsers =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedUsers.Count, model.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], model.Users[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaginatedUsers>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaginatedUsers>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<UserProfile> expectedUsers =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedUsers.Count, deserialized.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], deserialized.Users[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
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
                },
            ],
        };

        PaginatedUsers copied = new(model);

        Assert.Equal(model, copied);
    }
}
