using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X;
using XTwitterScraper.Models.X.Tweets;

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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            },
        };

        Article expectedArticle = new()
        {
            Contents =
            [
                new()
                {
                    Height = 675,
                    Text = "This is the first paragraph of the article.",
                    Type = "unstyled",
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
        TweetAuthor expectedAuthor = new()
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
            Contents =
            [
                new()
                {
                    Height = 675,
                    Text = "This is the first paragraph of the article.",
                    Type = "unstyled",
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
        TweetAuthor expectedAuthor = new()
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Contents =
                [
                    new()
                    {
                        Height = 675,
                        Text = "This is the first paragraph of the article.",
                        Type = "unstyled",
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
                Followers = 150000000,
                Username = "elonmusk",
                Verified = true,
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
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
            Contents =
            [
                new()
                {
                    Height = 675,
                    Text = "This is the first paragraph of the article.",
                    Type = "unstyled",
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

        List<Content> expectedContents =
        [
            new()
            {
                Height = 675,
                Text = "This is the first paragraph of the article.",
                Type = "unstyled",
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
            Contents =
            [
                new()
                {
                    Height = 675,
                    Text = "This is the first paragraph of the article.",
                    Type = "unstyled",
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
            Contents =
            [
                new()
                {
                    Height = 675,
                    Text = "This is the first paragraph of the article.",
                    Type = "unstyled",
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

        List<Content> expectedContents =
        [
            new()
            {
                Height = 675,
                Text = "This is the first paragraph of the article.",
                Type = "unstyled",
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
            Contents =
            [
                new()
                {
                    Height = 675,
                    Text = "This is the first paragraph of the article.",
                    Type = "unstyled",
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
            Contents =
            [
                new()
                {
                    Height = 675,
                    Text = "This is the first paragraph of the article.",
                    Type = "unstyled",
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
            Text = "This is the first paragraph of the article.",
            Type = "unstyled",
            Url = "https://pbs.twimg.com/media/example.jpg",
            Width = 1200,
        };

        long expectedHeight = 675;
        string expectedText = "This is the first paragraph of the article.";
        string expectedType = "unstyled";
        string expectedUrl = "https://pbs.twimg.com/media/example.jpg";
        long expectedWidth = 1200;

        Assert.Equal(expectedHeight, model.Height);
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
            Text = "This is the first paragraph of the article.",
            Type = "unstyled",
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
            Text = "This is the first paragraph of the article.",
            Type = "unstyled",
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
        string expectedText = "This is the first paragraph of the article.";
        string expectedType = "unstyled";
        string expectedUrl = "https://pbs.twimg.com/media/example.jpg";
        long expectedWidth = 1200;

        Assert.Equal(expectedHeight, deserialized.Height);
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
            Text = "This is the first paragraph of the article.",
            Type = "unstyled",
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
            Text = null,
            Type = null,
            Url = null,
            Width = null,
        };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
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
            Text = "This is the first paragraph of the article.",
            Type = "unstyled",
            Url = "https://pbs.twimg.com/media/example.jpg",
            Width = 1200,
        };

        Content copied = new(model);

        Assert.Equal(model, copied);
    }
}
