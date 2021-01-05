using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace appFoodDelivery.Entity
{
  public   class tax
    {
        public int id { get; set; }

        public decimal  taxpercentage { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
       


    }
}
