using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace appFoodDelivery.Models
{
    public class CustomerRegistrationCreateViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required"), StringLength(500, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s]+$"), Display(Name = "Name")]
        public string name { get; set; }
        public IFormFile profilephoto { get; set; }
        public string address { get; set; }

        [Display(Name = "Mobile No.")]
        [Required(ErrorMessage = "Mobile No is Required")]
        public string mobileno1 { get; set; }
        [Display(Name = "Alternet Mobile No.")]

        public string mobileno2 { get; set; }
        [Display(Name = "Email ID")]
        public string emailid1 { get; set; }
        [Display(Name = "Latitude")]
        public string latitude { get; set; }
        [Display(Name = "Longitude")]
        public string longitude { get; set; }
        [Required]
        [Display(Name = "Password")]

        public string password { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; } = DateTime.UtcNow;
        [Display(Name = "Date")]
        public DateTime createddate { get; set; } = DateTime.UtcNow;


        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
