﻿using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using AutoMapper;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Factories;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Policy
{
    public sealed class CreatePolicyCommandHandler : AwsCommandHandler<CreatePolicyCommand, ManagedPolicyDto>
    {
        private readonly IMapper _mapper;

        public CreatePolicyCommandHandler(IAwsClientFactory awsClientFactory, IMapper mapper) : base(awsClientFactory)
        {
            _mapper = mapper;
        }

        public async override Task<ManagedPolicyDto> Handle(CreatePolicyCommand command, CancellationToken cancellationToken = default)
        {
            using var client = _awsClientFactory.Create<AmazonIdentityManagementServiceClient>(command.Impersonate);

            var request = new CreatePolicyRequest()
            {
                PolicyName = command.PolicyName,
                PolicyDocument = command.PolicyDocument
            };

            ManagedPolicyDto result;

            try
            {
                result = _mapper.Map<ManagedPolicy, ManagedPolicyDto>((await client.CreatePolicyAsync(request, cancellationToken)).Policy);
            }
            catch (AmazonServiceException e)
            {
                throw new AwsFacadeException(e.Message, e);
            }

            return result;
        }
    }
}