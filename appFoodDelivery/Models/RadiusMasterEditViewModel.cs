using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class RadiusMasterEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Delivery Radius")]
        public string name { get; set; }
    }
}
