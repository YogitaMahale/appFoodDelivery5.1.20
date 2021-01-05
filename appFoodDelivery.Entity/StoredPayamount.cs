using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
  public  class StoredPayamount
    {
        public int id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string storeid { get; set; }


        //[ForeignKey("orders")]
        //public int oid { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; } = 0;



       

        public DateTime paydate { get; set; }

    }
}
