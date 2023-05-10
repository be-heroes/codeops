namespace BeHeroes.CodeOps.Abstractions.Protocols.Http
{
    public interface IHttpHeader
    {
        string Name { get; }

        IEnumerable<string> Values { get; }
    }
}
