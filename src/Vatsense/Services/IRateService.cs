using System;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Models.Rates;

namespace Vatsense.Services;

/// <summary>
/// VAT/GST rate lookups for countries worldwide
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a list of VAT/GST rates for all countries, sorted alphabetically by
    /// country code. Each rate is returned as a rate object containing the standard
    /// rate and any other applicable rates.
    ///
    /// <para>You can optionally filter by country code, IP address, or EU membership. </para>
    /// </summary>
    Task<RateListResponse> List(
        RateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Combines the functionality of the "Find a tax rate" and "VAT price calculation"
    /// endpoints to return the particular VAT price for an applicable VAT rate.
    /// Requires both a location (country_code or ip_address) and a price to calculate.
    /// </summary>
    Task<RateCalculatePriceResponse> CalculatePrice(
        RateCalculatePriceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get detailed tax rate information for a location, including all applicable rate
    /// classes (standard, reduced, zero, etc.).
    /// </summary>
    Task<FindRate> Details(
        RateDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// A handy endpoint for finding a rate that applies to a particular country and
    /// optional product type, based on country code or IP address.
    ///
    /// <para>If no type is provided, or no specific rate is applied to the given type,
    /// then the standard rate will be returned if the country is subject to tax.</para>
    ///
    /// <para>If the country is not subject to VAT/GST then an error response will be
    /// returned, indicating no tax applies. </para>
    /// </summary>
    Task<FindRate> Find(
        RateFindParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a list of all available product types that can be used to filter tax
    /// rates.
    /// </summary>
    Task<RateListTypesResponse> ListTypes(
        RateListTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /rates</c>, but is otherwise the
    /// same as <see cref="IRateService.List(RateListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RateListResponse>> List(
        RateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /rates/price</c>, but is otherwise the
    /// same as <see cref="IRateService.CalculatePrice(RateCalculatePriceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RateCalculatePriceResponse>> CalculatePrice(
        RateCalculatePriceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /rates/tax_rate</c>, but is otherwise the
    /// same as <see cref="IRateService.Details(RateDetailsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FindRate>> Details(
        RateDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /rates/rate</c>, but is otherwise the
    /// same as <see cref="IRateService.Find(RateFindParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FindRate>> Find(
        RateFindParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /rates/types</c>, but is otherwise the
    /// same as <see cref="IRateService.ListTypes(RateListTypesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RateListTypesResponse>> ListTypes(
        RateListTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
