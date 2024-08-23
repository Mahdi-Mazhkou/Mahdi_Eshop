using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.BusinessModel.Category
{
    public class CategoryAddEditModel
    {

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int? ParentID { get; set; }
    }
}
