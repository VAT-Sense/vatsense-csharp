using System;
using VatSense.Models.Countries;

namespace VatSense.Tests.Models.Countries;

public class CountryListProvincesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CountryListProvincesParams { CountryCode = "CA" };

        string expectedCountryCode = "CA";

        Assert.Equal(expectedCountryCode, parameters.CountryCode);
    }

    [Fact]
    public void Url_Works()
    {
        CountryListProvincesParams parameters = new() { CountryCode = "CA" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri("https://api.vatsense.com/1.0/countries/provinces?country_code=CA"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CountryListProvincesParams { CountryCode = "CA" };

        CountryListProvincesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
