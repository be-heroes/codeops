namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class KeyPair : IKeyPair
    {
        public IAlgorithm Algorithm { get; init; }

        public IKey Private{ get; init; }

        public IKey Public { get; init; }

        protected KeyPair(IAlgorithm algorithm, IKey privateKey, IKey publicKey)
        {
            Algorithm = algorithm;
            Private = privateKey;
            Public = publicKey;
        }
    }
}
