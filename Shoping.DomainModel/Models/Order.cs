using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public  class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int AddressID { get; set; }
        public int CustomerID { get; set; }
        public string OrderDescription { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Order()
        {
                this.OrderDetails=new List<OrderDetails>();
        }
    }
}
