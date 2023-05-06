namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class Structure : IStructure
    {
        protected readonly byte[]? _seed;

        public string Identifier { get; init; }

        protected Structure(string identifier, byte[]? seed)
        {
            Identifier = identifier;
            _seed = seed;
        }

        public bool Equals(IStructure other)
        { 
            return GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Identifier, _seed).GetHashCode();
        }

        public virtual byte[] GetSeed()
        {
            return _seed ?? Array.Empty<byte>();
        }
    }
}