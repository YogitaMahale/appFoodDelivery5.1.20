using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Services
{
  public  interface Istoreownerservices
    {
        Task<int> CreateAsync(storeowner obj);
        // Task CreateAsync(CustomerRegistration obj);
        storeowner GetById(int customerid);
        Task UpdateAsync(storeowner obj);
        void Updatestatus(storeowner obj);
        Task Delete(int customerid);

        IEnumerable<storeowner> GetAll();
    }
}
