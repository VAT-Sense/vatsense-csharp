using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Services;

namespace VatSense;

/// <inheritdoc/>
public sealed class VatSenseClient : IVatSenseClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string Username
    {
        get { return this._options.Username; }
        init { this._options.Username = value; }
    }

    /// <inheritdoc/>
    public string Password
    {
        get { return this._options.Password; }
        init { this._options.Password = value; }
    }

    readonly Lazy<IVatSenseClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVatSenseClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IVatSenseClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VatSenseClient(modifier(this._options));
    }

    readonly Lazy<IRateService> _rates;
    public IRateService Rates
    {
        get { return _rates.Value; }
    }

    readonly Lazy<ICountryService> _countries;
    public ICountryService Countries
    {
        get { return _countries.Value; }
    }

    readonly Lazy<IValidateService> _validate;
    public IValidateService Validate
    {
        get { return _validate.Value; }
    }

    readonly Lazy<ICurrencyService> _currency;
    public ICurrencyService Currency
    {
        get { return _currency.Value; }
    }

    readonly Lazy<IInvoiceService> _invoice;
    public IInvoiceService Invoice
    {
        get { return _invoice.Value; }
    }

    readonly Lazy<IUsageService> _usage;
    public IUsageService Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<ISandboxService> _sandbox;
    public ISandboxService Sandbox
    {
        get { return _sandbox.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public VatSenseClient()
    {
        _options = new();

        _withRawResponse = new(() => new VatSenseClientWithRawResponse(this._options));
        _rates = new(() => new RateService(this));
        _countries = new(() => new CountryService(this));
        _validate = new(() => new ValidateService(this));
        _currency = new(() => new CurrencyService(this));
        _invoice = new(() => new InvoiceService(this));
        _usage = new(() => new UsageService(this));
        _sandbox = new(() => new SandboxService(this));
    }

    public VatSenseClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class VatSenseClientWithRawResponse : IVatSenseClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string Username
    {
        get { return this._options.Username; }
        init { this._options.Username = value; }
    }

    /// <inheritdoc/>
    public string Password
    {
        get { return this._options.Password; }
        init { this._options.Password = value; }
    }

    /// <inheritdoc/>
    public IVatSenseClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VatSenseClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IRateServiceWithRawResponse> _rates;
    public IRateServiceWithRawResponse Rates
    {
        get { return _rates.Value; }
    }

    readonly Lazy<ICountryServiceWithRawResponse> _countries;
    public ICountryServiceWithRawResponse Countries
    {
        get { return _countries.Value; }
    }

    readonly Lazy<IValidateServiceWithRawResponse> _validate;
    public IValidateServiceWithRawResponse Validate
    {
        get { return _validate.Value; }
    }

    readonly Lazy<ICurrencyServiceWithRawResponse> _currency;
    public ICurrencyServiceWithRawResponse Currency
    {
        get { return _currency.Value; }
    }

    readonly Lazy<IInvoiceServiceWithRawResponse> _invoice;
    public IInvoiceServiceWithRawResponse Invoice
    {
        get { return _invoice.Value; }
    }

    readonly Lazy<IUsageServiceWithRawResponse> _usage;
    public IUsageServiceWithRawResponse Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<ISandboxServiceWithRawResponse> _sandbox;
    public ISandboxServiceWithRawResponse Sandbox
    {
        get { return _sandbox.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw VatSenseExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new VatSenseIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new VatSenseIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is VatSenseIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public VatSenseClientWithRawResponse()
    {
        _options = new();

        _rates = new(() => new RateServiceWithRawResponse(this));
        _countries = new(() => new CountryServiceWithRawResponse(this));
        _validate = new(() => new ValidateServiceWithRawResponse(this));
        _currency = new(() => new CurrencyServiceWithRawResponse(this));
        _invoice = new(() => new InvoiceServiceWithRawResponse(this));
        _usage = new(() => new UsageServiceWithRawResponse(this));
        _sandbox = new(() => new SandboxServiceWithRawResponse(this));
    }

    public VatSenseClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
