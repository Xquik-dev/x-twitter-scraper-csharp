// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperInvalidDataException : XTwitterScraperException
{
    public XTwitterScraperInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
