﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication.MS.Tests
{
    [TestClass]
    [TestCategory("Unit Test 2")]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(1, 1);
        }

        [Ignore]
        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(1, 2);
        }
    }
}
