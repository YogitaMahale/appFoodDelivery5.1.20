using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace appFoodDelivery.Entity
{
   public  class CountryRegistration
    {
        public int id { get; set; }
        [Required]
        public string countryname { get; set; }

        public string countrycode { get; set; }
       

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
        // public IEnumerable<StateRegistration> StateRegistrations { get; set; }
        //public virtual StateRegistration StateRegistration { get; set; }
        public IEnumerable<StateRegistration> StateRegistration { get; set; }
    }
}
