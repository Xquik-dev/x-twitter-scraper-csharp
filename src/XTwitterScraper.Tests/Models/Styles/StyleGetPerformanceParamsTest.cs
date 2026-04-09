using System;
using XTwitterScraper.Models.Styles;

namespace XTwitterScraper.Tests.Models.Styles;

public class StyleGetPerformanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new StyleGetPerformanceParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        StyleGetPerformanceParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/styles/id/performance"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new StyleGetPerformanceParams { ID = "id" };

        StyleGetPerformanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
