namespace BeHeroes.CodeOps.Abstractions.Strategies
{
    public interface IStrategy<T>
    {
        Task Apply(T target, CancellationToken cancellationToken = default);
    }
}
