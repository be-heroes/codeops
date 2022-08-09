using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost
{
    public sealed class GetMonthlyTotalCostCommand : AwsCommand<IEnumerable<CostDto>>
    {
        [JsonPropertyName("accountIdentifier")]
        public string AccountIdentifier { get; init; }

        public GetMonthlyTotalCostCommand(string accountIdentifier = default)
        {
            AccountIdentifier = accountIdentifier;
        }
    }
}