// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models.X.Lists;

namespace XTwitterScraper.Tests.Core;

public class ParamsBaseTest
{
    const string EveryKind = """
        {
          "null": null,
          "text": "abc",
          "number": 12,
          "yes": true,
          "no": false,
          "nested": { "inner": "x", "deep": { "leaf": true } },
          "list": [null, true, false, "s"]
        }
        """;

    static ListRetrieveTweetsParams Parameters(string headers, string query) =>
        ListRetrieveTweetsParams.FromRawUnchecked(
            JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(headers)!,
            JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(query)!,
            "list-id"
        );

    static string HeaderText(HttpRequestMessage request, string name) =>
        request.Headers.TryGetValues(name, out var values) ? string.Join(",", values) : "";

    [Fact]
    public void QueryEncodesEveryJsonKind()
    {
        ClientOptions options = new() { BaseUrl = "https://example.test" };
        using var optionsHttpClient = options.HttpClient;

        var url = Parameters("{}", EveryKind).Url(options);
        var pairs = url
            .Query.TrimStart('?')
            .Split('&')
            .Select(pair => pair.Split('='))
            .ToDictionary(
                pair => Uri.UnescapeDataString(pair[0]),
                pair => Uri.UnescapeDataString(pair[1])
            );

        Assert.Equal("/x/lists/list-id/tweets", url.AbsolutePath);
        Assert.Equal(
            new Dictionary<string, string>
            {
                ["null"] = "",
                ["text"] = "abc",
                ["number"] = "12",
                ["yes"] = "true",
                ["no"] = "false",
                ["nested[inner]"] = "x",
                ["nested[deep][leaf]"] = "true",
                ["list"] = ",true,false,s",
            },
            pairs
        );
    }

    [Fact]
    public void EmptyQueryLeavesTheUrlBare()
    {
        ClientOptions options = new() { BaseUrl = "https://example.test/" };
        using var optionsHttpClient = options.HttpClient;

        var url = Parameters("{}", "{}").Url(options);

        Assert.Equal("", url.Query);
        Assert.Equal(
            "https://example.test/x/lists/list-id/tweets",
            url.GetLeftPart(UriPartial.Path)
        );
    }

    [Fact]
    public void HeadersEncodeEveryJsonKind()
    {
        ClientOptions options = new()
        {
            BaseUrl = "https://example.test",
            ApiKey = "test-api-key",
            BearerToken = "test-bearer-token",
        };
        using var optionsHttpClient = options.HttpClient;
        using var request = new HttpRequestMessage();

        Parameters(
                """
                {
                  "x-null": null,
                  "x-text": "abc",
                  "x-number": 12,
                  "x-yes": true,
                  "x-no": false,
                  "x-nested": { "inner": "x", "deep": { "leaf": false } },
                  "x-list": [true, false, "s"]
                }
                """,
                "{}"
            )
            .AddHeadersToRequest(request, options);

        Assert.Equal("", HeaderText(request, "x-null"));
        Assert.Equal("abc", HeaderText(request, "x-text"));
        Assert.Equal("12", HeaderText(request, "x-number"));
        Assert.Equal("true", HeaderText(request, "x-yes"));
        Assert.Equal("false", HeaderText(request, "x-no"));
        Assert.Equal("x", HeaderText(request, "x-nested.inner"));
        Assert.Equal("false", HeaderText(request, "x-nested.deep.leaf"));
        Assert.Equal("true,false,s", HeaderText(request, "x-list"));
        Assert.Equal("test-api-key", HeaderText(request, "x-api-key"));
        Assert.Equal("Bearer test-bearer-token", HeaderText(request, "Authorization"));
    }

    [Fact]
    public void MissingCredentialsSendNoAuthHeaders()
    {
        ClientOptions options = new()
        {
            BaseUrl = "https://example.test",
            ApiKey = null,
            BearerToken = null,
            Timeout = TimeSpan.FromSeconds(5),
        };
        using var optionsHttpClient = options.HttpClient;
        using var request = new HttpRequestMessage();

        Parameters("{}", "{}").AddHeadersToRequest(request, options);

        Assert.False(request.Headers.Contains("x-api-key"));
        Assert.False(request.Headers.Contains("Authorization"));
        Assert.Equal("5", HeaderText(request, "X-Stainless-Timeout"));
        Assert.True(request.Headers.Contains("X-Stainless-Lang"));
    }
}
