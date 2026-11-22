namespace Vatsense.Models.Batches;

/// <summary>
/// The values of <c>Shortfall</c>: what happens when your requests do not cover a batch.
/// </summary>
public static class BatchShortfall
{
    /// <summary>Start nothing and return the quote (the default).</summary>
    public const string Wait = "wait";

    /// <summary>Check what is covered and pause the rest.</summary>
    public const string Pause = "pause";

    /// <summary>Run into overage (it must already be on in the dashboard).</summary>
    public const string Overage = "overage";
}
