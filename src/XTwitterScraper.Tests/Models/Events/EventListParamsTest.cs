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
            After = "after",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        string expectedAfter = "after";
        ApiEnum<string, EventType> expectedEventType = EventType.TweetNew;
        long expectedLimit = 1;
        string expectedMonitorID = "monitorId";

        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMonitorID, parameters.MonitorID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventListParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
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
            After = null,
            EventType = null,
            Limit = null,
            MonitorID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
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
            After = "after",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://xquik.com/api/v1/events?after=after&eventType=tweet.new&limit=1&monitorId=monitorId"
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
            After = "after",
            EventType = EventType.TweetNew,
            Limit = 1,
            MonitorID = "monitorId",
        };

        EventListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
