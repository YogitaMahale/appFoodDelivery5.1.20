using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class storeCountModel
    {
        //       totalAmount totalOrderCount totalPlacedOrder totalApprovedOrder  totalOngoingOrder totalCompleteOrder  totalCancelOrder
        public string totalAmount { get; set; }
        public string totalOrderCount { get; set; }
        public string totalPlacedOrder { get; set; }
        public string totalApprovedOrder { get; set; }
        public string totalOngoingOrder { get; set; }
        public string totalCompleteOrder { get; set; }
        public string totalCancelOrder { get; set; }
        public string storeAmountWithoutDeliveryboyCost { get; set; }

        public string deliveryboycharges { get; set; }


    }
}
