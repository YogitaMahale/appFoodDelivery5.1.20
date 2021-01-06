using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class customerTodeliveryboyFeedback
    {
        public int id { get; set; }
        public int fromcustomerid { get; set; }
        public int toDeliveryboyid { get; set; }
        public string comment { get; set; }
        public string rating { get; set; }
        public string customername { get; set; }

        public string deliveryboyname { get; set; }

    }
    public class customerToStoreFeedback
    {
        public int id { get; set; }
        public int fromcustomerid { get; set; }
        public string  toStoredid { get; set; }
        public string comment { get; set; }
        public string rating { get; set; }
        public string customername { get; set; }

        public string storename { get; set; }
    }
    public class deliveryboyCustomerFeedback
    {
        public int id { get; set; }
        public int deliveryboyid { get; set; }
        public int customerid { get; set; }
        public string comment { get; set; }
        public string rating { get; set; }
        public string customername { get; set; }

        public string deliveryboyname { get; set; }
    }
}
