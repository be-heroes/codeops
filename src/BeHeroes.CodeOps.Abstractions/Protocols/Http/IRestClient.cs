namespace BeHeroes.CodeOps.Abstractions.Protocols.Http
{
    public interface IRestClient : IDisposable, IAsyncDisposable
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
}
