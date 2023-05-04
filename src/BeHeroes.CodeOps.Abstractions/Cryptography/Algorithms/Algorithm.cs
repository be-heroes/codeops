using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public abstract class Algorithm : Disposable, IAlgorithm
    {
        public string Identifier { get; init; }

        public int KeySize { get; init; }

        public KeySizes[] LegalKeySizes { get; init; }
        
        public virtual Curve Curve { get; init; }

        ICurve IAlgorithm.Curve => Curve;

        protected Algorithm(string identifier, int keySize, KeySizes[] legalKeySizes, Curve curve)
        {
            Identifier = identifier;
            KeySize = keySize;
            LegalKeySizes = legalKeySizes;
            Curve = curve;
        }
    }
}