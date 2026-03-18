using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;

namespace Vatsense.Models.Usage;

[JsonConverter(typeof(JsonModelConverter<UsageRetrieveResponse, UsageRetrieveResponseFromRaw>))]
public sealed record class UsageRetrieveResponse : JsonModel
{
    public long? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        this.Data?.Validate();
        _ = this.Success;
    }

    public UsageRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageRetrieveResponse(UsageRetrieveResponse usageRetrieveResponse)
        : base(usageRetrieveResponse) { }
#pragma warning restore CS8618

    public UsageRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static UsageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageRetrieveResponseFromRaw : IFromRawJson<UsageRetrieveResponse>
{
    /// <inheritdoc/>
    public UsageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public Requests? Requests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Requests>("requests");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requests", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Requests?.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Requests, RequestsFromRaw>))]
public sealed record class Requests : JsonModel
{
    /// <summary>
    /// Requests remaining before the limit is reached.
    /// </summary>
    public long? Remaining
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("remaining");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("remaining", value);
        }
    }

    /// <summary>
    /// Total requests allowed on your plan.
    /// </summary>
    public long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total", value);
        }
    }

    /// <summary>
    /// Requests used in the last 30 days.
    /// </summary>
    public long? Used
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("used");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("used", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Remaining;
        _ = this.Total;
        _ = this.Used;
    }

    public Requests() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Requests(Requests requests)
        : base(requests) { }
#pragma warning restore CS8618

    public Requests(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Requests(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestsFromRaw.FromRawUnchecked"/>
    public static Requests FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestsFromRaw : IFromRawJson<Requests>
{
    /// <inheritdoc/>
    public Requests FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Requests.FromRawUnchecked(rawData);
}
