using System.Numerics;

namespace BeHeroes.CodeOps.Abstractions.Numerics
{
    /// <summary>
    /// Abstract base class for implementing a sequencer that generates unique sequential values.
    /// </summary>
    public abstract class Sequencer : ISequencer
    {
        /// <summary>
        /// The current value of the sequencer.
        /// </summary>
        protected BigInteger? _current = default!;

        /// <summary>
        /// The next value of the sequencer.
        /// </summary>
        protected BigInteger _next = default!;

        /// <summary>
        /// Gets the current value from the sequencer.
        /// </summary>
        /// <returns>The current seed value.</returns>
        public BigInteger? Current() => _current;

        /// <summary>
        /// Gets the next value from the sequencer.
        /// </summary>
        /// <returns>The new seed value.</returns>
        public abstract BigInteger Next();

        /// <summary>
        /// Resets the sequencer.
        /// </summary>
        public void Reset() {
            _current = default!;
            _next = default!;
        }
    }
}