using System;
using System.Threading;

namespace Mugen.Threading
{
    public class MReaderWriterLock
    {
        private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

        public IDisposable GetReaderLock() => new ReaderLocker(rwLock);

        public IDisposable GetWriterLock() => new WriterLocker(rwLock);

        struct ReaderLocker : IDisposable
        {
            private ReaderWriterLockSlim rwLock;

            public ReaderLocker(ReaderWriterLockSlim rwLock)
            {
                this.rwLock = rwLock;
                rwLock.EnterReadLock();
            }

            public void Dispose()
            {
                rwLock.ExitReadLock();
            }
        }

        struct WriterLocker : IDisposable
        {
            private ReaderWriterLockSlim rwLock;

            public WriterLocker(ReaderWriterLockSlim rwLock)
            {
                this.rwLock = rwLock;
                rwLock.EnterWriteLock();
            }

            public void Dispose()
            {
                rwLock.ExitWriteLock();
            }
        }

    }
}
