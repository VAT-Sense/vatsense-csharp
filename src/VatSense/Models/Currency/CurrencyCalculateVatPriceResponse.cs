using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using VatSense.Core;

namespace VatSense.Models.Currency;

[JsonConverter(
    typeof(JsonModelConverter<
        CurrencyCalculateVatPriceResponse,
        CurrencyCalculateVatPriceResponseFromRaw
    >)
)]
public sealed record class CurrencyCalculateVatPriceResponse : JsonModel
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

    public VatPrice? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VatPrice>("data");
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

    public CurrencyCalculateVatPriceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyCalculateVatPriceResponse(
        CurrencyCalculateVatPriceResponse currencyCalculateVatPriceResponse
    )
        : base(currencyCalculateVatPriceResponse) { }
#pragma warning restore CS8618

    public CurrencyCalculateVatPriceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyCalculateVatPriceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyCalculateVatPriceResponseFromRaw.FromRawUnchecked"/>
    public static CurrencyCalculateVatPriceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrencyCalculateVatPriceResponseFromRaw : IFromRawJson<CurrencyCalculateVatPriceResponse>
{
    /// <inheritdoc/>
    public CurrencyCalculateVatPriceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CurrencyCalculateVatPriceResponse.FromRawUnchecked(rawData);
}
