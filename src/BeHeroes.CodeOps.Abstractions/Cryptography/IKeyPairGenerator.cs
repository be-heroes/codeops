namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IKeyPairGenerator<T>
    {
        IKeyPair GenerateKeyPair();

        void Init(T parameters);
    }
}
