using System;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Models.Sandbox;

namespace VatSense.Services;

/// <summary>
/// Temporary sandbox API keys for testing
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISandboxService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISandboxServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISandboxService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Generate a temporary sandbox API key for testing. Sandbox keys have limited
    /// request allowances and restricted endpoint access (no invoice endpoints). Rate
    /// limited to 1 key per IP address per 6 hours.
    /// </summary>
    Task<SandboxGenerateKeyResponse> GenerateKey(
        SandboxGenerateKeyParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISandboxService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISandboxServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISandboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /sandbox/key</c>, but is otherwise the
    /// same as <see cref="ISandboxService.GenerateKey(SandboxGenerateKeyParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SandboxGenerateKeyResponse>> GenerateKey(
        SandboxGenerateKeyParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
