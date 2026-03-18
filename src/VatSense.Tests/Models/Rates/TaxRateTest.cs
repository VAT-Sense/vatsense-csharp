using System.Text.Json;
using VatSense.Core;
using VatSense.Exceptions;
using VatSense.Models.Rates;

namespace VatSense.Tests.Models.Rates;

public class TaxRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxRate
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        string expectedClass = "standard";
        string expectedDescription = "";
        ApiEnum<string, TaxRateObject> expectedObject = TaxRateObject.TaxRate;
        double expectedRate = 20;
        Types expectedTypes = false;

        Assert.Equal(expectedClass, model.Class);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedObject, model.Object);
        Assert.Equal(expectedRate, model.Rate);
        Assert.Equal(expectedTypes, model.Types);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TaxRate
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxRate>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TaxRate
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxRate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClass = "standard";
        string expectedDescription = "";
        ApiEnum<string, TaxRateObject> expectedObject = TaxRateObject.TaxRate;
        double expectedRate = 20;
        Types expectedTypes = false;

        Assert.Equal(expectedClass, deserialized.Class);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedObject, deserialized.Object);
        Assert.Equal(expectedRate, deserialized.Rate);
        Assert.Equal(expectedTypes, deserialized.Types);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TaxRate
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TaxRate { };

        Assert.Null(model.Class);
        Assert.False(model.RawData.ContainsKey("class"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.Types);
        Assert.False(model.RawData.ContainsKey("types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TaxRate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TaxRate
        {
            // Null should be interpreted as omitted for these properties
            Class = null,
            Description = null,
            Object = null,
            Rate = null,
            Types = null,
        };

        Assert.Null(model.Class);
        Assert.False(model.RawData.ContainsKey("class"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Object);
        Assert.False(model.RawData.ContainsKey("object"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.Types);
        Assert.False(model.RawData.ContainsKey("types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TaxRate
        {
            // Null should be interpreted as omitted for these properties
            Class = null,
            Description = null,
            Object = null,
            Rate = null,
            Types = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TaxRate
        {
            Class = "standard",
            Description = "",
            Object = TaxRateObject.TaxRate,
            Rate = 20,
            Types = false,
        };

        TaxRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TaxRateObjectTest : TestBase
{
    [Theory]
    [InlineData(TaxRateObject.TaxRate)]
    public void Validation_Works(TaxRateObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxRateObject> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxRateObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<VatSenseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TaxRateObject.TaxRate)]
    public void SerializationRoundtrip_Works(TaxRateObject rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxRateObject> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxRateObject>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxRateObject>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxRateObject>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypesTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Types value = "string";
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Types value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Types value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Types>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Types value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Types>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
