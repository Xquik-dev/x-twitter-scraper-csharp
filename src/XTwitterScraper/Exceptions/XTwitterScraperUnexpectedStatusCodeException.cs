using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperUnexpectedStatusCodeException : XTwitterScraperApiException
{
    public XTwitterScraperUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
