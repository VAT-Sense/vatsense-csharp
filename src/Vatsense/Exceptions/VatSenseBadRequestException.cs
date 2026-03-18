using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSenseBadRequestException : VatSense4xxException
{
    public VatSenseBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
