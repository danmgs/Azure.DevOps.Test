using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication.MS.Tests
{
    [TestClass]
    [TestCategory("Unit Test 1")]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
