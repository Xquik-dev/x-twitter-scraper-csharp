using System.Net.Http;

namespace XTwitterScraper.Exceptions;

public class XTwitterScraperUnprocessableEntityException : XTwitterScraper4xxException
{
    public XTwitterScraperUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
