using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Models.Sandbox;

namespace Vatsense.Services;

/// <inheritdoc/>
public sealed class SandboxService : ISandboxService
{
    readonly Lazy<ISandboxServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISandboxServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public ISandboxService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SandboxService(this._client.WithOptions(modifier));
    }

    public SandboxService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SandboxServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SandboxGenerateKeyResponse> GenerateKey(
        SandboxGenerateKeyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GenerateKey(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SandboxServiceWithRawResponse : ISandboxServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISandboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SandboxServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SandboxServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SandboxGenerateKeyResponse>> GenerateKey(
        SandboxGenerateKeyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SandboxGenerateKeyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SandboxGenerateKeyResponse>(token)
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
