using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class reportViewModel
    {
        public int id { get; set; }
        public decimal amount { get; set; }
        public string storeAmount { get; set; }
        public int customerid { get; set; }
        public string customername { get; set; }
        public DateTime placedate { get; set; }
        public int deliveryboyid { get; set; }
        public string drivername { get; set; }
        public string paymentstatus { get; set; }
        public string orderstatus { get; set; }
        public string storeid { get; set; }
        public string storename { get; set; }




        public string paymenttype { get; set; }
        public string promocode { get; set; }
        public string transactionid { get; set; }
        public string instructions { get; set; }
        public string customerdeliverylatitude { get; set; }


        public string customerdeliverylongitude { get; set; }
        public string deliveryboylatitude { get; set; }
        public string deliveryboylongitude { get; set; }
        public string storelatitude { get; set; }
        public string storelongitude { get; set; }

        public string deliveryboyCheckStaus { get; set; }
        public string storeCheckStaus { get; set; }
    }
}
