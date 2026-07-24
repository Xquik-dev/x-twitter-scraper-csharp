// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using XTwitterScraper.Models.X.Users;

namespace XTwitterScraper.Tests.Models.X.Users;

public class UserRetrieveFollowersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveFollowersParams
        {
            ID = "id",
            After = "after",
            Cursor = "cursor",
            Limit = 0,
            PageSize = 20,
        };

        string expectedID = "id";
        string expectedAfter = "after";
        string expectedCursor = "cursor";
        long expectedLimit = 0;
        long expectedPageSize = 20;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPageSize, parameters.PageSize);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserRetrieveFollowersParams { ID = "id" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserRetrieveFollowersParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            After = null,
            Cursor = null,
            Limit = null,
            PageSize = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("pageSize"));
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveFollowersParams parameters = new()
        {
            ID = "id",
            After = "after",
            Cursor = "cursor",
            Limit = 0,
            PageSize = 20,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/x/users/id/followers?after=after&cursor=cursor&limit=0&pageSize=20"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveFollowersParams
        {
            ID = "id",
            After = "after",
            Cursor = "cursor",
            Limit = 0,
            PageSize = 20,
        };

        UserRetrieveFollowersParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
