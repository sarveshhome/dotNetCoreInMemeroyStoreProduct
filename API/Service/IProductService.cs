using System;
using System.Collections.Generic;
using API.Model;

namespace API.Services
{
    public interface IProductsService
    {
        public List<Product> GetProducts();

        public Product AddProduct(Product productItem);

        public Product UpdateProduct(string id, Product productItem);

        public string DeleteProduct(string id);
    }
}