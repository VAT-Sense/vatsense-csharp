using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Services;

namespace Vatsense;

/// <summary>
/// A client for interacting with the Vat Sense REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVatSenseClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Use HTTP Basic Auth with username `user` and your API key as the password.
    /// </summary>
    string Username { get; init; }

    /// <summary>
    /// Use HTTP Basic Auth with username `user` and your API key as the password.
    /// </summary>
    string Password { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVatSenseClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVatSenseClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRateService Rates { get; }

    ICountryService Countries { get; }

    IValidateService Validate { get; }

    ICurrencyService Currency { get; }

    IInvoiceService Invoice { get; }

    IUsageService Usage { get; }

    ISandboxService Sandbox { get; }
}

/// <summary>
/// A view of <see cref="IVatSenseClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IVatSenseClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Use HTTP Basic Auth with username `user` and your API key as the password.
    /// </summary>
    string Username { get; init; }

    /// <summary>
    /// Use HTTP Basic Auth with username `user` and your API key as the password.
    /// </summary>
    string Password { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVatSenseClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRateServiceWithRawResponse Rates { get; }

    ICountryServiceWithRawResponse Countries { get; }

    IValidateServiceWithRawResponse Validate { get; }

    ICurrencyServiceWithRawResponse Currency { get; }

    IInvoiceServiceWithRawResponse Invoice { get; }

    IUsageServiceWithRawResponse Usage { get; }

    ISandboxServiceWithRawResponse Sandbox { get; }

    /// <summary>
    /// Sends a request to the Vat Sense REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
