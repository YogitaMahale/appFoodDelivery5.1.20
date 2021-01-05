using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
namespace appFoodDelivery.Services
{
  public    interface IRadiusMasterServices
    {
        Task CreateAsync(radiusmaster obj);
        // Task CreateAsync(CustomerRegistration obj);
        radiusmaster  GetById(int id);
        Task UpdateAsync(radiusmaster obj);
        void Updatestatus(radiusmaster obj);
        Task Delete(int id);

        IEnumerable<radiusmaster> GetAll();
    }
}
