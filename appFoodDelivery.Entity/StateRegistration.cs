using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
  public  class StateRegistration
    {


        public int id { get; set; }


        
        public int countryid { get; set; }
       
        [Required]
        public string StateName { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
        [ForeignKey("countryid")]

       public virtual CountryRegistration CountryRegistration { get; set; }
        //public virtual  CountryRegistration CountryRegistration { get; set; }

    }
}
