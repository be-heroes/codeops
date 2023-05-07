using BeHeroes.CodeOps.Abstractions.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Grid
{
    public interface IActor
    {
        Guid Id { get; }

        Uri Uri { get; }

        ActorType ActorType { get; }

        ActorStatus ActorStatus { get; }

        IKey? SecurityKey { get; }
        
        KeyValuePair<string, string>? GetResourcePrincipal();
    }
}
