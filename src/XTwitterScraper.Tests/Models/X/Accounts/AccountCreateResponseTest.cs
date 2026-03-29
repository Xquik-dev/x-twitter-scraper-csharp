using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        string expectedID = "id";
        string expectedStatus = "status";
        string expectedXUserID = "xUserId";
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedXUserID, model.XUserID);
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedStatus = "status";
        string expectedXUserID = "xUserId";
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedXUserID, deserialized.XUserID);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountCreateResponse
        {
            ID = "id",
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        AccountCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
