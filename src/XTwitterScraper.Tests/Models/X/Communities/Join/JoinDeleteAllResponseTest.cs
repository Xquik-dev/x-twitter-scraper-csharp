using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities.Join;

namespace XTwitterScraper.Tests.Models.X.Communities.Join;

public class JoinDeleteAllResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JoinDeleteAllResponse
        {
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        string expectedCommunityID = "communityId";
        string expectedCommunityName = "communityName";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.Equal(expectedCommunityID, model.CommunityID);
        Assert.Equal(expectedCommunityName, model.CommunityName);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JoinDeleteAllResponse
        {
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinDeleteAllResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JoinDeleteAllResponse
        {
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JoinDeleteAllResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCommunityID = "communityId";
        string expectedCommunityName = "communityName";
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.Equal(expectedCommunityID, deserialized.CommunityID);
        Assert.Equal(expectedCommunityName, deserialized.CommunityName);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JoinDeleteAllResponse
        {
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JoinDeleteAllResponse
        {
            CommunityID = "communityId",
            CommunityName = "communityName",
        };

        JoinDeleteAllResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
