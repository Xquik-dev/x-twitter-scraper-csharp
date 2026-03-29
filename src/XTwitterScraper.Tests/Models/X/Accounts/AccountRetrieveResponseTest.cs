using System;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
            CookiesObtainedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProxyCountry = "proxyCountry",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        string expectedXUserID = "xUserId";
        string expectedXUsername = "xUsername";
        DateTimeOffset expectedCookiesObtainedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProxyCountry = "proxyCountry";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedXUserID, model.XUserID);
        Assert.Equal(expectedXUsername, model.XUsername);
        Assert.Equal(expectedCookiesObtainedAt, model.CookiesObtainedAt);
        Assert.Equal(expectedProxyCountry, model.ProxyCountry);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
            CookiesObtainedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProxyCountry = "proxyCountry",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
            CookiesObtainedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProxyCountry = "proxyCountry",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        string expectedXUserID = "xUserId";
        string expectedXUsername = "xUsername";
        DateTimeOffset expectedCookiesObtainedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedProxyCountry = "proxyCountry";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedXUserID, deserialized.XUserID);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
        Assert.Equal(expectedCookiesObtainedAt, deserialized.CookiesObtainedAt);
        Assert.Equal(expectedProxyCountry, deserialized.ProxyCountry);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
            CookiesObtainedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProxyCountry = "proxyCountry",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        Assert.Null(model.CookiesObtainedAt);
        Assert.False(model.RawData.ContainsKey("cookiesObtainedAt"));
        Assert.Null(model.ProxyCountry);
        Assert.False(model.RawData.ContainsKey("proxyCountry"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",

            // Null should be interpreted as omitted for these properties
            CookiesObtainedAt = null,
            ProxyCountry = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CookiesObtainedAt);
        Assert.False(model.RawData.ContainsKey("cookiesObtainedAt"));
        Assert.Null(model.ProxyCountry);
        Assert.False(model.RawData.ContainsKey("proxyCountry"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",

            // Null should be interpreted as omitted for these properties
            CookiesObtainedAt = null,
            ProxyCountry = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountRetrieveResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
            CookiesObtainedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProxyCountry = "proxyCountry",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        AccountRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
