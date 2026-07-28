// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using FsCheck;
using FsCheck.Xunit;
using XTwitterScraper.Core;

namespace XTwitterScraper.Tests;

public class RetriesFuzzTest
{
    [Property(MaxTest = 250)]
    public void RetryAfterMillisecondsRoundTrips(NonNegativeInt generated)
    {
        var milliseconds = generated.Get % 60_000;
        using var response = Response();
        response.RawMessage.Headers.TryAddWithoutValidation(
            "Retry-After-Ms",
            milliseconds.ToString(CultureInfo.InvariantCulture)
        );

        Assert.Equal(
            TimeSpan.FromMilliseconds(milliseconds),
            XTwitterScraperClientWithRawResponse.ParseRetryAfterMsHeader(response)
        );
    }

    [Property(MaxTest = 250)]
    public void BoundedRetryAfterSecondsControlsBackoff(PositiveInt generated)
    {
        var seconds = (generated.Get % 59) + 1;
        var expected = TimeSpan.FromSeconds(seconds);
        using var response = Response();
        response.RawMessage.Headers.TryAddWithoutValidation(
            "Retry-After",
            seconds.ToString(CultureInfo.InvariantCulture)
        );

        Assert.Equal(
            expected,
            XTwitterScraperClientWithRawResponse.ParseRetryAfterHeader(response)
        );
        Assert.Equal(
            expected,
            XTwitterScraperClientWithRawResponse.ComputeRetryBackoff(generated.Get, response)
        );
    }

    static HttpResponse Response()
    {
        return new()
        {
            RawMessage = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
            {
                Content = new StringContent("{}"),
            },
        };
    }
}
