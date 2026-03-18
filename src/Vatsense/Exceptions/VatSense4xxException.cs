using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSense4xxException : VatSenseApiException
{
    public VatSense4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
