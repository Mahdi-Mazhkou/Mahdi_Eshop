using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public  class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public long UnitPrice { get; set; }
        public string Slug { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string JSONLDInformation { get; set; }
        public string ImageUrl { get; set;}
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<ProductKeyword> ProductKeywords { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public Product()
        {
                this.ProductKeywords=new List<ProductKeyword>();
                this.OrderDetails=new List<OrderDetails>();
                this.ProductFeatures=new List<ProductFeature>();
        }
    }
}
