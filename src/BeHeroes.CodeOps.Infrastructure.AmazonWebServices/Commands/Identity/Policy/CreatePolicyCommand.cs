using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed record CreatePolicyCommand : AwsCommand<ManagedPolicyDto>
    {
        [JsonPropertyName("policyName")]
        public required string PolicyName { get; init; }

        [JsonPropertyName("policyDocument")]
        public required string PolicyDocument { get; init; }

        [SetsRequiredMembers]
        public CreatePolicyCommand(string policyName, string policyDocument)
        {
            PolicyName = policyName;
            PolicyDocument = policyDocument;
        }
    }
}