using System.Collections.Generic;
using Xunit;

namespace WebApplication.Unit.Tests
{
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
        public void ShoudBeEqual()
        {
            List<string> products = null;
            // making it failed
            Assert.Equal(1, 1);
        }
    }
}
