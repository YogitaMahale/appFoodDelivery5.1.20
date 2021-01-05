using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class productcuisineEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Cuisine")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public IFormFile img { get; set; }
    }
}
