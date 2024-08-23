using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public  class ProductFeature
    {
        public int ProductFeatureID { get; set; }
        public int ProductID { get; set; } 
        public int FeatureID { get; set; } 
        public Product Product { get; set; } 
        public Feature Feature { get; set; } 
        public string ProductFeatureValue { get; set; }
        public int EffectOnUnitPrice { get; set; }
    }
}
