using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class DriverEditViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public IFormFile profilephoto { get; set; }
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Mobile No is Required")]
        public string mobileno { get; set; }
        [Display(Name = "Email ID")]
        public string emailid { get; set; }

        [Display(Name = "Password")]

        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }
        public string deviceid { get; set; }
        public DateTime createddate { get; set; }
        [Display(Name = "Bike Type")]
        public string biketype { get; set; }
        [Display(Name = "Manufacture Name")]
        public string manufacturename { get; set; }
        [Display(Name = "Model Name")]
        public string modelname { get; set; }
        [Display(Name = "Model Year")]
        public string modelyear { get; set; }
        [Display(Name = "Vehicle PlateNo")]
        public string vehicleplateno { get; set; }
        [Display(Name = "Driving License Photo")]
        public IFormFile drivinglicphoto { get; set; }
        [Display(Name = "Gender")]
        public IFormFile vehicleinsurancephoto { get; set; }
        [Display(Name = "Account No.")]
        public string accountno { get; set; }
        [Display(Name = "Bank Name")]
        public string bankname { get; set; }
        [Display(Name = "Bank Location")]
        public string banklocation { get; set; }
        [Display(Name = "IFSC Code")]
        public string ifsccode { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
        [Display(Name = "Blood Group")]
        public string bloodgroup { get; set; }


    }
}
