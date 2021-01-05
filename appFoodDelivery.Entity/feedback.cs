using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace appFoodDelivery.Entity
{
   public  class customerfeedback
    {
        public int id { get; set; }

        public int fromcustomerid { get; set; }
        public int? toDeliveryboyid { get; set; }
        public int? toStoredid { get; set; }


        public string comment { get; set; }

        public string rating { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
