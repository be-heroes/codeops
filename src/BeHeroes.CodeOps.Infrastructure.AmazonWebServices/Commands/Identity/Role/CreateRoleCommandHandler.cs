﻿using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using AutoMapper;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Role;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class CreateRoleCommandHandler : AwsCommandHandler<CreateRoleCommand, RoleDto>
    {
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IAwsClientFactory awsClientFactory, IMapper mapper) : base(awsClientFactory)
        {
            _mapper = mapper;
        }

        public async override Task<RoleDto> Handle(CreateRoleCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate);

            var request = new CreateRoleRequest()
            {
                RoleName = command.RoleName,
                AssumeRolePolicyDocument = command.PolicyDocument,
                Description = command.Description,
                Tags = command.Tags?.Select(tag => new Tag() { Key = tag.Key, Value = tag.Value }).ToList()
            };

            RoleDto result;

            try
            {
                result = _mapper.Map<Amazon.IdentityManagement.Model.Role, RoleDto>((await client.CreateRoleAsync(request, cancellationToken)).Role);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return result;
        }
    }
}