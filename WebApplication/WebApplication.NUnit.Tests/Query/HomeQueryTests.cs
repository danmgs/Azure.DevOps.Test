using FluentAssertions;
using NUnit.Framework;
using System;
using WebApplication.Model;
using WebApplication.Query;

namespace WebApplication.NUnit.TestsServices.Query
{
    [TestFixture]
    [Category("Home Query")]
    public class HomeQueryTests
    {
        #region Tests
        [Test]
        public void TestGet()
        {
            HomeQuery query = new HomeQuery();
            Product dummyProduct = new Product();
            query.Add(dummyProduct);

            var res = query.Get();

            res.Should().NotBeNullOrEmpty();
            res.Count.Should().Be(1);
        }

        [Test]
        public void TestAddWithStatusAdded()
        {
            HomeQuery query = new HomeQuery();
            Product dummyProduct = new Product();
            query.Add(dummyProduct);

            dummyProduct.Status.Should().Be("Added");
        }

        [Test]
        public void TestPrepareUpdate()
        {
            HomeQuery query = new HomeQuery();
            Product dummyProduct = new Product();
            var res = query.PrepareUpdate(dummyProduct);

            res.Should().BeTrue();
            dummyProduct.Date.Should().BeAfter(DateTime.MinValue);
        }


        #endregion
    }
}
