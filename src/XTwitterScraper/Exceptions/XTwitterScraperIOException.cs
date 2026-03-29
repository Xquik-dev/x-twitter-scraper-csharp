using System;
using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperIOException : XTwitterScraperException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public XTwitterScraperIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
