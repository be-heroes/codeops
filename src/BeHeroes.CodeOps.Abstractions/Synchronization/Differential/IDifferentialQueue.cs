using System.Collections.Immutable;

namespace BeHeroes.CodeOps.Abstractions.Synchronization.Differential
{
    /// <summary>
    /// Represents an immutable queue of differential elements.
    /// </summary>
    public interface IDifferentialQueue : IImmutableQueue<IDifferential>
    {
    }
}
