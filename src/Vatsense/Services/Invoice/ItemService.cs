using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Vatsense.Core;
using Vatsense.Exceptions;
using Vatsense.Models.Invoice;
using Vatsense.Models.Invoice.Item;

namespace Vatsense.Services.Invoice;

/// <inheritdoc/>
public sealed class ItemService : IItemService
{
    readonly Lazy<IItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    public ItemService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ItemServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ItemRetrieveResponse> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ItemRetrieveResponse> Retrieve(
        string itemID,
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceResponse> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvoiceResponse> Update(
        string itemID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceResponse> Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvoiceResponse> Delete(
        string itemID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceResponse> Add(
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvoiceResponse> Add(
        string invoiceID,
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ItemServiceWithRawResponse : IItemServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ItemServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ItemRetrieveResponse>> Retrieve(
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<ItemRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var item = await response
                    .Deserialize<ItemRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    item.Validate();
                }
                return item;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ItemRetrieveResponse>> Retrieve(
        string itemID,
        ItemRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceResponse>> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<ItemUpdateParams> request = new()
        {
            Method = VatSenseClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoiceResponse = await response
                    .Deserialize<InvoiceResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoiceResponse.Validate();
                }
                return invoiceResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InvoiceResponse>> Update(
        string itemID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceResponse>> Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<ItemDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoiceResponse = await response
                    .Deserialize<InvoiceResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoiceResponse.Validate();
                }
                return invoiceResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InvoiceResponse>> Delete(
        string itemID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceResponse>> Add(
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<ItemAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoiceResponse = await response
                    .Deserialize<InvoiceResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoiceResponse.Validate();
                }
                return invoiceResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InvoiceResponse>> Add(
        string invoiceID,
        ItemAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}
