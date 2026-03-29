using System;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DrawRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DrawRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/draws/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DrawRetrieveParams { ID = "id" };

        DrawRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
