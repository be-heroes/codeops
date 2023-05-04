using BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKeyPair
    {
        IAlgorithm Algorithm { get; }

        IKey Private{ get; }

        IKey Public { get; }
    }
}
