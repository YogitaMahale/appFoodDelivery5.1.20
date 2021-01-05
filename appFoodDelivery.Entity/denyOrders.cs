using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
  public  class denyOrders
    {
        public int id { get; set; }
        [ForeignKey("orders")]
        public int orderid { get; set; }

        
        [ForeignKey("driverRegistration")]
        public int? deliveryboyid { get; set; }

       
        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }


    }
}
