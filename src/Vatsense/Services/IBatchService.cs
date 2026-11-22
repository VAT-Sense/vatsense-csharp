using System;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Models.Batches;

namespace Vatsense.Services;

/// <summary>
/// Bulk validation: check many VAT numbers in one batch. With a test key a batch is
/// answered from the test numbers, is free and holds at most 1,000 numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a batch of VAT numbers and, by default, start checking it. Batch calls are free; each number a batch checks counts as one request.
    /// </summary>
    Task<BatchResponse> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The account's batches, newest first.
    /// </summary>
    Task<BatchListResponse> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a batch, with its counts and status.
    /// </summary>
    Task<BatchResponse> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BatchRetrieveParams, CancellationToken)"/>
    Task<BatchResponse> Retrieve(
        string batchID,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a draft batch that has not been started.
    /// </summary>
    Task<BatchDeleteResponse> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BatchDeleteParams, CancellationToken)"/>
    Task<BatchDeleteResponse> Delete(
        string batchID,
        BatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Start a draft batch.
    /// </summary>
    Task<BatchResponse> Start(
        BatchStartParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Start(BatchStartParams, CancellationToken)"/>
    Task<BatchResponse> Start(
        string batchID,
        BatchStartParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Pause a batch that is checking.
    /// </summary>
    Task<BatchResponse> Pause(
        BatchPauseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Pause(BatchPauseParams, CancellationToken)"/>
    Task<BatchResponse> Pause(
        string batchID,
        BatchPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Continue a paused batch.
    /// </summary>
    Task<BatchResponse> Continue(
        BatchContinueParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Continue(BatchContinueParams, CancellationToken)"/>
    Task<BatchResponse> Continue(
        string batchID,
        BatchContinueParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Finish a paused batch now, leaving its unchecked rows unchecked.
    /// </summary>
    Task<BatchResponse> Complete(
        BatchCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(BatchCompleteParams, CancellationToken)"/>
    Task<BatchResponse> Complete(
        string batchID,
        BatchCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// A page of a batch's results, in row order. Pass the page's <c>NextAfter</c> as <c>After</c> for the next.
    /// </summary>
    Task<BatchResultsResponse> Results(
        BatchResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Results(BatchResultsParams, CancellationToken)"/>
    Task<BatchResultsResponse> Results(
        string batchID,
        BatchResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// A batch's results as CSV text, with the same columns as the dashboard's download.
    /// </summary>
    Task<string> ResultsCsv(
        BatchResultsCsvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ResultsCsv(BatchResultsCsvParams, CancellationToken)"/>
    Task<string> ResultsCsv(
        string batchID,
        BatchResultsCsvParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /batches</c>, but is otherwise the
    /// same as <see cref="IBatchService.Create(BatchCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchResponse>> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /batches</c>, but is otherwise the
    /// same as <see cref="IBatchService.List(BatchListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchListResponse>> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /batches/{batch_id}</c>, but is otherwise the
    /// same as <see cref="IBatchService.Retrieve(BatchRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchResponse>> Retrieve(
        BatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BatchRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BatchResponse>> Retrieve(
        string batchID,
        BatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /batches/{batch_id}</c>, but is otherwise the
    /// same as <see cref="IBatchService.Delete(BatchDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchDeleteResponse>> Delete(
        BatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BatchDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BatchDeleteResponse>> Delete(
        string batchID,
        BatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /batches/{batch_id}/start</c>, but is otherwise the
    /// same as <see cref="IBatchService.Start(BatchStartParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchResponse>> Start(
        BatchStartParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Start(BatchStartParams, CancellationToken)"/>
    Task<HttpResponse<BatchResponse>> Start(
        string batchID,
        BatchStartParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /batches/{batch_id}/pause</c>, but is otherwise the
    /// same as <see cref="IBatchService.Pause(BatchPauseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchResponse>> Pause(
        BatchPauseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Pause(BatchPauseParams, CancellationToken)"/>
    Task<HttpResponse<BatchResponse>> Pause(
        string batchID,
        BatchPauseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /batches/{batch_id}/continue</c>, but is otherwise the
    /// same as <see cref="IBatchService.Continue(BatchContinueParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchResponse>> Continue(
        BatchContinueParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Continue(BatchContinueParams, CancellationToken)"/>
    Task<HttpResponse<BatchResponse>> Continue(
        string batchID,
        BatchContinueParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /batches/{batch_id}/complete</c>, but is otherwise the
    /// same as <see cref="IBatchService.Complete(BatchCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchResponse>> Complete(
        BatchCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Complete(BatchCompleteParams, CancellationToken)"/>
    Task<HttpResponse<BatchResponse>> Complete(
        string batchID,
        BatchCompleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /batches/{batch_id}/results</c>, but is otherwise the
    /// same as <see cref="IBatchService.Results(BatchResultsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchResultsResponse>> Results(
        BatchResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Results(BatchResultsParams, CancellationToken)"/>
    Task<HttpResponse<BatchResultsResponse>> Results(
        string batchID,
        BatchResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /batches/{batch_id}/results.csv</c>, but is otherwise the
    /// same as <see cref="IBatchService.ResultsCsv(BatchResultsCsvParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<string>> ResultsCsv(
        BatchResultsCsvParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ResultsCsv(BatchResultsCsvParams, CancellationToken)"/>
    Task<HttpResponse<string>> ResultsCsv(
        string batchID,
        BatchResultsCsvParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
