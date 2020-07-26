using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WebApplication.Model;
using WebApplication.Query;
using WebApplication.Service;

namespace WebApplication.NUnit.TestsServices.Services
{
    [TestFixture]
    [Category("Home Service")]
    public class HomeServiceTests
    {
        #region Variables
        Mock<IHomeQuery> _homeQueryMock;
        #endregion

        #region Setup
        [SetUp]
        public void Setup()
        {
            _homeQueryMock = new Mock<IHomeQuery>();

            List<Product> productListAddMock = new List<Product>();
            _homeQueryMock.Setup(h => h.Add(It.IsAny<Product>())).Returns(productListAddMock);

            Product productUpdateMock = new Product() { Status = "Executed" };
            _homeQueryMock.Setup(h => h.Update(It.IsAny<Product>())).Returns(It.IsAny<List<Product>>());

            //Product productWithOddIdMock = new Product() { Id = 1 };
            //_homeQueryMock.Setup(h => h.Execute(productWithOddIdMock)).Returns(false);

            //Product productWithEvenIdMock = new Product() { Id = 2 };
            //_homeQueryMock.Setup(h => h.Execute(productWithEvenIdMock)).Returns(true);
        }
        #endregion

        #region Tests
        [Test]
        public void TestAddIsCalledOnce()
        {
            HomeService service = new HomeService(_homeQueryMock.Object);
            List<Product> products = service.Add(It.IsAny<Product>());
            _homeQueryMock.Verify(h => h.Add(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void TestWhenUpdateProductThenUpdateIsCalledOnce()
        {
            HomeService service = new HomeService(_homeQueryMock.Object);

            List<Product> products = service.Update(It.IsAny<Product>());

            _homeQueryMock.Verify(h => h.Update(It.IsAny<Product>()), Times.Once);
            _homeQueryMock.Verify(h => h.PrepareUpdate(It.IsAny<Product>()), Times.Once);
            _homeQueryMock.VerifyNoOtherCalls();
        }
        #endregion
    }
}
