namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKeyPair
    {
        string Name { get; }

        PrivateKey Private{ get; }

        PublicKey Public { get; }
    }
}
