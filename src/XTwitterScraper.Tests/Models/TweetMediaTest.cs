using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class TweetMediaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetMedia
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
        };

        string expectedMediaUrl = "mediaUrl";
        ApiEnum<string, TweetMediaType> expectedType = TweetMediaType.Photo;
        string expectedUrl = "url";
        List<VideoVariant> expectedVideoVariants =
        [
            new()
            {
                ContentType = "contentType",
                Url = "url",
                Bitrate = 0,
            },
        ];

        Assert.Equal(expectedMediaUrl, model.MediaUrl);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.NotNull(model.VideoVariants);
        Assert.Equal(expectedVideoVariants.Count, model.VideoVariants.Count);
        for (int i = 0; i < expectedVideoVariants.Count; i++)
        {
            Assert.Equal(expectedVideoVariants[i], model.VideoVariants[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetMedia
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetMedia>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetMedia
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetMedia>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMediaUrl = "mediaUrl";
        ApiEnum<string, TweetMediaType> expectedType = TweetMediaType.Photo;
        string expectedUrl = "url";
        List<VideoVariant> expectedVideoVariants =
        [
            new()
            {
                ContentType = "contentType",
                Url = "url",
                Bitrate = 0,
            },
        ];

        Assert.Equal(expectedMediaUrl, deserialized.MediaUrl);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.NotNull(deserialized.VideoVariants);
        Assert.Equal(expectedVideoVariants.Count, deserialized.VideoVariants.Count);
        for (int i = 0; i < expectedVideoVariants.Count; i++)
        {
            Assert.Equal(expectedVideoVariants[i], deserialized.VideoVariants[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetMedia
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetMedia
        {
            MediaUrl = "mediaUrl",
            Type = TweetMediaType.Photo,
            Url = "url",
        };

        Assert.Null(model.VideoVariants);
        Assert.False(model.RawData.ContainsKey("videoVariants"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetMedia
        {
            MediaUrl = "mediaUrl",
            Type = TweetMediaType.Photo,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetMedia
        {
            MediaUrl = "mediaUrl",
            Type = TweetMediaType.Photo,
            Url = "url",

            // Null should be interpreted as omitted for these properties
            VideoVariants = null,
        };

        Assert.Null(model.VideoVariants);
        Assert.False(model.RawData.ContainsKey("videoVariants"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetMedia
        {
            MediaUrl = "mediaUrl",
            Type = TweetMediaType.Photo,
            Url = "url",

            // Null should be interpreted as omitted for these properties
            VideoVariants = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetMedia
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
        };

        TweetMedia copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TweetMediaTypeTest : TestBase
{
    [Theory]
    [InlineData(TweetMediaType.Photo)]
    [InlineData(TweetMediaType.Video)]
    [InlineData(TweetMediaType.AnimatedGif)]
    public void Validation_Works(TweetMediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetMediaType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetMediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<XTwitterScraperInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TweetMediaType.Photo)]
    [InlineData(TweetMediaType.Video)]
    [InlineData(TweetMediaType.AnimatedGif)]
    public void SerializationRoundtrip_Works(TweetMediaType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TweetMediaType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetMediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TweetMediaType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TweetMediaType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VideoVariantTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VideoVariant
        {
            ContentType = "contentType",
            Url = "url",
            Bitrate = 0,
        };

        string expectedContentType = "contentType";
        string expectedUrl = "url";
        long expectedBitrate = 0;

        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedBitrate, model.Bitrate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VideoVariant
        {
            ContentType = "contentType",
            Url = "url",
            Bitrate = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoVariant>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VideoVariant
        {
            ContentType = "contentType",
            Url = "url",
            Bitrate = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VideoVariant>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContentType = "contentType";
        string expectedUrl = "url";
        long expectedBitrate = 0;

        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedBitrate, deserialized.Bitrate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VideoVariant
        {
            ContentType = "contentType",
            Url = "url",
            Bitrate = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VideoVariant { ContentType = "contentType", Url = "url" };

        Assert.Null(model.Bitrate);
        Assert.False(model.RawData.ContainsKey("bitrate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VideoVariant { ContentType = "contentType", Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VideoVariant
        {
            ContentType = "contentType",
            Url = "url",

            // Null should be interpreted as omitted for these properties
            Bitrate = null,
        };

        Assert.Null(model.Bitrate);
        Assert.False(model.RawData.ContainsKey("bitrate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VideoVariant
        {
            ContentType = "contentType",
            Url = "url",

            // Null should be interpreted as omitted for these properties
            Bitrate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VideoVariant
        {
            ContentType = "contentType",
            Url = "url",
            Bitrate = 0,
        };

        VideoVariant copied = new(model);

        Assert.Equal(model, copied);
    }
}
