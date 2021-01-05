using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class driverAmountViewModel
    {
        public int id { get; set; }
         
        [Display(Name = "Delivery Name")]
        public string drivername { get; set; }
        
        [Display(Name = "Amount")]
        public decimal  finalamt { get; set; }
        [Required]
        [Display(Name = "Pay Amount")]
        public decimal  amount { get; set; }
        
        [Display(Name = "Remaining")]
        public decimal remaining { get; set; }
    }
}
