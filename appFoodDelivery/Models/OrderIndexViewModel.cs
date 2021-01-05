using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class OrderIndexViewModel
    {
        public int id { get; set; }

        public int customerid { get; set; }
        public string customername { get; set; }

        public string storeid { get; set; }


        public decimal amount { get; set; } = 0;
        public DateTime placedate { get; set; }


        public int? deliveryboyid { get; set; }

        public string orderstatus { get; set; }

        public string promocode { get; set; }


        public decimal discount { get; set; } = 0;
        public string deliveryaddress { get; set; }

        public string paymenttype { get; set; }

        public string paymentstatus { get; set; }

        public string transactionid { get; set; }

        public Boolean isdeleted { get; set; }
    }
}
