using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models.dtos
{
    public class hotelSelectSPViewModel
    {
        public int id { get; set; }
         
        public string storeid { get; set; }


        public string contactpersonname { get; set; }
        public string emailaddress { get; set; }
        public string contactno { get; set; }
        public string gender { get; set; }
        public string fooddelivery { get; set; }
        public string storename { get; set; }




        
        public int? radiusid { get; set; }
        public radiusmaster radiusmaster { get; set; } = null;



        public int? deliverytimeid { get; set; }
        public deliverytimemaster deliverytimemaster { get; set; } = null;



        public decimal orderMinAmount { get; set; }


       
        public decimal packagingCharges { get; set; }
        public string storeBannerPhoto { get; set; }

        public string address { get; set; }
        public string description { get; set; }

        public string storetime { get; set; }
        public string licPhoto { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }

         
        public int? cityid { get; set; }
        public CityRegistration CityRegistration { get; set; } = null;

 
        public Boolean isdeleted { get; set; }

        public string promocode { get; set; }
         
        public decimal discount { get; set; }

        public string accountno { get; set; }
        public string bankname { get; set; }
        public string banklocation { get; set; }
        public string ifsccode { get; set; }

        public string status { get; set; }



        
        public decimal adminCommissionPer { get; set; } = 0;


        public string taxstatus { get; set; }
       
        public decimal taxstatusPer { get; set; } = 0;

        
        public decimal payamount { get; set; } = 0;
    }
}
