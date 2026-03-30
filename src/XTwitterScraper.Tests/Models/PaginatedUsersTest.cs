using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models;

public class PaginatedUsersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users =
            [
                new()
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
                },
            ],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";
        List<UserProfile> expectedUsers =
        [
            new()
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
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaginatedUsers>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaginatedUsers>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";
        List<UserProfile> expectedUsers =
        [
            new()
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
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaginatedUsers
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users =
            [
                new()
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
                },
            ],
        };

        PaginatedUsers copied = new(model);

        Assert.Equal(model, copied);
    }
}
