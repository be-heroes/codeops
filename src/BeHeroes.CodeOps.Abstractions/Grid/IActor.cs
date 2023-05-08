using BeHeroes.CodeOps.Abstractions.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Grid
{
    public interface IActor : IDisposable, IAsyncDisposable
    {
        DecentralizedIdentifier Identifier { get; }

        IKey? SecurityKey { get; }

        ActorType ActorType => ActorType.None;

        ActorStatus ActorStatus { get; }
        
        KeyValuePair<string, string>? GetResourcePrincipal();
    }
}
