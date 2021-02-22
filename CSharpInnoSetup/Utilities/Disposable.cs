
using System;

namespace CodingMuscles.CSharpInnoSetup.Utilities
{
    /// <summary>
    /// Standardizes an implementation for <see cref="IDisposable"/>
    /// </summary>
    internal abstract class Disposable : IDisposable
    {
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Implements the actual disposal logic.  Subclasses should
        /// override this method to clean up resources.
        /// </summary>
        /// <param name="disposing">Whether the class is disposing from the Dispose() method</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                    OnDisposing();

                OnDispose();

                IsDisposed = true;
            }
        }

        protected abstract void OnDisposing();

        /// <summary>
        /// Called to dispose unmanaged resources
        /// </summary>
        protected virtual void OnDispose()
        {
        }

        /// <see cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Disposable()
        {
            Dispose(false);
        }
    }
}
