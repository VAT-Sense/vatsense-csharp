using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vatsense.Core;

namespace Vatsense.Models.Sandbox;

[JsonConverter(
    typeof(JsonModelConverter<SandboxGenerateKeyResponse, SandboxGenerateKeyResponseFromRaw>)
)]
public sealed record class SandboxGenerateKeyResponse : JsonModel
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

    public SandboxGenerateKeyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SandboxGenerateKeyResponse(SandboxGenerateKeyResponse sandboxGenerateKeyResponse)
        : base(sandboxGenerateKeyResponse) { }
#pragma warning restore CS8618

    public SandboxGenerateKeyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SandboxGenerateKeyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SandboxGenerateKeyResponseFromRaw.FromRawUnchecked"/>
    public static SandboxGenerateKeyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SandboxGenerateKeyResponseFromRaw : IFromRawJson<SandboxGenerateKeyResponse>
{
    /// <inheritdoc/>
    public SandboxGenerateKeyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SandboxGenerateKeyResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public IReadOnlyList<string>? AllowedEndpoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowed_endpoints");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_endpoints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    /// <summary>
    /// The temporary sandbox API key.
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    public long? RequestsRemaining
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("requests_remaining");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requests_remaining", value);
        }
    }

    public string? SignupUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signup_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signup_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedEndpoints;
        _ = this.ExpiresAt;
        _ = this.Key;
        _ = this.RequestsRemaining;
        _ = this.SignupUrl;
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
