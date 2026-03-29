using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Accounts;

namespace XTwitterScraper.Tests.Models.X.Accounts;

public class AccountListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    XUserID = "xUserId",
                    XUsername = "xUsername",
                },
            ],
        };

        List<AccountListResponseAccount> expectedAccounts =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                XUserID = "xUserId",
                XUsername = "xUsername",
            },
        ];

        Assert.Equal(expectedAccounts.Count, model.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], model.Accounts[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    XUserID = "xUserId",
                    XUsername = "xUsername",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    XUserID = "xUserId",
                    XUsername = "xUsername",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AccountListResponseAccount> expectedAccounts =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = "status",
                XUserID = "xUserId",
                XUsername = "xUsername",
            },
        ];

        Assert.Equal(expectedAccounts.Count, deserialized.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], deserialized.Accounts[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    XUserID = "xUserId",
                    XUsername = "xUsername",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountListResponse
        {
            Accounts =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = "status",
                    XUserID = "xUserId",
                    XUsername = "xUsername",
                },
            ],
        };

        AccountListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountListResponseAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountListResponseAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        string expectedXUserID = "xUserId";
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedXUserID, model.XUserID);
        Assert.Equal(expectedXUsername, model.XUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountListResponseAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountListResponseAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountListResponseAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountListResponseAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedStatus = "status";
        string expectedXUserID = "xUserId";
        string expectedXUsername = "xUsername";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedXUserID, deserialized.XUserID);
        Assert.Equal(expectedXUsername, deserialized.XUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountListResponseAccount
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
    public void CopyConstructor_Works()
    {
        var model = new AccountListResponseAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = "status",
            XUserID = "xUserId",
            XUsername = "xUsername",
        };

        AccountListResponseAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}
