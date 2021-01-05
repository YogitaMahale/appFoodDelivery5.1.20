using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace appFoodDelivery.Services
{
  public   interface IdenyOrdersServices
    {
        Task<int> CreateAsync(denyOrders obj);

        denyOrders GetById(int id);
        Task UpdateAsync(denyOrders obj);

        Task Delete(int id);

        IEnumerable<denyOrders> GetAll();
    }
}
