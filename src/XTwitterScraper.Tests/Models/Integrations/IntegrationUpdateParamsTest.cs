using System;
using System.Collections.Generic;
using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Integrations;

namespace XTwitterScraper.Tests.Models.Integrations;

public class IntegrationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationUpdateParams
        {
            ID = "id",
            EventTypes = [EventType.TweetNew],
            Filters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsActive = true,
            MessageTemplate = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ScopeAllMonitors = true,
            SilentPush = true,
        };

        string expectedID = "id";
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.TweetNew];
        Dictionary<string, JsonElement> expectedFilters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedIsActive = true;
        Dictionary<string, JsonElement> expectedMessageTemplate = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        bool expectedScopeAllMonitors = true;
        bool expectedSilentPush = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.NotNull(parameters.Filters);
        Assert.Equal(expectedFilters.Count, parameters.Filters.Count);
        foreach (var item in expectedFilters)
        {
            Assert.True(parameters.Filters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Filters[item.Key]));
        }
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.NotNull(parameters.MessageTemplate);
        Assert.Equal(expectedMessageTemplate.Count, parameters.MessageTemplate.Count);
        foreach (var item in expectedMessageTemplate)
        {
            Assert.True(parameters.MessageTemplate.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.MessageTemplate[item.Key]));
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedScopeAllMonitors, parameters.ScopeAllMonitors);
        Assert.Equal(expectedSilentPush, parameters.SilentPush);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntegrationUpdateParams { ID = "id" };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.Filters);
        Assert.False(parameters.RawBodyData.ContainsKey("filters"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
        Assert.Null(parameters.MessageTemplate);
        Assert.False(parameters.RawBodyData.ContainsKey("messageTemplate"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.ScopeAllMonitors);
        Assert.False(parameters.RawBodyData.ContainsKey("scopeAllMonitors"));
        Assert.Null(parameters.SilentPush);
        Assert.False(parameters.RawBodyData.ContainsKey("silentPush"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IntegrationUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            EventTypes = null,
            Filters = null,
            IsActive = null,
            MessageTemplate = null,
            Name = null,
            ScopeAllMonitors = null,
            SilentPush = null,
        };

        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.Filters);
        Assert.False(parameters.RawBodyData.ContainsKey("filters"));
        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("isActive"));
        Assert.Null(parameters.MessageTemplate);
        Assert.False(parameters.RawBodyData.ContainsKey("messageTemplate"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.ScopeAllMonitors);
        Assert.False(parameters.RawBodyData.ContainsKey("scopeAllMonitors"));
        Assert.Null(parameters.SilentPush);
        Assert.False(parameters.RawBodyData.ContainsKey("silentPush"));
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/integrations/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntegrationUpdateParams
        {
            ID = "id",
            EventTypes = [EventType.TweetNew],
            Filters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IsActive = true,
            MessageTemplate = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ScopeAllMonitors = true,
            SilentPush = true,
        };

        IntegrationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
