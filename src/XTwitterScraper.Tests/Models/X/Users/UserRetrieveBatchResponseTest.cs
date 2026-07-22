using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveBatchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserRetrieveBatchResponse
        {
            NextCursor = "",
            ProcessedCount = 2,
            RequestedCount = 2,
            ReturnedCount = 1,
            UnavailableIds = ["1234567890"],
            UnprocessedIds = ["321669910225"],
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

        JsonElement expectedHasNextPage = JsonSerializer.SerializeToElement(false);
        string expectedNextCursor = "";
        long expectedProcessedCount = 2;
        long expectedRequestedCount = 2;
        long expectedReturnedCount = 1;
        List<string> expectedUnavailableIds = ["1234567890"];
        List<string> expectedUnprocessedIds = ["321669910225"];
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

        Assert.True(JsonElement.DeepEquals(expectedHasNextPage, model.HasNextPage));
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedProcessedCount, model.ProcessedCount);
        Assert.Equal(expectedRequestedCount, model.RequestedCount);
        Assert.Equal(expectedReturnedCount, model.ReturnedCount);
        Assert.Equal(expectedUnavailableIds.Count, model.UnavailableIds.Count);
        for (int i = 0; i < expectedUnavailableIds.Count; i++)
        {
            Assert.Equal(expectedUnavailableIds[i], model.UnavailableIds[i]);
        }
        Assert.Equal(expectedUnprocessedIds.Count, model.UnprocessedIds.Count);
        for (int i = 0; i < expectedUnprocessedIds.Count; i++)
        {
            Assert.Equal(expectedUnprocessedIds[i], model.UnprocessedIds[i]);
        }
        Assert.Equal(expectedUsers.Count, model.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], model.Users[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserRetrieveBatchResponse
        {
            NextCursor = "",
            ProcessedCount = 2,
            RequestedCount = 2,
            ReturnedCount = 1,
            UnavailableIds = ["1234567890"],
            UnprocessedIds = ["321669910225"],
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
        var deserialized = JsonSerializer.Deserialize<UserRetrieveBatchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserRetrieveBatchResponse
        {
            NextCursor = "",
            ProcessedCount = 2,
            RequestedCount = 2,
            ReturnedCount = 1,
            UnavailableIds = ["1234567890"],
            UnprocessedIds = ["321669910225"],
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
        var deserialized = JsonSerializer.Deserialize<UserRetrieveBatchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedHasNextPage = JsonSerializer.SerializeToElement(false);
        string expectedNextCursor = "";
        long expectedProcessedCount = 2;
        long expectedRequestedCount = 2;
        long expectedReturnedCount = 1;
        List<string> expectedUnavailableIds = ["1234567890"];
        List<string> expectedUnprocessedIds = ["321669910225"];
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

        Assert.True(JsonElement.DeepEquals(expectedHasNextPage, deserialized.HasNextPage));
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedProcessedCount, deserialized.ProcessedCount);
        Assert.Equal(expectedRequestedCount, deserialized.RequestedCount);
        Assert.Equal(expectedReturnedCount, deserialized.ReturnedCount);
        Assert.Equal(expectedUnavailableIds.Count, deserialized.UnavailableIds.Count);
        for (int i = 0; i < expectedUnavailableIds.Count; i++)
        {
            Assert.Equal(expectedUnavailableIds[i], deserialized.UnavailableIds[i]);
        }
        Assert.Equal(expectedUnprocessedIds.Count, deserialized.UnprocessedIds.Count);
        for (int i = 0; i < expectedUnprocessedIds.Count; i++)
        {
            Assert.Equal(expectedUnprocessedIds[i], deserialized.UnprocessedIds[i]);
        }
        Assert.Equal(expectedUsers.Count, deserialized.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], deserialized.Users[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserRetrieveBatchResponse
        {
            NextCursor = "",
            ProcessedCount = 2,
            RequestedCount = 2,
            ReturnedCount = 1,
            UnavailableIds = ["1234567890"],
            UnprocessedIds = ["321669910225"],
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
        var model = new UserRetrieveBatchResponse
        {
            NextCursor = "",
            ProcessedCount = 2,
            RequestedCount = 2,
            ReturnedCount = 1,
            UnavailableIds = ["1234567890"],
            UnprocessedIds = ["321669910225"],
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

        UserRetrieveBatchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
