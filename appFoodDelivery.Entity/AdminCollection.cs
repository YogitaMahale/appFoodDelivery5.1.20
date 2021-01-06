using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
 public  class AdminCollection
    {
        public int id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string collectManagerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; } = 0;
        public DateTime date1 { get; set; }
        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
    }
}
