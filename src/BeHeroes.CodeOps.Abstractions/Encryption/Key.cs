using System.ComponentModel.DataAnnotations;

namespace BeHeroes.CodeOps.Abstractions.Encryption
{
    public abstract class Key : SignatureProvider, IValidatableObject
    {
        protected byte[]? _rawData;

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}