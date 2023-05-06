namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public interface ICurve : IStructure
    { 
        ICurveParameters Parameters { get; }
        
        byte[] GetSeed();
    }
}