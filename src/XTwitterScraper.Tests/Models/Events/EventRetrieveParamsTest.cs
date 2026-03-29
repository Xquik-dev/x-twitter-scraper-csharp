using System;
using XTwitterScraper.Models.Events;

namespace XTwitterScraper.Tests.Models.Events;

public class EventRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        EventRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/events/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventRetrieveParams { ID = "id" };

        EventRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
