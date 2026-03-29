using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.Account;

namespace XTwitterScraper.Tests.Models.Account;

public class AccountSetXUsernameResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountSetXUsernameResponse { XUsername = "xUsername" };

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedXUsername = "xUsername";

        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountSetXUsernameResponse { XUsername = "xUsername" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountSetXUsernameResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountSetXUsernameResponse { XUsername = "xUsername" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountSetXUsernameResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedXUsername = "xUsername";

        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountSetXUsernameResponse { XUsername = "xUsername" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountSetXUsernameResponse { XUsername = "xUsername" };

        AccountSetXUsernameResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
