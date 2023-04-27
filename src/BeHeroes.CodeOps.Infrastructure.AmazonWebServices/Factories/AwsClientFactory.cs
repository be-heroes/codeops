using Microsoft.Extensions.Options;

using Amazon;
using Amazon.Runtime;

using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Security;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories
{
    public sealed class AwsClientFactory : IAwsClientFactory
    {
        private readonly IOptions<AwsFacadeOptions> _options;
        private readonly IAwsCredentialResolver _awsCredentialResolver;

        public AwsClientFactory(IOptions<AwsFacadeOptions> options, IAwsCredentialResolver? awsCredentialResolver = default)
        {
            _options = options;
            _awsCredentialResolver = awsCredentialResolver ?? new AwsCredentialResolver(_options);
        }

        public T Create<T>(IAwsProfile? assumeProfile = default) where T : IAmazonService
        {
            AWSCredentials sdkClientCredentials = _awsCredentialResolver.Resolve(_options.Value.Impersonate) ?? FallbackCredentialsFactory.GetCredentials();

            if (assumeProfile != null)
            {
                var assumeProfileCredentials = _awsCredentialResolver.Resolve(assumeProfile);

                if(assumeProfileCredentials != null)
                    sdkClientCredentials = new AssumeRoleAWSCredentials(sdkClientCredentials, assumeProfile.RoleArn, assumeProfileCredentials.Token);
            }

            var clientOfTConstructor = typeof(T).GetConstructor(new[] { typeof(AWSCredentials), typeof(RegionEndpoint) });

            if(clientOfTConstructor == null)
                throw new AwsFacadeException($"Unable to find suitable constructor for AWS client {nameof(T)}");

            var clientOfT = (T)clientOfTConstructor.Invoke(new object[] { sdkClientCredentials, RegionEndpoint.GetBySystemName(_options.Value.Region) });

            return clientOfT;
        }
    }
}
