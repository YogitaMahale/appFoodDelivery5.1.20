using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class VersionEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Store Version")]
        public string storeVersion { get; set; }


        [Required]
        [Display(Name = "Customer Version")]
        public string customerVersion { get; set; }
        [Required]
        [Display(Name = "Delivery boy Version")]

        public string deliveryboyVersion { get; set; }


    }
}
