using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models.dtos
{
    public class GetUserDetailsViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string name { get; set; }
        public string mobileno { get; set; }
       public decimal CollectOrderAmtfromDeliveryboy { get; set; }

        public string role { get; set; }

        //  Id,Email,name ,mobileno
    }
}
