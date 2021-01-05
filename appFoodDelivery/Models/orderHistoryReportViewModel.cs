using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class orderHistoryReportViewModel
    {
        public string id { get; set; }
        public string storename { get; set; }


        public string customerName { get; set; }

        public decimal finalamt { get; set; }
        public decimal customeramt { get; set; }
        public decimal customerdeliverycharges { get; set; }
        public decimal deliveryboycharges { get; set; }

        public string placedate { get; set; }
        public string orderstatus { get; set; }


        public string deliveryboyName { get; set; }

        public string promocode { get; set; }
        public decimal tofozamt { get; set; }
        public decimal netpayable { get; set; }
        public string paymentstatus { get; set; }

        
    }
}
