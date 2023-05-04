namespace BeHeroes.CodeOps.Abstractions.Grid
{
    public interface IGridActor
    {
        Guid Id { get; }

        GridActorType ActorType { get; }
    }
}
