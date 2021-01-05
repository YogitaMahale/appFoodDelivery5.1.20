using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class productEditViewModel
    {
        public int id { get; set; }

        public string storeid { get; set; }

        [Display(Name = "Select Cuisine")]
        public int productcuisineid { get; set; }
        [Display(Name = "Select Menu")]
        public int fkmenuid { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Menu Name")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public IFormFile img { get; set; }
        [Display(Name = "Select Veg/Nonveg")]


        public string foodtype { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public decimal amount { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Discount Type")]
        public string discounttype { get; set; }
        [Required]
        [Display(Name = "Discount( % )")]
        public decimal discountamount { get; set; }

        public string status { get; set; }

    }
}
