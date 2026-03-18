using System;

namespace Vatsense.Exceptions;

public class VatSenseInvalidDataException : VatSenseException
{
    public VatSenseInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
