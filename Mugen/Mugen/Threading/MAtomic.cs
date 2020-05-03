namespace Mugen.Threading
{
    public class MAtomic<T>
    {
        private MReaderWriterLock rwLock;

        public T ValueNoLock { get; set; }


        public MAtomic(MReaderWriterLock rwLock, T value)
        {
            this.rwLock = rwLock;
            this.ValueNoLock = value;
        }

        public MAtomic(MReaderWriterLock rwLock) : this(rwLock, default(T))
        {
        }

        public MAtomic(T value) : this(new MReaderWriterLock(), value)
        {
        }

        public MAtomic() : this(new MReaderWriterLock(), default(T))
        {
        }

        public T Value
        {
            get
            {
                using var rlock = rwLock.GetReaderLock();
                return ValueNoLock;
            }
            set
            {
                using var wlock = rwLock.GetWriterLock();
                ValueNoLock = value;
            }
        }

        public static implicit operator T(MAtomic<T> atomic) => atomic.Value; 
    }
}
