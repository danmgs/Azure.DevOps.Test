using NUnit.Framework;
using System.Web.Mvc;
using WebApplication.Controllers;

namespace WebApplication.NUnit.Tests
{
    [TestFixture]
    [Category("Home Controller")]
    public class HomeControllerTests
    {        
        [Test]
        public void TestIndexReturnsNotNull()
        {
            HomeController ctrl = new HomeController();
            ActionResult result = ctrl.Index();
            Assert.NotNull(result);
        }
    }
}
