using NUnit.Framework;
using WebApplication.Controllers;

namespace WebApplication.NUnit.Tests
{
    [TestFixture]
    [Category("Values Controller")]
    public class ValuesControllerTests
    {        
        [Test]
        public void TestGetReturnsNotNull()
        {
            ValuesController ctrl = new ValuesController();
            var result = ctrl.Get();
            Assert.NotNull(result);
        }

        [Test]
        public void TestDelete()
        {
            ValuesController ctrl = new ValuesController();
            ctrl.Delete(1);
            Assert.Pass();
        }

        
    }
}
