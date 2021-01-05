using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace appFoodDelivery.Entity
{
  public   class deliveryboyAlertAmount
    {
        public int id { get; set; }

        public decimal amount { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }


    }
}
