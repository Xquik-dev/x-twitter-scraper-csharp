using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperForbiddenException : XTwitterScraper4xxException
{
    public XTwitterScraperForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
