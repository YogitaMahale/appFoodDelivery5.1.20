using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
namespace appFoodDelivery.Services
{
   public  interface IDeliveryTimeMasterServices
    {
        Task CreateAsync(deliverytimemaster obj);
        // Task CreateAsync(CustomerRegistration obj);
        deliverytimemaster GetById(int id);
        Task UpdateAsync(deliverytimemaster obj);
        void Updatestatus(deliverytimemaster obj);
        Task Delete(int id);

        IEnumerable<deliverytimemaster> GetAll();
    }
}
