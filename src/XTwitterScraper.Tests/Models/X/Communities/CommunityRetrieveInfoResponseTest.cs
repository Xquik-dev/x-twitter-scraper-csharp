using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Communities;

namespace XTwitterScraper.Tests.Models.X.Communities;

public class CommunityRetrieveInfoResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        JsonElement expectedCommunity = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.True(JsonElement.DeepEquals(expectedCommunity, model.Community));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityRetrieveInfoResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CommunityRetrieveInfoResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedCommunity = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.True(JsonElement.DeepEquals(expectedCommunity, deserialized.Community));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CommunityRetrieveInfoResponse
        {
            Community = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        CommunityRetrieveInfoResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
