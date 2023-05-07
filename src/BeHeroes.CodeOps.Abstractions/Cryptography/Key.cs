using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class Key : SecurityKey, IValidatableObject, IKey
    {
        protected readonly byte[] _rawData;

        protected readonly int _keySize;

        public override int KeySize => _keySize;

        public bool IsPrivate { get; init; }

        protected Key(byte[] rawData, int keySize = 256, bool isPrivate = true)
        {
            _rawData = rawData;
            _keySize = keySize;
            IsPrivate = isPrivate;
        }

        public virtual bool IsSupportedAlgorithm(IAlgorithm algorithm)
        {
            return IsSupportedAlgorithm(algorithm.Identifier);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (_rawData == null || _rawData.Length == 0)
                yield return new ValidationResult("Key is not initialized");
        }
    }
}