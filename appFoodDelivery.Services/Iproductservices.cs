using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
  public   interface Iproductservices
    {
        Task CreateAsync(product obj);
        // Task CreateAsync(CustomerRegistration obj);
        product GetById(int id);
        Task UpdateAsync(product obj);
       
        Task Delete(int id);

        IEnumerable<product> GetAll();
    }
}
