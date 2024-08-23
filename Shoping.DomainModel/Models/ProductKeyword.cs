using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public  class ProductKeyword
    {
        public int ProductKeywordID { get; set; }
        public int ProductID { get; set; }
        public int keywordID { get; set; }
        public KeyWord KeyWord { get; set; }
        public Product Product { get; set; }

    }
}
