namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class SignatureProvider : Microsoft.IdentityModel.Tokens.SignatureProvider, ISignatureProvider
    {
        protected SignatureProvider(Key key, string algorithm) : base(key, algorithm)
        {
        }
    }
}
