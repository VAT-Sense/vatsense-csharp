using System;

namespace Vatsense.Core;

readonly record struct SecurityOptions
{
    public SecurityOptions() { }

    public Boolean BasicAuth { get; init; } = false;

    public static SecurityOptions All() => new() { BasicAuth = true };
}
