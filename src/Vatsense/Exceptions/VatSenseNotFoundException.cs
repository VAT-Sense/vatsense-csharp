using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSenseNotFoundException : VatSense4xxException
{
    public VatSenseNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
