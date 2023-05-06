namespace BeHeroes.CodeOps.Abstractions.Cryptography
{
    public interface IStructure
    { 
        string Identifier { get; }
        
        bool Equals(IStructure other);

        int GetHashCode();

        byte[] GetSeed();
    }
}