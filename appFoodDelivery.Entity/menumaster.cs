using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
  public  class menumaster
    {
        public int id { get; set; }
        [Required]
        [ForeignKey("productcuisinemaster")]
        public int productcuisineid { get; set; }
        public productcuisinemaster productcuisinemaster { get; set; }

        public string name { get; set; }
        public string img { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

    }
}
