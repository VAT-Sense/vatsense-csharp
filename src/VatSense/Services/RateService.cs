using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Models.Rates;

namespace VatSense.Services;

/// <inheritdoc/>
public sealed class RateService : IRateService
{
    readonly Lazy<IRateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public IRateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RateService(this._client.WithOptions(modifier));
    }

    public RateService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RateServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RateListResponse> List(
        RateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RateCalculatePriceResponse> CalculatePrice(
        RateCalculatePriceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CalculatePrice(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FindRate> Details(
        RateDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Details(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FindRate> Find(
        RateFindParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Find(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RateListTypesResponse> ListTypes(
        RateListTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTypes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RateServiceWithRawResponse : IRateServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RateServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RateListResponse>> List(
        RateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var rates = await response
                    .Deserialize<RateListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    rates.Validate();
                }
                return rates;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RateCalculatePriceResponse>> CalculatePrice(
        RateCalculatePriceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RateCalculatePriceParams> request = new()
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
                    .Deserialize<RateCalculatePriceResponse>(token)
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
    public async Task<HttpResponse<FindRate>> Details(
        RateDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RateDetailsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var findRate = await response.Deserialize<FindRate>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    findRate.Validate();
                }
                return findRate;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FindRate>> Find(
        RateFindParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RateFindParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var findRate = await response.Deserialize<FindRate>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    findRate.Validate();
                }
                return findRate;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RateListTypesResponse>> ListTypes(
        RateListTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RateListTypesParams> request = new()
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
                    .Deserialize<RateListTypesResponse>(token)
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
