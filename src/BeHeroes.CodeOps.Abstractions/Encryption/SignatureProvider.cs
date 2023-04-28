namespace BeHeroes.CodeOps.Abstractions.Encryption
{
    public abstract class SignatureProvider : Microsoft.IdentityModel.Tokens.SignatureProvider, ISignatureProvider
    {
        protected SignatureProvider(Key key, string algorithm) : base(key, algorithm)
        {
        }
    }
}
