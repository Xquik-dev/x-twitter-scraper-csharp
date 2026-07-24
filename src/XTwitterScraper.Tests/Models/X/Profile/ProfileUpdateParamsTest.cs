// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;
using XTwitterScraper.Models.X.Profile;

namespace XTwitterScraper.Tests.Models.X.Profile;

public class ProfileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
            Description = "description_value",
            Location = "location_value",
            Name = "Example Name",
            UrlValue = "https://xquik.com/example",
        };

        string expectedAccount = "@elonmusk";
        string expectedIdempotencyKey = "Idempotency-Key";
        string expectedDescription = "description_value";
        string expectedLocation = "location_value";
        string expectedName = "Example Name";
        string expectedUrlValue = "https://xquik.com/example";

        Assert.Equal(expectedAccount, parameters.Account);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedLocation, parameters.Location);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Location);
        Assert.False(parameters.RawBodyData.ContainsKey("location"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Location = null,
            Name = null,
            UrlValue = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Location);
        Assert.False(parameters.RawBodyData.ContainsKey("location"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void Url_Works()
    {
        ProfileUpdateParams parameters = new()
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/profile"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProfileUpdateParams parameters = new()
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
        };

        parameters.AddHeadersToRequest(
            requestMessage,
            new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" }
        );

        Assert.Equal(["Idempotency-Key"], requestMessage.Headers.GetValues("Idempotency-Key"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProfileUpdateParams
        {
            Account = "@elonmusk",
            IdempotencyKey = "Idempotency-Key",
            Description = "description_value",
            Location = "location_value",
            Name = "Example Name",
            UrlValue = "https://xquik.com/example",
        };

        ProfileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
