namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public abstract class Curve : ICurve
    {
        protected readonly object _parameters;

        public string Identifier { get; init; }

        protected Curve(string identifier, object parameters)
        {
            Identifier = identifier;
            _parameters = parameters;
        }

        public bool Equals(ICurve other)
        { 
            return GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Identifier, _parameters).GetHashCode();
        }

        public abstract byte[] GetSeed();
    }
}