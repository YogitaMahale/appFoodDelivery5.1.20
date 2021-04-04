using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
   public  class driverRegistration
    {
        public int id { get; set; }

        public string name { get; set; }

        public string profilephoto { get; set; }

        public string mobileno { get; set; }

        public string emailid { get; set; }


        public string password { get; set; }

        public string gender { get; set; }

        public string latitude { get; set; } = "0";
        public string longitude { get; set; } = "0";
        public string deviceid { get; set; }
        public DateTime createddate { get; set; }

        public string biketype { get; set; }
        public string manufacturename { get; set; }
        public string modelname { get; set; }
        public string modelyear { get; set; }
        public string vehicleplateno { get; set; }
        public string drivinglicphoto { get; set; }
        public string vehicleinsurancephoto { get; set; }

        public string accountno { get; set; }
        public string bankname { get; set; }
        public string banklocation { get; set; }
        public string ifsccode { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
        public string status { get; set; }

        public string bloodgroup { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal payamount { get; set; } = 0;
    }
}
