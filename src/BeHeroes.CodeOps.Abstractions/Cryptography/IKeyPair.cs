namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKeyPair
    {
        PrivateKey Private{ get; }

        PublicKey Public { get; }
    }
}
