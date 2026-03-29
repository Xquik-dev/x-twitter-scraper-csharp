using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperNotFoundException : XTwitterScraper4xxException
{
    public XTwitterScraperNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
