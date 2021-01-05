using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class orderinvoice
    {
        //public IEnumerable<orderselectallViewModel> orderheader { get; set; }
        public orderselectallViewModel orderheader { get; set; }
        public IEnumerable<orderselectallDetailsViewModel> orderdetails { get; set; }
    }

}
