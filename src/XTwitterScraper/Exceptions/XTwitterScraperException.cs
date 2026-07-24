// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperException : Exception
{
    public XTwitterScraperException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected XTwitterScraperException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
