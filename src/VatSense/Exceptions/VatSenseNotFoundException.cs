using System.Net.Http;

namespace VatSense.Exceptions;

public class VatSenseNotFoundException : VatSense4xxException
{
    public VatSenseNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
