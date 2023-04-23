namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity
{
    public sealed class AwsProfile : IAwsProfile
    {
        public string SourceProfile { get; init; }

        public string Name { get; init; }

        public string RoleArn { get; init; }
        
        public AwsProfile(string sourceProfile, string name, string roleArn)
        {
            SourceProfile = sourceProfile;
            Name = name;
            RoleArn = roleArn;
        }
    }
}
