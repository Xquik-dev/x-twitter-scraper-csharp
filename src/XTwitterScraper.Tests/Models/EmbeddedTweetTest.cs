using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class EmbeddedTweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmbeddedTweet
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };

        string expectedID = "id";
        long expectedBookmarkCount = 0;
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        string expectedText = "text";
        long expectedViewCount = 0;
        Article expectedArticle = new()
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
        Card expectedCard = new()
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };
        CommunityNote expectedCommunityNote = new()
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
            AIGenerated = new() { DetectionSource = "UserDeclared", HasAIGeneratedMedia = true },
        };
        string expectedConversationID = "conversationId";
        string expectedCreatedAt = "createdAt";
        List<long> expectedDisplayTextRange = [0];
        Edit expectedEdit = new()
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditTweetIds = ["string"],
        };
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedInReplyToID = "inReplyToId";
        string expectedInReplyToUserID = "inReplyToUserId";
        string expectedInReplyToUsername = "inReplyToUsername";
        bool expectedIsLimitedReply = true;
        bool expectedIsNoteTweet = true;
        bool expectedIsQuoteStatus = true;
        bool expectedIsReply = true;
        bool expectedIsTranslatable = true;
        string expectedLang = "lang";
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
        NoteTweet expectedNoteTweet = new()
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
        Place expectedPlace = new()
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
        PreviousCounts expectedPreviousCounts = new()
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };
        string expectedSource = "source";
        string expectedType = "type";
        string expectedUrl = "url";
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
        Assert.Equal(expectedPreviousCounts, model.PreviousCounts);
        Assert.Equal(expectedQuotedTweet, model.QuotedTweet);
        Assert.Equal(expectedRetweetedTweet, model.RetweetedTweet);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedViewState, model.ViewState);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmbeddedTweet
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmbeddedTweet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmbeddedTweet
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmbeddedTweet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedBookmarkCount = 0;
        long expectedLikeCount = 0;
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        long expectedRetweetCount = 0;
        string expectedText = "text";
        long expectedViewCount = 0;
        Article expectedArticle = new()
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
        Card expectedCard = new()
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };
        CommunityNote expectedCommunityNote = new()
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
            AIGenerated = new() { DetectionSource = "UserDeclared", HasAIGeneratedMedia = true },
        };
        string expectedConversationID = "conversationId";
        string expectedCreatedAt = "createdAt";
        List<long> expectedDisplayTextRange = [0];
        Edit expectedEdit = new()
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditTweetIds = ["string"],
        };
        Dictionary<string, JsonElement> expectedEntities = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedInReplyToID = "inReplyToId";
        string expectedInReplyToUserID = "inReplyToUserId";
        string expectedInReplyToUsername = "inReplyToUsername";
        bool expectedIsLimitedReply = true;
        bool expectedIsNoteTweet = true;
        bool expectedIsQuoteStatus = true;
        bool expectedIsReply = true;
        bool expectedIsTranslatable = true;
        string expectedLang = "lang";
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
        NoteTweet expectedNoteTweet = new()
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
        Place expectedPlace = new()
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
        PreviousCounts expectedPreviousCounts = new()
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };
        string expectedSource = "source";
        string expectedType = "type";
        string expectedUrl = "url";
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
        Assert.Equal(expectedPreviousCounts, deserialized.PreviousCounts);
        Assert.Equal(expectedQuotedTweet, deserialized.QuotedTweet);
        Assert.Equal(expectedRetweetedTweet, deserialized.RetweetedTweet);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedViewState, deserialized.ViewState);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmbeddedTweet
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmbeddedTweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
        };

        Assert.Null(model.Article);
        Assert.False(model.RawData.ContainsKey("article"));
        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
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
        Assert.Null(model.PreviousCounts);
        Assert.False(model.RawData.ContainsKey("previousCounts"));
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
        Assert.Null(model.ViewState);
        Assert.False(model.RawData.ContainsKey("viewState"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmbeddedTweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EmbeddedTweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,

            // Null should be interpreted as omitted for these properties
            Article = null,
            Author = null,
            Card = null,
            CommunityNote = null,
            ContentDisclosure = null,
            ConversationID = null,
            CreatedAt = null,
            DisplayTextRange = null,
            Edit = null,
            Entities = null,
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
            PreviousCounts = null,
            QuotedTweet = null,
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
        Assert.Null(model.PreviousCounts);
        Assert.False(model.RawData.ContainsKey("previousCounts"));
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
        Assert.Null(model.ViewState);
        Assert.False(model.RawData.ContainsKey("viewState"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmbeddedTweet
        {
            ID = "id",
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
            Text = "text",
            ViewCount = 0,

            // Null should be interpreted as omitted for these properties
            Article = null,
            Author = null,
            Card = null,
            CommunityNote = null,
            ContentDisclosure = null,
            ConversationID = null,
            CreatedAt = null,
            DisplayTextRange = null,
            Edit = null,
            Entities = null,
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
            PreviousCounts = null,
            QuotedTweet = null,
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
        var model = new EmbeddedTweet
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
            Edit = new() { EditableUntilMsecs = "editableUntilMsecs", EditTweetIds = ["string"] },
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
                Source = "source",
                Type = "type",
                Url = "url",
                ViewState = "viewState",
            },
            Source = "source",
            Type = "type",
            Url = "url",
            ViewState = "viewState",
        };

        EmbeddedTweet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ArticleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Article
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
        var model = new Article
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Article>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Article
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Article>(
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
        var model = new Article
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
        var model = new Article { };

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
        var model = new Article { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Article
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
        var model = new Article
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
        var model = new Article
        {
            ID = "id",
            CoverMediaUrl = "coverMediaUrl",
            PreviewText = "previewText",
            Title = "title",
        };

        Article copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Card
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
        var model = new Card
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
        var deserialized = JsonSerializer.Deserialize<Card>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Card
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
        var deserialized = JsonSerializer.Deserialize<Card>(element, ModelBase.SerializerOptions);
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
        var model = new Card
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
        var model = new Card { };

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
        var model = new Card { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Card
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
        var model = new Card
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
        var model = new Card
        {
            ID = "id",
            BindingValues = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Url = "url",
        };

        Card copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CommunityNoteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CommunityNote
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
        var model = new CommunityNote
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
        var deserialized = JsonSerializer.Deserialize<CommunityNote>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CommunityNote
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
        var deserialized = JsonSerializer.Deserialize<CommunityNote>(
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
        var model = new CommunityNote
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
        var model = new CommunityNote { };

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
        var model = new CommunityNote { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CommunityNote
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
        var model = new CommunityNote
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
        var model = new CommunityNote
        {
            ID = "id",
            DestinationUrl = "destinationUrl",
            Footer = "footer",
            ShortTitle = "shortTitle",
            Subtitle = "subtitle",
            Title = "title",
            VisualStyle = "visualStyle",
        };

        CommunityNote copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Edit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditTweetIds = ["string"],
        };

        string expectedEditableUntilMsecs = "editableUntilMsecs";
        List<string> expectedEditTweetIds = ["string"];

        Assert.Equal(expectedEditableUntilMsecs, model.EditableUntilMsecs);
        Assert.NotNull(model.EditTweetIds);
        Assert.Equal(expectedEditTweetIds.Count, model.EditTweetIds.Count);
        for (int i = 0; i < expectedEditTweetIds.Count; i++)
        {
            Assert.Equal(expectedEditTweetIds[i], model.EditTweetIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Edit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditTweetIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Edit>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Edit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditTweetIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Edit>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedEditableUntilMsecs = "editableUntilMsecs";
        List<string> expectedEditTweetIds = ["string"];

        Assert.Equal(expectedEditableUntilMsecs, deserialized.EditableUntilMsecs);
        Assert.NotNull(deserialized.EditTweetIds);
        Assert.Equal(expectedEditTweetIds.Count, deserialized.EditTweetIds.Count);
        for (int i = 0; i < expectedEditTweetIds.Count; i++)
        {
            Assert.Equal(expectedEditTweetIds[i], deserialized.EditTweetIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Edit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditTweetIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Edit { };

        Assert.Null(model.EditableUntilMsecs);
        Assert.False(model.RawData.ContainsKey("editableUntilMsecs"));
        Assert.Null(model.EditTweetIds);
        Assert.False(model.RawData.ContainsKey("editTweetIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Edit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Edit
        {
            // Null should be interpreted as omitted for these properties
            EditableUntilMsecs = null,
            EditTweetIds = null,
        };

        Assert.Null(model.EditableUntilMsecs);
        Assert.False(model.RawData.ContainsKey("editableUntilMsecs"));
        Assert.Null(model.EditTweetIds);
        Assert.False(model.RawData.ContainsKey("editTweetIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Edit
        {
            // Null should be interpreted as omitted for these properties
            EditableUntilMsecs = null,
            EditTweetIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Edit
        {
            EditableUntilMsecs = "editableUntilMsecs",
            EditTweetIds = ["string"],
        };

        Edit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NoteTweetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NoteTweet
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
        List<RichtextTag> expectedRichtextTags =
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
        var model = new NoteTweet
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
        var deserialized = JsonSerializer.Deserialize<NoteTweet>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NoteTweet
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
        var deserialized = JsonSerializer.Deserialize<NoteTweet>(
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
        List<RichtextTag> expectedRichtextTags =
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
        var model = new NoteTweet
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
        var model = new NoteTweet { Text = "text" };

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
        var model = new NoteTweet { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NoteTweet
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
        var model = new NoteTweet
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
        var model = new NoteTweet
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

        NoteTweet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RichtextTagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RichtextTag
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
        var model = new RichtextTag
        {
            FromIndex = 0,
            ToIndex = 0,
            Types = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RichtextTag>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RichtextTag
        {
            FromIndex = 0,
            ToIndex = 0,
            Types = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RichtextTag>(
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
        var model = new RichtextTag
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
        var model = new RichtextTag
        {
            FromIndex = 0,
            ToIndex = 0,
            Types = ["string"],
        };

        RichtextTag copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Place
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
        var model = new Place
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
        var deserialized = JsonSerializer.Deserialize<Place>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Place
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
        var deserialized = JsonSerializer.Deserialize<Place>(element, ModelBase.SerializerOptions);
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
        var model = new Place
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
        var model = new Place { };

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
        var model = new Place { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Place
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
        var model = new Place
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
        var model = new Place
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

        Place copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PreviousCountsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviousCounts
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
        var model = new PreviousCounts
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviousCounts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviousCounts
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviousCounts>(
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
        var model = new PreviousCounts
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
        var model = new PreviousCounts { };

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
        var model = new PreviousCounts { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PreviousCounts
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
        var model = new PreviousCounts
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
        var model = new PreviousCounts
        {
            BookmarkCount = 0,
            LikeCount = 0,
            QuoteCount = 0,
            ReplyCount = 0,
            RetweetCount = 0,
        };

        PreviousCounts copied = new(model);

        Assert.Equal(model, copied);
    }
}
