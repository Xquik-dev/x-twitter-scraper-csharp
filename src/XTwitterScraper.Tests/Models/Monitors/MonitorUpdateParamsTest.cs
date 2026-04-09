using System;
using System.Collections.Generic;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Monitors;

namespace XTwitterScraper.Tests.Models.Monitors;

public class MonitorUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MonitorUpdateParams
        {
            ID = "id",
            EventTypes = [EventType.TweetNew],
            IsActive = true,
        };

        string expectedID = "id";
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        bool expectedIsActive = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedIsActive, parameters.IsActive);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MonitorUpdateParams { ID = "id" };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MonitorUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
            IsActive = null,
        };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
    }

    [Fact]
    public void Url_Works()
    {
        MonitorUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/monitors/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MonitorUpdateParams
        {
            ID = "id",
            EventTypes = [EventType.TweetNew],
            IsActive = true,
        };

        MonitorUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
