using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
    public class CityRegistration
    {
        public int id { get; set; }
        [ForeignKey("StateRegistration")]
        public int stateid { get; set; }
        public StateRegistration StateRegistration { get; set; }
         
        [Required]
        public string cityName { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

       
        

    }
}
