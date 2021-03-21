using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Types
{
    public class FixedSizedQueue<T> : ConcurrentQueue<T>
    {
        private readonly object syncObject = new object();

        public int Size { get; }

        public FixedSizedQueue(int size)
            :this(size, Enumerable.Empty<T>())
        {
        }

        public FixedSizedQueue(int size, IEnumerable<T> collection)
            :base(collection)
        {
            Size = size;
        }

        public new void Enqueue(T obj)
        {
            base.Enqueue(obj);
            lock (syncObject)
            {
                while (base.Count > Size)
                {
                    base.TryDequeue(out T outObj);
                }
            }
        }
    }
}
