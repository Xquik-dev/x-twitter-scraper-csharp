using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountReauthResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "id",
            Status = "status",
            XUsername = "xUsername",
        };

        string expectedID = "id";
        string expectedStatus = "status";
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "id",
            Status = "status",
            XUsername = "xUsername",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountReauthResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "id",
            Status = "status",
            XUsername = "xUsername",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountReauthResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedStatus = "status";
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "id",
            Status = "status",
            XUsername = "xUsername",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountReauthResponse
        {
            ID = "id",
            Status = "status",
            XUsername = "xUsername",
        };

        AccountReauthResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
