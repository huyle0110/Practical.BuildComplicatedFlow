namespace Practice.BuildComplicatedFlow.Services
{
    public abstract class CustomDisposable : IDisposable
    {
        public bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            //Prevents the garbage collector from calling the finalizer if Dispose() has already been called.
            GC.SuppressFinalize(this);
        }

        ~CustomDisposable()
        { 
            Dispose(false); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing) {
                // Free any other managed objects here.
            }

            _disposed = true;
        }
    }
}
