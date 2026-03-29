using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraper4xxException : XTwitterScraperApiException
{
    public XTwitterScraper4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
