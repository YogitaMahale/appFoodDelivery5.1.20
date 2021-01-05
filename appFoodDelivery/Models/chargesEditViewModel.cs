using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class chargesEditViewModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Customer Delivery Charge per 1 km")]
        public decimal customer1Km { get; set; } = 0;
        [Required]
        [Display(Name = "Customer Delivery Charge  for 2km ")]

        public decimal customer2K { get; set; } = 0;
        [Required]
        [Display(Name = "Delivery Boy Delivery Charge per 1 km")]

        public decimal deliveryboy1Km { get; set; } = 0;

        [Required]
        [Display(Name = "Delivery Boy Delivery Charge for 2km")]
        public decimal deliveryboy2Km { get; set; } = 0;
    }
}
