using Microsoft.Extensions.Options;

using Amazon.Runtime.CredentialManagement;

using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public sealed class AwsCredentialResolver : IAwsCredentialResolver
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public AwsCredentialResolver(IOptions<AwsFacadeOptions> options) : this(options.Value.ProfilesLocation)
        {
            
        }

        public AwsCredentialResolver(string? profilesLocation)
        {
            _credentialProfileStoreChain = !string.IsNullOrEmpty(profilesLocation) ? new CredentialProfileStoreChain(profilesLocation) : new CredentialProfileStoreChain();
        }

        public AwsCredentials? Resolve(IAwsProfile? profile = default)
        {
            if (string.IsNullOrEmpty(profile?.Name) || !_credentialProfileStoreChain.TryGetAWSCredentials(profile?.Name, out var credentialsHandle))
            {
                return null;
            }

            return (AwsCredentials)credentialsHandle.GetCredentials();
        }
    }
}
