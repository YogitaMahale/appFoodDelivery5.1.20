using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class CityCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Select Country")]
        public int countryid { get; set; }

        [Required]
        [Display(Name = "Select State")]
        public int stateid { get; set; }

        [Required]
        public string cityName { get; set; }



        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
