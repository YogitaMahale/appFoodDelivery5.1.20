using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
   public class DriverPayamount
    {
        public int id { get; set; }
        [ForeignKey("driverRegistration")]
        public int deliveryboyid { get; set; }

        //[ForeignKey("orders")]
        //public int oid { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; } = 0;



       

        public DateTime paydate { get; set; }

    }
}
