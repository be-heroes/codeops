using Amazon.Runtime.CredentialManagement;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed class UnregisterProfileCommandHandler : AwsCommandHandler<UnregisterProfileCommand, Task>
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public UnregisterProfileCommandHandler(IOptions<AwsFacadeOptions> options) : base(new AwsClientFactory(options))
        {
            _credentialProfileStoreChain = new CredentialProfileStoreChain(options.Value.ProfilesLocation);
        }

        public override Task<Task> Handle(UnregisterProfileCommand command, CancellationToken cancellationToken = default)
        {
            _credentialProfileStoreChain.UnregisterProfile(command.ProfileName);

            return Task.FromResult(Task.CompletedTask);
        }
    }
}
