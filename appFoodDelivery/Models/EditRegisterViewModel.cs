using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class EditRegisterViewModel
    {

        //public EditRegisterViewModel()
        //{
        //    Claims = new List<string>();
        //    Roles = new List<string>();
        //}
        public string Id { get; set; }


        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        ////[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
        [Required]
        public string name { get; set; }


        public IFormFile profilephoto { get; set; }
        public string  profilephotoName { get; set; }
        [Required]
        public string mobileno { get; set; } = "";


        public string gender { get; set; } = "";

        public string latitude { get; set; } = "";
        public string longitude { get; set; } = "";
        public string deviceid { get; set; } = "";

        public DateTime createddate { get; set; } = DateTime.UtcNow;

        public Boolean isdeleted { get; set; } = false;

        public Boolean isactive { get; set; } = false;

    }
}
