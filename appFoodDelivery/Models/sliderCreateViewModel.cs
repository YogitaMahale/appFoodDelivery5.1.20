using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class sliderCreateViewModel
    {
        public int id { get; set; }
        public IFormFile name { get; set; }


        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
