using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraper5xxException : XTwitterScraperApiException
{
    public XTwitterScraper5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
