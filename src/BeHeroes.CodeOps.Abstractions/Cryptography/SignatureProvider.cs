using BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class SignatureProvider : Microsoft.IdentityModel.Tokens.SignatureProvider, ISignatureProvider
    {
        protected readonly IAlgorithm _algorithm;

        protected SignatureProvider(Key key, IAlgorithm algorithm) : base(key, algorithm.Name)
        {
            _algorithm = algorithm;
        }

        IAlgorithm ISignatureProvider.Algorithm => _algorithm;
    }
}
