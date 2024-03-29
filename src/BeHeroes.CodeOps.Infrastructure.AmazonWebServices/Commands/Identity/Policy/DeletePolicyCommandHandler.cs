﻿using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed class DeletePolicyCommandHandler : AwsCommandHandler<DeletePolicyCommand, Task>
    {
        public DeletePolicyCommandHandler(IAwsClientFactory awsClientFactory) : base(awsClientFactory)
        { }

        public async override Task<Task> Handle(DeletePolicyCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate);

            var request = new DeletePolicyRequest()
            {
                PolicyArn = command.PolicyArn
            };

            try
            {
                await client.DeletePolicyAsync(request, cancellationToken);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return Task.CompletedTask;
        }
    }
}