using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.DomainModel.Models
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int TotalPrice
        {
            get { return Quantity * UnitPrice; }
            set { }
        }
    }
}
