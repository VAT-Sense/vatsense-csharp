using System;
using Vatsense.Models.Countries;

namespace Vatsense.Tests.Models.Countries;

public class CountryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CountryListParams { CountryCode = "GB", IPAddress = "86.27.166.97" };

        string expectedCountryCode = "GB";
        string expectedIPAddress = "86.27.166.97";

        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedIPAddress, parameters.IPAddress);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CountryListParams { };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawQueryData.ContainsKey("country_code"));
        Assert.Null(parameters.IPAddress);
        Assert.False(parameters.RawQueryData.ContainsKey("ip_address"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CountryListParams
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            IPAddress = null,
        };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawQueryData.ContainsKey("country_code"));
        Assert.Null(parameters.IPAddress);
        Assert.False(parameters.RawQueryData.ContainsKey("ip_address"));
    }

    [Fact]
    public void Url_Works()
    {
        CountryListParams parameters = new() { CountryCode = "GB", IPAddress = "86.27.166.97" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri(
                "https://api.vatsense.com/1.0/countries?country_code=GB&ip_address=86.27.166.97"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CountryListParams { CountryCode = "GB", IPAddress = "86.27.166.97" };

        CountryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
