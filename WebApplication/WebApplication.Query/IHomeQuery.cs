using System;
using WebApplication.Model;

namespace WebApplication.Query
{
    public interface IHomeQuery
    {
        Product Add(Product product);

        bool Execute(Product product, DateTime date);

        Product Update(Product product, DateTime date);
    }
}
