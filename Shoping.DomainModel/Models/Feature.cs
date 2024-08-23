using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public  class Feature
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }

        public Feature()
        {
                this.CategoryFeatures=new List <CategoryFeature>();
        }
    }
}
