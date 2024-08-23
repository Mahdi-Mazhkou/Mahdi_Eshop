using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public  class KeyWord
    {
        public int KeyWordID { get; set; } 
        public string KeyWordText { get; set; } 
        public ICollection<ProductKeyword> ProductKeywords { get; set; }

        public KeyWord()
        {
                this.ProductKeywords = new List<ProductKeyword>();   
        }
    }
}
