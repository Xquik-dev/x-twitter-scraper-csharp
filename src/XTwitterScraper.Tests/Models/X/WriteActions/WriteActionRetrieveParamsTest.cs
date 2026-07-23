using System;
using XTwitterScraper.Models.X.WriteActions;

namespace XTwitterScraper.Tests.Models.X.WriteActions;

public class WriteActionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WriteActionRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        WriteActionRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/x/write-actions/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WriteActionRetrieveParams { ID = "id" };

        WriteActionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
