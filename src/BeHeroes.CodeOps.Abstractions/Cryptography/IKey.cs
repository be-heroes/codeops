using System.ComponentModel.DataAnnotations;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKey
    {
        bool IsPrivate { get; }

        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}