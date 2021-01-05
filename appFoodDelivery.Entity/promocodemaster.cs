using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace appFoodDelivery.Entity
{
  public  class promocodemaster
    {
        public int id { get; set; }
        [Required]
        public string promocode { get; set; }
        public string promocodeusagelimit { get; set; }
        public string discount { get; set; }
        public string discounttype{ get; set; }

      
       

        public DateTime expirydate { get; set; }

        public DateTime createddate { get; set; }

        [System.ComponentModel.DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

       
    }
}
