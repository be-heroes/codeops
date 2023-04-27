using Amazon.Runtime;
using System.Diagnostics.CodeAnalysis;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public sealed record AwsCredentials : IAwsCredentials
    {
        public required string AccessKey { get; init; }

        public required string SecretKey { get; init; }

        public required string Token { get; init; }

        [SetsRequiredMembers]
        public AwsCredentials(string accessKey, string secretKey, string token)
        {
            AccessKey = accessKey;
            SecretKey = secretKey;
            Token = token;
        }

        public static implicit operator ImmutableCredentials(AwsCredentials awsCredentials) => new ImmutableCredentials(awsCredentials.AccessKey, awsCredentials.SecretKey, awsCredentials.Token);
        public static explicit operator AwsCredentials(ImmutableCredentials awsCredentials) => new AwsCredentials(awsCredentials.AccessKey, awsCredentials.SecretKey, awsCredentials.Token);

        public static implicit operator AWSCredentials(AwsCredentials c) => !string.IsNullOrEmpty(c.Token) ? new SessionAWSCredentials(c.AccessKey, c.SecretKey, c.Token) : new BasicAWSCredentials(c.AccessKey, c.SecretKey);
        public static explicit operator AwsCredentials(AWSCredentials c) => (AwsCredentials)c.GetCredentials();
    }
}
