namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public abstract class Structure : IStructure
    {
        public string Identifier { get; init; }

        protected Structure(string identifier)
        {
            Identifier = identifier;
        }

        public bool Equals(IStructure other)
        { 
            return GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Identifier).GetHashCode();
        }
    }
}