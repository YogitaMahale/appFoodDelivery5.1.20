using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
 public   class AssignDeliveryboyToManager
    {
        public int Id { get; set; }      
         

        [ForeignKey("ApplicationUser")]
        public string  managerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("driverRegistration")]
        public int deliveryboyid { get; set; }
        public driverRegistration driverRegistration { get; set; }


        

    }
}
