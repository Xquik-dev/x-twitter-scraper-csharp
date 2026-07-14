using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },
            Author = new()
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
        };

        TweetDetail expectedTweet = new()
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            Author = new()
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
            ContentDisclosure = new()
            {
                Advertising = new() { IsPaidPromotion = true },
                AIGenerated = new()
                {
                    CanEdit = true,
                    DetectionSource = "UserDeclared",
                    HasAIGeneratedMedia = true,
                },
            },
            ConversationID = "1234567890",
            CreatedAt = "2025-01-15T12:00:00Z",
            DisplayTextRange = [0, 31],
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            InReplyToID = "1234567890",
            InReplyToUserID = "9876543210",
            InReplyToUsername = "example_user",
            IsLimitedReply = false,
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            Lang = "en",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                },
            ],
            QuotedTweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "conversationId",
                CreatedAt = "createdAt",
                DisplayTextRange = [0],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                Source = "source",
                Type = "type",
                Url = "url",
            },
            RetweetedTweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "conversationId",
                CreatedAt = "createdAt",
                DisplayTextRange = [0],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                Source = "source",
                Type = "type",
                Url = "url",
            },
            Source = "Twitter Web App",
            Type = "tweet",
            Url = "https://x.com/example_user/status/1234567890",
        };
        TweetAuthor expectedAuthor = new()
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

        Assert.Equal(expectedTweet, model.Tweet);
        Assert.Equal(expectedAuthor, model.Author);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },
            Author = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },
            Author = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TweetDetail expectedTweet = new()
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            Author = new()
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
            ContentDisclosure = new()
            {
                Advertising = new() { IsPaidPromotion = true },
                AIGenerated = new()
                {
                    CanEdit = true,
                    DetectionSource = "UserDeclared",
                    HasAIGeneratedMedia = true,
                },
            },
            ConversationID = "1234567890",
            CreatedAt = "2025-01-15T12:00:00Z",
            DisplayTextRange = [0, 31],
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            InReplyToID = "1234567890",
            InReplyToUserID = "9876543210",
            InReplyToUsername = "example_user",
            IsLimitedReply = false,
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            Lang = "en",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                },
            ],
            QuotedTweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "conversationId",
                CreatedAt = "createdAt",
                DisplayTextRange = [0],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                Source = "source",
                Type = "type",
                Url = "url",
            },
            RetweetedTweet = new()
            {
                ID = "id",
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
                Text = "text",
                ViewCount = 0,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "conversationId",
                CreatedAt = "createdAt",
                DisplayTextRange = [0],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                Source = "source",
                Type = "type",
                Url = "url",
            },
            Source = "Twitter Web App",
            Type = "tweet",
            Url = "https://x.com/example_user/status/1234567890",
        };
        TweetAuthor expectedAuthor = new()
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

        Assert.Equal(expectedTweet, deserialized.Tweet);
        Assert.Equal(expectedAuthor, deserialized.Author);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },
            Author = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },

            // Null should be interpreted as omitted for these properties
            Author = null,
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },

            // Null should be interpreted as omitted for these properties
            Author = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetRetrieveResponse
        {
            Tweet = new()
            {
                ID = "1234567890",
                BookmarkCount = 2,
                LikeCount = 42,
                QuoteCount = 1,
                ReplyCount = 3,
                RetweetCount = 5,
                Text = "Just launched our new feature!",
                ViewCount = 1500,
                Author = new()
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
                ContentDisclosure = new()
                {
                    Advertising = new() { IsPaidPromotion = true },
                    AIGenerated = new()
                    {
                        CanEdit = true,
                        DetectionSource = "UserDeclared",
                        HasAIGeneratedMedia = true,
                    },
                },
                ConversationID = "1234567890",
                CreatedAt = "2025-01-15T12:00:00Z",
                DisplayTextRange = [0, 31],
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                InReplyToID = "1234567890",
                InReplyToUserID = "9876543210",
                InReplyToUsername = "example_user",
                IsLimitedReply = false,
                IsNoteTweet = false,
                IsQuoteStatus = false,
                IsReply = false,
                Lang = "en",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                    },
                ],
                QuotedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                RetweetedTweet = new()
                {
                    ID = "id",
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                    Text = "text",
                    ViewCount = 0,
                    Author = new()
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
                    ContentDisclosure = new()
                    {
                        Advertising = new() { IsPaidPromotion = true },
                        AIGenerated = new()
                        {
                            CanEdit = true,
                            DetectionSource = "UserDeclared",
                            HasAIGeneratedMedia = true,
                        },
                    },
                    ConversationID = "conversationId",
                    CreatedAt = "createdAt",
                    DisplayTextRange = [0],
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    InReplyToID = "inReplyToId",
                    InReplyToUserID = "inReplyToUserId",
                    InReplyToUsername = "inReplyToUsername",
                    IsLimitedReply = true,
                    IsNoteTweet = true,
                    IsQuoteStatus = true,
                    IsReply = true,
                    Lang = "lang",
                    Media =
                    [
                        new()
                        {
                            MediaUrl = "mediaUrl",
                            Type = TweetMediaType.Photo,
                            Url = "url",
                            VideoVariants =
                            [
                                new()
                                {
                                    ContentType = "contentType",
                                    Url = "url",
                                    Bitrate = 0,
                                },
                            ],
                        },
                    ],
                    Source = "source",
                    Type = "type",
                    Url = "url",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
            },
            Author = new()
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
        };

        TweetRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
