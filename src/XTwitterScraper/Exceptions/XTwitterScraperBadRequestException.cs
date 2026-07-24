// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperBadRequestException : XTwitterScraper4xxException
{
    public XTwitterScraperBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
