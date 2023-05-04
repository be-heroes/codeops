namespace BeHeroes.CodeOps.Abstractions.Protocols.Http
{
    public interface IRestClient : IDisposable
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
}
