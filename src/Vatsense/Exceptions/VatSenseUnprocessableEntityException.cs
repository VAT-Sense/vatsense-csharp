using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSenseUnprocessableEntityException : VatSense4xxException
{
    public VatSenseUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
