using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetCreateResponse { TweetID = "tweetId" };

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedTweetID = "tweetId";

        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
        Assert.Equal(expectedTweetID, model.TweetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetCreateResponse { TweetID = "tweetId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetCreateResponse { TweetID = "tweetId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedTweetID = "tweetId";

        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
        Assert.Equal(expectedTweetID, deserialized.TweetID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetCreateResponse { TweetID = "tweetId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetCreateResponse { TweetID = "tweetId" };

        TweetCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
