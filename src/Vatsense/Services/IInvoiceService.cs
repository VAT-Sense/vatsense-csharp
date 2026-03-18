using System;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Models.Invoice;
using Vatsense.Services.Invoice;

namespace Vatsense.Services;

/// <summary>
/// VAT-compliant invoice management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemService Item { get; }

    /// <summary>
    /// Create a new VAT-compliant invoice. VAT Sense will automatically calculate the
    /// totals based on the items provided.
    ///
    /// <para>Not available with sandbox API keys. </para>
    /// </summary>
    Task<InvoiceResponse> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific invoice by its ID.
    /// </summary>
    Task<InvoiceResponse> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InvoiceRetrieveParams, CancellationToken)"/>
    Task<InvoiceResponse> Retrieve(
        string invoiceID,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing invoice. Only the fields provided will be updated.
    /// </summary>
    Task<InvoiceResponse> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(InvoiceUpdateParams, CancellationToken)"/>
    Task<InvoiceResponse> Update(
        string invoiceID,
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a paginated list of all invoices.
    /// </summary>
    Task<InvoiceListResponse> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete an invoice.
    /// </summary>
    Task<InvoiceDeleteResponse> Delete(
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(InvoiceDeleteParams, CancellationToken)"/>
    Task<InvoiceDeleteResponse> Delete(
        string invoiceID,
        InvoiceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemServiceWithRawResponse Item { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /invoice</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Create(InvoiceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceResponse>> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /invoice/{invoice_id}</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Retrieve(InvoiceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceResponse>> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InvoiceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceResponse>> Retrieve(
        string invoiceID,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /invoice/{invoice_id}</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Update(InvoiceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceResponse>> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(InvoiceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceResponse>> Update(
        string invoiceID,
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /invoice</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.List(InvoiceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceListResponse>> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /invoice/{invoice_id}</c>, but is otherwise the
    /// same as <see cref="IInvoiceService.Delete(InvoiceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceDeleteResponse>> Delete(
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(InvoiceDeleteParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceDeleteResponse>> Delete(
        string invoiceID,
        InvoiceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
