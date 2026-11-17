// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.X.AccountConnectionLinks;

namespace XTwitterScraper.Tests.Models.X.AccountConnectionLinks;

public class AccountConnectionLinkApiKeyTest
{
    const string Fields =
        "\"object\":\"x_account_connection_link\",\"id\":\"xlink_AAAAAAAAAAAAAAAA\","
        + "\"purpose\":\"connect\",\"status\":\"pending\",\"reference\":null,"
        + "\"returnUrl\":null,\"accountId\":null,\"xUserId\":null,\"xUsername\":null,"
        + "\"health\":null,\"failure\":null,\"createdAt\":\"2026-11-08T12:00:00Z\","
        + "\"expiresAt\":\"2026-11-08T12:30:00Z\",\"completedAt\":null";

    [Fact]
    public void CreateResponseReadsTheKeyThatMadeTheLink()
    {
        var link = JsonSerializer.Deserialize<AccountConnectionLinkCreateResponse>(
            "{"
                + Fields
                + ",\"apiKeyId\":\"17\","
                + "\"url\":\"https://xquik.com/connect-x#token=CONNECT_LINK_TOKEN\"}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(link);
        link.Validate();
        Assert.Equal("17", link.ApiKeyID);
    }

    [Fact]
    public void ADashboardLinkReadsNull()
    {
        var link = JsonSerializer.Deserialize<XAccountConnectionLink>(
            "{" + Fields + ",\"apiKeyId\":null}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(link);
        link.Validate();
        Assert.True(link.RawData.ContainsKey("apiKeyId"));
        Assert.Null(link.ApiKeyID);
    }

    [Fact]
    public void SettingNullWritesNull()
    {
        var link = JsonSerializer.Deserialize<XAccountConnectionLink>(
            "{" + Fields + ",\"apiKeyId\":\"17\"}",
            ModelBase.SerializerOptions
        );
        Assert.NotNull(link);

        var json = JsonSerializer.SerializeToElement(
            link with { ApiKeyID = null },
            ModelBase.SerializerOptions
        );

        Assert.Equal(JsonValueKind.Null, json.GetProperty("apiKeyId").ValueKind);
    }

    [Fact]
    public void ALinkFromBeforeTheFieldReadsNull()
    {
        var link = JsonSerializer.Deserialize<XAccountConnectionLink>(
            "{" + Fields + "}",
            ModelBase.SerializerOptions
        );

        Assert.NotNull(link);
        link.Validate();
        Assert.Null(link.ApiKeyID);
    }
}
