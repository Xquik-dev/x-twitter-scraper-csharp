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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
            },
        };

        Article expectedArticle = new()
        {
            Contents =
            [
                new()
                {
                    Height = 0,
                    Text = "text",
                    Type = "type",
                    Url = "url",
                    Width = 0,
                },
            ],
            CoverImageUrl = "coverImageUrl",
            CreatedAt = "createdAt",
            LikeCount = 0,
            PreviewText = "previewText",
            QuoteCount = 0,
            ReplyCount = 0,
            Title = "title",
            ViewCount = 0,
        };
        TweetAuthor expectedAuthor = new()
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
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
                    Height = 0,
                    Text = "text",
                    Type = "type",
                    Url = "url",
                    Width = 0,
                },
            ],
            CoverImageUrl = "coverImageUrl",
            CreatedAt = "createdAt",
            LikeCount = 0,
            PreviewText = "previewText",
            QuoteCount = 0,
            ReplyCount = 0,
            Title = "title",
            ViewCount = 0,
        };
        TweetAuthor expectedAuthor = new()
        {
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
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
                        Height = 0,
                        Text = "text",
                        Type = "type",
                        Url = "url",
                        Width = 0,
                    },
                ],
                CoverImageUrl = "coverImageUrl",
                CreatedAt = "createdAt",
                LikeCount = 0,
                PreviewText = "previewText",
                QuoteCount = 0,
                ReplyCount = 0,
                Title = "title",
                ViewCount = 0,
            },
            Author = new()
            {
                ID = "id",
                Followers = 0,
                Username = "username",
                Verified = true,
                ProfilePicture = "profilePicture",
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
                    Height = 0,
                    Text = "text",
                    Type = "type",
                    Url = "url",
                    Width = 0,
                },
            ],
            CoverImageUrl = "coverImageUrl",
            CreatedAt = "createdAt",
            LikeCount = 0,
            PreviewText = "previewText",
            QuoteCount = 0,
            ReplyCount = 0,
            Title = "title",
            ViewCount = 0,
        };

        List<Content> expectedContents =
        [
            new()
            {
                Height = 0,
                Text = "text",
                Type = "type",
                Url = "url",
                Width = 0,
            },
        ];
        string expectedCoverImageUrl = "coverImageUrl";
        string expectedCreatedAt = "createdAt";
        long expectedLikeCount = 0;
        string expectedPreviewText = "previewText";
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        string expectedTitle = "title";
        long expectedViewCount = 0;

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
                    Height = 0,
                    Text = "text",
                    Type = "type",
                    Url = "url",
                    Width = 0,
                },
            ],
            CoverImageUrl = "coverImageUrl",
            CreatedAt = "createdAt",
            LikeCount = 0,
            PreviewText = "previewText",
            QuoteCount = 0,
            ReplyCount = 0,
            Title = "title",
            ViewCount = 0,
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
                    Height = 0,
                    Text = "text",
                    Type = "type",
                    Url = "url",
                    Width = 0,
                },
            ],
            CoverImageUrl = "coverImageUrl",
            CreatedAt = "createdAt",
            LikeCount = 0,
            PreviewText = "previewText",
            QuoteCount = 0,
            ReplyCount = 0,
            Title = "title",
            ViewCount = 0,
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
                Height = 0,
                Text = "text",
                Type = "type",
                Url = "url",
                Width = 0,
            },
        ];
        string expectedCoverImageUrl = "coverImageUrl";
        string expectedCreatedAt = "createdAt";
        long expectedLikeCount = 0;
        string expectedPreviewText = "previewText";
        long expectedQuoteCount = 0;
        long expectedReplyCount = 0;
        string expectedTitle = "title";
        long expectedViewCount = 0;

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
                    Height = 0,
                    Text = "text",
                    Type = "type",
                    Url = "url",
                    Width = 0,
                },
            ],
            CoverImageUrl = "coverImageUrl",
            CreatedAt = "createdAt",
            LikeCount = 0,
            PreviewText = "previewText",
            QuoteCount = 0,
            ReplyCount = 0,
            Title = "title",
            ViewCount = 0,
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
                    Height = 0,
                    Text = "text",
                    Type = "type",
                    Url = "url",
                    Width = 0,
                },
            ],
            CoverImageUrl = "coverImageUrl",
            CreatedAt = "createdAt",
            LikeCount = 0,
            PreviewText = "previewText",
            QuoteCount = 0,
            ReplyCount = 0,
            Title = "title",
            ViewCount = 0,
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
            Height = 0,
            Text = "text",
            Type = "type",
            Url = "url",
            Width = 0,
        };

        long expectedHeight = 0;
        string expectedText = "text";
        string expectedType = "type";
        string expectedUrl = "url";
        long expectedWidth = 0;

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
            Height = 0,
            Text = "text",
            Type = "type",
            Url = "url",
            Width = 0,
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
            Height = 0,
            Text = "text",
            Type = "type",
            Url = "url",
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedHeight = 0;
        string expectedText = "text";
        string expectedType = "type";
        string expectedUrl = "url";
        long expectedWidth = 0;

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
            Height = 0,
            Text = "text",
            Type = "type",
            Url = "url",
            Width = 0,
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
            Height = 0,
            Text = "text",
            Type = "type",
            Url = "url",
            Width = 0,
        };

        Content copied = new(model);

        Assert.Equal(model, copied);
    }
}
