using System;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Models.Currency;

namespace VatSense.Services;

/// <summary>
/// Currency exchange rates and conversion
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICurrencyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICurrencyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICurrencyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a list of all currency conversion rates sourced from HMRC (GBP) and the
    /// European Central Bank (EUR).
    ///
    /// <para>You can optionally filter by source and target currency. </para>
    /// </summary>
    Task<CurrencyListResponse> List(
        CurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Calculate the inclusive and exclusive VAT price on a given amount and VAT rate.
    /// This is a standalone calculation that does not look up rates by country.
    /// </summary>
    Task<CurrencyCalculateVatPriceResponse> CalculateVatPrice(
        CurrencyCalculateVatPriceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Convert a foreign currency amount to either GBP or EUR using official exchange
    /// rates.
    ///
    /// <para>GBP rates are from HMRC (updated on the 1st of every month). EUR rates are
    /// from the European Central Bank (updated around 16:00 CET on working days). </para>
    /// </summary>
    Task<CurrencyConvertResponse> Convert(
        CurrencyConvertParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICurrencyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICurrencyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICurrencyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /currency</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.List(CurrencyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyListResponse>> List(
        CurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /currency/price</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.CalculateVatPrice(CurrencyCalculateVatPriceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyCalculateVatPriceResponse>> CalculateVatPrice(
        CurrencyCalculateVatPriceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /currency/convert</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.Convert(CurrencyConvertParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyConvertResponse>> Convert(
        CurrencyConvertParams parameters,
        CancellationToken cancellationToken = default
    );
}
