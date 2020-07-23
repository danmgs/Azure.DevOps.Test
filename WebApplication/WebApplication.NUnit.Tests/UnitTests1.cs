using NUnit.Framework;
using System.Collections.Generic;

namespace WebApplication.NUnit.Tests
{
    [TestFixture]
    public class UnitTests1
    {
        [Category("Unit Test Cat 1.1")]
        [Test]
        public void ShoudBeNull()
        {
            List<string> products = null;
            // making it failed
            Assert.Null(products);
        }

        [Category("Unit Test Cat 1.2")]
        [Test]
        public void ShoudBeEqual()
        {
            List<string> products = null;
            // making it failed
            Assert.That(1 == 1);
        }

        [Category("Unit Test Cat 1.2")]
        [Test]
        public void ShoudBeEqualBis()
        {
            List<string> products = null;
            // making it failed
            Assert.That(2 == 2);
        }
    }
}
