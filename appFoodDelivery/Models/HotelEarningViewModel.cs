using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class HotelEarningViewModel
    {



        public string id { get; set; }
        public string storename { get; set; }
        public string storetaxStatus { get; set; }

        public string hotelamount { get; set; }
        public string customerName { get; set; }

        public decimal finalamt { get; set; }
        public string orderstatus { get; set; }
        public string deliveryboyName { get; set; }


        public decimal customeramt { get; set; }
        public decimal packingcharges { get; set; }
        public decimal subtotal1 { get; set; }
        public decimal storecommission { get; set; }
        public string placedate { get; set; }




        public decimal storetax { get; set; }
        public string promocode { get; set; }
        public decimal tofozamt { get; set; }
        public decimal servicetax { get; set; }
        public decimal TCS { get; set; }
        public decimal netpayable { get; set; }

    }
}
