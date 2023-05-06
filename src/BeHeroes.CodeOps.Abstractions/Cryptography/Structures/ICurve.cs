namespace BeHeroes.CodeOps.Abstractions.Cryptography.Structures
{
    public interface ICurve : IStructure
    {         
        byte[] GetSeed();
    }
}