using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSenseUnauthorizedException : VatSense4xxException
{
    public VatSenseUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
