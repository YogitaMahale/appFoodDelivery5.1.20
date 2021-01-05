using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class StorePaidAmountReportModel
    {
        public int id { get; set; }

        public string storeid { get; set; }
        //id, storeid, amount
        public string amount { get; set; }

        public string paydate { get; set; }
        

    }
}
