using System;
using System.Collections.Generic;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Monitors.Keywords;

namespace XTwitterScraper.Tests.Models.Monitors.Keywords;

public class KeywordUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KeywordUpdateParams
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
        var parameters = new KeywordUpdateParams { ID = "id" };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new KeywordUpdateParams
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
        KeywordUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/monitors/keywords/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new KeywordUpdateParams
        {
            ID = "id",
            EventTypes = [EventType.TweetNew],
            IsActive = true,
        };

        KeywordUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
