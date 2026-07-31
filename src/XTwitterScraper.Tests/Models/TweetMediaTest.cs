// SPDX-FileCopyrightText: 2026 Xquik-dev contributors
// SPDX-License-Identifier: Apache-2.0

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
        };

        string expectedMediaUrl = "mediaUrl";
        ApiEnum<string, TweetMediaType> expectedType = TweetMediaType.Photo;
        string expectedUrl = "url";
        string expectedID = "id";
        bool expectedAllowDownload = true;
        string expectedAltText = "altText";
        List<long> expectedAspectRatio = [0];
        string expectedAvailabilityStatus = "availabilityStatus";
        string expectedDisplayUrl = "displayUrl";
        long expectedDurationMillis = 0;
        string expectedExpandedUrl = "expandedUrl";
        Dictionary<string, List<UnnamedSchemaWithArrayParent0>> expectedFaceRects = new()
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
        };
        List<FocusRect> expectedFocusRects =
        [
            new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
        ];
        long expectedHeight = 0;
        List<long> expectedIndices = [0];
        string expectedMediaKey = "mediaKey";
        bool expectedMonetizable = true;
        Dictionary<string, SizesItem> expectedSizes = new()
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
        };
        List<VideoVariant> expectedVideoVariants =
        [
            new()
            {
                ContentType = "contentType",
                Url = "url",
                Bitrate = 0,
            },
        ];
        long expectedWidth = 0;

        Assert.Equal(expectedMediaUrl, model.MediaUrl);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAllowDownload, model.AllowDownload);
        Assert.Equal(expectedAltText, model.AltText);
        Assert.NotNull(model.AspectRatio);
        Assert.Equal(expectedAspectRatio.Count, model.AspectRatio.Count);
        for (int i = 0; i < expectedAspectRatio.Count; i++)
        {
            Assert.Equal(expectedAspectRatio[i], model.AspectRatio[i]);
        }
        Assert.Equal(expectedAvailabilityStatus, model.AvailabilityStatus);
        Assert.Equal(expectedDisplayUrl, model.DisplayUrl);
        Assert.Equal(expectedDurationMillis, model.DurationMillis);
        Assert.Equal(expectedExpandedUrl, model.ExpandedUrl);
        Assert.NotNull(model.FaceRects);
        Assert.Equal(expectedFaceRects.Count, model.FaceRects.Count);
        foreach (var item in expectedFaceRects)
        {
            Assert.True(model.FaceRects.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.FaceRects[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], model.FaceRects[item.Key][i]);
            }
        }
        Assert.NotNull(model.FocusRects);
        Assert.Equal(expectedFocusRects.Count, model.FocusRects.Count);
        for (int i = 0; i < expectedFocusRects.Count; i++)
        {
            Assert.Equal(expectedFocusRects[i], model.FocusRects[i]);
        }
        Assert.Equal(expectedHeight, model.Height);
        Assert.NotNull(model.Indices);
        Assert.Equal(expectedIndices.Count, model.Indices.Count);
        for (int i = 0; i < expectedIndices.Count; i++)
        {
            Assert.Equal(expectedIndices[i], model.Indices[i]);
        }
        Assert.Equal(expectedMediaKey, model.MediaKey);
        Assert.Equal(expectedMonetizable, model.Monetizable);
        Assert.NotNull(model.Sizes);
        Assert.Equal(expectedSizes.Count, model.Sizes.Count);
        foreach (var item in expectedSizes)
        {
            Assert.True(model.Sizes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Sizes[item.Key]);
        }
        Assert.NotNull(model.VideoVariants);
        Assert.Equal(expectedVideoVariants.Count, model.VideoVariants.Count);
        for (int i = 0; i < expectedVideoVariants.Count; i++)
        {
            Assert.Equal(expectedVideoVariants[i], model.VideoVariants[i]);
        }
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetMedia
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
        string expectedID = "id";
        bool expectedAllowDownload = true;
        string expectedAltText = "altText";
        List<long> expectedAspectRatio = [0];
        string expectedAvailabilityStatus = "availabilityStatus";
        string expectedDisplayUrl = "displayUrl";
        long expectedDurationMillis = 0;
        string expectedExpandedUrl = "expandedUrl";
        Dictionary<string, List<UnnamedSchemaWithArrayParent0>> expectedFaceRects = new()
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
        };
        List<FocusRect> expectedFocusRects =
        [
            new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
        ];
        long expectedHeight = 0;
        List<long> expectedIndices = [0];
        string expectedMediaKey = "mediaKey";
        bool expectedMonetizable = true;
        Dictionary<string, SizesItem> expectedSizes = new()
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
        };
        List<VideoVariant> expectedVideoVariants =
        [
            new()
            {
                ContentType = "contentType",
                Url = "url",
                Bitrate = 0,
            },
        ];
        long expectedWidth = 0;

        Assert.Equal(expectedMediaUrl, deserialized.MediaUrl);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAllowDownload, deserialized.AllowDownload);
        Assert.Equal(expectedAltText, deserialized.AltText);
        Assert.NotNull(deserialized.AspectRatio);
        Assert.Equal(expectedAspectRatio.Count, deserialized.AspectRatio.Count);
        for (int i = 0; i < expectedAspectRatio.Count; i++)
        {
            Assert.Equal(expectedAspectRatio[i], deserialized.AspectRatio[i]);
        }
        Assert.Equal(expectedAvailabilityStatus, deserialized.AvailabilityStatus);
        Assert.Equal(expectedDisplayUrl, deserialized.DisplayUrl);
        Assert.Equal(expectedDurationMillis, deserialized.DurationMillis);
        Assert.Equal(expectedExpandedUrl, deserialized.ExpandedUrl);
        Assert.NotNull(deserialized.FaceRects);
        Assert.Equal(expectedFaceRects.Count, deserialized.FaceRects.Count);
        foreach (var item in expectedFaceRects)
        {
            Assert.True(deserialized.FaceRects.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.FaceRects[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], deserialized.FaceRects[item.Key][i]);
            }
        }
        Assert.NotNull(deserialized.FocusRects);
        Assert.Equal(expectedFocusRects.Count, deserialized.FocusRects.Count);
        for (int i = 0; i < expectedFocusRects.Count; i++)
        {
            Assert.Equal(expectedFocusRects[i], deserialized.FocusRects[i]);
        }
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.NotNull(deserialized.Indices);
        Assert.Equal(expectedIndices.Count, deserialized.Indices.Count);
        for (int i = 0; i < expectedIndices.Count; i++)
        {
            Assert.Equal(expectedIndices[i], deserialized.Indices[i]);
        }
        Assert.Equal(expectedMediaKey, deserialized.MediaKey);
        Assert.Equal(expectedMonetizable, deserialized.Monetizable);
        Assert.NotNull(deserialized.Sizes);
        Assert.Equal(expectedSizes.Count, deserialized.Sizes.Count);
        foreach (var item in expectedSizes)
        {
            Assert.True(deserialized.Sizes.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Sizes[item.Key]);
        }
        Assert.NotNull(deserialized.VideoVariants);
        Assert.Equal(expectedVideoVariants.Count, deserialized.VideoVariants.Count);
        for (int i = 0; i < expectedVideoVariants.Count; i++)
        {
            Assert.Equal(expectedVideoVariants[i], deserialized.VideoVariants[i]);
        }
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetMedia
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

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AllowDownload);
        Assert.False(model.RawData.ContainsKey("allowDownload"));
        Assert.Null(model.AltText);
        Assert.False(model.RawData.ContainsKey("altText"));
        Assert.Null(model.AspectRatio);
        Assert.False(model.RawData.ContainsKey("aspectRatio"));
        Assert.Null(model.AvailabilityStatus);
        Assert.False(model.RawData.ContainsKey("availabilityStatus"));
        Assert.Null(model.DisplayUrl);
        Assert.False(model.RawData.ContainsKey("displayUrl"));
        Assert.Null(model.DurationMillis);
        Assert.False(model.RawData.ContainsKey("durationMillis"));
        Assert.Null(model.ExpandedUrl);
        Assert.False(model.RawData.ContainsKey("expandedUrl"));
        Assert.Null(model.FaceRects);
        Assert.False(model.RawData.ContainsKey("faceRects"));
        Assert.Null(model.FocusRects);
        Assert.False(model.RawData.ContainsKey("focusRects"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Indices);
        Assert.False(model.RawData.ContainsKey("indices"));
        Assert.Null(model.MediaKey);
        Assert.False(model.RawData.ContainsKey("mediaKey"));
        Assert.Null(model.Monetizable);
        Assert.False(model.RawData.ContainsKey("monetizable"));
        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.VideoVariants);
        Assert.False(model.RawData.ContainsKey("videoVariants"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
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
            ID = null,
            AllowDownload = null,
            AltText = null,
            AspectRatio = null,
            AvailabilityStatus = null,
            DisplayUrl = null,
            DurationMillis = null,
            ExpandedUrl = null,
            FaceRects = null,
            FocusRects = null,
            Height = null,
            Indices = null,
            MediaKey = null,
            Monetizable = null,
            Sizes = null,
            VideoVariants = null,
            Width = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AllowDownload);
        Assert.False(model.RawData.ContainsKey("allowDownload"));
        Assert.Null(model.AltText);
        Assert.False(model.RawData.ContainsKey("altText"));
        Assert.Null(model.AspectRatio);
        Assert.False(model.RawData.ContainsKey("aspectRatio"));
        Assert.Null(model.AvailabilityStatus);
        Assert.False(model.RawData.ContainsKey("availabilityStatus"));
        Assert.Null(model.DisplayUrl);
        Assert.False(model.RawData.ContainsKey("displayUrl"));
        Assert.Null(model.DurationMillis);
        Assert.False(model.RawData.ContainsKey("durationMillis"));
        Assert.Null(model.ExpandedUrl);
        Assert.False(model.RawData.ContainsKey("expandedUrl"));
        Assert.Null(model.FaceRects);
        Assert.False(model.RawData.ContainsKey("faceRects"));
        Assert.Null(model.FocusRects);
        Assert.False(model.RawData.ContainsKey("focusRects"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Indices);
        Assert.False(model.RawData.ContainsKey("indices"));
        Assert.Null(model.MediaKey);
        Assert.False(model.RawData.ContainsKey("mediaKey"));
        Assert.Null(model.Monetizable);
        Assert.False(model.RawData.ContainsKey("monetizable"));
        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.VideoVariants);
        Assert.False(model.RawData.ContainsKey("videoVariants"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
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
            ID = null,
            AllowDownload = null,
            AltText = null,
            AspectRatio = null,
            AvailabilityStatus = null,
            DisplayUrl = null,
            DurationMillis = null,
            ExpandedUrl = null,
            FaceRects = null,
            FocusRects = null,
            Height = null,
            Indices = null,
            MediaKey = null,
            Monetizable = null,
            Sizes = null,
            VideoVariants = null,
            Width = null,
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

public class UnnamedSchemaWithArrayParent0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        long expectedH = 0;
        long expectedW = 0;
        long expectedX = 0;
        long expectedY = 0;

        Assert.Equal(expectedH, model.H);
        Assert.Equal(expectedW, model.W);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedH = 0;
        long expectedW = 0;
        long expectedX = 0;
        long expectedY = 0;

        Assert.Equal(expectedH, deserialized.H);
        Assert.Equal(expectedW, deserialized.W);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnnamedSchemaWithArrayParent0
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        UnnamedSchemaWithArrayParent0 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FocusRectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FocusRect
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        long expectedH = 0;
        long expectedW = 0;
        long expectedX = 0;
        long expectedY = 0;

        Assert.Equal(expectedH, model.H);
        Assert.Equal(expectedW, model.W);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FocusRect
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FocusRect>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FocusRect
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FocusRect>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedH = 0;
        long expectedW = 0;
        long expectedX = 0;
        long expectedY = 0;

        Assert.Equal(expectedH, deserialized.H);
        Assert.Equal(expectedW, deserialized.W);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FocusRect
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FocusRect
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        FocusRect copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SizesItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SizesItem
        {
            H = 0,
            Resize = "resize",
            W = 0,
        };

        long expectedH = 0;
        string expectedResize = "resize";
        long expectedW = 0;

        Assert.Equal(expectedH, model.H);
        Assert.Equal(expectedResize, model.Resize);
        Assert.Equal(expectedW, model.W);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SizesItem
        {
            H = 0,
            Resize = "resize",
            W = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SizesItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SizesItem
        {
            H = 0,
            Resize = "resize",
            W = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SizesItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedH = 0;
        string expectedResize = "resize";
        long expectedW = 0;

        Assert.Equal(expectedH, deserialized.H);
        Assert.Equal(expectedResize, deserialized.Resize);
        Assert.Equal(expectedW, deserialized.W);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SizesItem
        {
            H = 0,
            Resize = "resize",
            W = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SizesItem
        {
            H = 0,
            Resize = "resize",
            W = 0,
        };

        SizesItem copied = new(model);

        Assert.Equal(model, copied);
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
