using System.ComponentModel.DataAnnotations;
using BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKey
    {
        bool IsPrivate { get; }

        bool IsSupportedAlgorithm(IAlgorithm algorithm);

        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}