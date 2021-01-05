using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace appFoodDelivery.Models
{
    public class ApplicationUser:   IdentityUser
    {
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public IFormFile profilephoto { get; set; }
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Mobile No is Required")]
        public string mobileno { get; set; }
       
        [Display(Name = "Gender")]
        public string gender { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }
        public string deviceid { get; set; }

        public DateTime createddate { get; set; } = DateTime.UtcNow;

        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }


    }
}
