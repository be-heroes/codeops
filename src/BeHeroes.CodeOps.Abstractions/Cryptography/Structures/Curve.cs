namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public abstract class Curve : Structure, ICurve
    {
        protected readonly IReadOnlyCollection<byte> _seed;

        protected Curve(string identifier, byte[] seed) : base(identifier)
        {
            _seed = seed;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(base.GetHashCode(), _seed).GetHashCode();
        }

        public virtual byte[] GetSeed()
        {
            return _seed.ToArray();
        }
    }
}