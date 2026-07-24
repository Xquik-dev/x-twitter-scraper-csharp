// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using XTwitterScraper.Models.Credits;

namespace XTwitterScraper.Tests.Models.Credits;

public class CreditRedirectTopupCheckoutParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditRedirectTopupCheckoutParams { SessionID = "session_id" };

        string expectedSessionID = "session_id";

        Assert.Equal(expectedSessionID, parameters.SessionID);
    }

    [Fact]
    public void Url_Works()
    {
        CreditRedirectTopupCheckoutParams parameters = new() { SessionID = "session_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/credits/topup/redirect?session_id=session_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditRedirectTopupCheckoutParams { SessionID = "session_id" };

        CreditRedirectTopupCheckoutParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
