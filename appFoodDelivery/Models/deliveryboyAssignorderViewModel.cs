using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace appFoodDelivery.Models
{
    public class deliveryboyAssignorderViewModel
    {
        public int id { get; set; }

        [Display(Name = "Select Deliveryboy")]
        public int deliveryboyid { get; set; }

        public string customername { get; set; }
    }
}
