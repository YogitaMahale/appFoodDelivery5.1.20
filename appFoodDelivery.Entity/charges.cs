using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
   public class charges
    {
        public int id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal customer1Km { get; set; } = 0;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal customer2K { get; set; } = 0;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal deliveryboy1Km { get; set; } = 0;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal deliveryboy2Km { get; set; } = 0;
    }
}
