using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication.MS.Tests
{
    [Ignore]
    [TestClass]
    [TestCategory("Unit Test 3")]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual(1, 2);
        }

        [Ignore]
        [TestMethod]
        public void TestMethod9()
        {
            Assert.AreEqual(1, 2);
        }
    }
}
