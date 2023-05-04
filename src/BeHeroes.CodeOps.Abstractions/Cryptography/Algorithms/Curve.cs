namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public abstract class Curve : ICurve
    {
        public virtual object Parameters { get; init; }

        public string Identifier { get; init; }

        protected Curve(string identifier, object parameters)
        {
            Identifier = identifier;
            Parameters = parameters;
        }

        public bool Equals(ICurve other)
        { 
            return GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Identifier, Parameters).GetHashCode();
        }

        public abstract byte[] GetSeed();
    }
}