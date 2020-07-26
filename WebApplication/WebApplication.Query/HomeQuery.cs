using System;
using System.Collections.Generic;
using WebApplication.Model;

namespace WebApplication.Query
{
    public class HomeQuery : IHomeQuery
    {
        readonly List<Product> _products = new List<Product>();

        public List<Product> Get()
        {
            return _products;
        }

        public List<Product> Add(Product product)
        {
            _products.Add(product);
            product.Status = "Added";
            return _products;
        }

        public bool PostUpdate(Product product)
        {
            return true;
        }

        public bool PrepareUpdate(Product product)
        {
            product.Date = DateTime.Now;
            return true;
        }

        public List<Product> Update(Product product)
        {
            var productToUpdate = _products.Find(p => p.Id == product.Id);

            productToUpdate.Status = "Updated";
            productToUpdate.Qty = product.Qty;

            return _products;
        }
    }
}
