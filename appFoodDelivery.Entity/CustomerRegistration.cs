using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace appFoodDelivery.Entity
{
  public  class CustomerRegistration
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string profilephoto { get; set; }
        public string address { get; set; }

        [Required]
        public string mobileno1 { get; set; }
        public string mobileno2 { get; set; }
        public string emailid1 { get; set; }
        public string latitude { get; set; }
      
        public string longitude { get; set; }

        
        [Required]
        public string password { get; set; }
        [Required]
        public string gender { get; set; }

        public DateTime DOB { get; set; }

        public DateTime createddate { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

        public string deviceid { get; set; }
    }
}
