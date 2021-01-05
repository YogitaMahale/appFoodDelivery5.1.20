using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class CustomerRegistrationEditViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required"), StringLength(500, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s]+$"), Display(Name = "Name")]
        public string name { get; set; }
        public IFormFile profilephoto { get; set; }
        public string address { get; set; }


        public string mobileno1 { get; set; }
        public string mobileno2 { get; set; }
        public string emailid1 { get; set; }
        public string latitude { get; set; }

        public string longitude { get; set; }


        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public DateTime DOB { get; set; } = DateTime.UtcNow;

        public DateTime createddate { get; set; } = DateTime.UtcNow;



    }
}
