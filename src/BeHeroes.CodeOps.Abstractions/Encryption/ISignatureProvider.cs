using System.Threading.Tasks;

namespace BeHeroes.CodeOps.Abstractions.Encryption
{
    public interface ISignatureProvider
    {
        ValueTask<string> GetSignature(string passphrase);
    }
}
