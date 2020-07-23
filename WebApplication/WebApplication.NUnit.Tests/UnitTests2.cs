using NUnit.Framework;
using System.Collections.Generic;

namespace WebApplication.NUnit.Tests
{
    [Category("Unit Test Cat 1.2")]
    [TestFixture]
    public class UnitTests2
    {
        [Test]
        public void ShoudBeNull()
        {
            List<string> products = null;
            // making it failed
            Assert.Null(products);
        }

        [Test]
        [Category("MyCategoryName")]
        public void ShoudBeEqual()
        {
            List<string> products = null;
            // making it failed
            Assert.That(1 == 1);
        }
    }
}
