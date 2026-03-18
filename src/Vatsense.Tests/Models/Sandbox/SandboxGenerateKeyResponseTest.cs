using System;
using System.Collections.Generic;
using System.Text.Json;
using Vatsense.Core;
using Vatsense.Models.Sandbox;

namespace Vatsense.Tests.Models.Sandbox;

public class SandboxGenerateKeyResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SandboxGenerateKeyResponse
        {
            Code = 201,
            Data = new()
            {
                AllowedEndpoints =
                [
                    "GET /1.0",
                    "GET /1.0/rates",
                    "GET /1.0/rates/rate",
                    "GET /1.0/rates/tax_rate",
                    "GET /1.0/rates/types",
                    "GET /1.0/rates/price",
                    "GET /1.0/countries",
                    "GET /1.0/countries/country",
                    "GET /1.0/currency",
                    "GET /1.0/currency/convert",
                    "GET /1.0/validate",
                    "GET /1.0/usage",
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Key = "tmp_abc123def456",
                RequestsRemaining = 50,
                SignupUrl = "https://vatsense.com",
            },
            Success = true,
        };

        long expectedCode = 201;
        Data expectedData = new()
        {
            AllowedEndpoints =
            [
                "GET /1.0",
                "GET /1.0/rates",
                "GET /1.0/rates/rate",
                "GET /1.0/rates/tax_rate",
                "GET /1.0/rates/types",
                "GET /1.0/rates/price",
                "GET /1.0/countries",
                "GET /1.0/countries/country",
                "GET /1.0/currency",
                "GET /1.0/currency/convert",
                "GET /1.0/validate",
                "GET /1.0/usage",
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Key = "tmp_abc123def456",
            RequestsRemaining = 50,
            SignupUrl = "https://vatsense.com",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SandboxGenerateKeyResponse
        {
            Code = 201,
            Data = new()
            {
                AllowedEndpoints =
                [
                    "GET /1.0",
                    "GET /1.0/rates",
                    "GET /1.0/rates/rate",
                    "GET /1.0/rates/tax_rate",
                    "GET /1.0/rates/types",
                    "GET /1.0/rates/price",
                    "GET /1.0/countries",
                    "GET /1.0/countries/country",
                    "GET /1.0/currency",
                    "GET /1.0/currency/convert",
                    "GET /1.0/validate",
                    "GET /1.0/usage",
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Key = "tmp_abc123def456",
                RequestsRemaining = 50,
                SignupUrl = "https://vatsense.com",
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SandboxGenerateKeyResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SandboxGenerateKeyResponse
        {
            Code = 201,
            Data = new()
            {
                AllowedEndpoints =
                [
                    "GET /1.0",
                    "GET /1.0/rates",
                    "GET /1.0/rates/rate",
                    "GET /1.0/rates/tax_rate",
                    "GET /1.0/rates/types",
                    "GET /1.0/rates/price",
                    "GET /1.0/countries",
                    "GET /1.0/countries/country",
                    "GET /1.0/currency",
                    "GET /1.0/currency/convert",
                    "GET /1.0/validate",
                    "GET /1.0/usage",
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Key = "tmp_abc123def456",
                RequestsRemaining = 50,
                SignupUrl = "https://vatsense.com",
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SandboxGenerateKeyResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCode = 201;
        Data expectedData = new()
        {
            AllowedEndpoints =
            [
                "GET /1.0",
                "GET /1.0/rates",
                "GET /1.0/rates/rate",
                "GET /1.0/rates/tax_rate",
                "GET /1.0/rates/types",
                "GET /1.0/rates/price",
                "GET /1.0/countries",
                "GET /1.0/countries/country",
                "GET /1.0/currency",
                "GET /1.0/currency/convert",
                "GET /1.0/validate",
                "GET /1.0/usage",
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Key = "tmp_abc123def456",
            RequestsRemaining = 50,
            SignupUrl = "https://vatsense.com",
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SandboxGenerateKeyResponse
        {
            Code = 201,
            Data = new()
            {
                AllowedEndpoints =
                [
                    "GET /1.0",
                    "GET /1.0/rates",
                    "GET /1.0/rates/rate",
                    "GET /1.0/rates/tax_rate",
                    "GET /1.0/rates/types",
                    "GET /1.0/rates/price",
                    "GET /1.0/countries",
                    "GET /1.0/countries/country",
                    "GET /1.0/currency",
                    "GET /1.0/currency/convert",
                    "GET /1.0/validate",
                    "GET /1.0/usage",
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Key = "tmp_abc123def456",
                RequestsRemaining = 50,
                SignupUrl = "https://vatsense.com",
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SandboxGenerateKeyResponse { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SandboxGenerateKeyResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SandboxGenerateKeyResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Data = null,
            Success = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SandboxGenerateKeyResponse
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Data = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SandboxGenerateKeyResponse
        {
            Code = 201,
            Data = new()
            {
                AllowedEndpoints =
                [
                    "GET /1.0",
                    "GET /1.0/rates",
                    "GET /1.0/rates/rate",
                    "GET /1.0/rates/tax_rate",
                    "GET /1.0/rates/types",
                    "GET /1.0/rates/price",
                    "GET /1.0/countries",
                    "GET /1.0/countries/country",
                    "GET /1.0/currency",
                    "GET /1.0/currency/convert",
                    "GET /1.0/validate",
                    "GET /1.0/usage",
                ],
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Key = "tmp_abc123def456",
                RequestsRemaining = 50,
                SignupUrl = "https://vatsense.com",
            },
            Success = true,
        };

        SandboxGenerateKeyResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            AllowedEndpoints =
            [
                "GET /1.0",
                "GET /1.0/rates",
                "GET /1.0/rates/rate",
                "GET /1.0/rates/tax_rate",
                "GET /1.0/rates/types",
                "GET /1.0/rates/price",
                "GET /1.0/countries",
                "GET /1.0/countries/country",
                "GET /1.0/currency",
                "GET /1.0/currency/convert",
                "GET /1.0/validate",
                "GET /1.0/usage",
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Key = "tmp_abc123def456",
            RequestsRemaining = 50,
            SignupUrl = "https://vatsense.com",
        };

        List<string> expectedAllowedEndpoints =
        [
            "GET /1.0",
            "GET /1.0/rates",
            "GET /1.0/rates/rate",
            "GET /1.0/rates/tax_rate",
            "GET /1.0/rates/types",
            "GET /1.0/rates/price",
            "GET /1.0/countries",
            "GET /1.0/countries/country",
            "GET /1.0/currency",
            "GET /1.0/currency/convert",
            "GET /1.0/validate",
            "GET /1.0/usage",
        ];
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedKey = "tmp_abc123def456";
        long expectedRequestsRemaining = 50;
        string expectedSignupUrl = "https://vatsense.com";

        Assert.NotNull(model.AllowedEndpoints);
        Assert.Equal(expectedAllowedEndpoints.Count, model.AllowedEndpoints.Count);
        for (int i = 0; i < expectedAllowedEndpoints.Count; i++)
        {
            Assert.Equal(expectedAllowedEndpoints[i], model.AllowedEndpoints[i]);
        }
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedRequestsRemaining, model.RequestsRemaining);
        Assert.Equal(expectedSignupUrl, model.SignupUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            AllowedEndpoints =
            [
                "GET /1.0",
                "GET /1.0/rates",
                "GET /1.0/rates/rate",
                "GET /1.0/rates/tax_rate",
                "GET /1.0/rates/types",
                "GET /1.0/rates/price",
                "GET /1.0/countries",
                "GET /1.0/countries/country",
                "GET /1.0/currency",
                "GET /1.0/currency/convert",
                "GET /1.0/validate",
                "GET /1.0/usage",
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Key = "tmp_abc123def456",
            RequestsRemaining = 50,
            SignupUrl = "https://vatsense.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            AllowedEndpoints =
            [
                "GET /1.0",
                "GET /1.0/rates",
                "GET /1.0/rates/rate",
                "GET /1.0/rates/tax_rate",
                "GET /1.0/rates/types",
                "GET /1.0/rates/price",
                "GET /1.0/countries",
                "GET /1.0/countries/country",
                "GET /1.0/currency",
                "GET /1.0/currency/convert",
                "GET /1.0/validate",
                "GET /1.0/usage",
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Key = "tmp_abc123def456",
            RequestsRemaining = 50,
            SignupUrl = "https://vatsense.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<string> expectedAllowedEndpoints =
        [
            "GET /1.0",
            "GET /1.0/rates",
            "GET /1.0/rates/rate",
            "GET /1.0/rates/tax_rate",
            "GET /1.0/rates/types",
            "GET /1.0/rates/price",
            "GET /1.0/countries",
            "GET /1.0/countries/country",
            "GET /1.0/currency",
            "GET /1.0/currency/convert",
            "GET /1.0/validate",
            "GET /1.0/usage",
        ];
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedKey = "tmp_abc123def456";
        long expectedRequestsRemaining = 50;
        string expectedSignupUrl = "https://vatsense.com";

        Assert.NotNull(deserialized.AllowedEndpoints);
        Assert.Equal(expectedAllowedEndpoints.Count, deserialized.AllowedEndpoints.Count);
        for (int i = 0; i < expectedAllowedEndpoints.Count; i++)
        {
            Assert.Equal(expectedAllowedEndpoints[i], deserialized.AllowedEndpoints[i]);
        }
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedRequestsRemaining, deserialized.RequestsRemaining);
        Assert.Equal(expectedSignupUrl, deserialized.SignupUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            AllowedEndpoints =
            [
                "GET /1.0",
                "GET /1.0/rates",
                "GET /1.0/rates/rate",
                "GET /1.0/rates/tax_rate",
                "GET /1.0/rates/types",
                "GET /1.0/rates/price",
                "GET /1.0/countries",
                "GET /1.0/countries/country",
                "GET /1.0/currency",
                "GET /1.0/currency/convert",
                "GET /1.0/validate",
                "GET /1.0/usage",
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Key = "tmp_abc123def456",
            RequestsRemaining = 50,
            SignupUrl = "https://vatsense.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.AllowedEndpoints);
        Assert.False(model.RawData.ContainsKey("allowed_endpoints"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.RequestsRemaining);
        Assert.False(model.RawData.ContainsKey("requests_remaining"));
        Assert.Null(model.SignupUrl);
        Assert.False(model.RawData.ContainsKey("signup_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            AllowedEndpoints = null,
            ExpiresAt = null,
            Key = null,
            RequestsRemaining = null,
            SignupUrl = null,
        };

        Assert.Null(model.AllowedEndpoints);
        Assert.False(model.RawData.ContainsKey("allowed_endpoints"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.RequestsRemaining);
        Assert.False(model.RawData.ContainsKey("requests_remaining"));
        Assert.Null(model.SignupUrl);
        Assert.False(model.RawData.ContainsKey("signup_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            AllowedEndpoints = null,
            ExpiresAt = null,
            Key = null,
            RequestsRemaining = null,
            SignupUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            AllowedEndpoints =
            [
                "GET /1.0",
                "GET /1.0/rates",
                "GET /1.0/rates/rate",
                "GET /1.0/rates/tax_rate",
                "GET /1.0/rates/types",
                "GET /1.0/rates/price",
                "GET /1.0/countries",
                "GET /1.0/countries/country",
                "GET /1.0/currency",
                "GET /1.0/currency/convert",
                "GET /1.0/validate",
                "GET /1.0/usage",
            ],
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Key = "tmp_abc123def456",
            RequestsRemaining = 50,
            SignupUrl = "https://vatsense.com",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
