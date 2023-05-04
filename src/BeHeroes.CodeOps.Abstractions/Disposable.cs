namespace BeHeroes.CodeOps.Abstractions
{
    public abstract class Disposable : IDisposable, IAsyncDisposable
    {
        protected bool _disposed = false;

        public void Dispose()
        {
            Dispose(disposing: true);
            
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            Dispose();

            return ValueTask.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                _disposed = true;
            }
        }
    }
}