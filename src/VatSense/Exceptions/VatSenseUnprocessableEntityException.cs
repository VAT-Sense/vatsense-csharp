using System.Net.Http;

namespace VatSense.Exceptions;

public class VatSenseUnprocessableEntityException : VatSense4xxException
{
    public VatSenseUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
