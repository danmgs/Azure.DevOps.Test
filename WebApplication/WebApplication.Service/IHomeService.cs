using System.Collections.Generic;
using WebApplication.Model;

namespace WebApplication.Service
{
    public interface IHomeService
    {
        List<Product> Add(Product product);

        List<Product> Update(Product product);
    }
}
