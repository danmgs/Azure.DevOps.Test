using System;
using WebApplication.Model;

namespace WebApplication.Query
{
    public class HomeQuery : IHomeQuery
    {
        public Product Add(Product product)
        {
            product.Status = "Added";
            return product;
        }

        public bool Execute(Product product, DateTime date)
        {
            product.Status = "Executed";
            return (product.Id % 2 == 0);
        }

        public Product Update(Product product, DateTime date)
        {
            DateTime d = DateTime.Now;
            bool res = this.Execute(product, d);
            return new Product()
            {
                Id = product.Id,
                Name = $"{product.Name}updated",
                Qty = res ? (product.Qty * 2) : product.Qty,
                Status = product.Status
            };
        }
    }
}
