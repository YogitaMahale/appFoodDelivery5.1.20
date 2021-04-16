using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models.dtos
{
    public class GetManagerList
    {
       // Id, deviceid, name
        public string  Id { get; set; }
        public string deviceid { get; set; }
        public string name { get; set; }
    }
}
