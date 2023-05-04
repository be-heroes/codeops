using System.ComponentModel.DataAnnotations;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKey
    {
        bool IsPrivate { get; init; }

        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}