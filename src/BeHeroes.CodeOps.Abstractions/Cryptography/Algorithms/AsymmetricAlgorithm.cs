namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public abstract class AsymmetricAlgorithm : Algorithm, IAsymmetricAlgorithm
    {
        public string? KeyExchangeAlgorithm { get; init ; }

        public string? SignatureAlgorithm { get; init ; }
    }
}