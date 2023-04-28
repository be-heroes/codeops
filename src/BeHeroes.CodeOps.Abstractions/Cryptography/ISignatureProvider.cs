using BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface ISignatureProvider
    {
        IAlgorithm Algorithm { get; }

        byte[] Sign (byte[] input);

        bool Verify (byte[] input, byte[] signature);

        bool Verify (byte[] input, int inputOffset, int inputLength, byte[] signature, int signatureOffset, int signatureLength);
    }
}
