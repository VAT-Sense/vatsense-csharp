using System.Net.Http;

namespace VatSense.Exceptions;

public class VatSenseRateLimitException : VatSense4xxException
{
    public VatSenseRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
