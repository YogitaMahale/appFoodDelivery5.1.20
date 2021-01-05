using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace appFoodDelivery.Entity
{
    public class storedetails
    {
        public int id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string storeid { get; set; }
        
        
        public string contactpersonname { get; set; }
        public string emailaddress { get; set; }
        public string contactno { get; set; }
        public string gender { get; set; }
        public string fooddelivery { get; set; }
        public string storename { get; set; }




        [ForeignKey("radiusmaster")]
        public int? radiusid { get; set; }
        public radiusmaster radiusmaster { get; set; }


        [ForeignKey("deliverytimemaster")]
        public int? deliverytimeid { get; set; }
        public deliverytimemaster deliverytimemaster { get; set; }

        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal orderMinAmount { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal packagingCharges { get; set; }
        public string storeBannerPhoto { get; set; }

        public string address { get; set; }
        public string description { get; set; }

        public string storetime { get; set; }
        public string licPhoto { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }

        [ForeignKey("CityRegistration")]
        public int? cityid { get; set; }
        public CityRegistration CityRegistration { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }

        public string promocode { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal discount { get; set; }

        public string accountno { get; set; }
        public string bankname { get; set; }
        public string banklocation { get; set; }
        public string ifsccode { get; set; }

        public string status { get; set; }



        [Column(TypeName = "decimal(18, 2)")]
        public decimal adminCommissionPer { get; set; } = 0;


        public string taxstatus { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal taxstatusPer { get; set; } = 0;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal payamount { get; set; } = 0;

    }
}
