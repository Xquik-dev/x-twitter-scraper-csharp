using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetAuthorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
        };

        string expectedID = "9876543210";
        long expectedFollowers = 150000000;
        string expectedUsername = "elonmusk";
        bool expectedVerified = true;
        string expectedProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedVerified, model.Verified);
        Assert.Equal(expectedProfilePicture, model.ProfilePicture);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetAuthor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetAuthor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        long expectedFollowers = 150000000;
        string expectedUsername = "elonmusk";
        bool expectedVerified = true;
        string expectedProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedVerified, deserialized.Verified);
        Assert.Equal(expectedProfilePicture, deserialized.ProfilePicture);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
        };

        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,

            // Null should be interpreted as omitted for these properties
            ProfilePicture = null,
        };

        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,

            // Null should be interpreted as omitted for these properties
            ProfilePicture = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetAuthor
        {
            ID = "9876543210",
            Followers = 150000000,
            Username = "elonmusk",
            Verified = true,
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
        };

        TweetAuthor copied = new(model);

        Assert.Equal(model, copied);
    }
}
