using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Security
{
    public interface IAwsCredentialResolver
    {
        AwsCredentials? Resolve(IAwsProfile? profile);
    }
}
