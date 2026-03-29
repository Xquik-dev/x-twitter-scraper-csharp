using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Followers;

namespace XTwitterScraper.Tests.Models.X.Followers;

public class FollowerRetrieveCheckResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FollowerRetrieveCheckResponse
        {
            IsFollowedBy = true,
            IsFollowing = true,
            SourceUsername = "sourceUsername",
            TargetUsername = "targetUsername",
        };

        bool expectedIsFollowedBy = true;
        bool expectedIsFollowing = true;
        string expectedSourceUsername = "sourceUsername";
        string expectedTargetUsername = "targetUsername";

        Assert.Equal(expectedIsFollowedBy, model.IsFollowedBy);
        Assert.Equal(expectedIsFollowing, model.IsFollowing);
        Assert.Equal(expectedSourceUsername, model.SourceUsername);
        Assert.Equal(expectedTargetUsername, model.TargetUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FollowerRetrieveCheckResponse
        {
            IsFollowedBy = true,
            IsFollowing = true,
            SourceUsername = "sourceUsername",
            TargetUsername = "targetUsername",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FollowerRetrieveCheckResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FollowerRetrieveCheckResponse
        {
            IsFollowedBy = true,
            IsFollowing = true,
            SourceUsername = "sourceUsername",
            TargetUsername = "targetUsername",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FollowerRetrieveCheckResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsFollowedBy = true;
        bool expectedIsFollowing = true;
        string expectedSourceUsername = "sourceUsername";
        string expectedTargetUsername = "targetUsername";

        Assert.Equal(expectedIsFollowedBy, deserialized.IsFollowedBy);
        Assert.Equal(expectedIsFollowing, deserialized.IsFollowing);
        Assert.Equal(expectedSourceUsername, deserialized.SourceUsername);
        Assert.Equal(expectedTargetUsername, deserialized.TargetUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FollowerRetrieveCheckResponse
        {
            IsFollowedBy = true,
            IsFollowing = true,
            SourceUsername = "sourceUsername",
            TargetUsername = "targetUsername",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FollowerRetrieveCheckResponse
        {
            IsFollowedBy = true,
            IsFollowing = true,
            SourceUsername = "sourceUsername",
            TargetUsername = "targetUsername",
        };

        FollowerRetrieveCheckResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
