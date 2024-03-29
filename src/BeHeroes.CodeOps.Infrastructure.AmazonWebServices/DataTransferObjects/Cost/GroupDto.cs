using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost
{
    public class GroupDto
    {
        [JsonPropertyName("keys")]
        public IEnumerable<string>? Keys { get; set; }

        [JsonPropertyName("metrics")]
        public IEnumerable<KeyValuePair<string, MetricValueDto>>? Metrics { get; set; }
    }
}