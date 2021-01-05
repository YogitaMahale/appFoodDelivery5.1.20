using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class StateIndexViewModel
    {
        public int id { get; set; }

        public int countryid { get; set; }
        public string countryName { get; set; }
        public CountryRegistration CountryRegistration { get; set; }
        public string StateName { get; set; }

    }
}
