using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Vatsense.Core;

namespace Vatsense.Models.Rates;

/// <summary>
/// Get detailed tax rate information for a location, including all applicable rate
/// classes (standard, reduced, zero, etc.).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RateDetailsParams : ParamsBase
{
    /// <summary>
    /// A 2-character ISO 3166-1 alpha-2 country code (e.g. "GB", "FR").
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("country_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("country_code", value);
        }
    }

    /// <summary>
    /// Filter results by EU membership. Use 1 for EU countries only, 0 for non-EU only.
    /// </summary>
    public bool? Eu
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("eu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("eu", value);
        }
    }

    /// <summary>
    /// An IPv4 or IPv6 address. If provided, the country will be determined from
    /// the IP address.
    /// </summary>
    public string? IPAddress
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("ip_address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("ip_address", value);
        }
    }

    /// <summary>
    /// A historical date to retrieve rates for (format "YYYY-MM-DD HH:MM:SS"). Must
    /// be a past date.
    /// </summary>
    public DateTimeOffset? Period
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("period");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("period", value);
        }
    }

    /// <summary>
    /// A 2-character province code (e.g. "NU", "NT"). If providing a province code,
    /// you must also provide the relevant country_code.
    /// </summary>
    public string? ProvinceCode
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("province_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("province_code", value);
        }
    }

    /// <summary>
    /// The product type to find the applicable rate for. See the /rates/types endpoint
    /// for a full list of valid values.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("type", value);
        }
    }

    public RateDetailsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateDetailsParams(RateDetailsParams rateDetailsParams)
        : base(rateDetailsParams) { }
#pragma warning restore CS8618

    public RateDetailsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateDetailsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RateDetailsParams FromRawUnchecked(
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

    public virtual bool Equals(RateDetailsParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/rates/tax_rate")
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
