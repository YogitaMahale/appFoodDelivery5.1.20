using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class DeliveryTimeIndexViewModel
    {
        public int id { get; set; }

        public string name { get; set; }
        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
