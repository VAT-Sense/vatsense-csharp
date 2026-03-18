using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSense5xxException : VatSenseApiException
{
    public VatSense5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
