using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Models.Usage;

namespace Vatsense.Services;

/// <inheritdoc/>
public sealed class UsageService : IUsageService
{
    readonly Lazy<IUsageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageService(this._client.WithOptions(modifier));
    }

    public UsageService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UsageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UsageRetrieveResponse> Retrieve(
        UsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UsageServiceWithRawResponse : IUsageServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UsageServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageRetrieveResponse>> Retrieve(
        UsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UsageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var usage = await response
                    .Deserialize<UsageRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    usage.Validate();
                }
                return usage;
            }
        );
    }
}
