using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class searchViewModel
    {
        public DateTime txtFromDate { get; set; } = Convert.ToDateTime(DateTime.UtcNow.ToString("dd/MM/yyyy"));
        public DateTime txtToDate { get; set; } = Convert.ToDateTime(DateTime.UtcNow.ToString("dd/MM/yyyy"));
    }
}
