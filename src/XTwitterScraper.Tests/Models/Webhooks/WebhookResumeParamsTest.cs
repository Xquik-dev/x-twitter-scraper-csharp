// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using XTwitterScraper.Models.Webhooks;

namespace XTwitterScraper.Tests.Models.Webhooks;

public class WebhookResumeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookResumeParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookResumeParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key", BearerToken = "My Bearer Token" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://xquik.com/api/v1/webhooks/id/resume"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookResumeParams { ID = "id" };

        WebhookResumeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
