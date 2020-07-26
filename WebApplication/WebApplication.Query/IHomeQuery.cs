using System.Collections.Generic;
using WebApplication.Model;

namespace WebApplication.Query
{
    public interface IHomeQuery
    {
        List<Product> Get();

        List<Product> Add(Product product);

        bool PrepareUpdate(Product product);

        bool PostUpdate(Product product);

        List<Product> Update(Product product);
    }
}
