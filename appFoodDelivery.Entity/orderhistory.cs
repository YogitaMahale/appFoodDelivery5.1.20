using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace appFoodDelivery.Entity
{
   public  class orderhistory
    {
        public int id { get; set; }
        [ForeignKey("orders")]
        public int oid { get; set; }
        public DateTime placedate { get; set; }
        public string orderstatus { get; set; }

      
        public string reason { get; set; }
    }
}
