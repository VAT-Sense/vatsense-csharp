using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Vatsense.Core;

namespace Vatsense.Models.Batches;

/// <summary>
/// A page of a batch's results, in row order.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BatchResultsParams : ParamsBase
{
    /// <summary>
    /// The batch's ID, such as <c>bat_...</c>.
    /// </summary>
    public string? BatchID { get; init; }

    /// <summary>
    /// Return rows after this row number (the last page's <c>NextAfter</c>).
    /// </summary>
    public long? After
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("after");
        }
        init { this._rawQueryData.Set("after", value); }
    }

    /// <summary>
    /// Rows a page, 1 to 1,000 (default 100).
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init { this._rawQueryData.Set("limit", value); }
    }

    public BatchResultsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchResultsParams(BatchResultsParams other)
        : base(other)
    {
        this.BatchID = other.BatchID;
    }
#pragma warning restore CS8618

    public BatchResultsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string batchID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.BatchID = batchID;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchResultsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string batchID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.BatchID = batchID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BatchResultsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string batchID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            batchID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BatchID"] = JsonSerializer.SerializeToElement(this.BatchID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BatchResultsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.BatchID?.Equals(other.BatchID) ?? other.BatchID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/batches/{0}/results", Uri.EscapeDataString(this.BatchID ?? ""))
        )
        {
            Query = this.QueryString(options, SecurityOptions.All()),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options, SecurityOptions.All());
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
