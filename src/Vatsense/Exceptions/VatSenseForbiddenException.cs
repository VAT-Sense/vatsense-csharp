using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSenseForbiddenException : VatSense4xxException
{
    public VatSenseForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
