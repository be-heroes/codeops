using System.Security.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Cryptography.Algorithms
{
    public abstract class Algorithm<T> : IAlgorithm where T : class, IDisposable, new()
    {
        public string Name { get; init; } = nameof(T);

        protected virtual T Provider => new T();

        public abstract int GetKeySize();

        public abstract KeySizes[] GetLegalKeySizes();
    }
}