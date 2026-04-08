using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Followers;

namespace XTwitterScraper.Tests.Models.X.Followers;

public class FollowerCheckResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FollowerCheckResponse
        {
            IsFollowedBy = false,
            IsFollowing = true,
            SourceUsername = "elonmusk",
            TargetUsername = "jack",
        };

        bool expectedIsFollowedBy = false;
        bool expectedIsFollowing = true;
        string expectedSourceUsername = "elonmusk";
        string expectedTargetUsername = "jack";

        Assert.Equal(expectedIsFollowedBy, model.IsFollowedBy);
        Assert.Equal(expectedIsFollowing, model.IsFollowing);
        Assert.Equal(expectedSourceUsername, model.SourceUsername);
        Assert.Equal(expectedTargetUsername, model.TargetUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FollowerCheckResponse
        {
            IsFollowedBy = false,
            IsFollowing = true,
            SourceUsername = "elonmusk",
            TargetUsername = "jack",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FollowerCheckResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FollowerCheckResponse
        {
            IsFollowedBy = false,
            IsFollowing = true,
            SourceUsername = "elonmusk",
            TargetUsername = "jack",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FollowerCheckResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsFollowedBy = false;
        bool expectedIsFollowing = true;
        string expectedSourceUsername = "elonmusk";
        string expectedTargetUsername = "jack";

        Assert.Equal(expectedIsFollowedBy, deserialized.IsFollowedBy);
        Assert.Equal(expectedIsFollowing, deserialized.IsFollowing);
        Assert.Equal(expectedSourceUsername, deserialized.SourceUsername);
        Assert.Equal(expectedTargetUsername, deserialized.TargetUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FollowerCheckResponse
        {
            IsFollowedBy = false,
            IsFollowing = true,
            SourceUsername = "elonmusk",
            TargetUsername = "jack",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FollowerCheckResponse
        {
            IsFollowedBy = false,
            IsFollowing = true,
            SourceUsername = "elonmusk",
            TargetUsername = "jack",
        };

        FollowerCheckResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
