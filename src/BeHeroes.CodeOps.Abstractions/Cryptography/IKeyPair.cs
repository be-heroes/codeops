using BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKeyPair
    {
        IAlgorithm Algorithm { get; }

        Key Private{ get; }

        Key Public { get; }
    }
}
