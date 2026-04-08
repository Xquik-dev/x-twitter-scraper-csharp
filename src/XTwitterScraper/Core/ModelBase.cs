using System.Text.Json;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Account;
using XTwitterScraper.Models.Compose;
using XTwitterScraper.Models.Draws;
using XTwitterScraper.Models.Radar;
using XTwitterScraper.Models.Subscribe;
using Drafts = XTwitterScraper.Models.Drafts;
using Extractions = XTwitterScraper.Models.Extractions;
using Tickets = XTwitterScraper.Models.Support.Tickets;
using Tweets = XTwitterScraper.Models.X.Tweets;
using X = XTwitterScraper.Models.X;

namespace XTwitterScraper.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, ErrorError>(),
            new ApiEnumConverter<string, EventType>(),
            new ApiEnumConverter<string, Plan>(),
            new ApiEnumConverter<string, Locale>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Step>(),
            new ApiEnumConverter<string, Goal>(),
            new ApiEnumConverter<string, MediaType>(),
            new ApiEnumConverter<string, Drafts::Goal>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, Extractions::ExtractionJobStatus>(),
            new ApiEnumConverter<string, Extractions::ExtractionJobToolType>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunResponseToolType>(),
            new ApiEnumConverter<string, Extractions::Status>(),
            new ApiEnumConverter<string, Extractions::ToolType>(),
            new ApiEnumConverter<string, Extractions::ExtractionEstimateCostParamsToolType>(),
            new ApiEnumConverter<string, Extractions::Format>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunParamsToolType>(),
            new ApiEnumConverter<string, Format>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, X::Type>(),
            new ApiEnumConverter<string, Tweets::Type>(),
            new ApiEnumConverter<string, Tweets::QueryType>(),
            new ApiEnumConverter<string, Tickets::Status>(),
        },
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
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="XTwitterScraperInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
