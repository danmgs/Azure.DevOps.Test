using System.Collections.Generic;
using Xunit;

namespace WebApplication.XUnit.Tests
{
    [Trait("Category", "Unit Test Cat 2")]
    public class UnitTests2
    {
        [Fact]
        public void ShoudBeNull()
        {
            List<string> products = null;
            // making it failed
            Assert.Null(products);
        }

        [Fact]
        [Trait("Category", "MyCategoryName")]
        public void ShoudBeEqual()
        {
            List<string> products = null;
            // making it failed
            Assert.Equal(1, 1);
        }
    }
}
