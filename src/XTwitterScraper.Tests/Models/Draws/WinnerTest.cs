using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class WinnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Winner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        string expectedAuthorUsername = "authorUsername";
        bool expectedIsBackup = true;
        long expectedPosition = 0;
        string expectedTweetID = "tweetId";

        Assert.Equal(expectedAuthorUsername, model.AuthorUsername);
        Assert.Equal(expectedIsBackup, model.IsBackup);
        Assert.Equal(expectedPosition, model.Position);
        Assert.Equal(expectedTweetID, model.TweetID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Winner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Winner>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Winner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Winner>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAuthorUsername = "authorUsername";
        bool expectedIsBackup = true;
        long expectedPosition = 0;
        string expectedTweetID = "tweetId";

        Assert.Equal(expectedAuthorUsername, deserialized.AuthorUsername);
        Assert.Equal(expectedIsBackup, deserialized.IsBackup);
        Assert.Equal(expectedPosition, deserialized.Position);
        Assert.Equal(expectedTweetID, deserialized.TweetID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Winner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Winner
        {
            AuthorUsername = "authorUsername",
            IsBackup = true,
            Position = 0,
            TweetID = "tweetId",
        };

        Winner copied = new(model);

        Assert.Equal(model, copied);
    }
}
