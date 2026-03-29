using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Tweets;

namespace XTwitterScraper.Tests.Models.X.Tweets;

public class TweetGetRetweetersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TweetGetRetweetersResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";
        List<JsonElement> expectedUsers = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedHasNextPage, model.HasNextPage);
        Assert.Equal(expectedNextCursor, model.NextCursor);
        Assert.Equal(expectedUsers.Count, model.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedUsers[i], model.Users[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TweetGetRetweetersResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetGetRetweetersResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TweetGetRetweetersResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TweetGetRetweetersResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasNextPage = true;
        string expectedNextCursor = "next_cursor";
        List<JsonElement> expectedUsers = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedHasNextPage, deserialized.HasNextPage);
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
        Assert.Equal(expectedUsers.Count, deserialized.Users.Count);
        for (int i = 0; i < expectedUsers.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedUsers[i], deserialized.Users[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TweetGetRetweetersResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TweetGetRetweetersResponse
        {
            HasNextPage = true,
            NextCursor = "next_cursor",
            Users = [JsonSerializer.Deserialize<JsonElement>("{}")],
        };

        TweetGetRetweetersResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
