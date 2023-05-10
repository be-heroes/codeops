using BeHeroes.CodeOps.Abstractions.Protocols.Http;

namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps
{
    public sealed record class AdoClientHeader : HttpHeader
    {
        public AdoClientHeader(string Name, IEnumerable<string> Values) : base(Name, Values)
        {
        }
    }
}
