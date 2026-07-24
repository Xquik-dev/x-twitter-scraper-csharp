// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Events;

namespace XTwitterScraper.Tests.Models.Events;

public class EventListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventListParams
        {
            Cursor = "cursor",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        string expectedCursor = "cursor";
        ApiEnum<string, EventType> expectedEventType = EventType.TweetNew;
        long expectedLimit = 1;
        string expectedMonitorID = "monitorId";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMonitorID, parameters.MonitorID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("eventType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MonitorID);
        Assert.False(parameters.RawQueryData.ContainsKey("monitorId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            EventType = null,
            Limit = null,
            MonitorID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("eventType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MonitorID);
        Assert.False(parameters.RawQueryData.ContainsKey("monitorId"));
    }

    [Fact]
    public void Url_Works()
    {
        EventListParams parameters = new()
        {
            Cursor = "cursor",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/events?cursor=cursor&eventType=tweet.new&limit=1&monitorId=monitorId"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventListParams
        {
            Cursor = "cursor",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        EventListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
