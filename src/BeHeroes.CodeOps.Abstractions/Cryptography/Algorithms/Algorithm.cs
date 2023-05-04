using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public abstract class Algorithm : Disposable, IAlgorithm
    {
        public string Name { get; init; } = string.Empty;

        public abstract int GetKeySize();

        public abstract KeySizes[] GetLegalKeySizes();
    }
}