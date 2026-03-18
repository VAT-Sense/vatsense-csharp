using System;
using VatSense.Models.Validate;

namespace VatSense.Tests.Models.Validate;

public class ValidateCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ValidateCheckParams
        {
            EoriNumber = "GB123456789123",
            RequesterVatNumber = "GB288305674",
            VatNumber = "GB288305674",
        };

        string expectedEoriNumber = "GB123456789123";
        string expectedRequesterVatNumber = "GB288305674";
        string expectedVatNumber = "GB288305674";

        Assert.Equal(expectedEoriNumber, parameters.EoriNumber);
        Assert.Equal(expectedRequesterVatNumber, parameters.RequesterVatNumber);
        Assert.Equal(expectedVatNumber, parameters.VatNumber);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ValidateCheckParams { };

        Assert.Null(parameters.EoriNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("eori_number"));
        Assert.Null(parameters.RequesterVatNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("requester_vat_number"));
        Assert.Null(parameters.VatNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("vat_number"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ValidateCheckParams
        {
            // Null should be interpreted as omitted for these properties
            EoriNumber = null,
            RequesterVatNumber = null,
            VatNumber = null,
        };

        Assert.Null(parameters.EoriNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("eori_number"));
        Assert.Null(parameters.RequesterVatNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("requester_vat_number"));
        Assert.Null(parameters.VatNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("vat_number"));
    }

    [Fact]
    public void Url_Works()
    {
        ValidateCheckParams parameters = new()
        {
            EoriNumber = "GB123456789123",
            RequesterVatNumber = "GB288305674",
            VatNumber = "GB288305674",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.Equal(
            new Uri(
                "https://api.vatsense.com/1.0/validate?eori_number=GB123456789123&requester_vat_number=GB288305674&vat_number=GB288305674"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ValidateCheckParams
        {
            EoriNumber = "GB123456789123",
            RequesterVatNumber = "GB288305674",
            VatNumber = "GB288305674",
        };

        ValidateCheckParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
