using System;

namespace Vatsense.Exceptions;

/// <summary>
/// A webhook event's signature is missing, malformed, too old or does not match.
/// </summary>
public class WebhookSignatureException : VatSenseException
{
    public WebhookSignatureException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
