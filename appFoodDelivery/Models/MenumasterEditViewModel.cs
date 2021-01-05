using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class MenumasterEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Menu Name")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public IFormFile img { get; set; }
        [Required]
        [Display(Name = "Select Cusine")]
        public int productcuisineid { get; set; }
    }
}
