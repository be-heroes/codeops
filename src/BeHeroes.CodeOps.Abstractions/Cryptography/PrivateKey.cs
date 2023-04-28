using System.ComponentModel.DataAnnotations;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class PrivateKey : Key
    {
        protected readonly byte[] _keyData;

        public override int KeySize => _keyData.Length;

        protected PrivateKey(byte[] rawKey){
            _keyData = rawKey;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(KeySize == 0)
                yield return new ValidationResult("Key is not initialized");
        }
    }
}