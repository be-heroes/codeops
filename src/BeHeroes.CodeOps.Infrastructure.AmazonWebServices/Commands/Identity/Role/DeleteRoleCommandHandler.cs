using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class DeleteRoleCommandHandler : AwsCommandHandler<DeleteRoleCommand, Task>
    {
        public DeleteRoleCommandHandler(IAwsClientFactory awsClientFactory) : base(awsClientFactory)
        { }

        public async override Task<Task> Handle(DeleteRoleCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate);

            var request = new DeleteRoleRequest()
            {
                RoleName = command.RoleName
            };

            try
            {
                await client.DeleteRoleAsync(request, cancellationToken);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return Task.CompletedTask;
        }
    }
}