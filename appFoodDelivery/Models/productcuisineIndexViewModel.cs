using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class productcuisineIndexViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Cuisine")]
        public string name { get; set; }

        public string img { get; set; }
    }
}
