using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.DataTransferObjects.Shared
{
    public sealed class ChangeDto : AdoDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}