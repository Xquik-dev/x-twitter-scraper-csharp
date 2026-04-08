using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityRetrieveModeratorsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CommunityRetrieveModeratorsResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
                {
                    ID = "9876543210",
                    Name = "Elon Musk",
                    Username = "elonmusk",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    Description = "CEO of Tesla, SpaceX, and X",
                    Followers = 150000000,
                    Following = 500,
                    Location = "Austin, TX",
                    ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
                    StatusesCount = 35000,
                    Verified = true,
                },
            ],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<CommunityRetrieveModeratorsResponseUser> expectedUsers =
        [
            new()
            {
                ID = "9876543210",
                Name = "Elon Musk",
                Username = "elonmusk",
                CreatedAt = "2009-06-02T20:12:29Z",
                Description = "CEO of Tesla, SpaceX, and X",
                Followers = 150000000,
                Following = 500,
                Location = "Austin, TX",
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
                StatusesCount = 35000,
                Verified = true,
            },
        ];

        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedUsers.Count, model.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], model.Users[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CommunityRetrieveModeratorsResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
                {
                    ID = "9876543210",
                    Name = "Elon Musk",
                    Username = "elonmusk",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    Description = "CEO of Tesla, SpaceX, and X",
                    Followers = 150000000,
                    Following = 500,
                    Location = "Austin, TX",
                    ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
                    StatusesCount = 35000,
                    Verified = true,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityRetrieveModeratorsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CommunityRetrieveModeratorsResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
                {
                    ID = "9876543210",
                    Name = "Elon Musk",
                    Username = "elonmusk",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    Description = "CEO of Tesla, SpaceX, and X",
                    Followers = 150000000,
                    Following = 500,
                    Location = "Austin, TX",
                    ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
                    StatusesCount = 35000,
                    Verified = true,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityRetrieveModeratorsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<CommunityRetrieveModeratorsResponseUser> expectedUsers =
        [
            new()
            {
                ID = "9876543210",
                Name = "Elon Musk",
                Username = "elonmusk",
                CreatedAt = "2009-06-02T20:12:29Z",
                Description = "CEO of Tesla, SpaceX, and X",
                Followers = 150000000,
                Following = 500,
                Location = "Austin, TX",
                ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
                StatusesCount = 35000,
                Verified = true,
            },
        ];

        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedUsers.Count, deserialized.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.Equal(expectedUsers[i], deserialized.Users[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CommunityRetrieveModeratorsResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
                {
                    ID = "9876543210",
                    Name = "Elon Musk",
                    Username = "elonmusk",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    Description = "CEO of Tesla, SpaceX, and X",
                    Followers = 150000000,
                    Following = 500,
                    Location = "Austin, TX",
                    ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
                    StatusesCount = 35000,
                    Verified = true,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CommunityRetrieveModeratorsResponse
        {
            HasNextPage = true,
            NextCursor = "DAACCgACGRElMJcAAA",
            Users =
            [
                new()
                {
                    ID = "9876543210",
                    Name = "Elon Musk",
                    Username = "elonmusk",
                    CreatedAt = "2009-06-02T20:12:29Z",
                    Description = "CEO of Tesla, SpaceX, and X",
                    Followers = 150000000,
                    Following = 500,
                    Location = "Austin, TX",
                    ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
                    StatusesCount = 35000,
                    Verified = true,
                },
            ],
        };

        CommunityRetrieveModeratorsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CommunityRetrieveModeratorsResponseUserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            Followers = 150000000,
            Following = 500,
            Location = "Austin, TX",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            StatusesCount = 35000,
            Verified = true,
        };

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        string expectedCreatedAt = "2009-06-02T20:12:29Z";
        string expectedDescription = "CEO of Tesla, SpaceX, and X";
        long expectedFollowers = 150000000;
        long expectedFollowing = 500;
        string expectedLocation = "Austin, TX";
        string expectedProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg";
        long expectedStatusesCount = 35000;
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
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            Followers = 150000000,
            Following = 500,
            Location = "Austin, TX",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            StatusesCount = 35000,
            Verified = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityRetrieveModeratorsResponseUser>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            Followers = 150000000,
            Following = 500,
            Location = "Austin, TX",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            StatusesCount = 35000,
            Verified = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityRetrieveModeratorsResponseUser>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "9876543210";
        string expectedName = "Elon Musk";
        string expectedUsername = "elonmusk";
        string expectedCreatedAt = "2009-06-02T20:12:29Z";
        string expectedDescription = "CEO of Tesla, SpaceX, and X";
        long expectedFollowers = 150000000;
        long expectedFollowing = 500;
        string expectedLocation = "Austin, TX";
        string expectedProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg";
        long expectedStatusesCount = 35000;
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
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            Followers = 150000000,
            Following = 500,
            Location = "Austin, TX",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            StatusesCount = 35000,
            Verified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
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
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

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
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",

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
        var model = new CommunityRetrieveModeratorsResponseUser
        {
            ID = "9876543210",
            Name = "Elon Musk",
            Username = "elonmusk",
            CreatedAt = "2009-06-02T20:12:29Z",
            Description = "CEO of Tesla, SpaceX, and X",
            Followers = 150000000,
            Following = 500,
            Location = "Austin, TX",
            ProfilePicture = "https://pbs.twimg.com/profile_images/example.jpg",
            StatusesCount = 35000,
            Verified = true,
        };

        CommunityRetrieveModeratorsResponseUser copied = new(model);

        Assert.Equal(model, copied);
    }
}
