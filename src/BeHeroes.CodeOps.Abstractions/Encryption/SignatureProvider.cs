using System.Threading.Tasks;

namespace BeHeroes.CodeOps.Abstractions.Encryption
{
    public abstract class SignatureProvider : ISignatureProvider
    {
        public abstract ValueTask<string> GetSignature(string passphrase);
    }
}
