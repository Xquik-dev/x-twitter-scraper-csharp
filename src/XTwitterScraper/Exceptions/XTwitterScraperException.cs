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
