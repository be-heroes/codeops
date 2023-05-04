using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public interface IAlgorithm : IDisposable
    { 
        string Identifier { get; }

        ICurve Curve { get; }

        int KeySize { get; }

        KeySizes[] LegalKeySizes { get; }
    }
}