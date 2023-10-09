using System.Collections;
using System.Collections.Immutable;

namespace BeHeroes.CodeOps.Abstractions.Synchronization.Differential
{
    //TODO: Migrate to BeHeroes.CodeOps.Abstractions package in Synchronization namespace
    /// <summary>
    /// Represents a queue differential elements.
    /// </summary>
    public sealed class DifferentialQueue : IDifferentialQueue
    {
        /// <summary>
        /// An immutable queue of <see cref="IDifferential"/> elements.
        /// </summary>
        private readonly IImmutableQueue<IDifferential> _queue = default!;

        /// <summary>
        /// Initializes a new instance of the <see cref="DifferentialQueue"/> type.
        /// </summary>
        /// <param name="queue">The immutable queue of differential elements to use when initializing the queue.</param>
        public DifferentialQueue(IImmutableQueue<IDifferential>? queue = default!)
        {
            _queue = queue ?? ImmutableQueue<IDifferential>.Empty;
        }

        /// <summary>
        /// Gets a value indicating whether the differential queue is empty.
        /// </summary>
        public bool IsEmpty => _queue.Count() == 0;

        /// <summary>
        /// Removes the first element in the differential queue, and returns a new queue.
        /// </summary>
        /// <returns>The new differential queue with the first element removed. This value is never null.</returns>
        public IImmutableQueue<IDifferential> Dequeue() => _queue.Dequeue();
        
        /// <summary>
        /// Adds an <see cref="IDifferential"/> element to the end of the queue, and returns a new queue.
        /// </summary>
        /// <param name="diff">The <see cref="IDifferential"/> element to add to the queue.</param>
        /// <returns>A new <see cref="IImmutableQueue{T}"/> with the added <see cref="IDifferential"/> element.</returns>
        public IImmutableQueue<IDifferential> Enqueue(IDifferential diff) => _queue.Enqueue(diff);

        /// <summary>
        /// Returns the next differential element in the queue without removing it.
        /// </summary>
        /// <returns>The next differential in the queue.</returns>
        public IDifferential Peek() => !IsEmpty ? _queue.Peek() : default!;

        /// <summary>
        /// Returns an enumerator that iterates through the differential elements in the queue.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the differential elements in the queue.</returns>
        public IEnumerator<IDifferential> GetEnumerator() => _queue.GetEnumerator();

        /// <summary>
        /// Returns a new queue with all the elements removed.
        /// </summary>
        /// <returns>An empty immutable queue.</returns>
        public IImmutableQueue<IDifferential> Clear() => _queue.Clear();

        /// <summary>
        /// Returns an enumerator that iterates through the differential elements in the queue.
        /// </summary>
        /// <returns>An enumerator that iterates through the differential elements in the queue.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}