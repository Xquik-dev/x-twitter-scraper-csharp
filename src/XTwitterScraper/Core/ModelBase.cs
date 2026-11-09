using System.Text.Json;
using XTwitterScraper.Exceptions;

namespace XTwitterScraper.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase) { }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters = { new FrozenDictionaryConverterFactory(), new ApiEnumConverterFactory() },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <exception cref="XTwitterScraperInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
