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
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        string expectedID = "id";
        long expectedFollowers = 0;
        string expectedUsername = "username";
        bool expectedVerified = true;
        string expectedProfilePicture = "profilePicture";

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
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
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
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetAuthor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedFollowers = 0;
        string expectedUsername = "username";
        bool expectedVerified = true;
        string expectedProfilePicture = "profilePicture";

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
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TweetAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
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
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TweetAuthor
        {
            ID = "id",
            Followers = 0,
            Username = "username",
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
            ID = "id",
            Followers = 0,
            Username = "username",
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
            ID = "id",
            Followers = 0,
            Username = "username",
            Verified = true,
            ProfilePicture = "profilePicture",
        };

        TweetAuthor copied = new(model);

        Assert.Equal(model, copied);
    }
}
