using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperUnauthorizedException : XTwitterScraper4xxException
{
    public XTwitterScraperUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
