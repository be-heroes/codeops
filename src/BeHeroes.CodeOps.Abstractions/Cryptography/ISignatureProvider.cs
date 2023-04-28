namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface ISignatureProvider
    {
        string Algorithm { get; }

        byte[] Sign (byte[] input);

        bool Verify (byte[] input, byte[] signature);

        bool Verify (byte[] input, int inputOffset, int inputLength, byte[] signature, int signatureOffset, int signatureLength);
    }
}
