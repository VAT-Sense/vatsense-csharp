using System;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Models.Countries;

namespace VatSense.Services;

/// <summary>
/// Country and province information
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICountryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICountryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICountryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a list of all countries, including whether they are subject to VAT/GST
    /// and whether they are subject to EU VAT. Each country is returned as a country
    /// object.
    ///
    /// <para>You can optionally filter by country code or IP address. </para>
    /// </summary>
    Task<CountryListResponse> List(
        CountryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of all provinces within a given country.
    /// </summary>
    Task<CountryListProvincesResponse> ListProvinces(
        CountryListProvincesParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICountryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICountryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICountryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /countries</c>, but is otherwise the
    /// same as <see cref="ICountryService.List(CountryListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CountryListResponse>> List(
        CountryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /countries/provinces</c>, but is otherwise the
    /// same as <see cref="ICountryService.ListProvinces(CountryListProvincesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CountryListProvincesResponse>> ListProvinces(
        CountryListProvincesParams parameters,
        CancellationToken cancellationToken = default
    );
}
