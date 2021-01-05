using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace appFoodDelivery.Entity
{
   public  class versions
    {
        public int id { get; set; }

        public string  storeVersion { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }


        public string customerVersion { get; set; }

        public string deliveryboyVersion { get; set; }


        

         
    }
}
