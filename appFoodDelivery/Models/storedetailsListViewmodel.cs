using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class storedetailsListViewmodel
    {
        public int id { get; set; }

        public string storeid { get; set; }
        public string contactpersonname { get; set; }
        public string emailaddress { get; set; }
        public string contactno { get; set; }
        public string gender { get; set; }
        public string fooddelivery { get; set; }
        public string storename { get; set; }
        public string radiusid { get; set; }
        public string deliverytimeid { get; set; }
        public decimal orderMinAmount { get; set; }
        public decimal packagingCharges { get; set; }
        public string storeBannerPhoto { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string storetime { get; set; }
        public string licPhoto { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string cityid { get; set; }
        public string promocode { get; set; }
        public decimal discount { get; set; }
        public string status { get; set; }

    }
}
