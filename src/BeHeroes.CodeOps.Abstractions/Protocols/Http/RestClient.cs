namespace BeHeroes.CodeOps.Abstractions.Protocols.Http
{
    public abstract class RestClient : HttpClient, IRestClient
    {
        protected RestClient(HttpMessageHandler handler) : base(handler)
        {
        }

        protected RestClient(HttpMessageHandler handler, bool disposeHandler) : base(handler, disposeHandler)
        {
        }

        public ValueTask DisposeAsync()
        {
            Dispose();

            return ValueTask.CompletedTask;
        }
    }
}
