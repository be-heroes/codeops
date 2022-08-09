using Amazon.IdentityManagement.Model;
using AutoMapper;
using BeHeroes.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Identity.Role;

namespace BeHeroes.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters
{
    public class RoleToRoleDtoConverter : ITypeConverter<Role, RoleDto>
    {
        public RoleDto Convert(Role source, RoleDto destination, ResolutionContext context)
        {
            destination ??= new RoleDto();

            destination.RoleId = source.RoleId;
            destination.RoleName = source.RoleName;
            destination.Path = source.Path;
            destination.MaxSessionDuration = source.MaxSessionDuration;
            destination.Arn = source.Arn;
            destination.AssumeRolePolicyDocument = source.AssumeRolePolicyDocument;
            destination.Description = source.Description;

            return destination;
        }
    }
}