using System;

namespace VatSense.Core;

readonly record struct SecurityOptions
{
    public SecurityOptions() { }

    public Boolean BasicAuth { get; init; } = false;

    public static SecurityOptions All() => new() { BasicAuth = true };
}
