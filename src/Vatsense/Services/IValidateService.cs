using System;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Models.Validate;

namespace Vatsense.Services;

/// <summary>
/// VAT and EORI number validation
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IValidateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IValidateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IValidateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Check whether a given VAT number or EORI number is valid against live government
    /// records.
    ///
    /// <para>**VAT validation** checks against UK (HMRC), EU (VIES), Australia, Norway,
    /// Switzerland, South Africa, and Brazil records.</para>
    ///
    /// <para>**EORI validation** checks against UK and EU records only.</para>
    ///
    /// <para>If the external validation service is temporarily unavailable, the API
    /// returns a `412` error and the request does not count against your usage quota.</para>
    ///
    /// <para>Provide either `vat_number` or `eori_number`, but not both. </para>
    /// </summary>
    Task<ValidateCheckResponse> Check(
        ValidateCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IValidateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IValidateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IValidateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /validate</c>, but is otherwise the
    /// same as <see cref="IValidateService.Check(ValidateCheckParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ValidateCheckResponse>> Check(
        ValidateCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
