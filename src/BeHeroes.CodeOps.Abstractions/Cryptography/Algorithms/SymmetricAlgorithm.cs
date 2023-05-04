using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public abstract class SymmetricAlgorithm : Algorithm, ISymmetricAlgorithm
    {
        public int BlockSize { get; init ; }

        public int FeedbackSize { get; init ; }

        public byte[] IV { get; init ; } = Array.Empty<byte>();

        public byte[] Key { get; init ; } = Array.Empty<byte>();

        public KeySizes[] LegalBlockSizes { get; init ; } = Array.Empty<KeySizes>();

        public CipherMode Mode { get; init ; }

        public PaddingMode Padding { get; init ; }
    }
}