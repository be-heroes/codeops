using Amazon.IdentityManagement.Model;
using Amazon.SimpleSystemsManagement.Model;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Policy;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Role;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.SimpleSystems.Parameter;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Mapping.Profiles
{
    public sealed class DefaultProfile : AutoMapper.Profile
    {
        public DefaultProfile()
        {
            CreateMap<Parameter, ParameterDto>()
            .ConvertUsing<ParameterToParameterDtoConverter>();

            CreateMap<ManagedPolicy, ManagedPolicyDto>()
            .ConvertUsing<ManagedPolicyToManagedPolicyDtoConverter>();

            CreateMap<Role, RoleDto>()
            .ConvertUsing<RoleToRoleDtoConverter>();
        }
    }
}
