using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsService.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Price { get; set; }
    }

    public class Products : List<Product>
    {
        public Products()
        {
            Add(new Product() { ProductId = 1001, ProductName = "P1", CategoryName = "C1", Price = 120000 });
            Add(new Product() { ProductId = 1002, ProductName = "P2", CategoryName = "C2", Price = 210000 });
            Add(new Product() { ProductId = 1003, ProductName = "P3", CategoryName = "C3", Price = 130000 });
            Add(new Product() { ProductId = 1004, ProductName = "P4", CategoryName = "C4", Price = 310000 });
            Add(new Product() { ProductId = 1005, ProductName = "P5", CategoryName = "C1", Price = 140000 });
            Add(new Product() { ProductId = 1006, ProductName = "P6", CategoryName = "C2", Price = 410000 });
            Add(new Product() { ProductId = 1007, ProductName = "P7", CategoryName = "C3", Price = 150000 });
            Add(new Product() { ProductId = 1008, ProductName = "P8", CategoryName = "C4", Price = 510000 });
        }
    }
}
