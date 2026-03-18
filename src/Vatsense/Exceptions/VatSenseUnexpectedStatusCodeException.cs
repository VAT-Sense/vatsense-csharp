using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSenseUnexpectedStatusCodeException : VatSenseApiException
{
    public VatSenseUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
