using System;
using XTwitterScraper.Models.Drafts;

namespace XTwitterScraper.Tests.Models.Drafts;

public class DraftDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DraftDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DraftDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/drafts/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DraftDeleteParams { ID = "id" };

        DraftDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
