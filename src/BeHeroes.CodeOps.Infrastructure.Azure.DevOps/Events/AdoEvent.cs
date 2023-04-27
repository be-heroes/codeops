using BeHeroes.CodeOps.Abstractions.Events;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Events
{
    public class AdoEvent : IIntegrationEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [JsonPropertyName("publisherId")]
        public string PublisherId { get; init; } = Assembly.GetExecutingAssembly().FullName ?? string.Empty;

        [JsonPropertyName("eventType")]
        public string EventType { get; init; } = nameof(AdoEvent);

        [JsonPropertyName("scope")]
        public string Scope { get; init; } = string.Empty;

        [JsonPropertyName("message")]
        public JsonElement? Message { get; init; }

        [JsonPropertyName("resource")]
        public JsonElement? Resource { get; init; }

        [JsonPropertyName("resourceVersion")]
        public string ResourceVersion { get; init; } = string.Empty;

        [JsonPropertyName("resourceContainers")]
        public JsonElement? ResourceContainers { get; init; }

        public string CorrelationId => Id;

        public DateTime CreationDate => DateTime.Now;

        public string SchemaVersion => "1";

        public string Type => EventType;

        public JsonElement? Payload => Resource;
    }
}
