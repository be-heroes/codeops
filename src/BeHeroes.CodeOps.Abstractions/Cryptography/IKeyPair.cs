namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKeyPair
    {
        Key Private{ get; }

        Key Public { get; }
    }
}
