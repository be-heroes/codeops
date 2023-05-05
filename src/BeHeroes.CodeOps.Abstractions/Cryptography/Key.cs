using System.ComponentModel.DataAnnotations;
using BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms;
using Microsoft.IdentityModel.Tokens;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class Key : SecurityKey, IValidatableObject, IKey
    {
        protected readonly byte[] _rawData = Array.Empty<byte>();

        public bool IsPrivate { get; init; }

        protected Key(byte[] rawData, bool isPrivate = true)
        {
            _rawData = rawData;
            IsPrivate = isPrivate;
        }

        public virtual bool IsSupportedAlgorithm(IAlgorithm algorithm)
        {
            return IsSupportedAlgorithm(algorithm.Identifier);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (_rawData.Length == 0)
                yield return new ValidationResult("Key is not initialized");
        }
    }
}