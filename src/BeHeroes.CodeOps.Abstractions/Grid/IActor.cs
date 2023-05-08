using BeHeroes.CodeOps.Abstractions.Cryptography;

namespace BeHeroes.CodeOps.Abstractions.Grid
{
    public interface IActor
    {
        DecentralizedIdentifier Identifier { get; }

        IKey? SecurityKey { get; }

        ActorType ActorType { get; }

        ActorStatus ActorStatus { get; }
        
        KeyValuePair<string, string>? GetResourcePrincipal();
    }
}
