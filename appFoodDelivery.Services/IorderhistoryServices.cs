using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;

namespace appFoodDelivery.Services
{
     
    public interface IorderhistoryServices
    {
        Task CreateAsync(orderhistory obj);

        orderhistory GetById(int id);
        Task UpdateAsync(orderhistory obj);

       // Task Delete(int id);

        IEnumerable<orderhistory> GetAll();
    }
}
