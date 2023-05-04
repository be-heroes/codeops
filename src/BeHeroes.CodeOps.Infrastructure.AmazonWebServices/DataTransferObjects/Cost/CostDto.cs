using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost
{
    public class CostDto
    {
        [JsonPropertyName("dimensionValueAttributes")]
        public IEnumerable<DimensionValueAttributeDto>? DimensionValueAttributes { get; set; }

        [JsonPropertyName("resultByTime")]
        public IEnumerable<ResultByTimeDto>? ResultsByTime { get; set; }
    }
}