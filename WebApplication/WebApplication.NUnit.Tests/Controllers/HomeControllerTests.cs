using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using WebApplication.Api.Controllers;
using WebApplication.Model;
using WebApplication.Service;

namespace WebApplication.NUnit.TestsControllers
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

            Product productMock = new Product() { Status = "Added" };
            _homeServiceMock.Setup(h => h.Add(It.IsAny<Product>())).Returns(productMock);
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
                //Assert.IsInstanceOf(typeof(Product), viewResult.ViewBag.Model);
                //Assert.IsInstanceOf(typeof(string), viewResult.ViewBag.Title);
                ((object)viewResult.ViewBag.Model).Should().BeOfType<Product>();
                ((object)viewResult.ViewBag.Title).Should().BeOfType<string>();

                //Further Asserts for your model ViewBag.Model ..
                Product p = viewResult.ViewBag.Model as Product;
                
                //Assert.AreEqual("Added", p.Status);
                p.Status.Should().Equals("Added");
            }

            _homeServiceMock.Verify(h => h.Add(It.IsAny<Product>()), Times.Once);

            Assert.NotNull(result);
        }
        #endregion
    }
}
