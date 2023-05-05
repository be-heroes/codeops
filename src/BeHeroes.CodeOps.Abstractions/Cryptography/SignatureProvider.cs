using BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class SignatureProvider : Microsoft.IdentityModel.Tokens.SignatureProvider, ISignatureProvider
    {
        protected readonly IAlgorithm _algorithm;

        IAlgorithm ISignatureProvider.Algorithm => _algorithm;

        protected SignatureProvider(Key key, IAlgorithm algorithm) : base(key, algorithm.Identifier)
        {
            _algorithm = algorithm;
        }
    }
}
