using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
namespace appFoodDelivery.Services
{
   public  interface ICustomerRegistrationservices
    {
        Task<int> CreateAsync(CustomerRegistration obj);
       // Task CreateAsync(CustomerRegistration obj);
        CustomerRegistration GetById(int customerid);
        Task UpdateAsync(CustomerRegistration obj);
        Task Delete(int customerid);
         
        IEnumerable<CustomerRegistration> GetAll();
    }
}
