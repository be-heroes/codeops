using System.Numerics;

namespace BeHeroes.CodeOps.Abstractions.Numerics
{
    /// <summary>
    /// Defines an interface for a sequencer that generates incrementing values.
    /// </summary>
    public interface ISequencer
    {
        /// <summary>
        /// Gets the current value from the sequence.
        /// </summary>
        /// <returns>The current seed.</returns>
        BigInteger? Current();
        
        /// <summary>
        /// Gets the next value from the sequence.
        /// </summary>
        /// <returns>The next seed.</returns>
        BigInteger Next();

        /// <summary>
        /// Advanced the sequencer to the provider value granted that is higher then the current value.
        /// </summary>
        void Advance(BigInteger value);

        /// <summary>
        /// Resets the sequencer.
        /// </summary>
        void Reset();
    }
}
