using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",
            CreatedAt = "createdAt",
            Description = "description",
            Followers = 0,
            Following = 0,
            Location = "location",
            ProfilePicture = "profilePicture",
            StatusesCount = 0,
            Verified = true,
        };

        string expectedID = "id";
        string expectedName = "name";
        string expectedUsername = "username";
        string expectedCreatedAt = "createdAt";
        string expectedDescription = "description";
        long expectedFollowers = 0;
        long expectedFollowing = 0;
        string expectedLocation = "location";
        string expectedProfilePicture = "profilePicture";
        long expectedStatusesCount = 0;
        bool expectedVerified = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedFollowing, model.Following);
        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedProfilePicture, model.ProfilePicture);
        Assert.Equal(expectedStatusesCount, model.StatusesCount);
        Assert.Equal(expectedVerified, model.Verified);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",
            CreatedAt = "createdAt",
            Description = "description",
            Followers = 0,
            Following = 0,
            Location = "location",
            ProfilePicture = "profilePicture",
            StatusesCount = 0,
            Verified = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",
            CreatedAt = "createdAt",
            Description = "description",
            Followers = 0,
            Following = 0,
            Location = "location",
            ProfilePicture = "profilePicture",
            StatusesCount = 0,
            Verified = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        string expectedUsername = "username";
        string expectedCreatedAt = "createdAt";
        string expectedDescription = "description";
        long expectedFollowers = 0;
        long expectedFollowing = 0;
        string expectedLocation = "location";
        string expectedProfilePicture = "profilePicture";
        long expectedStatusesCount = 0;
        bool expectedVerified = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedFollowing, deserialized.Following);
        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedProfilePicture, deserialized.ProfilePicture);
        Assert.Equal(expectedStatusesCount, deserialized.StatusesCount);
        Assert.Equal(expectedVerified, deserialized.Verified);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",
            CreatedAt = "createdAt",
            Description = "description",
            Followers = 0,
            Following = 0,
            Location = "location",
            ProfilePicture = "profilePicture",
            StatusesCount = 0,
            Verified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Following);
        Assert.False(model.RawData.ContainsKey("following"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
        Assert.Null(model.StatusesCount);
        Assert.False(model.RawData.ContainsKey("statusesCount"));
        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Description = null,
            Followers = null,
            Following = null,
            Location = null,
            ProfilePicture = null,
            StatusesCount = null,
            Verified = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Following);
        Assert.False(model.RawData.ContainsKey("following"));
        Assert.Null(model.Location);
        Assert.False(model.RawData.ContainsKey("location"));
        Assert.Null(model.ProfilePicture);
        Assert.False(model.RawData.ContainsKey("profilePicture"));
        Assert.Null(model.StatusesCount);
        Assert.False(model.RawData.ContainsKey("statusesCount"));
        Assert.Null(model.Verified);
        Assert.False(model.RawData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Description = null,
            Followers = null,
            Following = null,
            Location = null,
            ProfilePicture = null,
            StatusesCount = null,
            Verified = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserProfile
        {
            ID = "id",
            Name = "name",
            Username = "username",
            CreatedAt = "createdAt",
            Description = "description",
            Followers = 0,
            Following = 0,
            Location = "location",
            ProfilePicture = "profilePicture",
            StatusesCount = 0,
            Verified = true,
        };

        UserProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
