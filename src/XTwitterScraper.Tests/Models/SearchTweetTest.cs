// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class SearchTweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweet
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "1234567890",
            InReplyToUserID = "9876543210",
            InReplyToUsername = "example_user",
            IsLimitedReply = false,
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            IsTranslatable = true,
            Lang = "en",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Retweeted = true,
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "Twitter Web App",
            Type = "tweet",
            Url = "https://x.com/example_user/status/1234567890",
            ViewState = "viewState",
        };

        string expectedID = "1234567890";
        long expectedBookmarkCount = 2;
        long expectedLikeCount = 42;
        long expectedQuoteCount = 1;
        long expectedReplyCount = 3;
        long expectedRetweetCount = 5;
        string expectedText = "Just launched our new feature!";
        long expectedViewCount = 1500;
        SearchTweetArticle expectedArticle = new()
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };
        UserProfile expectedAuthor = new()
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
            CanDm = false,
            CanMediaTag = true,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            CreatorSubscriptionsCount = 0,
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            FollowRequestSent = true,
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
            NotificationsEnabled = true,
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
            SuperFollowedBy = true,
            SuperFollowEligible = true,
            SuperFollowing = true,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            ViewerBlockedBy = true,
            ViewerBlocking = true,
            ViewerFollowedBy = false,
            ViewerFollowing = true,
            ViewerLiveFollowing = true,
            ViewerMuting = true,
            WithheldInCountries = ["DE"],
        };
        bool expectedBookmarked = true;
        SearchTweetCard expectedCard = new()
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };
        SearchTweetCommunityNote expectedCommunityNote = new()
        {
            ID = "id",
            DestinationUrl = "destinationUrl",
            Footer = "footer",
            ShortTitle = "shortTitle",
            Subtitle = "subtitle",
            Title = "title",
            VisualStyle = "visualStyle",
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
        SearchTweetEdit expectedEdit = new()
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditsRemaining = "editsRemaining",
            EditTweetIds = ["string"],
            IsEditEligible = true,
        };
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedFavorited = true;
        bool expectedGrokAnalysisButton = true;
        bool expectedGrokImageEditable = true;
        string expectedInReplyToID = "1234567890";
        string expectedInReplyToUserID = "9876543210";
        string expectedInReplyToUsername = "example_user";
        bool expectedIsLimitedReply = false;
        bool expectedIsNoteTweet = false;
        bool expectedIsQuoteStatus = false;
        bool expectedIsReply = false;
        bool expectedIsTranslatable = true;
        string expectedLang = "en";
        List<TweetMedia> expectedMedia =
        [
            new()
            {
                MediaUrl = "mediaUrl",
                Type = TweetMediaType.Photo,
                Url = "url",
                ID = "id",
                AllowDownload = true,
                AltText = "altText",
                AspectRatio = [0],
                AvailabilityStatus = "availabilityStatus",
                DisplayUrl = "displayUrl",
                DurationMillis = 0,
                ExpandedUrl = "expandedUrl",
                FaceRects = new Dictionary<string, IReadOnlyList<UnnamedSchemaWithArrayParent0>>()
                {
                    {
                        "foo",
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ]
                    },
                },
                FocusRects =
                [
                    new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                ],
                Height = 0,
                Indices = [0],
                MediaKey = "mediaKey",
                Monetizable = true,
                Sizes = new Dictionary<string, SizesItem>()
                {
                    {
                        "foo",
                        new()
                        {
                            H = 0,
                            Resize = "resize",
                            W = 0,
                        }
                    },
                },
                VideoVariants =
                [
                    new()
                    {
                        ContentType = "contentType",
                        Url = "url",
                        Bitrate = 0,
                    },
                ],
                Width = 0,
            },
        ];
        SearchTweetNoteTweet expectedNoteTweet = new()
        {
            Text = "text",
            ID = "id",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsExpandable = true,
            RichtextTags =
            [
                new()
                {
                    FromIndex = 0,
                    ToIndex = 0,
                    Types = ["string"],
                },
            ],
        };
        SearchTweetPlace expectedPlace = new()
        {
            ID = "id",
            BoundingBox = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Country = "country",
            CountryCode = "countryCode",
            FullName = "fullName",
            Name = "name",
            PlaceType = "placeType",
            Url = "url",
        };
        bool expectedPossiblySensitive = true;
        bool expectedPossiblySensitiveEditable = true;
        SearchTweetPreviousCounts expectedPreviousCounts = new()
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };
        string expectedQuickPromoteEligibility = "quickPromoteEligibility";
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
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "inReplyToId",
            InReplyToUserID = "inReplyToUserId",
            InReplyToUsername = "inReplyToUsername",
            IsLimitedReply = true,
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            IsTranslatable = true,
            Lang = "lang",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
            Retweeted = true,
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };
        bool expectedRetweeted = true;
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
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "inReplyToId",
            InReplyToUserID = "inReplyToUserId",
            InReplyToUsername = "inReplyToUsername",
            IsLimitedReply = true,
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            IsTranslatable = true,
            Lang = "lang",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
            Retweeted = true,
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };
        string expectedSource = "Twitter Web App";
        string expectedType = "tweet";
        string expectedUrl = "https://x.com/example_user/status/1234567890";
        string expectedViewState = "viewState";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBookmarkCount, model.BookmarkCount);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedQuoteCount, model.QuoteCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedRetweetCount, model.RetweetCount);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedViewCount, model.ViewCount);
        Assert.Equal(expectedArticle, model.Article);
        Assert.Equal(expectedAuthor, model.Author);
        Assert.Equal(expectedBookmarked, model.Bookmarked);
        Assert.Equal(expectedCard, model.Card);
        Assert.Equal(expectedCommunityNote, model.CommunityNote);
        Assert.Equal(expectedContentDisclosure, model.ContentDisclosure);
        Assert.Equal(expectedConversationID, model.ConversationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.DisplayTextRange);
        Assert.Equal(expectedDisplayTextRange.Count, model.DisplayTextRange.Count);
        for (int i = 0; i < expectedDisplayTextRange.Count; i++)
        {
            Assert.Equal(expectedDisplayTextRange[i], model.DisplayTextRange[i]);
        }
        Assert.Equal(expectedEdit, model.Edit);
        Assert.NotNull(model.Entities);
        Assert.Equal(expectedEntities.Count, model.Entities.Count);
        foreach (var item in expectedEntities)
        {
            Assert.True(model.Entities.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Entities[item.Key]));
        }
        Assert.Equal(expectedFavorited, model.Favorited);
        Assert.Equal(expectedGrokAnalysisButton, model.GrokAnalysisButton);
        Assert.Equal(expectedGrokImageEditable, model.GrokImageEditable);
        Assert.Equal(expectedInReplyToID, model.InReplyToID);
        Assert.Equal(expectedInReplyToUserID, model.InReplyToUserID);
        Assert.Equal(expectedInReplyToUsername, model.InReplyToUsername);
        Assert.Equal(expectedIsLimitedReply, model.IsLimitedReply);
        Assert.Equal(expectedIsNoteTweet, model.IsNoteTweet);
        Assert.Equal(expectedIsQuoteStatus, model.IsQuoteStatus);
        Assert.Equal(expectedIsReply, model.IsReply);
        Assert.Equal(expectedIsTranslatable, model.IsTranslatable);
        Assert.Equal(expectedLang, model.Lang);
        Assert.NotNull(model.Media);
        Assert.Equal(expectedMedia.Count, model.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], model.Media[i]);
        }
        Assert.Equal(expectedNoteTweet, model.NoteTweet);
        Assert.Equal(expectedPlace, model.Place);
        Assert.Equal(expectedPossiblySensitive, model.PossiblySensitive);
        Assert.Equal(expectedPossiblySensitiveEditable, model.PossiblySensitiveEditable);
        Assert.Equal(expectedPreviousCounts, model.PreviousCounts);
        Assert.Equal(expectedQuickPromoteEligibility, model.QuickPromoteEligibility);
        Assert.Equal(expectedQuotedTweet, model.QuotedTweet);
        Assert.Equal(expectedRetweeted, model.Retweeted);
        Assert.Equal(expectedRetweetedTweet, model.RetweetedTweet);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedViewState, model.ViewState);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweet
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "1234567890",
            InReplyToUserID = "9876543210",
            InReplyToUsername = "example_user",
            IsLimitedReply = false,
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            IsTranslatable = true,
            Lang = "en",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Retweeted = true,
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "Twitter Web App",
            Type = "tweet",
            Url = "https://x.com/example_user/status/1234567890",
            ViewState = "viewState",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweet
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "1234567890",
            InReplyToUserID = "9876543210",
            InReplyToUsername = "example_user",
            IsLimitedReply = false,
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            IsTranslatable = true,
            Lang = "en",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Retweeted = true,
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "Twitter Web App",
            Type = "tweet",
            Url = "https://x.com/example_user/status/1234567890",
            ViewState = "viewState",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweet>(
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
        SearchTweetArticle expectedArticle = new()
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };
        UserProfile expectedAuthor = new()
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
            CanDm = false,
            CanMediaTag = true,
            CommunityRole = "Member",
            CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
            CreatedAt = "2009-06-02T20:12:29Z",
            CreatorSubscriptionsCount = 0,
            Description = "CEO of Tesla, SpaceX, and X",
            FavouritesCount = 18000,
            Followers = 150000000,
            Following = 500,
            FollowRequestSent = true,
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
            NotificationsEnabled = true,
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
            SuperFollowedBy = true,
            SuperFollowEligible = true,
            SuperFollowing = true,
            Unavailable = false,
            UnavailableReason = "suspended",
            Url = "https://xquik.com",
            Verified = true,
            VerifiedType = "Business",
            ViewerBlockedBy = true,
            ViewerBlocking = true,
            ViewerFollowedBy = false,
            ViewerFollowing = true,
            ViewerLiveFollowing = true,
            ViewerMuting = true,
            WithheldInCountries = ["DE"],
        };
        bool expectedBookmarked = true;
        SearchTweetCard expectedCard = new()
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };
        SearchTweetCommunityNote expectedCommunityNote = new()
        {
            ID = "id",
            DestinationUrl = "destinationUrl",
            Footer = "footer",
            ShortTitle = "shortTitle",
            Subtitle = "subtitle",
            Title = "title",
            VisualStyle = "visualStyle",
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
        SearchTweetEdit expectedEdit = new()
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditsRemaining = "editsRemaining",
            EditTweetIds = ["string"],
            IsEditEligible = true,
        };
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedFavorited = true;
        bool expectedGrokAnalysisButton = true;
        bool expectedGrokImageEditable = true;
        string expectedInReplyToID = "1234567890";
        string expectedInReplyToUserID = "9876543210";
        string expectedInReplyToUsername = "example_user";
        bool expectedIsLimitedReply = false;
        bool expectedIsNoteTweet = false;
        bool expectedIsQuoteStatus = false;
        bool expectedIsReply = false;
        bool expectedIsTranslatable = true;
        string expectedLang = "en";
        List<TweetMedia> expectedMedia =
        [
            new()
            {
                MediaUrl = "mediaUrl",
                Type = TweetMediaType.Photo,
                Url = "url",
                ID = "id",
                AllowDownload = true,
                AltText = "altText",
                AspectRatio = [0],
                AvailabilityStatus = "availabilityStatus",
                DisplayUrl = "displayUrl",
                DurationMillis = 0,
                ExpandedUrl = "expandedUrl",
                FaceRects = new Dictionary<string, IReadOnlyList<UnnamedSchemaWithArrayParent0>>()
                {
                    {
                        "foo",
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ]
                    },
                },
                FocusRects =
                [
                    new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                ],
                Height = 0,
                Indices = [0],
                MediaKey = "mediaKey",
                Monetizable = true,
                Sizes = new Dictionary<string, SizesItem>()
                {
                    {
                        "foo",
                        new()
                        {
                            H = 0,
                            Resize = "resize",
                            W = 0,
                        }
                    },
                },
                VideoVariants =
                [
                    new()
                    {
                        ContentType = "contentType",
                        Url = "url",
                        Bitrate = 0,
                    },
                ],
                Width = 0,
            },
        ];
        SearchTweetNoteTweet expectedNoteTweet = new()
        {
            Text = "text",
            ID = "id",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsExpandable = true,
            RichtextTags =
            [
                new()
                {
                    FromIndex = 0,
                    ToIndex = 0,
                    Types = ["string"],
                },
            ],
        };
        SearchTweetPlace expectedPlace = new()
        {
            ID = "id",
            BoundingBox = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Country = "country",
            CountryCode = "countryCode",
            FullName = "fullName",
            Name = "name",
            PlaceType = "placeType",
            Url = "url",
        };
        bool expectedPossiblySensitive = true;
        bool expectedPossiblySensitiveEditable = true;
        SearchTweetPreviousCounts expectedPreviousCounts = new()
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };
        string expectedQuickPromoteEligibility = "quickPromoteEligibility";
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
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "inReplyToId",
            InReplyToUserID = "inReplyToUserId",
            InReplyToUsername = "inReplyToUsername",
            IsLimitedReply = true,
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            IsTranslatable = true,
            Lang = "lang",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
            Retweeted = true,
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };
        bool expectedRetweeted = true;
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
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "inReplyToId",
            InReplyToUserID = "inReplyToUserId",
            InReplyToUsername = "inReplyToUsername",
            IsLimitedReply = true,
            IsNoteTweet = true,
            IsQuoteStatus = true,
            IsReply = true,
            IsTranslatable = true,
            Lang = "lang",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
            Retweeted = true,
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };
        string expectedSource = "Twitter Web App";
        string expectedType = "tweet";
        string expectedUrl = "https://x.com/example_user/status/1234567890";
        string expectedViewState = "viewState";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBookmarkCount, deserialized.BookmarkCount);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedQuoteCount, deserialized.QuoteCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedRetweetCount, deserialized.RetweetCount);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedViewCount, deserialized.ViewCount);
        Assert.Equal(expectedArticle, deserialized.Article);
        Assert.Equal(expectedAuthor, deserialized.Author);
        Assert.Equal(expectedBookmarked, deserialized.Bookmarked);
        Assert.Equal(expectedCard, deserialized.Card);
        Assert.Equal(expectedCommunityNote, deserialized.CommunityNote);
        Assert.Equal(expectedContentDisclosure, deserialized.ContentDisclosure);
        Assert.Equal(expectedConversationID, deserialized.ConversationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.DisplayTextRange);
        Assert.Equal(expectedDisplayTextRange.Count, deserialized.DisplayTextRange.Count);
        for (int i = 0; i < expectedDisplayTextRange.Count; i++)
        {
            Assert.Equal(expectedDisplayTextRange[i], deserialized.DisplayTextRange[i]);
        }
        Assert.Equal(expectedEdit, deserialized.Edit);
        Assert.NotNull(deserialized.Entities);
        Assert.Equal(expectedEntities.Count, deserialized.Entities.Count);
        foreach (var item in expectedEntities)
        {
            Assert.True(deserialized.Entities.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Entities[item.Key]));
        }
        Assert.Equal(expectedFavorited, deserialized.Favorited);
        Assert.Equal(expectedGrokAnalysisButton, deserialized.GrokAnalysisButton);
        Assert.Equal(expectedGrokImageEditable, deserialized.GrokImageEditable);
        Assert.Equal(expectedInReplyToID, deserialized.InReplyToID);
        Assert.Equal(expectedInReplyToUserID, deserialized.InReplyToUserID);
        Assert.Equal(expectedInReplyToUsername, deserialized.InReplyToUsername);
        Assert.Equal(expectedIsLimitedReply, deserialized.IsLimitedReply);
        Assert.Equal(expectedIsNoteTweet, deserialized.IsNoteTweet);
        Assert.Equal(expectedIsQuoteStatus, deserialized.IsQuoteStatus);
        Assert.Equal(expectedIsReply, deserialized.IsReply);
        Assert.Equal(expectedIsTranslatable, deserialized.IsTranslatable);
        Assert.Equal(expectedLang, deserialized.Lang);
        Assert.NotNull(deserialized.Media);
        Assert.Equal(expectedMedia.Count, deserialized.Media.Count);
        for (int i = 0; i < expectedMedia.Count; i++)
        {
            Assert.Equal(expectedMedia[i], deserialized.Media[i]);
        }
        Assert.Equal(expectedNoteTweet, deserialized.NoteTweet);
        Assert.Equal(expectedPlace, deserialized.Place);
        Assert.Equal(expectedPossiblySensitive, deserialized.PossiblySensitive);
        Assert.Equal(expectedPossiblySensitiveEditable, deserialized.PossiblySensitiveEditable);
        Assert.Equal(expectedPreviousCounts, deserialized.PreviousCounts);
        Assert.Equal(expectedQuickPromoteEligibility, deserialized.QuickPromoteEligibility);
        Assert.Equal(expectedQuotedTweet, deserialized.QuotedTweet);
        Assert.Equal(expectedRetweeted, deserialized.Retweeted);
        Assert.Equal(expectedRetweetedTweet, deserialized.RetweetedTweet);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedViewState, deserialized.ViewState);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweet
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "1234567890",
            InReplyToUserID = "9876543210",
            InReplyToUsername = "example_user",
            IsLimitedReply = false,
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            IsTranslatable = true,
            Lang = "en",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Retweeted = true,
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "Twitter Web App",
            Type = "tweet",
            Url = "https://x.com/example_user/status/1234567890",
            ViewState = "viewState",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchTweet
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

        Assert.Null(model.Article);
        Assert.False(model.RawData.ContainsKey("article"));
        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.Bookmarked);
        Assert.False(model.RawData.ContainsKey("bookmarked"));
        Assert.Null(model.Card);
        Assert.False(model.RawData.ContainsKey("card"));
        Assert.Null(model.CommunityNote);
        Assert.False(model.RawData.ContainsKey("communityNote"));
        Assert.Null(model.ContentDisclosure);
        Assert.False(model.RawData.ContainsKey("contentDisclosure"));
        Assert.Null(model.ConversationID);
        Assert.False(model.RawData.ContainsKey("conversationId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayTextRange);
        Assert.False(model.RawData.ContainsKey("displayTextRange"));
        Assert.Null(model.Edit);
        Assert.False(model.RawData.ContainsKey("edit"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.Favorited);
        Assert.False(model.RawData.ContainsKey("favorited"));
        Assert.Null(model.GrokAnalysisButton);
        Assert.False(model.RawData.ContainsKey("grokAnalysisButton"));
        Assert.Null(model.GrokImageEditable);
        Assert.False(model.RawData.ContainsKey("grokImageEditable"));
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
        Assert.Null(model.IsTranslatable);
        Assert.False(model.RawData.ContainsKey("isTranslatable"));
        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.NoteTweet);
        Assert.False(model.RawData.ContainsKey("noteTweet"));
        Assert.Null(model.Place);
        Assert.False(model.RawData.ContainsKey("place"));
        Assert.Null(model.PossiblySensitive);
        Assert.False(model.RawData.ContainsKey("possiblySensitive"));
        Assert.Null(model.PossiblySensitiveEditable);
        Assert.False(model.RawData.ContainsKey("possiblySensitiveEditable"));
        Assert.Null(model.PreviousCounts);
        Assert.False(model.RawData.ContainsKey("previousCounts"));
        Assert.Null(model.QuickPromoteEligibility);
        Assert.False(model.RawData.ContainsKey("quickPromoteEligibility"));
        Assert.Null(model.QuotedTweet);
        Assert.False(model.RawData.ContainsKey("quoted_tweet"));
        Assert.Null(model.Retweeted);
        Assert.False(model.RawData.ContainsKey("retweeted"));
        Assert.Null(model.RetweetedTweet);
        Assert.False(model.RawData.ContainsKey("retweeted_tweet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.ViewState);
        Assert.False(model.RawData.ContainsKey("viewState"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchTweet
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
        var model = new SearchTweet
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
            Article = null,
            Author = null,
            Bookmarked = null,
            Card = null,
            CommunityNote = null,
            ContentDisclosure = null,
            ConversationID = null,
            CreatedAt = null,
            DisplayTextRange = null,
            Edit = null,
            Entities = null,
            Favorited = null,
            GrokAnalysisButton = null,
            GrokImageEditable = null,
            InReplyToID = null,
            InReplyToUserID = null,
            InReplyToUsername = null,
            IsLimitedReply = null,
            IsNoteTweet = null,
            IsQuoteStatus = null,
            IsReply = null,
            IsTranslatable = null,
            Lang = null,
            Media = null,
            NoteTweet = null,
            Place = null,
            PossiblySensitive = null,
            PossiblySensitiveEditable = null,
            PreviousCounts = null,
            QuickPromoteEligibility = null,
            QuotedTweet = null,
            Retweeted = null,
            RetweetedTweet = null,
            Source = null,
            Type = null,
            Url = null,
            ViewState = null,
        };

        Assert.Null(model.Article);
        Assert.False(model.RawData.ContainsKey("article"));
        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.Bookmarked);
        Assert.False(model.RawData.ContainsKey("bookmarked"));
        Assert.Null(model.Card);
        Assert.False(model.RawData.ContainsKey("card"));
        Assert.Null(model.CommunityNote);
        Assert.False(model.RawData.ContainsKey("communityNote"));
        Assert.Null(model.ContentDisclosure);
        Assert.False(model.RawData.ContainsKey("contentDisclosure"));
        Assert.Null(model.ConversationID);
        Assert.False(model.RawData.ContainsKey("conversationId"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.DisplayTextRange);
        Assert.False(model.RawData.ContainsKey("displayTextRange"));
        Assert.Null(model.Edit);
        Assert.False(model.RawData.ContainsKey("edit"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.Favorited);
        Assert.False(model.RawData.ContainsKey("favorited"));
        Assert.Null(model.GrokAnalysisButton);
        Assert.False(model.RawData.ContainsKey("grokAnalysisButton"));
        Assert.Null(model.GrokImageEditable);
        Assert.False(model.RawData.ContainsKey("grokImageEditable"));
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
        Assert.Null(model.IsTranslatable);
        Assert.False(model.RawData.ContainsKey("isTranslatable"));
        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
        Assert.Null(model.Media);
        Assert.False(model.RawData.ContainsKey("media"));
        Assert.Null(model.NoteTweet);
        Assert.False(model.RawData.ContainsKey("noteTweet"));
        Assert.Null(model.Place);
        Assert.False(model.RawData.ContainsKey("place"));
        Assert.Null(model.PossiblySensitive);
        Assert.False(model.RawData.ContainsKey("possiblySensitive"));
        Assert.Null(model.PossiblySensitiveEditable);
        Assert.False(model.RawData.ContainsKey("possiblySensitiveEditable"));
        Assert.Null(model.PreviousCounts);
        Assert.False(model.RawData.ContainsKey("previousCounts"));
        Assert.Null(model.QuickPromoteEligibility);
        Assert.False(model.RawData.ContainsKey("quickPromoteEligibility"));
        Assert.Null(model.QuotedTweet);
        Assert.False(model.RawData.ContainsKey("quoted_tweet"));
        Assert.Null(model.Retweeted);
        Assert.False(model.RawData.ContainsKey("retweeted"));
        Assert.Null(model.RetweetedTweet);
        Assert.False(model.RawData.ContainsKey("retweeted_tweet"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.ViewState);
        Assert.False(model.RawData.ContainsKey("viewState"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchTweet
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
            Article = null,
            Author = null,
            Bookmarked = null,
            Card = null,
            CommunityNote = null,
            ContentDisclosure = null,
            ConversationID = null,
            CreatedAt = null,
            DisplayTextRange = null,
            Edit = null,
            Entities = null,
            Favorited = null,
            GrokAnalysisButton = null,
            GrokImageEditable = null,
            InReplyToID = null,
            InReplyToUserID = null,
            InReplyToUsername = null,
            IsLimitedReply = null,
            IsNoteTweet = null,
            IsQuoteStatus = null,
            IsReply = null,
            IsTranslatable = null,
            Lang = null,
            Media = null,
            NoteTweet = null,
            Place = null,
            PossiblySensitive = null,
            PossiblySensitiveEditable = null,
            PreviousCounts = null,
            QuickPromoteEligibility = null,
            QuotedTweet = null,
            Retweeted = null,
            RetweetedTweet = null,
            Source = null,
            Type = null,
            Url = null,
            ViewState = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweet
        {
            ID = "1234567890",
            BookmarkCount = 2,
            LikeCount = 42,
            QuoteCount = 1,
            ReplyCount = 3,
            RetweetCount = 5,
            Text = "Just launched our new feature!",
            ViewCount = 1500,
            Article = new()
            {
                ID = "id",
                CoverMediaUrl = "coverMediaUrl",
                PreviewText = "previewText",
                Title = "title",
            },
            Author = new()
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
                CanDm = false,
                CanMediaTag = true,
                CommunityRole = "Member",
                CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                CreatedAt = "2009-06-02T20:12:29Z",
                CreatorSubscriptionsCount = 0,
                Description = "CEO of Tesla, SpaceX, and X",
                FavouritesCount = 18000,
                Followers = 150000000,
                Following = 500,
                FollowRequestSent = true,
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
                NotificationsEnabled = true,
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
                SuperFollowedBy = true,
                SuperFollowEligible = true,
                SuperFollowing = true,
                Unavailable = false,
                UnavailableReason = "suspended",
                Url = "https://xquik.com",
                Verified = true,
                VerifiedType = "Business",
                ViewerBlockedBy = true,
                ViewerBlocking = true,
                ViewerFollowedBy = false,
                ViewerFollowing = true,
                ViewerLiveFollowing = true,
                ViewerMuting = true,
                WithheldInCountries = ["DE"],
            },
            Bookmarked = true,
            Card = new()
            {
                ID = "id",
                BindingValues = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Name = "name",
                Url = "url",
            },
            CommunityNote = new()
            {
                ID = "id",
                DestinationUrl = "destinationUrl",
                Footer = "footer",
                ShortTitle = "shortTitle",
                Subtitle = "subtitle",
                Title = "title",
                VisualStyle = "visualStyle",
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
            Edit = new()
            {
                EditableUntilMsecs = "editableUntilMsecs",
                EditsRemaining = "editsRemaining",
                EditTweetIds = ["string"],
                IsEditEligible = true,
            },
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Favorited = true,
            GrokAnalysisButton = true,
            GrokImageEditable = true,
            InReplyToID = "1234567890",
            InReplyToUserID = "9876543210",
            InReplyToUsername = "example_user",
            IsLimitedReply = false,
            IsNoteTweet = false,
            IsQuoteStatus = false,
            IsReply = false,
            IsTranslatable = true,
            Lang = "en",
            Media =
            [
                new()
                {
                    MediaUrl = "mediaUrl",
                    Type = TweetMediaType.Photo,
                    Url = "url",
                    ID = "id",
                    AllowDownload = true,
                    AltText = "altText",
                    AspectRatio = [0],
                    AvailabilityStatus = "availabilityStatus",
                    DisplayUrl = "displayUrl",
                    DurationMillis = 0,
                    ExpandedUrl = "expandedUrl",
                    FaceRects = new Dictionary<
                        string,
                        IReadOnlyList<UnnamedSchemaWithArrayParent0>
                    >()
                    {
                        {
                            "foo",
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                            ]
                        },
                    },
                    FocusRects =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                    ],
                    Height = 0,
                    Indices = [0],
                    MediaKey = "mediaKey",
                    Monetizable = true,
                    Sizes = new Dictionary<string, SizesItem>()
                    {
                        {
                            "foo",
                            new()
                            {
                                H = 0,
                                Resize = "resize",
                                W = 0,
                            }
                        },
                    },
                    VideoVariants =
                    [
                        new()
                        {
                            ContentType = "contentType",
                            Url = "url",
                            Bitrate = 0,
                        },
                    ],
                    Width = 0,
                },
            ],
            NoteTweet = new()
            {
                Text = "text",
                ID = "id",
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                IsExpandable = true,
                RichtextTags =
                [
                    new()
                    {
                        FromIndex = 0,
                        ToIndex = 0,
                        Types = ["string"],
                    },
                ],
            },
            Place = new()
            {
                ID = "id",
                BoundingBox = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Country = "country",
                CountryCode = "countryCode",
                FullName = "fullName",
                Name = "name",
                PlaceType = "placeType",
                Url = "url",
            },
            PossiblySensitive = true,
            PossiblySensitiveEditable = true,
            PreviousCounts = new()
            {
                BookmarkCount = 0,
                LikeCount = 0,
                QuoteCount = 0,
                ReplyCount = 0,
                RetweetCount = 0,
            },
            QuickPromoteEligibility = "quickPromoteEligibility",
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Retweeted = true,
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
                Article = new()
                {
                    ID = "id",
                    CoverMediaUrl = "coverMediaUrl",
                    PreviewText = "previewText",
                    Title = "title",
                },
                Author = new()
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
                    CanDm = false,
                    CanMediaTag = true,
                    CommunityRole = "Member",
                    CoverPicture = "https://pbs.twimg.com/profile_banners/example.jpg",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    CreatorSubscriptionsCount = 0,
                    Description = "CEO of Tesla, SpaceX, and X",
                    FavouritesCount = 18000,
                    Followers = 150000000,
                    Following = 500,
                    FollowRequestSent = true,
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
                    NotificationsEnabled = true,
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
                    SuperFollowedBy = true,
                    SuperFollowEligible = true,
                    SuperFollowing = true,
                    Unavailable = false,
                    UnavailableReason = "suspended",
                    Url = "https://xquik.com",
                    Verified = true,
                    VerifiedType = "Business",
                    ViewerBlockedBy = true,
                    ViewerBlocking = true,
                    ViewerFollowedBy = false,
                    ViewerFollowing = true,
                    ViewerLiveFollowing = true,
                    ViewerMuting = true,
                    WithheldInCountries = ["DE"],
                },
                Bookmarked = true,
                Card = new()
                {
                    ID = "id",
                    BindingValues = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Name = "name",
                    Url = "url",
                },
                CommunityNote = new()
                {
                    ID = "id",
                    DestinationUrl = "destinationUrl",
                    Footer = "footer",
                    ShortTitle = "shortTitle",
                    Subtitle = "subtitle",
                    Title = "title",
                    VisualStyle = "visualStyle",
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
                Edit = new()
                {
                    EditableUntilMsecs = "editableUntilMsecs",
                    EditsRemaining = "editsRemaining",
                    EditTweetIds = ["string"],
                    IsEditEligible = true,
                },
                Entities = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Favorited = true,
                GrokAnalysisButton = true,
                GrokImageEditable = true,
                InReplyToID = "inReplyToId",
                InReplyToUserID = "inReplyToUserId",
                InReplyToUsername = "inReplyToUsername",
                IsLimitedReply = true,
                IsNoteTweet = true,
                IsQuoteStatus = true,
                IsReply = true,
                IsTranslatable = true,
                Lang = "lang",
                Media =
                [
                    new()
                    {
                        MediaUrl = "mediaUrl",
                        Type = TweetMediaType.Photo,
                        Url = "url",
                        ID = "id",
                        AllowDownload = true,
                        AltText = "altText",
                        AspectRatio = [0],
                        AvailabilityStatus = "availabilityStatus",
                        DisplayUrl = "displayUrl",
                        DurationMillis = 0,
                        ExpandedUrl = "expandedUrl",
                        FaceRects = new Dictionary<
                            string,
                            IReadOnlyList<UnnamedSchemaWithArrayParent0>
                        >()
                        {
                            {
                                "foo",
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                ]
                            },
                        },
                        FocusRects =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                        ],
                        Height = 0,
                        Indices = [0],
                        MediaKey = "mediaKey",
                        Monetizable = true,
                        Sizes = new Dictionary<string, SizesItem>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    H = 0,
                                    Resize = "resize",
                                    W = 0,
                                }
                            },
                        },
                        VideoVariants =
                        [
                            new()
                            {
                                ContentType = "contentType",
                                Url = "url",
                                Bitrate = 0,
                            },
                        ],
                        Width = 0,
                    },
                ],
                NoteTweet = new()
                {
                    Text = "text",
                    ID = "id",
                    Entities = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    IsExpandable = true,
                    RichtextTags =
                    [
                        new()
                        {
                            FromIndex = 0,
                            ToIndex = 0,
                            Types = ["string"],
                        },
                    ],
                },
                Place = new()
                {
                    ID = "id",
                    BoundingBox = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Country = "country",
                    CountryCode = "countryCode",
                    FullName = "fullName",
                    Name = "name",
                    PlaceType = "placeType",
                    Url = "url",
                },
                PossiblySensitive = true,
                PossiblySensitiveEditable = true,
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
                QuickPromoteEligibility = "quickPromoteEligibility",
                Retweeted = true,
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "Twitter Web App",
            Type = "tweet",
            Url = "https://x.com/example_user/status/1234567890",
            ViewState = "viewState",
        };

        SearchTweet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTweetArticleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweetArticle
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };

        string expectedID = "id";
        string expectedCoverMediaUrl = "coverMediaUrl";
        string expectedPreviewText = "previewText";
        string expectedTitle = "title";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCoverMediaUrl, model.CoverMediaUrl);
        Assert.Equal(expectedPreviewText, model.PreviewText);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweetArticle
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetArticle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweetArticle
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetArticle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCoverMediaUrl = "coverMediaUrl";
        string expectedPreviewText = "previewText";
        string expectedTitle = "title";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCoverMediaUrl, deserialized.CoverMediaUrl);
        Assert.Equal(expectedPreviewText, deserialized.PreviewText);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweetArticle
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchTweetArticle { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CoverMediaUrl);
        Assert.False(model.RawData.ContainsKey("coverMediaUrl"));
        Assert.Null(model.PreviewText);
        Assert.False(model.RawData.ContainsKey("previewText"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchTweetArticle { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SearchTweetArticle
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CoverMediaUrl = null,
            PreviewText = null,
            Title = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CoverMediaUrl);
        Assert.False(model.RawData.ContainsKey("coverMediaUrl"));
        Assert.Null(model.PreviewText);
        Assert.False(model.RawData.ContainsKey("previewText"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchTweetArticle
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CoverMediaUrl = null,
            PreviewText = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweetArticle
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };

        SearchTweetArticle copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTweetCardTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweetCard
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedBindingValues = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.BindingValues);
        Assert.Equal(expectedBindingValues.Count, model.BindingValues.Count);
        foreach (var item in expectedBindingValues)
        {
            Assert.True(model.BindingValues.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.BindingValues[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweetCard
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetCard>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweetCard
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetCard>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedBindingValues = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.BindingValues);
        Assert.Equal(expectedBindingValues.Count, deserialized.BindingValues.Count);
        foreach (var item in expectedBindingValues)
        {
            Assert.True(deserialized.BindingValues.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.BindingValues[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweetCard
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchTweetCard { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BindingValues);
        Assert.False(model.RawData.ContainsKey("bindingValues"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchTweetCard { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SearchTweetCard
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            BindingValues = null,
            Name = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BindingValues);
        Assert.False(model.RawData.ContainsKey("bindingValues"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchTweetCard
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            BindingValues = null,
            Name = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweetCard
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };

        SearchTweetCard copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTweetCommunityNoteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweetCommunityNote
        {
            ID = "id",
            DestinationUrl = "destinationUrl",
            Footer = "footer",
            ShortTitle = "shortTitle",
            Subtitle = "subtitle",
            Title = "title",
            VisualStyle = "visualStyle",
        };

        string expectedID = "id";
        string expectedDestinationUrl = "destinationUrl";
        string expectedFooter = "footer";
        string expectedShortTitle = "shortTitle";
        string expectedSubtitle = "subtitle";
        string expectedTitle = "title";
        string expectedVisualStyle = "visualStyle";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDestinationUrl, model.DestinationUrl);
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedShortTitle, model.ShortTitle);
        Assert.Equal(expectedSubtitle, model.Subtitle);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedVisualStyle, model.VisualStyle);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweetCommunityNote
        {
            ID = "id",
            DestinationUrl = "destinationUrl",
            Footer = "footer",
            ShortTitle = "shortTitle",
            Subtitle = "subtitle",
            Title = "title",
            VisualStyle = "visualStyle",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetCommunityNote>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweetCommunityNote
        {
            ID = "id",
            DestinationUrl = "destinationUrl",
            Footer = "footer",
            ShortTitle = "shortTitle",
            Subtitle = "subtitle",
            Title = "title",
            VisualStyle = "visualStyle",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetCommunityNote>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDestinationUrl = "destinationUrl";
        string expectedFooter = "footer";
        string expectedShortTitle = "shortTitle";
        string expectedSubtitle = "subtitle";
        string expectedTitle = "title";
        string expectedVisualStyle = "visualStyle";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDestinationUrl, deserialized.DestinationUrl);
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedShortTitle, deserialized.ShortTitle);
        Assert.Equal(expectedSubtitle, deserialized.Subtitle);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedVisualStyle, deserialized.VisualStyle);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweetCommunityNote
        {
            ID = "id",
            DestinationUrl = "destinationUrl",
            Footer = "footer",
            ShortTitle = "shortTitle",
            Subtitle = "subtitle",
            Title = "title",
            VisualStyle = "visualStyle",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchTweetCommunityNote { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DestinationUrl);
        Assert.False(model.RawData.ContainsKey("destinationUrl"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.ShortTitle);
        Assert.False(model.RawData.ContainsKey("shortTitle"));
        Assert.Null(model.Subtitle);
        Assert.False(model.RawData.ContainsKey("subtitle"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.VisualStyle);
        Assert.False(model.RawData.ContainsKey("visualStyle"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchTweetCommunityNote { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SearchTweetCommunityNote
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            DestinationUrl = null,
            Footer = null,
            ShortTitle = null,
            Subtitle = null,
            Title = null,
            VisualStyle = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DestinationUrl);
        Assert.False(model.RawData.ContainsKey("destinationUrl"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.ShortTitle);
        Assert.False(model.RawData.ContainsKey("shortTitle"));
        Assert.Null(model.Subtitle);
        Assert.False(model.RawData.ContainsKey("subtitle"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.VisualStyle);
        Assert.False(model.RawData.ContainsKey("visualStyle"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchTweetCommunityNote
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            DestinationUrl = null,
            Footer = null,
            ShortTitle = null,
            Subtitle = null,
            Title = null,
            VisualStyle = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweetCommunityNote
        {
            ID = "id",
            DestinationUrl = "destinationUrl",
            Footer = "footer",
            ShortTitle = "shortTitle",
            Subtitle = "subtitle",
            Title = "title",
            VisualStyle = "visualStyle",
        };

        SearchTweetCommunityNote copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTweetEditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweetEdit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditsRemaining = "editsRemaining",
            EditTweetIds = ["string"],
            IsEditEligible = true,
        };

        string expectedEditableUntilMsecs = "editableUntilMsecs";
        string expectedEditsRemaining = "editsRemaining";
        List<string> expectedEditTweetIds = ["string"];
        bool expectedIsEditEligible = true;

        Assert.Equal(expectedEditableUntilMsecs, model.EditableUntilMsecs);
        Assert.Equal(expectedEditsRemaining, model.EditsRemaining);
        Assert.NotNull(model.EditTweetIds);
        Assert.Equal(expectedEditTweetIds.Count, model.EditTweetIds.Count);
        for (int i = 0; i < expectedEditTweetIds.Count; i++)
        {
            Assert.Equal(expectedEditTweetIds[i], model.EditTweetIds[i]);
        }
        Assert.Equal(expectedIsEditEligible, model.IsEditEligible);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweetEdit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditsRemaining = "editsRemaining",
            EditTweetIds = ["string"],
            IsEditEligible = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetEdit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweetEdit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditsRemaining = "editsRemaining",
            EditTweetIds = ["string"],
            IsEditEligible = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetEdit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEditableUntilMsecs = "editableUntilMsecs";
        string expectedEditsRemaining = "editsRemaining";
        List<string> expectedEditTweetIds = ["string"];
        bool expectedIsEditEligible = true;

        Assert.Equal(expectedEditableUntilMsecs, deserialized.EditableUntilMsecs);
        Assert.Equal(expectedEditsRemaining, deserialized.EditsRemaining);
        Assert.NotNull(deserialized.EditTweetIds);
        Assert.Equal(expectedEditTweetIds.Count, deserialized.EditTweetIds.Count);
        for (int i = 0; i < expectedEditTweetIds.Count; i++)
        {
            Assert.Equal(expectedEditTweetIds[i], deserialized.EditTweetIds[i]);
        }
        Assert.Equal(expectedIsEditEligible, deserialized.IsEditEligible);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweetEdit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditsRemaining = "editsRemaining",
            EditTweetIds = ["string"],
            IsEditEligible = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchTweetEdit { };

        Assert.Null(model.EditableUntilMsecs);
        Assert.False(model.RawData.ContainsKey("editableUntilMsecs"));
        Assert.Null(model.EditsRemaining);
        Assert.False(model.RawData.ContainsKey("editsRemaining"));
        Assert.Null(model.EditTweetIds);
        Assert.False(model.RawData.ContainsKey("editTweetIds"));
        Assert.Null(model.IsEditEligible);
        Assert.False(model.RawData.ContainsKey("isEditEligible"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchTweetEdit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SearchTweetEdit
        {
            // Null should be interpreted as omitted for these properties
            EditableUntilMsecs = null,
            EditsRemaining = null,
            EditTweetIds = null,
            IsEditEligible = null,
        };

        Assert.Null(model.EditableUntilMsecs);
        Assert.False(model.RawData.ContainsKey("editableUntilMsecs"));
        Assert.Null(model.EditsRemaining);
        Assert.False(model.RawData.ContainsKey("editsRemaining"));
        Assert.Null(model.EditTweetIds);
        Assert.False(model.RawData.ContainsKey("editTweetIds"));
        Assert.Null(model.IsEditEligible);
        Assert.False(model.RawData.ContainsKey("isEditEligible"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchTweetEdit
        {
            // Null should be interpreted as omitted for these properties
            EditableUntilMsecs = null,
            EditsRemaining = null,
            EditTweetIds = null,
            IsEditEligible = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweetEdit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditsRemaining = "editsRemaining",
            EditTweetIds = ["string"],
            IsEditEligible = true,
        };

        SearchTweetEdit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTweetNoteTweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweetNoteTweet
        {
            Text = "text",
            ID = "id",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsExpandable = true,
            RichtextTags =
            [
                new()
                {
                    FromIndex = 0,
                    ToIndex = 0,
                    Types = ["string"],
                },
            ],
        };

        string expectedText = "text";
        string expectedID = "id";
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedIsExpandable = true;
        List<SearchTweetNoteTweetRichtextTag> expectedRichtextTags =
        [
            new()
            {
                FromIndex = 0,
                ToIndex = 0,
                Types = ["string"],
            },
        ];

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Entities);
        Assert.Equal(expectedEntities.Count, model.Entities.Count);
        foreach (var item in expectedEntities)
        {
            Assert.True(model.Entities.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Entities[item.Key]));
        }
        Assert.Equal(expectedIsExpandable, model.IsExpandable);
        Assert.NotNull(model.RichtextTags);
        Assert.Equal(expectedRichtextTags.Count, model.RichtextTags.Count);
        for (int i = 0; i < expectedRichtextTags.Count; i++)
        {
            Assert.Equal(expectedRichtextTags[i], model.RichtextTags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweetNoteTweet
        {
            Text = "text",
            ID = "id",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsExpandable = true,
            RichtextTags =
            [
                new()
                {
                    FromIndex = 0,
                    ToIndex = 0,
                    Types = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetNoteTweet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweetNoteTweet
        {
            Text = "text",
            ID = "id",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsExpandable = true,
            RichtextTags =
            [
                new()
                {
                    FromIndex = 0,
                    ToIndex = 0,
                    Types = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetNoteTweet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        string expectedID = "id";
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedIsExpandable = true;
        List<SearchTweetNoteTweetRichtextTag> expectedRichtextTags =
        [
            new()
            {
                FromIndex = 0,
                ToIndex = 0,
                Types = ["string"],
            },
        ];

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Entities);
        Assert.Equal(expectedEntities.Count, deserialized.Entities.Count);
        foreach (var item in expectedEntities)
        {
            Assert.True(deserialized.Entities.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Entities[item.Key]));
        }
        Assert.Equal(expectedIsExpandable, deserialized.IsExpandable);
        Assert.NotNull(deserialized.RichtextTags);
        Assert.Equal(expectedRichtextTags.Count, deserialized.RichtextTags.Count);
        for (int i = 0; i < expectedRichtextTags.Count; i++)
        {
            Assert.Equal(expectedRichtextTags[i], deserialized.RichtextTags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweetNoteTweet
        {
            Text = "text",
            ID = "id",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsExpandable = true,
            RichtextTags =
            [
                new()
                {
                    FromIndex = 0,
                    ToIndex = 0,
                    Types = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchTweetNoteTweet { Text = "text" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.IsExpandable);
        Assert.False(model.RawData.ContainsKey("isExpandable"));
        Assert.Null(model.RichtextTags);
        Assert.False(model.RawData.ContainsKey("richtextTags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchTweetNoteTweet { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SearchTweetNoteTweet
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Entities = null,
            IsExpandable = null,
            RichtextTags = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
        Assert.Null(model.IsExpandable);
        Assert.False(model.RawData.ContainsKey("isExpandable"));
        Assert.Null(model.RichtextTags);
        Assert.False(model.RawData.ContainsKey("richtextTags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchTweetNoteTweet
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Entities = null,
            IsExpandable = null,
            RichtextTags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweetNoteTweet
        {
            Text = "text",
            ID = "id",
            Entities = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsExpandable = true,
            RichtextTags =
            [
                new()
                {
                    FromIndex = 0,
                    ToIndex = 0,
                    Types = ["string"],
                },
            ],
        };

        SearchTweetNoteTweet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTweetNoteTweetRichtextTagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweetNoteTweetRichtextTag
        {
            FromIndex = 0,
            ToIndex = 0,
            Types = ["string"],
        };

        long expectedFromIndex = 0;
        long expectedToIndex = 0;
        List<string> expectedTypes = ["string"];

        Assert.Equal(expectedFromIndex, model.FromIndex);
        Assert.Equal(expectedToIndex, model.ToIndex);
        Assert.Equal(expectedTypes.Count, model.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], model.Types[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweetNoteTweetRichtextTag
        {
            FromIndex = 0,
            ToIndex = 0,
            Types = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetNoteTweetRichtextTag>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweetNoteTweetRichtextTag
        {
            FromIndex = 0,
            ToIndex = 0,
            Types = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetNoteTweetRichtextTag>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedFromIndex = 0;
        long expectedToIndex = 0;
        List<string> expectedTypes = ["string"];

        Assert.Equal(expectedFromIndex, deserialized.FromIndex);
        Assert.Equal(expectedToIndex, deserialized.ToIndex);
        Assert.Equal(expectedTypes.Count, deserialized.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], deserialized.Types[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweetNoteTweetRichtextTag
        {
            FromIndex = 0,
            ToIndex = 0,
            Types = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweetNoteTweetRichtextTag
        {
            FromIndex = 0,
            ToIndex = 0,
            Types = ["string"],
        };

        SearchTweetNoteTweetRichtextTag copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTweetPlaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweetPlace
        {
            ID = "id",
            BoundingBox = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Country = "country",
            CountryCode = "countryCode",
            FullName = "fullName",
            Name = "name",
            PlaceType = "placeType",
            Url = "url",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedBoundingBox = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedCountry = "country";
        string expectedCountryCode = "countryCode";
        string expectedFullName = "fullName";
        string expectedName = "name";
        string expectedPlaceType = "placeType";
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.BoundingBox);
        Assert.Equal(expectedBoundingBox.Count, model.BoundingBox.Count);
        foreach (var item in expectedBoundingBox)
        {
            Assert.True(model.BoundingBox.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.BoundingBox[item.Key]));
        }
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedFullName, model.FullName);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlaceType, model.PlaceType);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweetPlace
        {
            ID = "id",
            BoundingBox = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Country = "country",
            CountryCode = "countryCode",
            FullName = "fullName",
            Name = "name",
            PlaceType = "placeType",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetPlace>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweetPlace
        {
            ID = "id",
            BoundingBox = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Country = "country",
            CountryCode = "countryCode",
            FullName = "fullName",
            Name = "name",
            PlaceType = "placeType",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetPlace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedBoundingBox = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedCountry = "country";
        string expectedCountryCode = "countryCode";
        string expectedFullName = "fullName";
        string expectedName = "name";
        string expectedPlaceType = "placeType";
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.BoundingBox);
        Assert.Equal(expectedBoundingBox.Count, deserialized.BoundingBox.Count);
        foreach (var item in expectedBoundingBox)
        {
            Assert.True(deserialized.BoundingBox.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.BoundingBox[item.Key]));
        }
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedFullName, deserialized.FullName);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPlaceType, deserialized.PlaceType);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweetPlace
        {
            ID = "id",
            BoundingBox = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Country = "country",
            CountryCode = "countryCode",
            FullName = "fullName",
            Name = "name",
            PlaceType = "placeType",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchTweetPlace { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BoundingBox);
        Assert.False(model.RawData.ContainsKey("boundingBox"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.FullName);
        Assert.False(model.RawData.ContainsKey("fullName"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PlaceType);
        Assert.False(model.RawData.ContainsKey("placeType"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchTweetPlace { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SearchTweetPlace
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            BoundingBox = null,
            Country = null,
            CountryCode = null,
            FullName = null,
            Name = null,
            PlaceType = null,
            Url = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BoundingBox);
        Assert.False(model.RawData.ContainsKey("boundingBox"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.FullName);
        Assert.False(model.RawData.ContainsKey("fullName"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PlaceType);
        Assert.False(model.RawData.ContainsKey("placeType"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchTweetPlace
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            BoundingBox = null,
            Country = null,
            CountryCode = null,
            FullName = null,
            Name = null,
            PlaceType = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweetPlace
        {
            ID = "id",
            BoundingBox = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Country = "country",
            CountryCode = "countryCode",
            FullName = "fullName",
            Name = "name",
            PlaceType = "placeType",
            Url = "url",
        };

        SearchTweetPlace copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTweetPreviousCountsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchTweetPreviousCounts
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };

        long expectedBookmarkCount = 0;
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;

        Assert.Equal(expectedBookmarkCount, model.BookmarkCount);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedQuoteCount, model.QuoteCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedRetweetCount, model.RetweetCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchTweetPreviousCounts
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetPreviousCounts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchTweetPreviousCounts
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SearchTweetPreviousCounts>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBookmarkCount = 0;
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;

        Assert.Equal(expectedBookmarkCount, deserialized.BookmarkCount);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedQuoteCount, deserialized.QuoteCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedRetweetCount, deserialized.RetweetCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchTweetPreviousCounts
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchTweetPreviousCounts { };

        Assert.Null(model.BookmarkCount);
        Assert.False(model.RawData.ContainsKey("bookmarkCount"));
        Assert.Null(model.LikeCount);
        Assert.False(model.RawData.ContainsKey("likeCount"));
        Assert.Null(model.QuoteCount);
        Assert.False(model.RawData.ContainsKey("quoteCount"));
        Assert.Null(model.ReplyCount);
        Assert.False(model.RawData.ContainsKey("replyCount"));
        Assert.Null(model.RetweetCount);
        Assert.False(model.RawData.ContainsKey("retweetCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchTweetPreviousCounts { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SearchTweetPreviousCounts
        {
            // Null should be interpreted as omitted for these properties
            BookmarkCount = null,
            LikeCount = null,
            QuoteCount = null,
            ReplyCount = null,
            RetweetCount = null,
        };

        Assert.Null(model.BookmarkCount);
        Assert.False(model.RawData.ContainsKey("bookmarkCount"));
        Assert.Null(model.LikeCount);
        Assert.False(model.RawData.ContainsKey("likeCount"));
        Assert.Null(model.QuoteCount);
        Assert.False(model.RawData.ContainsKey("quoteCount"));
        Assert.Null(model.ReplyCount);
        Assert.False(model.RawData.ContainsKey("replyCount"));
        Assert.Null(model.RetweetCount);
        Assert.False(model.RawData.ContainsKey("retweetCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchTweetPreviousCounts
        {
            // Null should be interpreted as omitted for these properties
            BookmarkCount = null,
            LikeCount = null,
            QuoteCount = null,
            ReplyCount = null,
            RetweetCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SearchTweetPreviousCounts
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };

        SearchTweetPreviousCounts copied = new(model);

        Assert.Equal(model, copied);
    }
}
