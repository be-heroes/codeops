﻿using Microsoft.Extensions.Options;

using Amazon.Runtime.CredentialManagement;

using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed class RegisterProfileCommandHandler : AwsCommandHandler<RegisterProfileCommand, Task>
    {
        private readonly CredentialProfileStoreChain _credentialProfileStoreChain;

        public RegisterProfileCommandHandler(IOptions<AwsFacadeOptions> options) : base(new AwsClientFactory(options))
        {
            _credentialProfileStoreChain = new CredentialProfileStoreChain(options.Value.ProfilesLocation);
        }

        public override Task<Task> Handle(RegisterProfileCommand command, CancellationToken cancellationToken = default)
        {
            var profileOptions = new CredentialProfileOptions
            {
                SourceProfile = command.Profile.SourceProfile,
                RoleArn = command.Profile.RoleArn,
                AccessKey = command.AccessKey,
                SecretKey = command.SecretKey
            };

            var credentialProfile = new CredentialProfile(command.Profile.Name, profileOptions);

            _credentialProfileStoreChain.RegisterProfile(credentialProfile);

            return Task.FromResult(Task.CompletedTask);
        }
    }
}
