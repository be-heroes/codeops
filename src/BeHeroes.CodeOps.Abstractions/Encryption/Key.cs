using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace BeHeroes.CodeOps.Abstractions.Encryption
{
    public abstract class Key : SecurityKey, IValidatableObject
    {
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}