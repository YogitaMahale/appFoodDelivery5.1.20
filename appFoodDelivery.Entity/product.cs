using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
    public class product
    {
        public int id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string  storeid { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("productcuisinemaster")]
        public int productcuisineid { get; set; }
        public productcuisinemaster productcuisinemaster { get; set; }


        // [ForeignKey("menumaster")]
        public int fkmenuid { get; set; }
       // public menumaster menumaster { get; set; }




        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public string img { get; set; }
        [Display(Name = "Food Type")]
        
        public string foodtype { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
        public string description { get; set; }
      
        public string discounttype { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal discountamount { get; set; }
        public DateTime createddate { get; set; } = DateTime.UtcNow;

        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
        public string status { get; set; }

    }
}
