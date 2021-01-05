using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class orderselectallDetailsViewModel
    {
        public int id { get; set; }

        public int oid { get; set; }

        public int pid { get; set; }
        public string productname { get; set; }
        public decimal qty { get; set; }

        public decimal price { get; set; }
        public string total { get; set; }
        public Boolean isdeleted { get; set; }
    }
}
