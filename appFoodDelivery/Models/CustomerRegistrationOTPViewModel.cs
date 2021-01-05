using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace appFoodDelivery.Models
{
    public class CustomerRegistrationOTPViewModel
    {
        public int? id { get; set; } = null;

        public string name { get; set; } = null;
        public string profilephoto { get; set; } = null;
        public string address { get; set; } = null;


        public string mobileno1 { get; set; } = null;

        public string mobileno2 { get; set; } = null;

        public string emailid1 { get; set; } = null;

        public string latitude { get; set; } = null;

        public string longitude { get; set; } = null;


        public string password { get; set; } = null;
        public string gender { get; set; } = null;

        public DateTime? DOB { get; set; } = null;

        public DateTime? createddate { get; set; } = null;


        public Boolean? isdeleted { get; set; } = null;

        public Boolean? isactive { get; set; } = null;

        public string otpno { get; set; } = null;
    }
}
