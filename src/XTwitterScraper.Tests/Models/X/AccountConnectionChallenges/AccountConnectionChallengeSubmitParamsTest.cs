// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using XTwitterScraper.Models.X.AccountConnectionChallenges;

namespace XTwitterScraper.Tests.Models.X.AccountConnectionChallenges;

public class AccountConnectionChallengeSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountConnectionChallengeSubmitParams
        {
            ID = "id",
            EmailCode = "<EMAIL_VERIFICATION_CODE>",
        };

        string expectedID = "id";
        string expectedEmailCode = "<EMAIL_VERIFICATION_CODE>";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEmailCode, parameters.EmailCode);
    }

    [Fact]
    public void Url_Works()
    {
        AccountConnectionChallengeSubmitParams parameters = new()
        {
            ID = "id",
            EmailCode = "<EMAIL_VERIFICATION_CODE>",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://xquik.com/api/v1/x/account-connection-challenges/id/submit"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountConnectionChallengeSubmitParams
        {
            ID = "id",
            EmailCode = "<EMAIL_VERIFICATION_CODE>",
        };

        AccountConnectionChallengeSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
