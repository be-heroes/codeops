namespace BeHeroes.CodeOps.Abstractions.Protocols.Http
{
    public interface IHttpClient : IDisposable, IAsyncDisposable
    {
        IEnumerable<IHttpHeader> DefaultRequestHeaders { get; }

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
}
