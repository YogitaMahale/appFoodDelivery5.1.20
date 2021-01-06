using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class adminCollectionViewModel
    {
        public string  managerid { get; set; }

        [Display(Name = "Manager Name")]
        public string managername { get; set; }
        

        [Display(Name = "Amount")]
        public decimal finalamt { get; set; }
        [Required]
        [Display(Name = "Collect Amount")]
        public decimal amount { get; set; }

        [Display(Name = "Remaining")]
        public decimal remaining { get; set; }
    }
}
