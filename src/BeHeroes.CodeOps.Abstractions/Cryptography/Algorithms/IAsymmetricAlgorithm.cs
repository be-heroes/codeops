namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public interface IAsymmetricAlgorithm : IAlgorithm
    { 
        string? KeyExchangeAlgorithm { get; }

        string? SignatureAlgorithm { get; }
    }
}