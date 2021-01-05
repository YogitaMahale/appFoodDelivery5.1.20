using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Services
{
   public interface IordersServices
    {
        Task<int> CreateAsync(orders obj);

        orders GetById(int id);
        Task UpdateAsync(orders obj);

        Task Delete(int id);

        IEnumerable<orders> GetAll();
    }
}
