using System;
using System.Net.Http;

namespace VatSense.Exceptions;

public class VatSenseIOException : VatSenseException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public VatSenseIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
