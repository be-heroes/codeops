using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using System.Text.Json.Serialization;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed class CreatePolicyCommand : AwsCommand<ManagedPolicyDto>
    {
        [JsonPropertyName("policyName")]
        public string PolicyName { get; init; }

        [JsonPropertyName("policyDocument")]
        public string PolicyDocument { get; init; }

        public CreatePolicyCommand(string policyName, string policyDocument)
        {
            PolicyName = policyName;
            PolicyDocument = policyDocument;
        }
    }
}