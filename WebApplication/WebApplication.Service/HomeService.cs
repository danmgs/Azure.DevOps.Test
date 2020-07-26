using System.Collections.Generic;
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

        public List<Product> Add(Product product)
        {
            return _homequery.Add(product);
        }

        public List<Product> Update(Product product)
        {
            _homequery.PrepareUpdate(product);
            return _homequery.Update(product);
        }
    }
}
