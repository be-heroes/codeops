using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IAlgorithm : IDisposable
    { 
        IStructure? Structure { get; }

        string Identifier { get; }

        int KeySize { get; }

        IEnumerable<KeySizes> LegalKeySizes { get; }
    }
}