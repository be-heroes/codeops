using Amazon.Runtime;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Identity;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories
{
    public interface IAwsClientFactory
    {
        T Create<T>(IAwsProfile assumeProfile = default) where T : IAmazonService;
    }
}
