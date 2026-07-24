// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DrawListParams { Cursor = "cursor", Limit = 1 };

        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DrawListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DrawListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        DrawListParams parameters = new() { Cursor = "cursor", Limit = 1 };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/draws?cursor=cursor&limit=1"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DrawListParams { Cursor = "cursor", Limit = 1 };

        DrawListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
