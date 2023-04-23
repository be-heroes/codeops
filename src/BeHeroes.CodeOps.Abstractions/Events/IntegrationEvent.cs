using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Abstractions.Events
{
    public class IntegrationEvent : IIntegrationEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; init; }

        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; init; }

        [JsonPropertyName("schemaVersion")]
        public string SchemaVersion { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("payload")]
        public JsonElement? Payload { get; init; }

        [JsonConstructor]
        public IntegrationEvent(string type, JsonElement? payload, string? correlationId = default, string schemaVersion = "1") : this(type, payload, correlationId, schemaVersion, Guid.NewGuid().ToString(), DateTime.UtcNow)
        {
        }

        public IntegrationEvent(string type, JsonElement? payload = default, string? correlationId = default, string schemaVersion = "1", string? id = default, DateTime creationDate = default)
        {
            Type = type;
            Payload = payload;
            CorrelationId = correlationId ?? Guid.NewGuid().ToString();
            SchemaVersion = schemaVersion;
            Id = id ?? Guid.NewGuid().ToString();
            CreationDate = (creationDate != DateTime.MinValue) ? creationDate : DateTime.UtcNow;
        }
    }
}
