using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
  public   interface IpromocodeServices
    {
        Task CreateAsync(promocodemaster obj);
        // Task CreateAsync(CustomerRegistration obj);
        promocodemaster GetById(int id);
        Task UpdateAsync(promocodemaster obj);

        Task Delete(int id);

        IEnumerable<promocodemaster> GetAll();
    }
}
