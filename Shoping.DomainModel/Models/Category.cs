using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public  class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName{ get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int? ParentID { get; set; }
        public string LineAge { get; set; }
        public int DirectChildCount { get; set; }
        public int ProductCount { get; set; }
        public Category Parent { get; set; } 
        public  ICollection <Product> Products { get; set; }
        public  ICollection <CategoryFeature> CategoryFeatures { get; set; }
        public ICollection<Category>Children { get; set; }
        public Category()
        {
                this.Products=new List<Product>();
                this.CategoryFeatures= new List<CategoryFeature>();
                this.Children=new List<Category>();
        }

    }
}
