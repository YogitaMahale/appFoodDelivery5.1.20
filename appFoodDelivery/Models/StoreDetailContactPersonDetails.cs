using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace appFoodDelivery.Models
{
    public class StoreDetailContactPersonDetails
    {
        public int id { get; set; }

        public string storeid { get; set; }
        [Required]
        [Display(Name = "Contact Person Name")]

        public string contactpersonname { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string emailaddress { get; set; }

        [Required]
        [Display(Name = "Contact No")]
        public string contactno { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }


        public Boolean isdeleted { get; set; }
    }
}
