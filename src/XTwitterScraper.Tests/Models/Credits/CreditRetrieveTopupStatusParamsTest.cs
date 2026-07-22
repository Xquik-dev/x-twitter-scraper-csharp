using System;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Tests.Models.Credits;

public class CreditRetrieveTopupStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditRetrieveTopupStatusParams { SessionID = "session_id" };

        string expectedSessionID = "session_id";

        Assert.Equal(expectedSessionID, parameters.SessionID);
    }

    [Fact]
    public void Url_Works()
    {
        CreditRetrieveTopupStatusParams parameters = new() { SessionID = "session_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/credits/topup/status?session_id=session_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditRetrieveTopupStatusParams { SessionID = "session_id" };

        CreditRetrieveTopupStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
