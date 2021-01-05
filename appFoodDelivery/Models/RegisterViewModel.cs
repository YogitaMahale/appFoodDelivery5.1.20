using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string name { get; set; }


        public string profilephoto { get; set; } = "";

        public string mobileno { get; set; } = "";


        public string gender { get; set; } = "";

        public string latitude { get; set; } = "";
        public string longitude { get; set; } = "";
        public string deviceid { get; set; } = "";

        public DateTime createddate { get; set; } = DateTime.UtcNow;

        public Boolean isdeleted { get; set; } = false;

        public Boolean isactive { get; set; } = false;
        public string Role { get; set; }

        public IEnumerable<SelectListItem> roleList { get; set; }
    }
}
