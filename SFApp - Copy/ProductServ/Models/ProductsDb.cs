using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServ.Models
{
    public class ProductsDb : List<Product>
    {
        public ProductsDb()
        {
            Add(new Product() { ProductId= Guid.Parse("244A37C7-23BB-43E5-BCDB-38BA453AA321"),
                ProductName="Laptop",
                Category="Electronics",Manufacturer="IBM",Price=10000 });

            Add(new Product()
            {
                ProductId = Guid.Parse("244A37C7-23BB-43F5-BCDB-38BA453AA321"),
                ProductName = "Iron",
                Category = "Electrical",
                Manufacturer = "Bajaj",
                Price = 1000
            });
            Add(new Product()
            {
                ProductId = Guid.Parse("344A37C7-23BB-43E5-BCDB-38BA453AA321"),
                ProductName = "Biscuts",
                Category = "Food",
                Manufacturer = "Parle",
                Price = 10
            });
        }
    }
}
