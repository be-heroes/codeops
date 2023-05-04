using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public interface IAlgorithm : IDisposable
    { 
        string Name { get; }

        int KeySize { get; }

        KeySizes[] LegalKeySizes { get; }
    }
}