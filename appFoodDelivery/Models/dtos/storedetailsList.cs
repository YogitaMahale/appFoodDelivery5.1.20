using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models.dtos
{
    public class storedetailsList
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string storeName { get; set; }
        public string adminCommissionPer { get; set; }
        public string storeBannerPhoto { get; set; }
        public string taxstatus { get; set; }
        public decimal taxstatusPer { get; set; }
        public string ownername { get; set; }
        public string storestatus { get; set; }


        //        Id
        //,Email
        //            ,storeName
        //            adminCommissionPer
        //            storeBannerPhoto
        //            taxstatus
        //            taxstatusPer
    }
}
