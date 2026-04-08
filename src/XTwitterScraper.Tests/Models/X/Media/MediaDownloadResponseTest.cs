using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Media;

namespace XTwitterScraper.Tests.Models.X.Media;

public class MediaDownloadResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MediaDownloadResponse
        {
            CacheHit = false,
            GalleryUrl = "https://xquik.com/gallery/abc123",
            TotalMedia = 5,
            TotalTweets = 2,
            TweetID = "1234567890",
        };

        bool expectedCacheHit = false;
        string expectedGalleryUrl = "https://xquik.com/gallery/abc123";
        long expectedTotalMedia = 5;
        long expectedTotalTweets = 2;
        string expectedTweetID = "1234567890";

        Assert.Equal(expectedCacheHit, model.CacheHit);
        Assert.Equal(expectedGalleryUrl, model.GalleryUrl);
        Assert.Equal(expectedTotalMedia, model.TotalMedia);
        Assert.Equal(expectedTotalTweets, model.TotalTweets);
        Assert.Equal(expectedTweetID, model.TweetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MediaDownloadResponse
        {
            CacheHit = false,
            GalleryUrl = "https://xquik.com/gallery/abc123",
            TotalMedia = 5,
            TotalTweets = 2,
            TweetID = "1234567890",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MediaDownloadResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MediaDownloadResponse
        {
            CacheHit = false,
            GalleryUrl = "https://xquik.com/gallery/abc123",
            TotalMedia = 5,
            TotalTweets = 2,
            TweetID = "1234567890",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MediaDownloadResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCacheHit = false;
        string expectedGalleryUrl = "https://xquik.com/gallery/abc123";
        long expectedTotalMedia = 5;
        long expectedTotalTweets = 2;
        string expectedTweetID = "1234567890";

        Assert.Equal(expectedCacheHit, deserialized.CacheHit);
        Assert.Equal(expectedGalleryUrl, deserialized.GalleryUrl);
        Assert.Equal(expectedTotalMedia, deserialized.TotalMedia);
        Assert.Equal(expectedTotalTweets, deserialized.TotalTweets);
        Assert.Equal(expectedTweetID, deserialized.TweetID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MediaDownloadResponse
        {
            CacheHit = false,
            GalleryUrl = "https://xquik.com/gallery/abc123",
            TotalMedia = 5,
            TotalTweets = 2,
            TweetID = "1234567890",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MediaDownloadResponse { };

        Assert.Null(model.CacheHit);
        Assert.False(model.RawData.ContainsKey("cacheHit"));
        Assert.Null(model.GalleryUrl);
        Assert.False(model.RawData.ContainsKey("galleryUrl"));
        Assert.Null(model.TotalMedia);
        Assert.False(model.RawData.ContainsKey("totalMedia"));
        Assert.Null(model.TotalTweets);
        Assert.False(model.RawData.ContainsKey("totalTweets"));
        Assert.Null(model.TweetID);
        Assert.False(model.RawData.ContainsKey("tweetId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MediaDownloadResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MediaDownloadResponse
        {
            // Null should be interpreted as omitted for these properties
            CacheHit = null,
            GalleryUrl = null,
            TotalMedia = null,
            TotalTweets = null,
            TweetID = null,
        };

        Assert.Null(model.CacheHit);
        Assert.False(model.RawData.ContainsKey("cacheHit"));
        Assert.Null(model.GalleryUrl);
        Assert.False(model.RawData.ContainsKey("galleryUrl"));
        Assert.Null(model.TotalMedia);
        Assert.False(model.RawData.ContainsKey("totalMedia"));
        Assert.Null(model.TotalTweets);
        Assert.False(model.RawData.ContainsKey("totalTweets"));
        Assert.Null(model.TweetID);
        Assert.False(model.RawData.ContainsKey("tweetId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MediaDownloadResponse
        {
            // Null should be interpreted as omitted for these properties
            CacheHit = null,
            GalleryUrl = null,
            TotalMedia = null,
            TotalTweets = null,
            TweetID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MediaDownloadResponse
        {
            CacheHit = false,
            GalleryUrl = "https://xquik.com/gallery/abc123",
            TotalMedia = 5,
            TotalTweets = 2,
            TweetID = "1234567890",
        };

        MediaDownloadResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
