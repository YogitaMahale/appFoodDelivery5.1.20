using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
   public  class deliveryboyPaidAmount
    {
        public int id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string  collectManagerId { get; set; }       


        [ForeignKey("driverRegistration")]
        public int? deliveryboyid { get; set; }



       

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; } = 0;
        public DateTime date1 { get; set; }
         
    }
}
