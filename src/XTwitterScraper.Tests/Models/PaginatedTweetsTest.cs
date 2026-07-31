using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models;

public class TweetGetRepliesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
            Diagnostic = new()
            {
                Complete = true,
                CoveragePercentage = 0,
                CursorFailures = 0,
                DuplicateCount = 0,
                EmptyFalseProgressPages = 0,
                MalformedCount = 0,
                MissingResponseModulesOrFields = ["string"],
                NestedReplyCount = 0,
                PagesAttempted = 0,
                RecommendedFallback = "recommendedFallback",
                RepeatedCursorCount = 0,
                ReportedReplyCount = 0,
                ResponseTruncated = true,
                Richness = new()
                {
                    Article = 0,
                    Author = 0,
                    Card = 0,
                    CommunityNote = 0,
                    CreatedAt = 0,
                    EngagementCounts = 0,
                    Entities = 0,
                    Language = 0,
                    Media = 0,
                    QuotedOrRepostedTweet = 0,
                    Text = 0,
                    TotalReplies = 0,
                    Url = 0,
                },
                StrategiesAttempted =
                [
                    new()
                    {
                        Name = "name",
                        NewDirectReplies = 0,
                        NewNestedReplies = 0,
                        PagesAttempted = 0,
                        StopReason = StopReason.Deadline,
                    },
                ],
                TargetDirectReplies = 0,
                UniqueDirectReplies = 0,
                UnrelatedCount = 0,
            },
            NestedReplies =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<SearchTweet> expectedTweets =
        [
            new()
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
                },
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
                    EditTweetIds = ["string"],
                },
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
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
                    Source = "source",
                    Type = "type",
                    Url = "url",
                    ViewState = "viewState",
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
                    Source = "source",
                    Type = "type",
                    Url = "url",
                    ViewState = "viewState",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
                ViewState = "viewState",
            },
        ];
        Diagnostic expectedDiagnostic = new()
        {
            Complete = true,
            CoveragePercentage = 0,
            CursorFailures = 0,
            DuplicateCount = 0,
            EmptyFalseProgressPages = 0,
            MalformedCount = 0,
            MissingResponseModulesOrFields = ["string"],
            NestedReplyCount = 0,
            PagesAttempted = 0,
            RecommendedFallback = "recommendedFallback",
            RepeatedCursorCount = 0,
            ReportedReplyCount = 0,
            ResponseTruncated = true,
            Richness = new()
            {
                Article = 0,
                Author = 0,
                Card = 0,
                CommunityNote = 0,
                CreatedAt = 0,
                EngagementCounts = 0,
                Entities = 0,
                Language = 0,
                Media = 0,
                QuotedOrRepostedTweet = 0,
                Text = 0,
                TotalReplies = 0,
                Url = 0,
            },
            StrategiesAttempted =
            [
                new()
                {
                    Name = "name",
                    NewDirectReplies = 0,
                    NewNestedReplies = 0,
                    PagesAttempted = 0,
                    StopReason = StopReason.Deadline,
                },
            ],
            TargetDirectReplies = 0,
            UniqueDirectReplies = 0,
            UnrelatedCount = 0,
        };
        List<SearchTweet> expectedNestedReplies =
        [
            new()
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
                },
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
                    EditTweetIds = ["string"],
                },
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
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
                    Source = "source",
                    Type = "type",
                    Url = "url",
                    ViewState = "viewState",
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
                    Source = "source",
                    Type = "type",
                    Url = "url",
                    ViewState = "viewState",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
                ViewState = "viewState",
            },
        ];

        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedTweets.Count, model.Tweets.Count);
        for (int i = 0; i < expectedTweets.Count; i++)
        {
            Assert.Equal(expectedTweets[i], model.Tweets[i]);
        }
        Assert.Equal(expectedDiagnostic, model.Diagnostic);
        Assert.NotNull(model.NestedReplies);
        Assert.Equal(expectedNestedReplies.Count, model.NestedReplies.Count);
        for (int i = 0; i < expectedNestedReplies.Count; i++)
        {
            Assert.Equal(expectedNestedReplies[i], model.NestedReplies[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
            Diagnostic = new()
            {
                Complete = true,
                CoveragePercentage = 0,
                CursorFailures = 0,
                DuplicateCount = 0,
                EmptyFalseProgressPages = 0,
                MalformedCount = 0,
                MissingResponseModulesOrFields = ["string"],
                NestedReplyCount = 0,
                PagesAttempted = 0,
                RecommendedFallback = "recommendedFallback",
                RepeatedCursorCount = 0,
                ReportedReplyCount = 0,
                ResponseTruncated = true,
                Richness = new()
                {
                    Article = 0,
                    Author = 0,
                    Card = 0,
                    CommunityNote = 0,
                    CreatedAt = 0,
                    EngagementCounts = 0,
                    Entities = 0,
                    Language = 0,
                    Media = 0,
                    QuotedOrRepostedTweet = 0,
                    Text = 0,
                    TotalReplies = 0,
                    Url = 0,
                },
                StrategiesAttempted =
                [
                    new()
                    {
                        Name = "name",
                        NewDirectReplies = 0,
                        NewNestedReplies = 0,
                        PagesAttempted = 0,
                        StopReason = StopReason.Deadline,
                    },
                ],
                TargetDirectReplies = 0,
                UniqueDirectReplies = 0,
                UnrelatedCount = 0,
            },
            NestedReplies =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetGetRepliesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
            Diagnostic = new()
            {
                Complete = true,
                CoveragePercentage = 0,
                CursorFailures = 0,
                DuplicateCount = 0,
                EmptyFalseProgressPages = 0,
                MalformedCount = 0,
                MissingResponseModulesOrFields = ["string"],
                NestedReplyCount = 0,
                PagesAttempted = 0,
                RecommendedFallback = "recommendedFallback",
                RepeatedCursorCount = 0,
                ReportedReplyCount = 0,
                ResponseTruncated = true,
                Richness = new()
                {
                    Article = 0,
                    Author = 0,
                    Card = 0,
                    CommunityNote = 0,
                    CreatedAt = 0,
                    EngagementCounts = 0,
                    Entities = 0,
                    Language = 0,
                    Media = 0,
                    QuotedOrRepostedTweet = 0,
                    Text = 0,
                    TotalReplies = 0,
                    Url = 0,
                },
                StrategiesAttempted =
                [
                    new()
                    {
                        Name = "name",
                        NewDirectReplies = 0,
                        NewNestedReplies = 0,
                        PagesAttempted = 0,
                        StopReason = StopReason.Deadline,
                    },
                ],
                TargetDirectReplies = 0,
                UniqueDirectReplies = 0,
                UnrelatedCount = 0,
            },
            NestedReplies =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetGetRepliesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<SearchTweet> expectedTweets =
        [
            new()
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
                },
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
                    EditTweetIds = ["string"],
                },
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
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
                    Source = "source",
                    Type = "type",
                    Url = "url",
                    ViewState = "viewState",
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
                    Source = "source",
                    Type = "type",
                    Url = "url",
                    ViewState = "viewState",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
                ViewState = "viewState",
            },
        ];
        Diagnostic expectedDiagnostic = new()
        {
            Complete = true,
            CoveragePercentage = 0,
            CursorFailures = 0,
            DuplicateCount = 0,
            EmptyFalseProgressPages = 0,
            MalformedCount = 0,
            MissingResponseModulesOrFields = ["string"],
            NestedReplyCount = 0,
            PagesAttempted = 0,
            RecommendedFallback = "recommendedFallback",
            RepeatedCursorCount = 0,
            ReportedReplyCount = 0,
            ResponseTruncated = true,
            Richness = new()
            {
                Article = 0,
                Author = 0,
                Card = 0,
                CommunityNote = 0,
                CreatedAt = 0,
                EngagementCounts = 0,
                Entities = 0,
                Language = 0,
                Media = 0,
                QuotedOrRepostedTweet = 0,
                Text = 0,
                TotalReplies = 0,
                Url = 0,
            },
            StrategiesAttempted =
            [
                new()
                {
                    Name = "name",
                    NewDirectReplies = 0,
                    NewNestedReplies = 0,
                    PagesAttempted = 0,
                    StopReason = StopReason.Deadline,
                },
            ],
            TargetDirectReplies = 0,
            UniqueDirectReplies = 0,
            UnrelatedCount = 0,
        };
        List<SearchTweet> expectedNestedReplies =
        [
            new()
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
                },
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
                    EditTweetIds = ["string"],
                },
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
                PreviousCounts = new()
                {
                    BookmarkCount = 0,
                    LikeCount = 0,
                    QuoteCount = 0,
                    ReplyCount = 0,
                    RetweetCount = 0,
                },
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
                    Source = "source",
                    Type = "type",
                    Url = "url",
                    ViewState = "viewState",
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
                    Source = "source",
                    Type = "type",
                    Url = "url",
                    ViewState = "viewState",
                },
                Source = "Twitter Web App",
                Type = "tweet",
                Url = "https://x.com/example_user/status/1234567890",
                ViewState = "viewState",
            },
        ];

        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedTweets.Count, deserialized.Tweets.Count);
        for (int i = 0; i < expectedTweets.Count; i++)
        {
            Assert.Equal(expectedTweets[i], deserialized.Tweets[i]);
        }
        Assert.Equal(expectedDiagnostic, deserialized.Diagnostic);
        Assert.NotNull(deserialized.NestedReplies);
        Assert.Equal(expectedNestedReplies.Count, deserialized.NestedReplies.Count);
        for (int i = 0; i < expectedNestedReplies.Count; i++)
        {
            Assert.Equal(expectedNestedReplies[i], deserialized.NestedReplies[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
            Diagnostic = new()
            {
                Complete = true,
                CoveragePercentage = 0,
                CursorFailures = 0,
                DuplicateCount = 0,
                EmptyFalseProgressPages = 0,
                MalformedCount = 0,
                MissingResponseModulesOrFields = ["string"],
                NestedReplyCount = 0,
                PagesAttempted = 0,
                RecommendedFallback = "recommendedFallback",
                RepeatedCursorCount = 0,
                ReportedReplyCount = 0,
                ResponseTruncated = true,
                Richness = new()
                {
                    Article = 0,
                    Author = 0,
                    Card = 0,
                    CommunityNote = 0,
                    CreatedAt = 0,
                    EngagementCounts = 0,
                    Entities = 0,
                    Language = 0,
                    Media = 0,
                    QuotedOrRepostedTweet = 0,
                    Text = 0,
                    TotalReplies = 0,
                    Url = 0,
                },
                StrategiesAttempted =
                [
                    new()
                    {
                        Name = "name",
                        NewDirectReplies = 0,
                        NewNestedReplies = 0,
                        PagesAttempted = 0,
                        StopReason = StopReason.Deadline,
                    },
                ],
                TargetDirectReplies = 0,
                UniqueDirectReplies = 0,
                UnrelatedCount = 0,
            },
            NestedReplies =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
        };

        Assert.Null(model.Diagnostic);
        Assert.False(model.RawData.ContainsKey("diagnostic"));
        Assert.Null(model.NestedReplies);
        Assert.False(model.RawData.ContainsKey("nested_replies"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Diagnostic = null,
            NestedReplies = null,
        };

        Assert.Null(model.Diagnostic);
        Assert.False(model.RawData.ContainsKey("diagnostic"));
        Assert.Null(model.NestedReplies);
        Assert.False(model.RawData.ContainsKey("nested_replies"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Diagnostic = null,
            NestedReplies = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetGetRepliesResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Tweets =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
            Diagnostic = new()
            {
                Complete = true,
                CoveragePercentage = 0,
                CursorFailures = 0,
                DuplicateCount = 0,
                EmptyFalseProgressPages = 0,
                MalformedCount = 0,
                MissingResponseModulesOrFields = ["string"],
                NestedReplyCount = 0,
                PagesAttempted = 0,
                RecommendedFallback = "recommendedFallback",
                RepeatedCursorCount = 0,
                ReportedReplyCount = 0,
                ResponseTruncated = true,
                Richness = new()
                {
                    Article = 0,
                    Author = 0,
                    Card = 0,
                    CommunityNote = 0,
                    CreatedAt = 0,
                    EngagementCounts = 0,
                    Entities = 0,
                    Language = 0,
                    Media = 0,
                    QuotedOrRepostedTweet = 0,
                    Text = 0,
                    TotalReplies = 0,
                    Url = 0,
                },
                StrategiesAttempted =
                [
                    new()
                    {
                        Name = "name",
                        NewDirectReplies = 0,
                        NewNestedReplies = 0,
                        PagesAttempted = 0,
                        StopReason = StopReason.Deadline,
                    },
                ],
                TargetDirectReplies = 0,
                UniqueDirectReplies = 0,
                UnrelatedCount = 0,
            },
            NestedReplies =
            [
                new()
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
                    },
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
                        EditTweetIds = ["string"],
                    },
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
                    PreviousCounts = new()
                    {
                        BookmarkCount = 0,
                        LikeCount = 0,
                        QuoteCount = 0,
                        ReplyCount = 0,
                        RetweetCount = 0,
                    },
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
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
                        },
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
                            EditTweetIds = ["string"],
                        },
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
                        PreviousCounts = new()
                        {
                            BookmarkCount = 0,
                            LikeCount = 0,
                            QuoteCount = 0,
                            ReplyCount = 0,
                            RetweetCount = 0,
                        },
                        Source = "source",
                        Type = "type",
                        Url = "url",
                        ViewState = "viewState",
                    },
                    Source = "Twitter Web App",
                    Type = "tweet",
                    Url = "https://x.com/example_user/status/1234567890",
                    ViewState = "viewState",
                },
            ],
        };

        TweetGetRepliesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiagnosticTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Diagnostic
        {
            Complete = true,
            CoveragePercentage = 0,
            CursorFailures = 0,
            DuplicateCount = 0,
            EmptyFalseProgressPages = 0,
            MalformedCount = 0,
            MissingResponseModulesOrFields = ["string"],
            NestedReplyCount = 0,
            PagesAttempted = 0,
            RecommendedFallback = "recommendedFallback",
            RepeatedCursorCount = 0,
            ReportedReplyCount = 0,
            ResponseTruncated = true,
            Richness = new()
            {
                Article = 0,
                Author = 0,
                Card = 0,
                CommunityNote = 0,
                CreatedAt = 0,
                EngagementCounts = 0,
                Entities = 0,
                Language = 0,
                Media = 0,
                QuotedOrRepostedTweet = 0,
                Text = 0,
                TotalReplies = 0,
                Url = 0,
            },
            StrategiesAttempted =
            [
                new()
                {
                    Name = "name",
                    NewDirectReplies = 0,
                    NewNestedReplies = 0,
                    PagesAttempted = 0,
                    StopReason = StopReason.Deadline,
                },
            ],
            TargetDirectReplies = 0,
            UniqueDirectReplies = 0,
            UnrelatedCount = 0,
        };

        bool expectedComplete = true;
        double expectedCoveragePercentage = 0;
        long expectedCursorFailures = 0;
        long expectedDuplicateCount = 0;
        long expectedEmptyFalseProgressPages = 0;
        long expectedMalformedCount = 0;
        List<string> expectedMissingResponseModulesOrFields = ["string"];
        long expectedNestedReplyCount = 0;
        long expectedPagesAttempted = 0;
        string expectedRecommendedFallback = "recommendedFallback";
        long expectedRepeatedCursorCount = 0;
        long expectedReportedReplyCount = 0;
        bool expectedResponseTruncated = true;
        Richness expectedRichness = new()
        {
            Article = 0,
            Author = 0,
            Card = 0,
            CommunityNote = 0,
            CreatedAt = 0,
            EngagementCounts = 0,
            Entities = 0,
            Language = 0,
            Media = 0,
            QuotedOrRepostedTweet = 0,
            Text = 0,
            TotalReplies = 0,
            Url = 0,
        };
        List<StrategiesAttempted> expectedStrategiesAttempted =
        [
            new()
            {
                Name = "name",
                NewDirectReplies = 0,
                NewNestedReplies = 0,
                PagesAttempted = 0,
                StopReason = StopReason.Deadline,
            },
        ];
        long expectedTargetDirectReplies = 0;
        long expectedUniqueDirectReplies = 0;
        long expectedUnrelatedCount = 0;

        Assert.Equal(expectedComplete, model.Complete);
        Assert.Equal(expectedCoveragePercentage, model.CoveragePercentage);
        Assert.Equal(expectedCursorFailures, model.CursorFailures);
        Assert.Equal(expectedDuplicateCount, model.DuplicateCount);
        Assert.Equal(expectedEmptyFalseProgressPages, model.EmptyFalseProgressPages);
        Assert.Equal(expectedMalformedCount, model.MalformedCount);
        Assert.Equal(
            expectedMissingResponseModulesOrFields.Count,
            model.MissingResponseModulesOrFields.Count
        );
        for (int i = 0; i < expectedMissingResponseModulesOrFields.Count; i++)
        {
            Assert.Equal(
                expectedMissingResponseModulesOrFields[i],
                model.MissingResponseModulesOrFields[i]
            );
        }
        Assert.Equal(expectedNestedReplyCount, model.NestedReplyCount);
        Assert.Equal(expectedPagesAttempted, model.PagesAttempted);
        Assert.Equal(expectedRecommendedFallback, model.RecommendedFallback);
        Assert.Equal(expectedRepeatedCursorCount, model.RepeatedCursorCount);
        Assert.Equal(expectedReportedReplyCount, model.ReportedReplyCount);
        Assert.Equal(expectedResponseTruncated, model.ResponseTruncated);
        Assert.Equal(expectedRichness, model.Richness);
        Assert.Equal(expectedStrategiesAttempted.Count, model.StrategiesAttempted.Count);
        for (int i = 0; i < expectedStrategiesAttempted.Count; i++)
        {
            Assert.Equal(expectedStrategiesAttempted[i], model.StrategiesAttempted[i]);
        }
        Assert.Equal(expectedTargetDirectReplies, model.TargetDirectReplies);
        Assert.Equal(expectedUniqueDirectReplies, model.UniqueDirectReplies);
        Assert.Equal(expectedUnrelatedCount, model.UnrelatedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Diagnostic
        {
            Complete = true,
            CoveragePercentage = 0,
            CursorFailures = 0,
            DuplicateCount = 0,
            EmptyFalseProgressPages = 0,
            MalformedCount = 0,
            MissingResponseModulesOrFields = ["string"],
            NestedReplyCount = 0,
            PagesAttempted = 0,
            RecommendedFallback = "recommendedFallback",
            RepeatedCursorCount = 0,
            ReportedReplyCount = 0,
            ResponseTruncated = true,
            Richness = new()
            {
                Article = 0,
                Author = 0,
                Card = 0,
                CommunityNote = 0,
                CreatedAt = 0,
                EngagementCounts = 0,
                Entities = 0,
                Language = 0,
                Media = 0,
                QuotedOrRepostedTweet = 0,
                Text = 0,
                TotalReplies = 0,
                Url = 0,
            },
            StrategiesAttempted =
            [
                new()
                {
                    Name = "name",
                    NewDirectReplies = 0,
                    NewNestedReplies = 0,
                    PagesAttempted = 0,
                    StopReason = StopReason.Deadline,
                },
            ],
            TargetDirectReplies = 0,
            UniqueDirectReplies = 0,
            UnrelatedCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Diagnostic>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Diagnostic
        {
            Complete = true,
            CoveragePercentage = 0,
            CursorFailures = 0,
            DuplicateCount = 0,
            EmptyFalseProgressPages = 0,
            MalformedCount = 0,
            MissingResponseModulesOrFields = ["string"],
            NestedReplyCount = 0,
            PagesAttempted = 0,
            RecommendedFallback = "recommendedFallback",
            RepeatedCursorCount = 0,
            ReportedReplyCount = 0,
            ResponseTruncated = true,
            Richness = new()
            {
                Article = 0,
                Author = 0,
                Card = 0,
                CommunityNote = 0,
                CreatedAt = 0,
                EngagementCounts = 0,
                Entities = 0,
                Language = 0,
                Media = 0,
                QuotedOrRepostedTweet = 0,
                Text = 0,
                TotalReplies = 0,
                Url = 0,
            },
            StrategiesAttempted =
            [
                new()
                {
                    Name = "name",
                    NewDirectReplies = 0,
                    NewNestedReplies = 0,
                    PagesAttempted = 0,
                    StopReason = StopReason.Deadline,
                },
            ],
            TargetDirectReplies = 0,
            UniqueDirectReplies = 0,
            UnrelatedCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Diagnostic>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedComplete = true;
        double expectedCoveragePercentage = 0;
        long expectedCursorFailures = 0;
        long expectedDuplicateCount = 0;
        long expectedEmptyFalseProgressPages = 0;
        long expectedMalformedCount = 0;
        List<string> expectedMissingResponseModulesOrFields = ["string"];
        long expectedNestedReplyCount = 0;
        long expectedPagesAttempted = 0;
        string expectedRecommendedFallback = "recommendedFallback";
        long expectedRepeatedCursorCount = 0;
        long expectedReportedReplyCount = 0;
        bool expectedResponseTruncated = true;
        Richness expectedRichness = new()
        {
            Article = 0,
            Author = 0,
            Card = 0,
            CommunityNote = 0,
            CreatedAt = 0,
            EngagementCounts = 0,
            Entities = 0,
            Language = 0,
            Media = 0,
            QuotedOrRepostedTweet = 0,
            Text = 0,
            TotalReplies = 0,
            Url = 0,
        };
        List<StrategiesAttempted> expectedStrategiesAttempted =
        [
            new()
            {
                Name = "name",
                NewDirectReplies = 0,
                NewNestedReplies = 0,
                PagesAttempted = 0,
                StopReason = StopReason.Deadline,
            },
        ];
        long expectedTargetDirectReplies = 0;
        long expectedUniqueDirectReplies = 0;
        long expectedUnrelatedCount = 0;

        Assert.Equal(expectedComplete, deserialized.Complete);
        Assert.Equal(expectedCoveragePercentage, deserialized.CoveragePercentage);
        Assert.Equal(expectedCursorFailures, deserialized.CursorFailures);
        Assert.Equal(expectedDuplicateCount, deserialized.DuplicateCount);
        Assert.Equal(expectedEmptyFalseProgressPages, deserialized.EmptyFalseProgressPages);
        Assert.Equal(expectedMalformedCount, deserialized.MalformedCount);
        Assert.Equal(
            expectedMissingResponseModulesOrFields.Count,
            deserialized.MissingResponseModulesOrFields.Count
        );
        for (int i = 0; i < expectedMissingResponseModulesOrFields.Count; i++)
        {
            Assert.Equal(
                expectedMissingResponseModulesOrFields[i],
                deserialized.MissingResponseModulesOrFields[i]
            );
        }
        Assert.Equal(expectedNestedReplyCount, deserialized.NestedReplyCount);
        Assert.Equal(expectedPagesAttempted, deserialized.PagesAttempted);
        Assert.Equal(expectedRecommendedFallback, deserialized.RecommendedFallback);
        Assert.Equal(expectedRepeatedCursorCount, deserialized.RepeatedCursorCount);
        Assert.Equal(expectedReportedReplyCount, deserialized.ReportedReplyCount);
        Assert.Equal(expectedResponseTruncated, deserialized.ResponseTruncated);
        Assert.Equal(expectedRichness, deserialized.Richness);
        Assert.Equal(expectedStrategiesAttempted.Count, deserialized.StrategiesAttempted.Count);
        for (int i = 0; i < expectedStrategiesAttempted.Count; i++)
        {
            Assert.Equal(expectedStrategiesAttempted[i], deserialized.StrategiesAttempted[i]);
        }
        Assert.Equal(expectedTargetDirectReplies, deserialized.TargetDirectReplies);
        Assert.Equal(expectedUniqueDirectReplies, deserialized.UniqueDirectReplies);
        Assert.Equal(expectedUnrelatedCount, deserialized.UnrelatedCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Diagnostic
        {
            Complete = true,
            CoveragePercentage = 0,
            CursorFailures = 0,
            DuplicateCount = 0,
            EmptyFalseProgressPages = 0,
            MalformedCount = 0,
            MissingResponseModulesOrFields = ["string"],
            NestedReplyCount = 0,
            PagesAttempted = 0,
            RecommendedFallback = "recommendedFallback",
            RepeatedCursorCount = 0,
            ReportedReplyCount = 0,
            ResponseTruncated = true,
            Richness = new()
            {
                Article = 0,
                Author = 0,
                Card = 0,
                CommunityNote = 0,
                CreatedAt = 0,
                EngagementCounts = 0,
                Entities = 0,
                Language = 0,
                Media = 0,
                QuotedOrRepostedTweet = 0,
                Text = 0,
                TotalReplies = 0,
                Url = 0,
            },
            StrategiesAttempted =
            [
                new()
                {
                    Name = "name",
                    NewDirectReplies = 0,
                    NewNestedReplies = 0,
                    PagesAttempted = 0,
                    StopReason = StopReason.Deadline,
                },
            ],
            TargetDirectReplies = 0,
            UniqueDirectReplies = 0,
            UnrelatedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Diagnostic
        {
            Complete = true,
            CoveragePercentage = 0,
            CursorFailures = 0,
            DuplicateCount = 0,
            EmptyFalseProgressPages = 0,
            MalformedCount = 0,
            MissingResponseModulesOrFields = ["string"],
            NestedReplyCount = 0,
            PagesAttempted = 0,
            RecommendedFallback = "recommendedFallback",
            RepeatedCursorCount = 0,
            ReportedReplyCount = 0,
            ResponseTruncated = true,
            Richness = new()
            {
                Article = 0,
                Author = 0,
                Card = 0,
                CommunityNote = 0,
                CreatedAt = 0,
                EngagementCounts = 0,
                Entities = 0,
                Language = 0,
                Media = 0,
                QuotedOrRepostedTweet = 0,
                Text = 0,
                TotalReplies = 0,
                Url = 0,
            },
            StrategiesAttempted =
            [
                new()
                {
                    Name = "name",
                    NewDirectReplies = 0,
                    NewNestedReplies = 0,
                    PagesAttempted = 0,
                    StopReason = StopReason.Deadline,
                },
            ],
            TargetDirectReplies = 0,
            UniqueDirectReplies = 0,
            UnrelatedCount = 0,
        };

        Diagnostic copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RichnessTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Richness
        {
            Article = 0,
            Author = 0,
            Card = 0,
            CommunityNote = 0,
            CreatedAt = 0,
            EngagementCounts = 0,
            Entities = 0,
            Language = 0,
            Media = 0,
            QuotedOrRepostedTweet = 0,
            Text = 0,
            TotalReplies = 0,
            Url = 0,
        };

        long expectedArticle = 0;
        long expectedAuthor = 0;
        long expectedCard = 0;
        long expectedCommunityNote = 0;
        long expectedCreatedAt = 0;
        long expectedEngagementCounts = 0;
        long expectedEntities = 0;
        long expectedLanguage = 0;
        long expectedMedia = 0;
        long expectedQuotedOrRepostedTweet = 0;
        long expectedText = 0;
        long expectedTotalReplies = 0;
        long expectedUrl = 0;

        Assert.Equal(expectedArticle, model.Article);
        Assert.Equal(expectedAuthor, model.Author);
        Assert.Equal(expectedCard, model.Card);
        Assert.Equal(expectedCommunityNote, model.CommunityNote);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEngagementCounts, model.EngagementCounts);
        Assert.Equal(expectedEntities, model.Entities);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedMedia, model.Media);
        Assert.Equal(expectedQuotedOrRepostedTweet, model.QuotedOrRepostedTweet);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTotalReplies, model.TotalReplies);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Richness
        {
            Article = 0,
            Author = 0,
            Card = 0,
            CommunityNote = 0,
            CreatedAt = 0,
            EngagementCounts = 0,
            Entities = 0,
            Language = 0,
            Media = 0,
            QuotedOrRepostedTweet = 0,
            Text = 0,
            TotalReplies = 0,
            Url = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Richness>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Richness
        {
            Article = 0,
            Author = 0,
            Card = 0,
            CommunityNote = 0,
            CreatedAt = 0,
            EngagementCounts = 0,
            Entities = 0,
            Language = 0,
            Media = 0,
            QuotedOrRepostedTweet = 0,
            Text = 0,
            TotalReplies = 0,
            Url = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Richness>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedArticle = 0;
        long expectedAuthor = 0;
        long expectedCard = 0;
        long expectedCommunityNote = 0;
        long expectedCreatedAt = 0;
        long expectedEngagementCounts = 0;
        long expectedEntities = 0;
        long expectedLanguage = 0;
        long expectedMedia = 0;
        long expectedQuotedOrRepostedTweet = 0;
        long expectedText = 0;
        long expectedTotalReplies = 0;
        long expectedUrl = 0;

        Assert.Equal(expectedArticle, deserialized.Article);
        Assert.Equal(expectedAuthor, deserialized.Author);
        Assert.Equal(expectedCard, deserialized.Card);
        Assert.Equal(expectedCommunityNote, deserialized.CommunityNote);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEngagementCounts, deserialized.EngagementCounts);
        Assert.Equal(expectedEntities, deserialized.Entities);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedMedia, deserialized.Media);
        Assert.Equal(expectedQuotedOrRepostedTweet, deserialized.QuotedOrRepostedTweet);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTotalReplies, deserialized.TotalReplies);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Richness
        {
            Article = 0,
            Author = 0,
            Card = 0,
            CommunityNote = 0,
            CreatedAt = 0,
            EngagementCounts = 0,
            Entities = 0,
            Language = 0,
            Media = 0,
            QuotedOrRepostedTweet = 0,
            Text = 0,
            TotalReplies = 0,
            Url = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Richness
        {
            Article = 0,
            Author = 0,
            Card = 0,
            CommunityNote = 0,
            CreatedAt = 0,
            EngagementCounts = 0,
            Entities = 0,
            Language = 0,
            Media = 0,
            QuotedOrRepostedTweet = 0,
            Text = 0,
            TotalReplies = 0,
            Url = 0,
        };

        Richness copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StrategiesAttemptedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StrategiesAttempted
        {
            Name = "name",
            NewDirectReplies = 0,
            NewNestedReplies = 0,
            PagesAttempted = 0,
            StopReason = StopReason.Deadline,
        };

        string expectedName = "name";
        long expectedNewDirectReplies = 0;
        long expectedNewNestedReplies = 0;
        long expectedPagesAttempted = 0;
        ApiEnum<string, StopReason> expectedStopReason = StopReason.Deadline;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNewDirectReplies, model.NewDirectReplies);
        Assert.Equal(expectedNewNestedReplies, model.NewNestedReplies);
        Assert.Equal(expectedPagesAttempted, model.PagesAttempted);
        Assert.Equal(expectedStopReason, model.StopReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StrategiesAttempted
        {
            Name = "name",
            NewDirectReplies = 0,
            NewNestedReplies = 0,
            PagesAttempted = 0,
            StopReason = StopReason.Deadline,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StrategiesAttempted>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StrategiesAttempted
        {
            Name = "name",
            NewDirectReplies = 0,
            NewNestedReplies = 0,
            PagesAttempted = 0,
            StopReason = StopReason.Deadline,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StrategiesAttempted>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        long expectedNewDirectReplies = 0;
        long expectedNewNestedReplies = 0;
        long expectedPagesAttempted = 0;
        ApiEnum<string, StopReason> expectedStopReason = StopReason.Deadline;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNewDirectReplies, deserialized.NewDirectReplies);
        Assert.Equal(expectedNewNestedReplies, deserialized.NewNestedReplies);
        Assert.Equal(expectedPagesAttempted, deserialized.PagesAttempted);
        Assert.Equal(expectedStopReason, deserialized.StopReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StrategiesAttempted
        {
            Name = "name",
            NewDirectReplies = 0,
            NewNestedReplies = 0,
            PagesAttempted = 0,
            StopReason = StopReason.Deadline,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StrategiesAttempted
        {
            Name = "name",
            NewDirectReplies = 0,
            NewNestedReplies = 0,
            PagesAttempted = 0,
            StopReason = StopReason.Deadline,
        };

        StrategiesAttempted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StopReasonTest : TestBase
{
    [Theory]
    [InlineData(StopReason.Deadline)]
    [InlineData(StopReason.EmptyPages)]
    [InlineData(StopReason.Error)]
    [InlineData(StopReason.MissingCursor)]
    [InlineData(StopReason.NoNextPage)]
    [InlineData(StopReason.PageCap)]
    [InlineData(StopReason.RepeatedCursor)]
    public void Validation_Works(StopReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StopReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StopReason.Deadline)]
    [InlineData(StopReason.EmptyPages)]
    [InlineData(StopReason.Error)]
    [InlineData(StopReason.MissingCursor)]
    [InlineData(StopReason.NoNextPage)]
    [InlineData(StopReason.PageCap)]
    [InlineData(StopReason.RepeatedCursor)]
    public void SerializationRoundtrip_Works(StopReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StopReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StopReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
