using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
   public  class orders
    {
        public int id { get; set; }
        [ForeignKey("CustomerRegistration")]
        public int customerid { get; set; }

        [ForeignKey("ApplicationUser")]
        public string storeid { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; } = 0;
        public DateTime placedate { get; set; }
         
        [ForeignKey("driverRegistration")]
        public int? deliveryboyid { get; set; }
       
        public string orderstatus { get; set; }

        public string promocode { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal discount { get; set; } = 0;
        public string deliveryaddress { get; set; }

        public string paymenttype { get; set; }

        public string paymentstatus { get; set; }

        public string transactionid { get; set; }

        public string instructions { get; set; }
        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }


        public string customerdeliverylatitude { get; set; }

        public string customerdeliverylongitude { get; set; }

        public string deliveryboylatitude { get; set; }

        public string deliveryboylongitude { get; set; }
        public string storelatitude { get; set; }

        public string storelongitude { get; set; }


        //[DefaultValue("false")]
        //  public Boolean isactive { get; set; }
        public string  deliveryboyCheckStaus { get; set; } 
        public string storeCheckStaus { get; set; } 
    }
}
