using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace appFoodDelivery.Models
{
    public class deliveryboyAssignorderViewModel
    {
        [Display(Name = "Order ID")]
        public int id { get; set; }

        [Display(Name = "Select Deliveryboy")]
        public int deliveryboyid { get; set; }
        [Display(Name = "Customer")]
        public string customername { get; set; }
    }
}
