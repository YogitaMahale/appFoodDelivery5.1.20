using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class promocodeIndexViewModel
    {
        public int id { get; set; }

        public string promocode { get; set; }
        public string promocodeusagelimit { get; set; }
        public string discount { get; set; }
        public string discounttype { get; set; }




        public DateTime expirydate { get; set; }

        public DateTime createddate { get; set; }


        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }

    }
}
