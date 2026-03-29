using System;
using XTwitterScraper.Models.Drafts;

namespace XTwitterScraper.Tests.Models.Drafts;

public class DraftRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DraftRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DraftRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/drafts/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DraftRetrieveParams { ID = "id" };

        DraftRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
