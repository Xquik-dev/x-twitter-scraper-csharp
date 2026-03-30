using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleCompareResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
        };

        StyleProfile expectedStyle1 = new()
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };
        StyleProfile expectedStyle2 = new()
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };

        Assert.Equal(expectedStyle1, model.Style1);
        Assert.Equal(expectedStyle2, model.Style2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleCompareResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StyleCompareResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        StyleProfile expectedStyle1 = new()
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };
        StyleProfile expectedStyle2 = new()
        {
            FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsOwnAccount = true,
            TweetCount = 0,
            Tweets =
            [
                new()
                {
                    ID = "id",
                    Text = "text",
                    AuthorUsername = "authorUsername",
                    CreatedAt = "createdAt",
                },
            ],
            XUsername = "xUsername",
        };

        Assert.Equal(expectedStyle1, deserialized.Style1);
        Assert.Equal(expectedStyle2, deserialized.Style2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StyleCompareResponse
        {
            Style1 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
            Style2 = new()
            {
                FetchedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsOwnAccount = true,
                TweetCount = 0,
                Tweets =
                [
                    new()
                    {
                        ID = "id",
                        Text = "text",
                        AuthorUsername = "authorUsername",
                        CreatedAt = "createdAt",
                    },
                ],
                XUsername = "xUsername",
            },
        };

        StyleCompareResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
