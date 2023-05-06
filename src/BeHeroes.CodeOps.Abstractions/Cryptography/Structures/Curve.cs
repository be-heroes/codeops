using System.Collections.ObjectModel;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public abstract class Curve : Structure, ICurve
    {
        protected IReadOnlyCollection<byte> _seed;

        protected Curve(string identifier, byte[] seed) : base(identifier)
        {
            _seed = seed.AsReadOnly<byte>();
        }

        public override int GetHashCode()
        {
            return Tuple.Create(base.GetHashCode(), _seed).GetHashCode();
        }

        public byte[] GetSeed()
        {
            return _seed.ToArray();
        }
    }
}