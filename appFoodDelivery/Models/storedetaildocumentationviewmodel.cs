using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class storedetaildocumentationviewmodel
    {
        public int id { get; set; }

        [Display(Name = "Licence Photo")]
        public IFormFile licPhoto { get; set; }


        public Boolean isdeleted { get; set; }
    }
}
