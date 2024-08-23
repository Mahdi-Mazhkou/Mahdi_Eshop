using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.BusinessModel.Product
{
    public  class ProductListItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public bool HasRelatedOrder { get; set; }
        public long UnitPrice { get; set; }
        public string Slug { get; set; }
    }
}
