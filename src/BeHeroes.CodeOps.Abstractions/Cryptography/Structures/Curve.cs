namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public abstract class Curve<T> : Structure, ICurve
    {
        public IEnumerable<ICurveParameter> Parameters { get; init; }

        protected Curve(string identifier, IEnumerable<ICurveParameter> parameters) : base(identifier)
        {
            Parameters = parameters;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(base.GetHashCode(), Parameters).GetHashCode();
        }

        public abstract byte[] GetSeed();
    }
}