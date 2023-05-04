using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class UpdateRoleCommandHandler : AwsCommandHandler<UpdateRoleCommand, Task>
    {
        public UpdateRoleCommandHandler(IAwsClientFactory awsClientFactory) : base(awsClientFactory)
        { }

        public async override Task<Task> Handle(UpdateRoleCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate);

            var request = new UpdateRoleRequest()
            {
                RoleName = command.RoleName
            };

            if (!string.IsNullOrEmpty(command.Description))
            {
                request.Description = command.Description;
            }

            try
            {
                await client.UpdateRoleAsync(request, cancellationToken);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return Task.CompletedTask;
        }
    }
}