using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Models.Validate;

namespace Vatsense.Services;

/// <inheritdoc/>
public sealed class ValidateService : IValidateService
{
    readonly Lazy<IValidateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IValidateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public IValidateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ValidateService(this._client.WithOptions(modifier));
    }

    public ValidateService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ValidateServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ValidateCheckResponse> Check(
        ValidateCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Check(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ValidateServiceWithRawResponse : IValidateServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IValidateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ValidateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ValidateServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ValidateCheckResponse>> Check(
        ValidateCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ValidateCheckParams> request = new()
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
                    .Deserialize<ValidateCheckResponse>(token)
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
