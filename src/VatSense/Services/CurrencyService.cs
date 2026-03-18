using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Models.Currency;

namespace VatSense.Services;

/// <inheritdoc/>
public sealed class CurrencyService : ICurrencyService
{
    readonly Lazy<ICurrencyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICurrencyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public ICurrencyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CurrencyService(this._client.WithOptions(modifier));
    }

    public CurrencyService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CurrencyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CurrencyListResponse> List(
        CurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CurrencyCalculateVatPriceResponse> CalculateVatPrice(
        CurrencyCalculateVatPriceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CalculateVatPrice(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CurrencyConvertResponse> Convert(
        CurrencyConvertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Convert(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CurrencyServiceWithRawResponse : ICurrencyServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICurrencyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CurrencyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CurrencyServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyListResponse>> List(
        CurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CurrencyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencies = await response
                    .Deserialize<CurrencyListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencies.Validate();
                }
                return currencies;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyCalculateVatPriceResponse>> CalculateVatPrice(
        CurrencyCalculateVatPriceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CurrencyCalculateVatPriceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<CurrencyCalculateVatPriceResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyConvertResponse>> Convert(
        CurrencyConvertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CurrencyConvertParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<CurrencyConvertResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
