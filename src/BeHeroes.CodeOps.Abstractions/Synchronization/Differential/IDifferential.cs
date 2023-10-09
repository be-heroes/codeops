using System.Numerics;

namespace BeHeroes.CodeOps.Abstractions.Synchronization.Differential
{
    /// <summary>
    /// Represents a differential that can be used for differential synchronization.
    /// </summary>
    public interface IDifferential
    {
        /// <summary>
        /// Gets the version of the differential.
        /// </summary>
        BigInteger Version { get; }        
    }
}
