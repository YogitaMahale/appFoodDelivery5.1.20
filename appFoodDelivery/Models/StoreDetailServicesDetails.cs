using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace appFoodDelivery.Models
{
    public class StoreDetailServicesDetails
    {
        public int id { get; set; }

        public string storeid { get; set; }
        [Required]
        [Display(Name = "Service")]
        public string fooddelivery { get; set; }

        public Boolean isdeleted { get; set; }
    }
}
