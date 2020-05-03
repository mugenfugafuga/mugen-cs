using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace Mugen.Threading.Tests
{
    [TestClass()]
    public class MAtomicTests
    {
        [TestMethod()]
        public void MAtomic_MAtomicTest()
        {
            var hoge = new Hoge();

            Task.Run(() =>
            {
                Thread.Sleep(10);
                hoge.Value = "atomic!";
            });

            Assert.AreEqual(0, hoge.Status);


            while (hoge.Status == 0)
            {
                Thread.Sleep(1);
            }

            Assert.AreEqual(1, hoge.Status);
            Assert.AreEqual("atomic!", hoge.Value);
        }

        class Hoge
        {
            private MReaderWriterLock rwlock;
            private MAtomic<int> status;
            private MAtomic<string> val;

            public Hoge()
            {
                rwlock = new MReaderWriterLock();
                status = new MAtomic<int>(rwlock, 0);
                val = new MAtomic<string>(rwlock); 
            }

            public int Status => status;

            public string Value
            {
                get => val;
                set
                {
                    using var wlock = rwlock.GetWriterLock();

                    status.ValueNoLock = 1;
                    val.ValueNoLock = value;
                }
            }
        }
    }
}