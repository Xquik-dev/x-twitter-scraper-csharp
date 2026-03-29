using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Bot.PlatformLinks;

namespace XTwitterScraper.Tests.Models.Bot.PlatformLinks;

public class PlatformLinkLookupResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlatformLinkLookupResponse { UserID = "userId" };

        string expectedUserID = "userId";

        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlatformLinkLookupResponse { UserID = "userId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlatformLinkLookupResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlatformLinkLookupResponse { UserID = "userId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlatformLinkLookupResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUserID = "userId";

        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlatformLinkLookupResponse { UserID = "userId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlatformLinkLookupResponse { UserID = "userId" };

        PlatformLinkLookupResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
