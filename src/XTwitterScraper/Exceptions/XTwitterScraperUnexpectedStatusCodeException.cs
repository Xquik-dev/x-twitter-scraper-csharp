// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperUnexpectedStatusCodeException : XTwitterScraperApiException
{
    public XTwitterScraperUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
