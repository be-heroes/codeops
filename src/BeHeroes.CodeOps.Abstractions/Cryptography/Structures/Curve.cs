namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public abstract class Curve : Structure, ICurve
    {
        public ICurveParameters Parameters { get; init; }

        protected Curve(string identifier, ICurveParameters parameters) : base(identifier)
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