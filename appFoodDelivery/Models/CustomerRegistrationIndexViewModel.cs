using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class CustomerRegistrationIndexViewModel
    {
        public int id { get; set; }

        public string name { get; set; }
        public string profilephoto { get; set; }
        public string address { get; set; }


        public string mobileno1 { get; set; }



        public string gender { get; set; }

        public DateTime DOB { get; set; }

        public DateTime createddate { get; set; }



    }
}
