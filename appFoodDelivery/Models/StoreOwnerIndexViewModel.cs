using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class StoreOwnerIndexViewModel
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

        
        public Boolean isactive { get; set; }



    }
}
