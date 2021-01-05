using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class storePaymentViewModel
    {
     //   id,payamount, storeid, storename
         
        public int id { get; set; }
        public decimal  payamount { get; set; }
        public string  storeid { get; set; }
        public string storename { get; set; }

    }
}
