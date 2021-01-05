using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class amtcollectionReportViewModel
    {


        
        public int id { get; set; }
        public int deliveryboyid { get; set; }


        public decimal amount { get; set; }

        public string  date1 { get; set; }
        public decimal remainingamt { get; set; }
        
    }
}
