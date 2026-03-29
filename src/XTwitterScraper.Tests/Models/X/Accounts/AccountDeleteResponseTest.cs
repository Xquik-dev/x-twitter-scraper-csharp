using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountDeleteResponse { };

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountDeleteResponse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountDeleteResponse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);

        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountDeleteResponse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountDeleteResponse { };

        AccountDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
