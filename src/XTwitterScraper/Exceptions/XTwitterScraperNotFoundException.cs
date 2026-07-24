// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperNotFoundException : XTwitterScraper4xxException
{
    public XTwitterScraperNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
