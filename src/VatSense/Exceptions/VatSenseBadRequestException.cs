using System.Net.Http;

namespace VatSense.Exceptions;

public class VatSenseBadRequestException : VatSense4xxException
{
    public VatSenseBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
