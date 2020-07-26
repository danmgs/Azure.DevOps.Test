using NUnit.Framework;
using WebApplication.Api.Controllers;

namespace WebApplication.NUnit.TestsControllers.Controllers
{
    [Ignore("Ignore")]
    [TestFixture]
    [Category("Values Controller")]
    public class ValuesControllerTests
    {
        #region Tests
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
        #endregion
    }
}
