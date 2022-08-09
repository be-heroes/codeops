using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost
{
    public class MetricValueDto
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}