using System.Collections.Generic;
using Xunit;

namespace WebApplication.XUnit.Tests
{
    public class UnitTests1
    {
        [Trait("Category", "Unit Test Cat 1.1")]
        [Fact]
        public void ShoudBeNull()
        {
            List<string> products = null;
            // making it failed
            Assert.Null(products);
        }

        [Trait("Category", "Unit Test Cat 1.2")]
        [Fact]
        public void ShoudBeEqual()
        {
            List<string> products = null;
            // making it failed
            Assert.Equal(1, 1);
        }

        [Trait("Category", "Unit Test Cat 1.2")]
        [Fact]
        public void ShoudBeEqualBis()
        {
            List<string> products = null;
            // making it failed
            Assert.Equal(2, 2);
        }
    }
}
