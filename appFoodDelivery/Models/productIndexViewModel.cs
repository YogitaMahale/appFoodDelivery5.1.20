using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class productIndexViewModel
    {
        public int id { get; set; }

        public string storeid { get; set; }
        public ApplicationUser ApplicationUser { get; set; }



        public int productcuisineid { get; set; }
        public productcuisinemaster productcuisinemaster { get; set; }


        public int fkmenuid { get; set; }

        public string name { get; set; }

        public string img { get; set; }

        public string foodtype { get; set; }

        public decimal amount { get; set; }
        public string description { get; set; }

        public string discounttype { get; set; }

        public decimal discountamount { get; set; }



    }
}
