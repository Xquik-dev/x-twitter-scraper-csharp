using System;
using XTwitterScraper.Models.Extractions;

namespace XTwitterScraper.Tests.Models.Extractions;

public class ExtractionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExtractionRetrieveParams
        {
            ID = "id",
            After = "after",
            Limit = 1,
        };

        string expectedID = "id";
        string expectedAfter = "after";
        long expectedLimit = 1;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExtractionRetrieveParams { ID = "id" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExtractionRetrieveParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            After = null,
            Limit = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ExtractionRetrieveParams parameters = new()
        {
            ID = "id",
            After = "after",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(new Uri("https://xquik.com/api/v1/extractions/id?after=after&limit=1"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractionRetrieveParams
        {
            ID = "id",
            After = "after",
            Limit = 1,
        };

        ExtractionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
