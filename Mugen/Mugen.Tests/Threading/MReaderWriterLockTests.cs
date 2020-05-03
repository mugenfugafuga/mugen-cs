using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mugen.Threading.Tests
{
    [TestClass()]
    public class MReaderWriterLockTests
    {
        [TestMethod()]
        public void MReaderWriterLock_LockTest()
        {
            var rwlock = new MReaderWriterLock();
            var val = 0;

            var presult = Parallel.ForEach(Enumerable.Range(0, 100), i =>
            {
                using var wlock = rwlock.GetWriterLock();

                ++val;
            });

            while (!presult.IsCompleted)
            {
                Thread.Sleep(1);
            }

            Assert.AreEqual(100, val);
        }
    }
}