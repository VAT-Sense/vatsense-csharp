using System.Net.Http;

namespace VatSense.Exceptions;

public class VatSenseUnexpectedStatusCodeException : VatSenseApiException
{
    public VatSenseUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
