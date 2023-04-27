using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity
{
    public sealed class AwsProfile : IAwsProfile
    {
        public required string Name { get; init; }

        public required string SourceProfile { get; init; }

        public required string RoleArn { get; init; }
        
        [SetsRequiredMembers]
        public AwsProfile(string name, string sourceProfile, string roleArn)
        {
            SourceProfile = sourceProfile;
            Name = name;
            RoleArn = roleArn;
        }
    }
}
