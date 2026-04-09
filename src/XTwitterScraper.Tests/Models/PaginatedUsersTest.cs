using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class PaginatedUsersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaginatedUsers
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
        List<UserProfile> expectedUsers =
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
        var model = new PaginatedUsers
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
        var deserialized = JsonSerializer.Deserialize<PaginatedUsers>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "DAACCgACGRElMJcAAA";
        List<UserProfile> expectedUsers =
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
        var model = new PaginatedUsers
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
        var model = new PaginatedUsers
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

        PaginatedUsers copied = new(model);

        Assert.Equal(model, copied);
    }
}
