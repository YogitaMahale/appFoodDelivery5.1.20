using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class CityIndexViewModel
    {
        public int id { get; set; }


        public int countryid { get; set; }
        public int stateid { get; set; }


        public string cityName { get; set; }


        public CountryRegistration CountryRegistration { get; set; }

        public StateRegistration StateRegistration { get; set; }
    }
}
