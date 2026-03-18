using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Invoice;
using VatSense.Services.Invoice;

namespace VatSense.Services;

/// <inheritdoc/>
public sealed class InvoiceService : IInvoiceService
{
    readonly Lazy<IInvoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IVatSenseClient _client;

    /// <inheritdoc/>
    public IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceService(this._client.WithOptions(modifier));
    }

    public InvoiceService(IVatSenseClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InvoiceServiceWithRawResponse(client.WithRawResponse));
        _item = new(() => new ItemService(client));
    }

    readonly Lazy<IItemService> _item;
    public IItemService Item
    {
        get { return _item.Value; }
    }

    /// <inheritdoc/>
    public async Task<InvoiceResponse> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InvoiceResponse> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvoiceResponse> Retrieve(
        string invoiceID,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceResponse> Update(
        InvoiceUpdateParams parameters,
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
        string invoiceID,
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceListResponse> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InvoiceDeleteResponse> Delete(
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvoiceDeleteResponse> Delete(
        string invoiceID,
        InvoiceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InvoiceServiceWithRawResponse : IInvoiceServiceWithRawResponse
{
    readonly IVatSenseClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvoiceServiceWithRawResponse(IVatSenseClientWithRawResponse client)
    {
        _client = client;

        _item = new(() => new ItemServiceWithRawResponse(client));
    }

    readonly Lazy<IItemServiceWithRawResponse> _item;
    public IItemServiceWithRawResponse Item
    {
        get { return _item.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceResponse>> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoiceCreateParams> request = new()
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
    public async Task<HttpResponse<InvoiceResponse>> Retrieve(
        InvoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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
    public Task<HttpResponse<InvoiceResponse>> Retrieve(
        string invoiceID,
        InvoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceResponse>> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceUpdateParams> request = new()
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
        string invoiceID,
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceListResponse>> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InvoiceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoices = await response
                    .Deserialize<InvoiceListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoices.Validate();
                }
                return invoices;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceDeleteResponse>> Delete(
        InvoiceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new VatSenseInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response
                    .Deserialize<InvoiceDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InvoiceDeleteResponse>> Delete(
        string invoiceID,
        InvoiceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}
