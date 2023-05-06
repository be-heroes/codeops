namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public interface ICurve : IStructure
    { 
        IEnumerable<ICurveParameter> Parameters { get; }
        
        byte[] GetSeed();
    }
}