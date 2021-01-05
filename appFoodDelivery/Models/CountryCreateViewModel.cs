using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class CountryCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Country Name")]
        public string countryname { get; set; }
        public string countrycode { get; set; }



        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
