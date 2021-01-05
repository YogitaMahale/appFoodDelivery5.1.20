using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class productModel
    {
        public int id { get; set; }

        public string storeid { get; set; }

        public int productcuisineid { get; set; }



        public int fkmenuid { get; set; }




        public string name { get; set; }

        public string img { get; set; }

        public string foodtype { get; set; }

        public decimal amount { get; set; }
        public string description { get; set; }

        public string discounttype { get; set; }

        public decimal discountamount { get; set; }
        public DateTime createddate { get; set; } = DateTime.UtcNow;

        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
        public string status { get; set; }
    }
}
