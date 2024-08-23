using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.BusinessModel.Product
{
    public  class ProductAddEditModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public long UnitPrice { get; set; }
        public string Slug { get; set; }
        public string PageTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string JSONLDInformation { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
       
    }
}
