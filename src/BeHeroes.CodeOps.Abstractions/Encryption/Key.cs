using System.ComponentModel.DataAnnotations;

namespace BeHeroes.CodeOps.Abstractions.Encryption
{
    public abstract class Key : SignatureProvider, IValidatableObject
    {
        public byte[] Data {get; init;}

        public string? Identifier {get; init;}

        protected Key(byte[] rawData, string? identifier)
        {
            Data = rawData;
            Identifier = identifier;
        }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}