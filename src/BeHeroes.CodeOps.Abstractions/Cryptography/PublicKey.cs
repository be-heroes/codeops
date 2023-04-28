using System.ComponentModel.DataAnnotations;

using ProtoBuf;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    [ProtoContract(IgnoreUnknownSubTypes = true)]
    public sealed class PublicKey : Key
    {
        [ProtoMember(1)]
        public override string KeyId {
            get {
                return base.KeyId;
            }
            set{
                base.KeyId = value;
            }
        }

        [ProtoMember(2)]
        public byte[]? KeyData
        {
            get; init;
        }
                
        public override int KeySize => KeyData?.Length ?? 0;

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {   
            if(KeyData == null || KeySize == 0)
                yield return new ValidationResult("KeyData is not initialized");

            if(string.IsNullOrEmpty(KeyId))
                yield return new ValidationResult("KeyId is not initialized");
        }
    }
}