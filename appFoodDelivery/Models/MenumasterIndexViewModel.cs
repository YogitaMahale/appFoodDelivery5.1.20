using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class MenumasterIndexViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Menu Name")]
        public string name { get; set; }

        public string img { get; set; }

        public int productcuisineid { get; set; }

        public string cusinename { get; set; }
    }
}
