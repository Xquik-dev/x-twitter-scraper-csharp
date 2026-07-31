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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
        };
        TweetAuthor expectedAuthor = new()
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
        };
        TweetAuthor expectedAuthor = new()
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
        };

        TweetRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
