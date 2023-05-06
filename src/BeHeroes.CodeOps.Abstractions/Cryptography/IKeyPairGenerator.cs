namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKeyPairGenerator
    {
        IKeyPair GenerateKeyPair();
    }
}
