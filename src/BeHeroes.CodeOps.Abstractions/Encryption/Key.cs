using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace BeHeroes.CodeOps.Abstractions.Encryption
{
    public abstract class Key : SecurityKey, IValidatableObject
    {
        protected byte[]? _rawData;

        public override int KeySize => _rawData?.Length ?? 0;

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}