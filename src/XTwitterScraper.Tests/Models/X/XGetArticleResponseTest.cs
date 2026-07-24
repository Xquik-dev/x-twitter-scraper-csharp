// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X;

namespace XTwitterScraper.Tests.Models.X;

public class XGetArticleResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
            },
            Author = new()
            {
                ID = "9876543210",
                Name = "Elon Musk",
                Username = "elonmusk",
                CanDm = true,
                CreatedAt = "createdAt",
                Description = "description",
                FavouritesCount = 0,
                FollowersCount = 0,
                FollowingCount = 0,
                IsBlueVerified = true,
                IsTranslator = true,
                IsVerified = true,
                Location = "location",
                MediaCount = 0,
                ProfileBannerUrl = "profileBannerUrl",
                ProfilePicture = "profilePicture",
                Protected = true,
                StatusesCount = 0,
                Url = "url",
            },
        };

        Article expectedArticle = new()
        {
            BodyText = "This is the first paragraph of the article.",
            Contents =
            [
                new()
                {
                    Height = 675,
                    InlineStyleRanges =
                    [
                        new()
                        {
                            Length = 8,
                            Offset = 0,
                            Style = "BOLD",
                        },
                    ],
                    PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                    Text = "This is the first paragraph of the article.",
                    Type = "paragraph",
                    Url = "https://pbs.twimg.com/media/example.jpg",
                    Width = 1200,
                },
            ],
            CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
            CreatedAt = "2025-01-15T12:00:00Z",
            LikeCount = 150,
            PreviewText = "A deep dive into the latest AI trends...",
            QuoteCount = 8,
            ReplyCount = 23,
            Title = "The Future of AI",
            ViewCount = 5000,
        };
        Author expectedAuthor = new()
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CanDm = true,
            CreatedAt = "createdAt",
            Description = "description",
            FavouritesCount = 0,
            FollowersCount = 0,
            FollowingCount = 0,
            IsBlueVerified = true,
            IsTranslator = true,
            IsVerified = true,
            Location = "location",
            MediaCount = 0,
            ProfileBannerUrl = "profileBannerUrl",
            ProfilePicture = "profilePicture",
            Protected = true,
            StatusesCount = 0,
            Url = "url",
        };

        Assert.Equal(expectedArticle, model.Article);
        Assert.Equal(expectedAuthor, model.Author);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
            },
            Author = new()
            {
                ID = "9876543210",
                Name = "Elon Musk",
                Username = "elonmusk",
                CanDm = true,
                CreatedAt = "createdAt",
                Description = "description",
                FavouritesCount = 0,
                FollowersCount = 0,
                FollowingCount = 0,
                IsBlueVerified = true,
                IsTranslator = true,
                IsVerified = true,
                Location = "location",
                MediaCount = 0,
                ProfileBannerUrl = "profileBannerUrl",
                ProfilePicture = "profilePicture",
                Protected = true,
                StatusesCount = 0,
                Url = "url",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XGetArticleResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
            },
            Author = new()
            {
                ID = "9876543210",
                Name = "Elon Musk",
                Username = "elonmusk",
                CanDm = true,
                CreatedAt = "createdAt",
                Description = "description",
                FavouritesCount = 0,
                FollowersCount = 0,
                FollowingCount = 0,
                IsBlueVerified = true,
                IsTranslator = true,
                IsVerified = true,
                Location = "location",
                MediaCount = 0,
                ProfileBannerUrl = "profileBannerUrl",
                ProfilePicture = "profilePicture",
                Protected = true,
                StatusesCount = 0,
                Url = "url",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<XGetArticleResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Article expectedArticle = new()
        {
            BodyText = "This is the first paragraph of the article.",
            Contents =
            [
                new()
                {
                    Height = 675,
                    InlineStyleRanges =
                    [
                        new()
                        {
                            Length = 8,
                            Offset = 0,
                            Style = "BOLD",
                        },
                    ],
                    PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                    Text = "This is the first paragraph of the article.",
                    Type = "paragraph",
                    Url = "https://pbs.twimg.com/media/example.jpg",
                    Width = 1200,
                },
            ],
            CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
            CreatedAt = "2025-01-15T12:00:00Z",
            LikeCount = 150,
            PreviewText = "A deep dive into the latest AI trends...",
            QuoteCount = 8,
            ReplyCount = 23,
            Title = "The Future of AI",
            ViewCount = 5000,
        };
        Author expectedAuthor = new()
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CanDm = true,
            CreatedAt = "createdAt",
            Description = "description",
            FavouritesCount = 0,
            FollowersCount = 0,
            FollowingCount = 0,
            IsBlueVerified = true,
            IsTranslator = true,
            IsVerified = true,
            Location = "location",
            MediaCount = 0,
            ProfileBannerUrl = "profileBannerUrl",
            ProfilePicture = "profilePicture",
            Protected = true,
            StatusesCount = 0,
            Url = "url",
        };

        Assert.Equal(expectedArticle, deserialized.Article);
        Assert.Equal(expectedAuthor, deserialized.Author);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
            },
            Author = new()
            {
                ID = "9876543210",
                Name = "Elon Musk",
                Username = "elonmusk",
                CanDm = true,
                CreatedAt = "createdAt",
                Description = "description",
                FavouritesCount = 0,
                FollowersCount = 0,
                FollowingCount = 0,
                IsBlueVerified = true,
                IsTranslator = true,
                IsVerified = true,
                Location = "location",
                MediaCount = 0,
                ProfileBannerUrl = "profileBannerUrl",
                ProfilePicture = "profilePicture",
                Protected = true,
                StatusesCount = 0,
                Url = "url",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
            },
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
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
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
            },

            // Null should be interpreted as omitted for these properties
            Author = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new XGetArticleResponse
        {
            Article = new()
            {
                BodyText = "This is the first paragraph of the article.",
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        InlineStyleRanges =
                        [
                            new()
                            {
                                Length = 8,
                                Offset = 0,
                                Style = "BOLD",
                            },
                        ],
                        PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                        Text = "This is the first paragraph of the article.",
                        Type = "paragraph",
                        Url = "https://pbs.twimg.com/media/example.jpg",
                        Width = 1200,
                    },
                ],
                CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
                CreatedAt = "2025-01-15T12:00:00Z",
                LikeCount = 150,
                PreviewText = "A deep dive into the latest AI trends...",
                QuoteCount = 8,
                ReplyCount = 23,
                Title = "The Future of AI",
                ViewCount = 5000,
            },
            Author = new()
            {
                ID = "9876543210",
                Name = "Elon Musk",
                Username = "elonmusk",
                CanDm = true,
                CreatedAt = "createdAt",
                Description = "description",
                FavouritesCount = 0,
                FollowersCount = 0,
                FollowingCount = 0,
                IsBlueVerified = true,
                IsTranslator = true,
                IsVerified = true,
                Location = "location",
                MediaCount = 0,
                ProfileBannerUrl = "profileBannerUrl",
                ProfilePicture = "profilePicture",
                Protected = true,
                StatusesCount = 0,
                Url = "url",
            },
        };

        XGetArticleResponse copied = new(model);

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
            BodyText = "This is the first paragraph of the article.",
            Contents =
            [
                new()
                {
                    Height = 675,
                    InlineStyleRanges =
                    [
                        new()
                        {
                            Length = 8,
                            Offset = 0,
                            Style = "BOLD",
                        },
                    ],
                    PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                    Text = "This is the first paragraph of the article.",
                    Type = "paragraph",
                    Url = "https://pbs.twimg.com/media/example.jpg",
                    Width = 1200,
                },
            ],
            CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
            CreatedAt = "2025-01-15T12:00:00Z",
            LikeCount = 150,
            PreviewText = "A deep dive into the latest AI trends...",
            QuoteCount = 8,
            ReplyCount = 23,
            Title = "The Future of AI",
            ViewCount = 5000,
        };

        string expectedBodyText = "This is the first paragraph of the article.";
        List<Content> expectedContents =
        [
            new()
            {
                Height = 675,
                InlineStyleRanges =
                [
                    new()
                    {
                        Length = 8,
                        Offset = 0,
                        Style = "BOLD",
                    },
                ],
                PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                Text = "This is the first paragraph of the article.",
                Type = "paragraph",
                Url = "https://pbs.twimg.com/media/example.jpg",
                Width = 1200,
            },
        ];
        string expectedCoverImageUrl = "https://pbs.twimg.com/media/example.jpg";
        string expectedCreatedAt = "2025-01-15T12:00:00Z";
        long expectedLikeCount = 150;
        string expectedPreviewText = "A deep dive into the latest AI trends...";
        long expectedQuoteCount = 8;
        long expectedReplyCount = 23;
        string expectedTitle = "The Future of AI";
        long expectedViewCount = 5000;

        Assert.Equal(expectedBodyText, model.BodyText);
        Assert.NotNull(model.Contents);
        Assert.Equal(expectedContents.Count, model.Contents.Count);
        for (int i = 0; i < expectedContents.Count; i++)
        {
            Assert.Equal(expectedContents[i], model.Contents[i]);
        }
        Assert.Equal(expectedCoverImageUrl, model.CoverImageUrl);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLikeCount, model.LikeCount);
        Assert.Equal(expectedPreviewText, model.PreviewText);
        Assert.Equal(expectedQuoteCount, model.QuoteCount);
        Assert.Equal(expectedReplyCount, model.ReplyCount);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedViewCount, model.ViewCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Article
        {
            BodyText = "This is the first paragraph of the article.",
            Contents =
            [
                new()
                {
                    Height = 675,
                    InlineStyleRanges =
                    [
                        new()
                        {
                            Length = 8,
                            Offset = 0,
                            Style = "BOLD",
                        },
                    ],
                    PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                    Text = "This is the first paragraph of the article.",
                    Type = "paragraph",
                    Url = "https://pbs.twimg.com/media/example.jpg",
                    Width = 1200,
                },
            ],
            CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
            CreatedAt = "2025-01-15T12:00:00Z",
            LikeCount = 150,
            PreviewText = "A deep dive into the latest AI trends...",
            QuoteCount = 8,
            ReplyCount = 23,
            Title = "The Future of AI",
            ViewCount = 5000,
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
            BodyText = "This is the first paragraph of the article.",
            Contents =
            [
                new()
                {
                    Height = 675,
                    InlineStyleRanges =
                    [
                        new()
                        {
                            Length = 8,
                            Offset = 0,
                            Style = "BOLD",
                        },
                    ],
                    PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                    Text = "This is the first paragraph of the article.",
                    Type = "paragraph",
                    Url = "https://pbs.twimg.com/media/example.jpg",
                    Width = 1200,
                },
            ],
            CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
            CreatedAt = "2025-01-15T12:00:00Z",
            LikeCount = 150,
            PreviewText = "A deep dive into the latest AI trends...",
            QuoteCount = 8,
            ReplyCount = 23,
            Title = "The Future of AI",
            ViewCount = 5000,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Article>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBodyText = "This is the first paragraph of the article.";
        List<Content> expectedContents =
        [
            new()
            {
                Height = 675,
                InlineStyleRanges =
                [
                    new()
                    {
                        Length = 8,
                        Offset = 0,
                        Style = "BOLD",
                    },
                ],
                PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                Text = "This is the first paragraph of the article.",
                Type = "paragraph",
                Url = "https://pbs.twimg.com/media/example.jpg",
                Width = 1200,
            },
        ];
        string expectedCoverImageUrl = "https://pbs.twimg.com/media/example.jpg";
        string expectedCreatedAt = "2025-01-15T12:00:00Z";
        long expectedLikeCount = 150;
        string expectedPreviewText = "A deep dive into the latest AI trends...";
        long expectedQuoteCount = 8;
        long expectedReplyCount = 23;
        string expectedTitle = "The Future of AI";
        long expectedViewCount = 5000;

        Assert.Equal(expectedBodyText, deserialized.BodyText);
        Assert.NotNull(deserialized.Contents);
        Assert.Equal(expectedContents.Count, deserialized.Contents.Count);
        for (int i = 0; i < expectedContents.Count; i++)
        {
            Assert.Equal(expectedContents[i], deserialized.Contents[i]);
        }
        Assert.Equal(expectedCoverImageUrl, deserialized.CoverImageUrl);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLikeCount, deserialized.LikeCount);
        Assert.Equal(expectedPreviewText, deserialized.PreviewText);
        Assert.Equal(expectedQuoteCount, deserialized.QuoteCount);
        Assert.Equal(expectedReplyCount, deserialized.ReplyCount);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedViewCount, deserialized.ViewCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Article
        {
            BodyText = "This is the first paragraph of the article.",
            Contents =
            [
                new()
                {
                    Height = 675,
                    InlineStyleRanges =
                    [
                        new()
                        {
                            Length = 8,
                            Offset = 0,
                            Style = "BOLD",
                        },
                    ],
                    PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                    Text = "This is the first paragraph of the article.",
                    Type = "paragraph",
                    Url = "https://pbs.twimg.com/media/example.jpg",
                    Width = 1200,
                },
            ],
            CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
            CreatedAt = "2025-01-15T12:00:00Z",
            LikeCount = 150,
            PreviewText = "A deep dive into the latest AI trends...",
            QuoteCount = 8,
            ReplyCount = 23,
            Title = "The Future of AI",
            ViewCount = 5000,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Article { };

        Assert.Null(model.BodyText);
        Assert.False(model.RawData.ContainsKey("bodyText"));
        Assert.Null(model.Contents);
        Assert.False(model.RawData.ContainsKey("contents"));
        Assert.Null(model.CoverImageUrl);
        Assert.False(model.RawData.ContainsKey("coverImageUrl"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.LikeCount);
        Assert.False(model.RawData.ContainsKey("likeCount"));
        Assert.Null(model.PreviewText);
        Assert.False(model.RawData.ContainsKey("previewText"));
        Assert.Null(model.QuoteCount);
        Assert.False(model.RawData.ContainsKey("quoteCount"));
        Assert.Null(model.ReplyCount);
        Assert.False(model.RawData.ContainsKey("replyCount"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.ViewCount);
        Assert.False(model.RawData.ContainsKey("viewCount"));
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
            BodyText = null,
            Contents = null,
            CoverImageUrl = null,
            CreatedAt = null,
            LikeCount = null,
            PreviewText = null,
            QuoteCount = null,
            ReplyCount = null,
            Title = null,
            ViewCount = null,
        };

        Assert.Null(model.BodyText);
        Assert.False(model.RawData.ContainsKey("bodyText"));
        Assert.Null(model.Contents);
        Assert.False(model.RawData.ContainsKey("contents"));
        Assert.Null(model.CoverImageUrl);
        Assert.False(model.RawData.ContainsKey("coverImageUrl"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.LikeCount);
        Assert.False(model.RawData.ContainsKey("likeCount"));
        Assert.Null(model.PreviewText);
        Assert.False(model.RawData.ContainsKey("previewText"));
        Assert.Null(model.QuoteCount);
        Assert.False(model.RawData.ContainsKey("quoteCount"));
        Assert.Null(model.ReplyCount);
        Assert.False(model.RawData.ContainsKey("replyCount"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.ViewCount);
        Assert.False(model.RawData.ContainsKey("viewCount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Article
        {
            // Null should be interpreted as omitted for these properties
            BodyText = null,
            Contents = null,
            CoverImageUrl = null,
            CreatedAt = null,
            LikeCount = null,
            PreviewText = null,
            QuoteCount = null,
            ReplyCount = null,
            Title = null,
            ViewCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Article
        {
            BodyText = "This is the first paragraph of the article.",
            Contents =
            [
                new()
                {
                    Height = 675,
                    InlineStyleRanges =
                    [
                        new()
                        {
                            Length = 8,
                            Offset = 0,
                            Style = "BOLD",
                        },
                    ],
                    PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
                    Text = "This is the first paragraph of the article.",
                    Type = "paragraph",
                    Url = "https://pbs.twimg.com/media/example.jpg",
                    Width = 1200,
                },
            ],
            CoverImageUrl = "https://pbs.twimg.com/media/example.jpg",
            CreatedAt = "2025-01-15T12:00:00Z",
            LikeCount = 150,
            PreviewText = "A deep dive into the latest AI trends...",
            QuoteCount = 8,
            ReplyCount = 23,
            Title = "The Future of AI",
            ViewCount = 5000,
        };

        Article copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Content
        {
            Height = 675,
            InlineStyleRanges =
            [
                new()
                {
                    Length = 8,
                    Offset = 0,
                    Style = "BOLD",
                },
            ],
            PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
            Text = "This is the first paragraph of the article.",
            Type = "paragraph",
            Url = "https://pbs.twimg.com/media/example.jpg",
            Width = 1200,
        };

        long expectedHeight = 675;
        List<InlineStyleRange> expectedInlineStyleRanges =
        [
            new()
            {
                Length = 8,
                Offset = 0,
                Style = "BOLD",
            },
        ];
        string expectedPreviewUrl = "https://pbs.twimg.com/media/example.jpg";
        string expectedText = "This is the first paragraph of the article.";
        string expectedType = "paragraph";
        string expectedUrl = "https://pbs.twimg.com/media/example.jpg";
        long expectedWidth = 1200;

        Assert.Equal(expectedHeight, model.Height);
        Assert.NotNull(model.InlineStyleRanges);
        Assert.Equal(expectedInlineStyleRanges.Count, model.InlineStyleRanges.Count);
        for (int i = 0; i < expectedInlineStyleRanges.Count; i++)
        {
            Assert.Equal(expectedInlineStyleRanges[i], model.InlineStyleRanges[i]);
        }
        Assert.Equal(expectedPreviewUrl, model.PreviewUrl);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Content
        {
            Height = 675,
            InlineStyleRanges =
            [
                new()
                {
                    Length = 8,
                    Offset = 0,
                    Style = "BOLD",
                },
            ],
            PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
            Text = "This is the first paragraph of the article.",
            Type = "paragraph",
            Url = "https://pbs.twimg.com/media/example.jpg",
            Width = 1200,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Content
        {
            Height = 675,
            InlineStyleRanges =
            [
                new()
                {
                    Length = 8,
                    Offset = 0,
                    Style = "BOLD",
                },
            ],
            PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
            Text = "This is the first paragraph of the article.",
            Type = "paragraph",
            Url = "https://pbs.twimg.com/media/example.jpg",
            Width = 1200,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedHeight = 675;
        List<InlineStyleRange> expectedInlineStyleRanges =
        [
            new()
            {
                Length = 8,
                Offset = 0,
                Style = "BOLD",
            },
        ];
        string expectedPreviewUrl = "https://pbs.twimg.com/media/example.jpg";
        string expectedText = "This is the first paragraph of the article.";
        string expectedType = "paragraph";
        string expectedUrl = "https://pbs.twimg.com/media/example.jpg";
        long expectedWidth = 1200;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.NotNull(deserialized.InlineStyleRanges);
        Assert.Equal(expectedInlineStyleRanges.Count, deserialized.InlineStyleRanges.Count);
        for (int i = 0; i < expectedInlineStyleRanges.Count; i++)
        {
            Assert.Equal(expectedInlineStyleRanges[i], deserialized.InlineStyleRanges[i]);
        }
        Assert.Equal(expectedPreviewUrl, deserialized.PreviewUrl);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Content
        {
            Height = 675,
            InlineStyleRanges =
            [
                new()
                {
                    Length = 8,
                    Offset = 0,
                    Style = "BOLD",
                },
            ],
            PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
            Text = "This is the first paragraph of the article.",
            Type = "paragraph",
            Url = "https://pbs.twimg.com/media/example.jpg",
            Width = 1200,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Content { };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.InlineStyleRanges);
        Assert.False(model.RawData.ContainsKey("inlineStyleRanges"));
        Assert.Null(model.PreviewUrl);
        Assert.False(model.RawData.ContainsKey("previewUrl"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Content { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Content
        {
            // Null should be interpreted as omitted for these properties
            Height = null,
            InlineStyleRanges = null,
            PreviewUrl = null,
            Text = null,
            Type = null,
            Url = null,
            Width = null,
        };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.InlineStyleRanges);
        Assert.False(model.RawData.ContainsKey("inlineStyleRanges"));
        Assert.Null(model.PreviewUrl);
        Assert.False(model.RawData.ContainsKey("previewUrl"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Content
        {
            // Null should be interpreted as omitted for these properties
            Height = null,
            InlineStyleRanges = null,
            PreviewUrl = null,
            Text = null,
            Type = null,
            Url = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Content
        {
            Height = 675,
            InlineStyleRanges =
            [
                new()
                {
                    Length = 8,
                    Offset = 0,
                    Style = "BOLD",
                },
            ],
            PreviewUrl = "https://pbs.twimg.com/media/example.jpg",
            Text = "This is the first paragraph of the article.",
            Type = "paragraph",
            Url = "https://pbs.twimg.com/media/example.jpg",
            Width = 1200,
        };

        Content copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InlineStyleRangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InlineStyleRange
        {
            Length = 8,
            Offset = 0,
            Style = "BOLD",
        };

        long expectedLength = 8;
        long expectedOffset = 0;
        string expectedStyle = "BOLD";

        Assert.Equal(expectedLength, model.Length);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedStyle, model.Style);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InlineStyleRange
        {
            Length = 8,
            Offset = 0,
            Style = "BOLD",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InlineStyleRange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InlineStyleRange
        {
            Length = 8,
            Offset = 0,
            Style = "BOLD",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InlineStyleRange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedLength = 8;
        long expectedOffset = 0;
        string expectedStyle = "BOLD";

        Assert.Equal(expectedLength, deserialized.Length);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedStyle, deserialized.Style);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InlineStyleRange
        {
            Length = 8,
            Offset = 0,
            Style = "BOLD",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InlineStyleRange { };

        Assert.Null(model.Length);
        Assert.False(model.RawData.ContainsKey("length"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Style);
        Assert.False(model.RawData.ContainsKey("style"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InlineStyleRange { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InlineStyleRange
        {
            // Null should be interpreted as omitted for these properties
            Length = null,
            Offset = null,
            Style = null,
        };

        Assert.Null(model.Length);
        Assert.False(model.RawData.ContainsKey("length"));
        Assert.Null(model.Offset);
        Assert.False(model.RawData.ContainsKey("offset"));
        Assert.Null(model.Style);
        Assert.False(model.RawData.ContainsKey("style"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InlineStyleRange
        {
            // Null should be interpreted as omitted for these properties
            Length = null,
            Offset = null,
            Style = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InlineStyleRange
        {
            Length = 8,
            Offset = 0,
            Style = "BOLD",
        };

        InlineStyleRange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AuthorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Author
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CanDm = true,
            CreatedAt = "createdAt",
            Description = "description",
            FavouritesCount = 0,
            FollowersCount = 0,
            FollowingCount = 0,
            IsBlueVerified = true,
            IsTranslator = true,
            IsVerified = true,
            Location = "location",
            MediaCount = 0,
            ProfileBannerUrl = "profileBannerUrl",
            ProfilePicture = "profilePicture",
            Protected = true,
            StatusesCount = 0,
            Url = "url",
        };

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        bool expectedCanDm = true;
        string expectedCreatedAt = "createdAt";
        string expectedDescription = "description";
        long expectedFavouritesCount = 0;
        long expectedFollowersCount = 0;
        long expectedFollowingCount = 0;
        bool expectedIsBlueVerified = true;
        bool expectedIsTranslator = true;
        bool expectedIsVerified = true;
        string expectedLocation = "location";
        long expectedMediaCount = 0;
        string expectedProfileBannerUrl = "profileBannerUrl";
        string expectedProfilePicture = "profilePicture";
        bool expectedProtected = true;
        long expectedStatusesCount = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedCanDm, model.CanDm);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFavouritesCount, model.FavouritesCount);
        Assert.Equal(expectedFollowersCount, model.FollowersCount);
        Assert.Equal(expectedFollowingCount, model.FollowingCount);
        Assert.Equal(expectedIsBlueVerified, model.IsBlueVerified);
        Assert.Equal(expectedIsTranslator, model.IsTranslator);
        Assert.Equal(expectedIsVerified, model.IsVerified);
        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedMediaCount, model.MediaCount);
        Assert.Equal(expectedProfileBannerUrl, model.ProfileBannerUrl);
        Assert.Equal(expectedProfilePicture, model.ProfilePicture);
        Assert.Equal(expectedProtected, model.Protected);
        Assert.Equal(expectedStatusesCount, model.StatusesCount);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Author
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CanDm = true,
            CreatedAt = "createdAt",
            Description = "description",
            FavouritesCount = 0,
            FollowersCount = 0,
            FollowingCount = 0,
            IsBlueVerified = true,
            IsTranslator = true,
            IsVerified = true,
            Location = "location",
            MediaCount = 0,
            ProfileBannerUrl = "profileBannerUrl",
            ProfilePicture = "profilePicture",
            Protected = true,
            StatusesCount = 0,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Author>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Author
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CanDm = true,
            CreatedAt = "createdAt",
            Description = "description",
            FavouritesCount = 0,
            FollowersCount = 0,
            FollowingCount = 0,
            IsBlueVerified = true,
            IsTranslator = true,
            IsVerified = true,
            Location = "location",
            MediaCount = 0,
            ProfileBannerUrl = "profileBannerUrl",
            ProfilePicture = "profilePicture",
            Protected = true,
            StatusesCount = 0,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Author>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        bool expectedCanDm = true;
        string expectedCreatedAt = "createdAt";
        string expectedDescription = "description";
        long expectedFavouritesCount = 0;
        long expectedFollowersCount = 0;
        long expectedFollowingCount = 0;
        bool expectedIsBlueVerified = true;
        bool expectedIsTranslator = true;
        bool expectedIsVerified = true;
        string expectedLocation = "location";
        long expectedMediaCount = 0;
        string expectedProfileBannerUrl = "profileBannerUrl";
        string expectedProfilePicture = "profilePicture";
        bool expectedProtected = true;
        long expectedStatusesCount = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedCanDm, deserialized.CanDm);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFavouritesCount, deserialized.FavouritesCount);
        Assert.Equal(expectedFollowersCount, deserialized.FollowersCount);
        Assert.Equal(expectedFollowingCount, deserialized.FollowingCount);
        Assert.Equal(expectedIsBlueVerified, deserialized.IsBlueVerified);
        Assert.Equal(expectedIsTranslator, deserialized.IsTranslator);
        Assert.Equal(expectedIsVerified, deserialized.IsVerified);
        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedMediaCount, deserialized.MediaCount);
        Assert.Equal(expectedProfileBannerUrl, deserialized.ProfileBannerUrl);
        Assert.Equal(expectedProfilePicture, deserialized.ProfilePicture);
        Assert.Equal(expectedProtected, deserialized.Protected);
        Assert.Equal(expectedStatusesCount, deserialized.StatusesCount);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Author
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CanDm = true,
            CreatedAt = "createdAt",
            Description = "description",
            FavouritesCount = 0,
            FollowersCount = 0,
            FollowingCount = 0,
            IsBlueVerified = true,
            IsTranslator = true,
            IsVerified = true,
            Location = "location",
            MediaCount = 0,
            ProfileBannerUrl = "profileBannerUrl",
            ProfilePicture = "profilePicture",
            Protected = true,
            StatusesCount = 0,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Author
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
        };

        Assert.Null(model.CanDm);
        Assert.False(model.RawData.ContainsKey("canDm"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FavouritesCount);
        Assert.False(model.RawData.ContainsKey("favouritesCount"));
        Assert.Null(model.FollowersCount);
        Assert.False(model.RawData.ContainsKey("followersCount"));
        Assert.Null(model.FollowingCount);
        Assert.False(model.RawData.ContainsKey("followingCount"));
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
        Assert.Null(model.ProfileBannerUrl);
        Assert.False(model.RawData.ContainsKey("profileBannerUrl"));
        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
        Assert.Null(model.Protected);
        Assert.False(model.RawData.ContainsKey("protected"));
        Assert.Null(model.StatusesCount);
        Assert.False(model.RawData.ContainsKey("statusesCount"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Author
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
        var model = new Author
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            CanDm = null,
            CreatedAt = null,
            Description = null,
            FavouritesCount = null,
            FollowersCount = null,
            FollowingCount = null,
            IsBlueVerified = null,
            IsTranslator = null,
            IsVerified = null,
            Location = null,
            MediaCount = null,
            ProfileBannerUrl = null,
            ProfilePicture = null,
            Protected = null,
            StatusesCount = null,
            Url = null,
        };

        Assert.Null(model.CanDm);
        Assert.False(model.RawData.ContainsKey("canDm"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.FavouritesCount);
        Assert.False(model.RawData.ContainsKey("favouritesCount"));
        Assert.Null(model.FollowersCount);
        Assert.False(model.RawData.ContainsKey("followersCount"));
        Assert.Null(model.FollowingCount);
        Assert.False(model.RawData.ContainsKey("followingCount"));
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
        Assert.Null(model.ProfileBannerUrl);
        Assert.False(model.RawData.ContainsKey("profileBannerUrl"));
        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
        Assert.Null(model.Protected);
        Assert.False(model.RawData.ContainsKey("protected"));
        Assert.Null(model.StatusesCount);
        Assert.False(model.RawData.ContainsKey("statusesCount"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Author
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

            // Null should be interpreted as omitted for these properties
            CanDm = null,
            CreatedAt = null,
            Description = null,
            FavouritesCount = null,
            FollowersCount = null,
            FollowingCount = null,
            IsBlueVerified = null,
            IsTranslator = null,
            IsVerified = null,
            Location = null,
            MediaCount = null,
            ProfileBannerUrl = null,
            ProfilePicture = null,
            Protected = null,
            StatusesCount = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Author
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CanDm = true,
            CreatedAt = "createdAt",
            Description = "description",
            FavouritesCount = 0,
            FollowersCount = 0,
            FollowingCount = 0,
            IsBlueVerified = true,
            IsTranslator = true,
            IsVerified = true,
            Location = "location",
            MediaCount = 0,
            ProfileBannerUrl = "profileBannerUrl",
            ProfilePicture = "profilePicture",
            Protected = true,
            StatusesCount = 0,
            Url = "url",
        };

        Author copied = new(model);

        Assert.Equal(model, copied);
    }
}
