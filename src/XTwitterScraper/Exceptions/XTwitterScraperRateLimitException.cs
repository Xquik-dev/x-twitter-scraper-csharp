using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperRateLimitException : XTwitterScraper4xxException
{
    public XTwitterScraperRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
