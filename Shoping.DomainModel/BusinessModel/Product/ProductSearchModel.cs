using FrameWork.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.BusinessModel.Product
{
    public  class ProductSearchModel:PageModel
    {
        public int? SupplierID { get; set; }
        public int? CategotyID { get; set; }
        public int? UnitPriceFrom { get; set; }
        public int? UnitPriceTo { get; set; }
        public string  ProductName { get; set; }
        public string Slug { get; set; }

    }
}
