using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
  public  class distance
    {
        public int id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal range { get; set; } = 0;



        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

    }
}
