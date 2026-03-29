using System;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperInvalidDataException : XTwitterScraperException
{
    public XTwitterScraperInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
