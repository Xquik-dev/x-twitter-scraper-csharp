using System.Text.Json;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;
using XTwitterScraper.Models.Account;
using XTwitterScraper.Models.Compose;
using XTwitterScraper.Models.Draws;
using XTwitterScraper.Models.Radar;
using XTwitterScraper.Models.Subscribe;
using XTwitterScraper.Models.X.Tweets;
using Drafts = XTwitterScraper.Models.Drafts;
using Events = XTwitterScraper.Models.Events;
using Extractions = XTwitterScraper.Models.Extractions;
using Integrations = XTwitterScraper.Models.Integrations;
using Monitors = XTwitterScraper.Models.Monitors;
using Tickets = XTwitterScraper.Models.Support.Tickets;
using Webhooks = XTwitterScraper.Models.Webhooks;
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
            new ApiEnumConverter<string, Monitors::MonitorEventType>(),
            new ApiEnumConverter<string, Monitors::MonitorCreateResponseEventType>(),
            new ApiEnumConverter<string, Monitors::MonitorRetrieveResponseEventType>(),
            new ApiEnumConverter<string, Monitors::MonitorUpdateResponseEventType>(),
            new ApiEnumConverter<string, Monitors::MonitorListResponseMonitorEventType>(),
            new ApiEnumConverter<string, Monitors::EventType>(),
            new ApiEnumConverter<string, Monitors::MonitorUpdateParamsEventType>(),
            new ApiEnumConverter<string, Events::Type>(),
            new ApiEnumConverter<string, Events::EventDetailType>(),
            new ApiEnumConverter<string, Events::EventRetrieveResponseType>(),
            new ApiEnumConverter<string, Events::EventListResponseEventType>(),
            new ApiEnumConverter<string, Events::EventType>(),
            new ApiEnumConverter<string, Extractions::ExtractionJobStatus>(),
            new ApiEnumConverter<string, Extractions::ExtractionJobToolType>(),
            new ApiEnumConverter<string, Extractions::ExtractionStatus>(),
            new ApiEnumConverter<string, Extractions::ExtractionToolType>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunResponseStatus>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunResponseToolType>(),
            new ApiEnumConverter<string, Extractions::Status>(),
            new ApiEnumConverter<string, Extractions::ToolType>(),
            new ApiEnumConverter<string, Extractions::ExtractionEstimateCostParamsToolType>(),
            new ApiEnumConverter<string, Extractions::Format>(),
            new ApiEnumConverter<string, Extractions::ExtractionRunParamsToolType>(),
            new ApiEnumConverter<string, Format>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Webhooks::WebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::WebhookCreateResponseEventType>(),
            new ApiEnumConverter<string, Webhooks::WebhookUpdateResponseEventType>(),
            new ApiEnumConverter<string, Webhooks::WebhookListResponseWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::EventType>(),
            new ApiEnumConverter<string, Webhooks::WebhookUpdateParamsEventType>(),
            new ApiEnumConverter<string, Integrations::IntegrationEventType>(),
            new ApiEnumConverter<string, Integrations::IntegrationType>(),
            new ApiEnumConverter<string, Integrations::IntegrationCreateResponseEventType>(),
            new ApiEnumConverter<string, Integrations::IntegrationCreateResponseType>(),
            new ApiEnumConverter<string, Integrations::IntegrationRetrieveResponseEventType>(),
            new ApiEnumConverter<string, Integrations::IntegrationRetrieveResponseType>(),
            new ApiEnumConverter<string, Integrations::IntegrationUpdateResponseEventType>(),
            new ApiEnumConverter<string, Integrations::IntegrationUpdateResponseType>(),
            new ApiEnumConverter<
                string,
                Integrations::IntegrationListResponseIntegrationEventType
            >(),
            new ApiEnumConverter<string, Integrations::IntegrationListResponseIntegrationType>(),
            new ApiEnumConverter<string, Integrations::EventType>(),
            new ApiEnumConverter<string, Integrations::Type>(),
            new ApiEnumConverter<string, Integrations::IntegrationUpdateParamsEventType>(),
            new ApiEnumConverter<string, X::Type>(),
            new ApiEnumConverter<string, QueryType>(),
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
