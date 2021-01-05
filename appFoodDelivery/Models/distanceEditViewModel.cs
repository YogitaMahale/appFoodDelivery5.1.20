using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class distanceEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Range")]
        public decimal range { get; set; } = 0;





    }
}
