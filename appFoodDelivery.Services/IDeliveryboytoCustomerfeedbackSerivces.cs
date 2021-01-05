using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Services
{
   public  interface IDeliveryboytoCustomerfeedbackSerivces
    {
        Task<int> CreateAsync(DeliveryboytoCustomerfeedback obj);

        

        IEnumerable<DeliveryboytoCustomerfeedback> GetAll();
    }
}
