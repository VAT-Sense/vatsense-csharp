using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using VatSense.Core;

namespace VatSense.Models.Validate;

/// <summary>
/// Check whether a given VAT number or EORI number is valid against live government records.
///
/// <para>**VAT validation** checks against UK (HMRC), EU (VIES), Australia, Norway,
/// Switzerland, South Africa, and Brazil records.</para>
///
/// <para>**EORI validation** checks against UK and EU records only.</para>
///
/// <para>If the external validation service is temporarily unavailable, the API
/// returns a `412` error and the request does not count against your usage quota.</para>
///
/// <para>Provide either `vat_number` or `eori_number`, but not both.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ValidateCheckParams : ParamsBase
{
    /// <summary>
    /// The EORI number to validate. Must include the leading 2-character country
    /// code (e.g. "GB123456789123"). UK and EU only.
    /// </summary>
    public string? EoriNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("eori_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("eori_number", value);
        }
    }

    /// <summary>
    /// Your own VAT number. If supplied, the response will include a unique consultation
    /// number issued by the relevant authority (VIES or HMRC). Must include the leading
    /// 2-character country code.
    ///
    /// <para>Note: GB requester numbers only work for GB validations; EU requester
    /// numbers only work for EU validations. Cross-region is not supported. </para>
    /// </summary>
    public string? RequesterVatNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("requester_vat_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("requester_vat_number", value);
        }
    }

    /// <summary>
    /// The VAT number to validate. Must include the leading 2-character country code
    /// (e.g. "GB288305674", "FR12345678901").
    /// </summary>
    public string? VatNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("vat_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("vat_number", value);
        }
    }

    public ValidateCheckParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValidateCheckParams(ValidateCheckParams validateCheckParams)
        : base(validateCheckParams) { }
#pragma warning restore CS8618

    public ValidateCheckParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValidateCheckParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ValidateCheckParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(ValidateCheckParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/validate")
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
