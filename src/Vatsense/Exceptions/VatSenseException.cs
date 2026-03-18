using System;
using System.Net.Http;

namespace Vatsense.Exceptions;

public class VatSenseException : Exception
{
    public VatSenseException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected VatSenseException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
