using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared
{
    public sealed class EnvironmentDto : AdoDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}