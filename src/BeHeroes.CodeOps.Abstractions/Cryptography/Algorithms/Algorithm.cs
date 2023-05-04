using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public abstract class Algorithm : Disposable, IAlgorithm
    {
        public string Name { get; init; } = string.Empty;

        public int KeySize { get; init; } = 256;

        public KeySizes[] LegalKeySizes { get; init; } = new KeySizes[]{ new KeySizes(256, 256, 0)};
    }
}