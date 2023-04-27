using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost
{
    public sealed record GetMonthlyTotalCostCommand : AwsCommand<IEnumerable<CostDto>>
    {
        [JsonPropertyName("accountIdentifier")]
        public string? AccountIdentifier { get; init; }

        [SetsRequiredMembers]
        public GetMonthlyTotalCostCommand(string? accountIdentifier = default)
        {
            AccountIdentifier = accountIdentifier;
        }
    }
}