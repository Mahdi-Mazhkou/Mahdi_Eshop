using FrameWork.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.BusinessModel.Category
{
    public  class CategorySearchModel:PageModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int SortOrder { get; set; }
        public int ProductCount { get; set; }
        public int? ParentID { get; set; }
    }
}
