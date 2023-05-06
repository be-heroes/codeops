using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class Algorithm : Disposable, IAlgorithm
    {        
        public IStructure? Structure { get; init; }

        public string Identifier { get; init; }

        public int KeySize { get; init; }

        public IEnumerable<KeySizes> LegalKeySizes { get; init; }

        protected Algorithm(string identifier, int keySize, IEnumerable<KeySizes> legalKeySizes, IStructure? structure = default)
        {
            Identifier = identifier;
            KeySize = keySize;
            LegalKeySizes = legalKeySizes;
            Structure = structure;
        }
    }
}