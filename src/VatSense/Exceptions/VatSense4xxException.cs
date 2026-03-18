using System.Net.Http;

namespace VatSense.Exceptions;

public class VatSense4xxException : VatSenseApiException
{
    public VatSense4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
