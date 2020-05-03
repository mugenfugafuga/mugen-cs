using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Mugen.Tests
{
    [TestClass()]
    public class Enumerable2Tests
    {
        [TestMethod()]
        public void Enumerable2_Zip2Test()
        {
            var v1 = Enumerable.Range(0, 100);
            var v2 = Enumerable.Range(10, 10).Select(i => i.ToString());

            var i = 0;

            foreach (var vv in v1.Zip2(v2))
            {
                Assert.AreEqual(i, vv.Item1);
                Assert.AreEqual((i + 10).ToString(), vv.Item2);
                ++i;
            }

            Assert.AreEqual(10, i);

        }

        [TestMethod()]
        public void Enumerable2_Zip2Test1()
        {
            var v1 = Enumerable.Range(0, 100);
            var v2 = Enumerable.Range(10, 10).Select(i => i.ToString());
            var v3 = Enumerable.Range(100, 5).Select(i => i.ToString());

            var i = 0;

            foreach (var vv in v1.Zip2(v2, v3))
            {
                Assert.AreEqual(i, vv.Item1);
                Assert.AreEqual((i + 10).ToString(), vv.Item2);
                Assert.AreEqual((i + 100).ToString(), vv.Item3);
                ++i;
            }

            Assert.AreEqual(5, i);
        }
    }
}