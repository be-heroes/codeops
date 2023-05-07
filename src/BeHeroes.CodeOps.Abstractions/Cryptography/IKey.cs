using System.ComponentModel.DataAnnotations;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKey
    {
        bool IsPrivate { get; }

        int KeySize { get; }

        bool IsSupportedAlgorithm(IAlgorithm algorithm);

        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}