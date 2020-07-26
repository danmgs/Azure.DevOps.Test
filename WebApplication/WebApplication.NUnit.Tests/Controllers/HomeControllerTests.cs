using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Api.Controllers;
using WebApplication.Model;
using WebApplication.Service;

namespace WebApplication.NUnit.TestsControllers.Controllers
{
    [TestFixture]
    [Category("Home Controller")]
    public class HomeControllerTests
    {
        #region Variables
        Mock<IHomeService> _homeServiceMock;
        #endregion

        #region Setup
        [SetUp]
        public void Setup()
        {
            _homeServiceMock = new Mock<IHomeService>();

            List<Product> productListMock = new List<Product>() { new Product { Status = "Init" }, new Product { Status = "Init" }, };
            _homeServiceMock.Setup(h => h.Add(It.IsAny<Product>())).Returns(productListMock);
        }
        #endregion

        #region Tests
        [Test]
        public void TestIndexReturnsNotNull()
        {
            HomeController ctrl = new HomeController(_homeServiceMock.Object);
            ActionResult result = ctrl.Index();

            Assert.IsInstanceOf(typeof(ViewResult), result);

            //Since view has been asserted as ViewResult
            ViewResult viewResult = result as ViewResult;
            if (viewResult != null)
            {
                ((object)viewResult.ViewBag.Model).Should().BeOfType<List<Product>>();
                ((object)viewResult.ViewBag.Title).Should().BeOfType<string>();

                //Further Asserts for your model ViewBag.Model ..
                List<Product> products = viewResult.ViewBag.Model as List<Product>;

                products.ForEach(p => p.Status.Should().Equals("Home"));
                ((object)viewResult.ViewBag.Title).Should().Be("Home Page");
            }

            _homeServiceMock.Verify(h => h.Add(It.IsAny<Product>()), Times.Once);

            Assert.NotNull(result);
        }
        #endregion
    }
}
