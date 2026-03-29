using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperBadRequestException : XTwitterScraper4xxException
{
    public XTwitterScraperBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
