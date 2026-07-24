// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetDetail
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

        string expectedID = "1234567890";
        long expectedBookmarkCount = 2;
        long expectedLikeCount = 42;
        long expectedQuoteCount = 1;
        long expectedReplyCount = 3;
        long expectedRetweetCount = 5;
        string expectedText = "Just launched our new feature!";
        long expectedViewCount = 1500;
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
        ContentDisclosure expectedContentDisclosure = new()
        {
            Advertising = new() { IsPaidPromotion = true },
            AIGenerated = new()
            {
                CanEdit = true,
                DetectionSource = "UserDeclared",
                HasAIGeneratedMedia = true,
            },
        };
        string expectedConversationID = "1234567890";
        string expectedCreatedAt = "2025-01-15T12:00:00Z";
        List<long> expectedDisplayTextRange = [0, 31];
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedInReplyToID = "1234567890";
        string expectedInReplyToUserID = "9876543210";
        string expectedInReplyToUsername = "example_user";
        bool expectedIsLimitedReply = false;
        bool expectedIsNoteTweet = false;
        bool expectedIsQuoteStatus = false;
        bool expectedIsReply = false;
        string expectedLang = "en";
        List<TweetMedia> expectedMedia =
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
        ];
        EmbeddedTweet expectedQuotedTweet = new()
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
        };
        EmbeddedTweet expectedRetweetedTweet = new()
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
        };
        string expectedSource = "Twitter Web App";
        string expectedType = "tweet";
        string expectedUrl = "https://x.com/example_user/status/1234567890";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBookmarkCount, model.BookmarkCount);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedQuoteCount, model.QuoteCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedRetweetCount, model.RetweetCount);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedViewCount, model.ViewCount);
        Assert.Equal(expectedAuthor, model.Author);
        Assert.Equal(expectedContentDisclosure, model.ContentDisclosure);
        Assert.Equal(expectedConversationID, model.ConversationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.DisplayTextRange);
        Assert.Equal(expectedDisplayTextRange.Count, model.DisplayTextRange.Count);
        for (int i = 0; i < expectedDisplayTextRange.Count; i++)
        {
            Assert.Equal(expectedDisplayTextRange[i], model.DisplayTextRange[i]);
        }
        Assert.NotNull(model.Entities);
        Assert.Equal(expectedEntities.Count, model.Entities.Count);
        foreach (var item in expectedEntities)
        {
            Assert.True(model.Entities.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Entities[item.Key]));
        }
        Assert.Equal(expectedInReplyToID, model.InReplyToID);
        Assert.Equal(expectedInReplyToUserID, model.InReplyToUserID);
        Assert.Equal(expectedInReplyToUsername, model.InReplyToUsername);
        Assert.Equal(expectedIsLimitedReply, model.IsLimitedReply);
        Assert.Equal(expectedIsNoteTweet, model.IsNoteTweet);
        Assert.Equal(expectedIsQuoteStatus, model.IsQuoteStatus);
        Assert.Equal(expectedIsReply, model.IsReply);
        Assert.Equal(expectedLang, model.Lang);
        Assert.NotNull(model.Media);
        Assert.Equal(expectedMedia.Count, model.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], model.Media[i]);
        }
        Assert.Equal(expectedQuotedTweet, model.QuotedTweet);
        Assert.Equal(expectedRetweetedTweet, model.RetweetedTweet);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetDetail
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetDetail
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "1234567890";
        long expectedBookmarkCount = 2;
        long expectedLikeCount = 42;
        long expectedQuoteCount = 1;
        long expectedReplyCount = 3;
        long expectedRetweetCount = 5;
        string expectedText = "Just launched our new feature!";
        long expectedViewCount = 1500;
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
        ContentDisclosure expectedContentDisclosure = new()
        {
            Advertising = new() { IsPaidPromotion = true },
            AIGenerated = new()
            {
                CanEdit = true,
                DetectionSource = "UserDeclared",
                HasAIGeneratedMedia = true,
            },
        };
        string expectedConversationID = "1234567890";
        string expectedCreatedAt = "2025-01-15T12:00:00Z";
        List<long> expectedDisplayTextRange = [0, 31];
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedInReplyToID = "1234567890";
        string expectedInReplyToUserID = "9876543210";
        string expectedInReplyToUsername = "example_user";
        bool expectedIsLimitedReply = false;
        bool expectedIsNoteTweet = false;
        bool expectedIsQuoteStatus = false;
        bool expectedIsReply = false;
        string expectedLang = "en";
        List<TweetMedia> expectedMedia =
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
        ];
        EmbeddedTweet expectedQuotedTweet = new()
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
        };
        EmbeddedTweet expectedRetweetedTweet = new()
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
        };
        string expectedSource = "Twitter Web App";
        string expectedType = "tweet";
        string expectedUrl = "https://x.com/example_user/status/1234567890";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBookmarkCount, deserialized.BookmarkCount);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedQuoteCount, deserialized.QuoteCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedRetweetCount, deserialized.RetweetCount);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedViewCount, deserialized.ViewCount);
        Assert.Equal(expectedAuthor, deserialized.Author);
        Assert.Equal(expectedContentDisclosure, deserialized.ContentDisclosure);
        Assert.Equal(expectedConversationID, deserialized.ConversationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.DisplayTextRange);
        Assert.Equal(expectedDisplayTextRange.Count, deserialized.DisplayTextRange.Count);
        for (int i = 0; i < expectedDisplayTextRange.Count; i++)
        {
            Assert.Equal(expectedDisplayTextRange[i], deserialized.DisplayTextRange[i]);
        }
        Assert.NotNull(deserialized.Entities);
        Assert.Equal(expectedEntities.Count, deserialized.Entities.Count);
        foreach (var item in expectedEntities)
        {
            Assert.True(deserialized.Entities.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Entities[item.Key]));
        }
        Assert.Equal(expectedInReplyToID, deserialized.InReplyToID);
        Assert.Equal(expectedInReplyToUserID, deserialized.InReplyToUserID);
        Assert.Equal(expectedInReplyToUsername, deserialized.InReplyToUsername);
        Assert.Equal(expectedIsLimitedReply, deserialized.IsLimitedReply);
        Assert.Equal(expectedIsNoteTweet, deserialized.IsNoteTweet);
        Assert.Equal(expectedIsQuoteStatus, deserialized.IsQuoteStatus);
        Assert.Equal(expectedIsReply, deserialized.IsReply);
        Assert.Equal(expectedLang, deserialized.Lang);
        Assert.NotNull(deserialized.Media);
        Assert.Equal(expectedMedia.Count, deserialized.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], deserialized.Media[i]);
        }
        Assert.Equal(expectedQuotedTweet, deserialized.QuotedTweet);
        Assert.Equal(expectedRetweetedTweet, deserialized.RetweetedTweet);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetDetail
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetDetail
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.ContentDisclosure);
        Assert.False(model.RawData.ContainsKey("contentDisclosure"));
        Assert.Null(model.ConversationID);
        Assert.False(model.RawData.ContainsKey("conversationId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayTextRange);
        Assert.False(model.RawData.ContainsKey("displayTextRange"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.InReplyToID);
        Assert.False(model.RawData.ContainsKey("inReplyToId"));
        Assert.Null(model.InReplyToUserID);
        Assert.False(model.RawData.ContainsKey("inReplyToUserId"));
        Assert.Null(model.InReplyToUsername);
        Assert.False(model.RawData.ContainsKey("inReplyToUsername"));
        Assert.Null(model.IsLimitedReply);
        Assert.False(model.RawData.ContainsKey("isLimitedReply"));
        Assert.Null(model.IsNoteTweet);
        Assert.False(model.RawData.ContainsKey("isNoteTweet"));
        Assert.Null(model.IsQuoteStatus);
        Assert.False(model.RawData.ContainsKey("isQuoteStatus"));
        Assert.Null(model.IsReply);
        Assert.False(model.RawData.ContainsKey("isReply"));
        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.QuotedTweet);
        Assert.False(model.RawData.ContainsKey("quoted_tweet"));
        Assert.Null(model.RetweetedTweet);
        Assert.False(model.RawData.ContainsKey("retweeted_tweet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetDetail
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetDetail
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,

            // Null should be interpreted as omitted for these properties
            Author = null,
            ContentDisclosure = null,
            ConversationID = null,
            CreatedAt = null,
            DisplayTextRange = null,
            Entities = null,
            InReplyToID = null,
            InReplyToUserID = null,
            InReplyToUsername = null,
            IsLimitedReply = null,
            IsNoteTweet = null,
            IsQuoteStatus = null,
            IsReply = null,
            Lang = null,
            Media = null,
            QuotedTweet = null,
            RetweetedTweet = null,
            Source = null,
            Type = null,
            Url = null,
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.ContentDisclosure);
        Assert.False(model.RawData.ContainsKey("contentDisclosure"));
        Assert.Null(model.ConversationID);
        Assert.False(model.RawData.ContainsKey("conversationId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayTextRange);
        Assert.False(model.RawData.ContainsKey("displayTextRange"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.InReplyToID);
        Assert.False(model.RawData.ContainsKey("inReplyToId"));
        Assert.Null(model.InReplyToUserID);
        Assert.False(model.RawData.ContainsKey("inReplyToUserId"));
        Assert.Null(model.InReplyToUsername);
        Assert.False(model.RawData.ContainsKey("inReplyToUsername"));
        Assert.Null(model.IsLimitedReply);
        Assert.False(model.RawData.ContainsKey("isLimitedReply"));
        Assert.Null(model.IsNoteTweet);
        Assert.False(model.RawData.ContainsKey("isNoteTweet"));
        Assert.Null(model.IsQuoteStatus);
        Assert.False(model.RawData.ContainsKey("isQuoteStatus"));
        Assert.Null(model.IsReply);
        Assert.False(model.RawData.ContainsKey("isReply"));
        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.QuotedTweet);
        Assert.False(model.RawData.ContainsKey("quoted_tweet"));
        Assert.Null(model.RetweetedTweet);
        Assert.False(model.RawData.ContainsKey("retweeted_tweet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetDetail
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,

            // Null should be interpreted as omitted for these properties
            Author = null,
            ContentDisclosure = null,
            ConversationID = null,
            CreatedAt = null,
            DisplayTextRange = null,
            Entities = null,
            InReplyToID = null,
            InReplyToUserID = null,
            InReplyToUsername = null,
            IsLimitedReply = null,
            IsNoteTweet = null,
            IsQuoteStatus = null,
            IsReply = null,
            Lang = null,
            Media = null,
            QuotedTweet = null,
            RetweetedTweet = null,
            Source = null,
            Type = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetDetail
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

        TweetDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}
