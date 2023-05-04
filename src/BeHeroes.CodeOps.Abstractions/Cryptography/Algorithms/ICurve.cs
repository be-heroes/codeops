namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public interface ICurve
    { 
        string Identifier { get; }

        byte[] GetSeed();

        bool Equals(ICurve other);

        int GetHashCode();
    }
}