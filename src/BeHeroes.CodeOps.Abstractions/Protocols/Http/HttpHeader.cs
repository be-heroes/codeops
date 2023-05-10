namespace BeHeroes.CodeOps.Abstractions.Protocols.Http
{
    public abstract record class HttpHeader(string Name, IEnumerable<string> Values) : IHttpHeader
    {
    }
}
