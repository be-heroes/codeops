namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public interface ICurve
    { 
        string Identifier { get; }

        int CoordinateSystem { get; }
        
        int FieldSize { get; }
        
        byte[] Cofactor { get; }
        
        byte[] Order { get; }

        byte[] GetSeed();

        bool SupportsCoordinateSystem(int coord);

        bool Equals(ICurve other);

        int GetHashCode();
    }
}