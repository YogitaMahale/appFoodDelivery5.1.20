using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class productcuisineCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Cuisine")]
        public string name { get; set; }
        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
        [Display(Name = "Photo")]
        public IFormFile img { get; set; }
    }
}
