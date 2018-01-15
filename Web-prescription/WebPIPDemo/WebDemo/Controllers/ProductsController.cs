using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDemo.Models;
using System.Web.Mvc;
namespace WebDemo.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]{
            new Product{ ID = 1, Name="Tomato Soup", Category = "Groceries", Price=1},
            new Product{ ID = 2, Name="Yo-yo", Category = "Toys", Price=3.75M},
            new Product{ ID = 3, Name="Hammer", Category = "Hardware", Price=16.99M}
        };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
        public IEnumerable<Product> GetProductsByName(string name)
        {
            var _products = products.Where(p => p.Name.Contains(name));
            if (_products.Count() <= 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return _products;
        }
        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.ID.Equals(id));
            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return product;
        }
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where((p) => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }
    }
}
