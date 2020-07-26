using System;
using WebApplication.Model;

namespace WebApplication.Service
{
    public interface IHomeService
    {
        Product Add(Product product);

        Product Update(Product product, DateTime date);
    }
}
