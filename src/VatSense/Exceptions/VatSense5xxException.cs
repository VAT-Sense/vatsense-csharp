using System.Net.Http;

namespace VatSense.Exceptions;

public class VatSense5xxException : VatSenseApiException
{
    public VatSense5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
