using System;
using WebApplication.Model;
using WebApplication.Query;

namespace WebApplication.Service
{
    public class HomeService : IHomeService
    {
        readonly IHomeQuery _homequery;

        public HomeService(IHomeQuery homequery)
        {
            _homequery = homequery;
        }

        public Product Add(Product product)
        {
            return _homequery.Add(product);
        }

        public Product Update(Product product, DateTime date)
        {
            return _homequery.Update(product, DateTime.Now);
        }
    }
}
