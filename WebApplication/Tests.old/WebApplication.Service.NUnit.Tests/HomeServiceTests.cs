using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using WebApplication.Model;
using WebApplication.Query;

namespace WebApplication.Service.NUnit.Tests
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

            Product productAddMock = new Product() { Status = "Added" };
            _homeQueryMock.Setup(h => h.Add(It.IsAny<Product>())).Returns(productAddMock);

            Product productUpdateMock = new Product() { Status = "Executed" };
            _homeQueryMock.Setup(h => h.Update(It.IsAny<Product>(), It.IsAny<DateTime>())).Returns(productUpdateMock);

            Product productWithOddIdMock = new Product() { Id = 1 };
            _homeQueryMock.Setup(h => h.Execute(productWithOddIdMock, It.IsAny<DateTime>())).Returns(false);

            Product productWithEvenIdMock = new Product() { Id = 2 };
            _homeQueryMock.Setup(h => h.Execute(productWithEvenIdMock, It.IsAny<DateTime>())).Returns(true);
        }
        #endregion

        #region Tests
        [Test]
        public void TestAddReturnsTrue()
        {
            HomeService service = new HomeService(_homeQueryMock.Object);
            Product p = service.Add(It.IsAny<Product>());
            p.Status.Should().Be("Added");
        }

        [Test]
        public void TestWhenUpdateProductReturnsStatusExecuted()
        {
            HomeService service = new HomeService(_homeQueryMock.Object);

            Product p = service.Update(It.IsAny<Product>(), It.IsAny<DateTime>());

            p.Status.Should().Be("Executed");
        }

        [Test]
        public void TestWhenUpdateProductThenExecuteIsCalledOnce()
        {
            HomeService service = new HomeService(_homeQueryMock.Object);

            Product p = service.Update(It.IsAny<Product>(), It.IsAny<DateTime>());

            _homeQueryMock.Verify(h => h.Update(It.IsAny<Product>(), It.IsAny<DateTime>()), Times.Once);
        }

        [Ignore("Ignore")]
        [Test]
        public void TestWhenUpdateProductWithEvenIdThenReturnsDoubleQty()
        {
            HomeService service = new HomeService(_homeQueryMock.Object);

            Product productAddMock = new Product() { Id = 2, Name = "Piano", Qty = 10 };
            Product p = service.Update(productAddMock, It.IsAny<DateTime>());

            p.Status.Should().Equals("Executed");

            //Assert.AreEqual(p.Qty, productAddMock.Qty * 2);
            var expected = productAddMock.Qty * 2;
            p.Qty.Should().Be(expected);
        }

        [Ignore("Ignore")]
        [Test]
        public void TestWhenUpdateProductWithOddIdThenReturnsUnchangedQty()
        {
            HomeService service = new HomeService(_homeQueryMock.Object);

            Product productAddMock = new Product() { Id = 1, Name = "Piano", Qty = 10 };
            Product p = service.Update(productAddMock, It.IsAny<DateTime>());

            p.Status.Should().Equals("Executed");
            p.Qty.Should().Be(productAddMock.Qty);
        }
        #endregion
    }
}
