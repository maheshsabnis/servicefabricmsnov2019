using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServ.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
    }
}
