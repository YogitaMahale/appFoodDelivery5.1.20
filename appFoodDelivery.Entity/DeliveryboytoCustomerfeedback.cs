using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace appFoodDelivery.Entity
{
  public  class DeliveryboytoCustomerfeedback
    {
        public int id { get; set; }

       
        public int deliveryboyid { get; set; }
        public int customerid { get; set; }

        public string comment { get; set; }

        public string rating { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
