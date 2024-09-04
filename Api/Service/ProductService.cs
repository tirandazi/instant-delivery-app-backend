using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DbConfig;
using Api.Model;

namespace Api.Service
{

    public class ProductService
    {
        private InstantAppDbContext _instantDbContext;
        public ProductService(InstantAppDbContext instantDbContext) {
            _instantDbContext = instantDbContext;
        }

        public List<Product> GetAllProducts() {
            var products = _instantDbContext.products.ToList();
            // var products = new List<Product>();
            return products;
        }
    }
}