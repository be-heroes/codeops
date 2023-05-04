using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public interface ISymmetricAlgorithm : IAlgorithm
    { 
        int BlockSize { get; }

        int FeedbackSize { get; }

        byte[] IV { get; }

        byte[] Key { get; }

        KeySizes[] LegalBlockSizes { get; }

        CipherMode Mode { get; }

        PaddingMode Padding { get; }
    }
}