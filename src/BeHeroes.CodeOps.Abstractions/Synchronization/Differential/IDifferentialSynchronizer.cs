namespace BeHeroes.CodeOps.Abstractions.Synchronization.Differential
{
    /// <summary>
    /// Represents a differential synchronizer that can be used to synchronize differentials.
    /// </summary>
    /// <typeparam name="TDiff">The type of object that is being synchronized.</typeparam>
    public interface IDifferentialSynchronizer<TDiff> where TDiff : class, IDifferential
    {
        /// <summary>
        /// Gets the differential synchronizers current differential.
        /// </summary>
        /// <returns>A <see cref="TDiff"/> the current differential of the synchronizer.</returns>
        TDiff? GetDifferential();
        
        /// <summary>
        /// Asynchronously retrieves an enumerator of differentials that represent the pending differential edits to be applied to the differential synchronizers current differential.
        /// </summary>
        /// <returns>A <see cref="TResult"/> that represents the asynchronous operation. The result of the task contains an enumerator of <see cref="IDifferential"/> elements.</returns>
        IEnumerator<IDifferential> GetDifferentialEdits();

        /// <summary>
        /// Applies the specified differential to the differential synchronizers.
        /// </summary>
        /// <param name="differential">The differential to apply.</param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        void ApplyDifferential(IDifferential differential);
    }
}   
