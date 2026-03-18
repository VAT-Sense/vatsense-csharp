using System;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Models.Invoice;
using VatSense.Models.Invoice.Item;

namespace VatSense.Services.Invoice;

/// <summary>
/// VAT-compliant invoice management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve a specific line item from an invoice.
    /// </summary>
    Task<ItemRetrieveResponse> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ItemRetrieveParams, CancellationToken)"/>
    Task<ItemRetrieveResponse> Retrieve(
        string itemID,
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a specific line item on an invoice.
    /// </summary>
    Task<InvoiceResponse> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ItemUpdateParams, CancellationToken)"/>
    Task<InvoiceResponse> Update(
        string itemID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a specific line item from an invoice.
    /// </summary>
    Task<InvoiceResponse> Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ItemDeleteParams, CancellationToken)"/>
    Task<InvoiceResponse> Delete(
        string itemID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add one or more line items to an existing invoice.
    /// </summary>
    Task<InvoiceResponse> Add(
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ItemAddParams, CancellationToken)"/>
    Task<InvoiceResponse> Add(
        string invoiceID,
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /invoice/{invoice_id}/item/{item_id}</c>, but is otherwise the
    /// same as <see cref="IItemService.Retrieve(ItemRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ItemRetrieveResponse>> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ItemRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ItemRetrieveResponse>> Retrieve(
        string itemID,
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /invoice/{invoice_id}/item/{item_id}</c>, but is otherwise the
    /// same as <see cref="IItemService.Update(ItemUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceResponse>> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ItemUpdateParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceResponse>> Update(
        string itemID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /invoice/{invoice_id}/item/{item_id}</c>, but is otherwise the
    /// same as <see cref="IItemService.Delete(ItemDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceResponse>> Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ItemDeleteParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceResponse>> Delete(
        string itemID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /invoice/{invoice_id}/item</c>, but is otherwise the
    /// same as <see cref="IItemService.Add(ItemAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceResponse>> Add(
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ItemAddParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceResponse>> Add(
        string invoiceID,
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    );
}
