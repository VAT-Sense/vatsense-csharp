using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSenseRateLimitException : VatSense4xxException
{
    public VatSenseRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
