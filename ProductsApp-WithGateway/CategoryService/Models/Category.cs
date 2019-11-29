using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class Categories : List<Category>
    {
        public Categories()
        {
            Add(new Category() { CategoryId = 101, CategoryName = "C1" });
            Add(new Category() { CategoryId = 102, CategoryName = "C2" });
            Add(new Category() { CategoryId = 103, CategoryName = "C3" });
            Add(new Category() { CategoryId = 104, CategoryName = "C4" });
        }
    }
}
