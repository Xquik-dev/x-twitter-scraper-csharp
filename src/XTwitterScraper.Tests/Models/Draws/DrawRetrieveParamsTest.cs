using System;
using XTwitterScraper.Models.Draws;

namespace XTwitterScraper.Tests.Models.Draws;

public class DrawRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DrawRetrieveParams { ID = "f4bd00a2-7b4e-4e59-8e1b-72e2c9f12345" };

        string expectedID = "f4bd00a2-7b4e-4e59-8e1b-72e2c9f12345";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DrawRetrieveParams parameters = new() { ID = "f4bd00a2-7b4e-4e59-8e1b-72e2c9f12345" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/draws/f4bd00a2-7b4e-4e59-8e1b-72e2c9f12345"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DrawRetrieveParams { ID = "f4bd00a2-7b4e-4e59-8e1b-72e2c9f12345" };

        DrawRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
