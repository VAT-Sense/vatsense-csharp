using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Models.Countries;

namespace VatSense.Services;

/// <inheritdoc/>
public sealed class CountryService : ICountryService
{
    readonly Lazy<ICountryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICountryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public ICountryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CountryService(this._client.WithOptions(modifier));
    }

    public CountryService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CountryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CountryListResponse> List(
        CountryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CountryListProvincesResponse> ListProvinces(
        CountryListProvincesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListProvinces(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CountryServiceWithRawResponse : ICountryServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICountryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CountryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CountryServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CountryListResponse>> List(
        CountryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CountryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var countries = await response
                    .Deserialize<CountryListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    countries.Validate();
                }
                return countries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CountryListProvincesResponse>> ListProvinces(
        CountryListProvincesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CountryListProvincesParams> request = new()
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
                    .Deserialize<CountryListProvincesResponse>(token)
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
