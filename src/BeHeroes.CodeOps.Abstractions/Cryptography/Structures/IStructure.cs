namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public interface IStructure
    { 
        string Identifier { get; }

        bool Equals(IStructure other);

        int GetHashCode();
    }
}