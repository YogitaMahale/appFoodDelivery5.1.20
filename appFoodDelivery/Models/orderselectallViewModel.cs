using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace appFoodDelivery.Models
{
    public class orderselectallViewModel
    {

        //       id, customerid, amount, placedate, deliveryboyid, paymentstatus, orderstatus, isdeleted, discount, 
        //storeid, deliveryaddress, paymenttype, promocode, transactionid,customerName,mobileno,storename
        public int id { get; set; }

        public int customerid { get; set; }

        public string logintype { get; set; }
        public string storeid { get; set; }
        [Display(Name = "Customer Name")]

        public string customerName { get; set; }
        public string mobileno { get; set; }
        public string storename { get; set; }

        public decimal amount { get; set; } = 0;
        public string placedate { get; set; }

        public int? deliveryboyid { get; set; }

        public string orderstatus { get; set; }
        public string orderstatusPropername { get; set; }

        public string promocode { get; set; }




        public decimal discount { get; set; } = 0;
        public string deliveryaddress { get; set; }

        public string paymenttype { get; set; }

        public string paymentstatus { get; set; }

        public string transactionid { get; set; }
        public string storeaddress { get; set; }
        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
        public string deliveryboyname { get; set; }
        public string time { get; set; }
        public string instructions { get; set; }


        public string deliverychargers { get; set; }
        public string kilometer { get; set; }

        public string customerdeliverylatitude { get; set; }
        public string customerdeliverylongitude { get; set; }
        public decimal deliveryboycharges { get; set; }
        public decimal productCost { get; set; }
        public decimal deliverycharges { get; set; }
    }
}
//"id": 749,
//      "customerid": 7,
//      "logintype": "admin",
//      "storeid": "93bb55c0-e6dd-4875-8928-ffa0cf51f40a",
//      "customerName": "yogesh",
//      "mobileno": "7276541222",
//      "storename": "All In One",
//      "amount": 62.50,
//      "placedate": "19/09/2020",
//      "deliveryboyid": 2,
//      "orderstatus": "ongoingorders",
//      "orderstatusPropername": "Shipped",
//      "promocode": "Welcome",
//      "discount": 10.00,
//      "deliveryaddress": "37, Makhmalabad Rd, Ganesh Nagar, Janata Raja Colony, Nashik, Maharashtra 422003, India",
//      "paymenttype": "Cash on Delivery",
//      "paymentstatus": "Cash on Delivery",
//      "transactionid": null,
//      "storeaddress": null,
//      "isdeleted": false,
//      "isactive": false,
//      "deliveryboyname": "raju",
//      "time": "8:17:44",
//      "instructions": null