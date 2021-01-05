using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class DriverIndexViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public string profilephoto { get; set; }
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Mobile No is Required")]
        public string mobileno { get; set; }
        [Display(Name = "Email ID")]

        public Boolean isactive { get; set; }
    }
}
