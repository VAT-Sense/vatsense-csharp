using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Batches;

namespace Vatsense.Services;

/// <inheritdoc/>
public sealed class BatchService : IBatchService
{
    readonly Lazy<IBatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBatchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchService(this._client.WithOptions(modifier));
    }

    public BatchService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BatchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BatchResponse> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BatchListResponse> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BatchResponse> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchResponse> Retrieve(
        string batchID,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BatchDeleteResponse> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchDeleteResponse> Delete(
        string batchID,
        BatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BatchResponse> Start(
        BatchStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Start(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchResponse> Start(
        string batchID,
        BatchStartParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Start(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BatchResponse> Pause(
        BatchPauseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Pause(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchResponse> Pause(
        string batchID,
        BatchPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Pause(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BatchResponse> Continue(
        BatchContinueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Continue(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchResponse> Continue(
        string batchID,
        BatchContinueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Continue(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BatchResponse> Complete(
        BatchCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Complete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchResponse> Complete(
        string batchID,
        BatchCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BatchResultsResponse> Results(
        BatchResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Results(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchResultsResponse> Results(
        string batchID,
        BatchResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Results(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<string> ResultsCsv(
        BatchResultsCsvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ResultsCsv(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<string> ResultsCsv(
        string batchID,
        BatchResultsCsvParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ResultsCsv(parameters with { BatchID = batchID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BatchServiceWithRawResponse : IBatchServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BatchServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchResponse>> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchListResponse>> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BatchListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchResponse>> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BatchResponse>> Retrieve(
        string batchID,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchDeleteResponse>> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BatchDeleteResponse>> Delete(
        string batchID,
        BatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchResponse>> Start(
        BatchStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchStartParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BatchResponse>> Start(
        string batchID,
        BatchStartParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Start(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchResponse>> Pause(
        BatchPauseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchPauseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BatchResponse>> Pause(
        string batchID,
        BatchPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Pause(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchResponse>> Continue(
        BatchContinueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchContinueParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BatchResponse>> Continue(
        string batchID,
        BatchContinueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Continue(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchResponse>> Complete(
        BatchCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchCompleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BatchResponse>> Complete(
        string batchID,
        BatchCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Complete(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchResultsResponse>> Results(
        BatchResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchResultsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserialized = await response
                    .Deserialize<BatchResultsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserialized.Validate();
                }
                return deserialized;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BatchResultsResponse>> Results(
        string batchID,
        BatchResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Results(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> ResultsCsv(
        BatchResultsCsvParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchResultsCsvParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) => await response.ReadAsString(token).ConfigureAwait(false)
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<string>> ResultsCsv(
        string batchID,
        BatchResultsCsvParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ResultsCsv(parameters with { BatchID = batchID }, cancellationToken);
    }
}
