using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace appFoodDelivery.Entity
{
    public class storeowner
    {
        public int id { get; set; }

        public string name { get; set; }

        public string profilephoto { get; set; }

        public string mobileno { get; set; }

        public string emailid { get; set; }


        public string password { get; set; }

        public string gender { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }
        public string deviceid { get; set; }
        public DateTime createddate { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }






    }
}
