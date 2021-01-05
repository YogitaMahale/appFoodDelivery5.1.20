using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace appFoodDelivery.Entity
{
  public   class orderproducts
    {
        public int id { get; set; }
        [ForeignKey("orders")]
        public int oid { get; set; }

        [ForeignKey("product")]
        public int pid { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal qty { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal price { get; set; }
        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
       

    }
}
