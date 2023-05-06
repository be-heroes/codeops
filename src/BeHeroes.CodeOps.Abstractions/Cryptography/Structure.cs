namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public abstract class Structure : IStructure
    {
        public string Identifier { get; init; }

        public IStructureParameters? Parameters { get; init; }

        protected Structure(string identifier, IStructureParameters? parameters)
        {
            Identifier = identifier;
            Parameters = parameters;
        }

        public bool Equals(IStructure other)
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