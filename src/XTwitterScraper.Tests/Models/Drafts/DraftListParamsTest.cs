using System;
using XTwitterScraper.Models.Drafts;

namespace XTwitterScraper.Tests.Models.Drafts;

public class DraftListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DraftListParams { AfterCursor = "afterCursor", Limit = 1 };

        string expectedAfterCursor = "afterCursor";
        long expectedLimit = 1;

        Assert.Equal(expectedAfterCursor, parameters.AfterCursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DraftListParams { };

        Assert.Null(parameters.AfterCursor);
        Assert.False(parameters.RawQueryData.ContainsKey("afterCursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DraftListParams
        {
            // Null should be interpreted as omitted for these properties
            AfterCursor = null,
            Limit = null,
        };

        Assert.Null(parameters.AfterCursor);
        Assert.False(parameters.RawQueryData.ContainsKey("afterCursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        DraftListParams parameters = new() { AfterCursor = "afterCursor", Limit = 1 };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.Equal(
            new Uri("https://xquik.com/api/v1/drafts?afterCursor=afterCursor&limit=1"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DraftListParams { AfterCursor = "afterCursor", Limit = 1 };

        DraftListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
