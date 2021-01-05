using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace appFoodDelivery.Services
{
    public  interface IstoredetailsServices
    {
        Task<int> CreateAsync(storedetails  obj);
        // Task CreateAsync(CustomerRegistration obj);
        storedetails GetById(int customerid);
        Task UpdateAsync(storedetails obj);
        //void Updatestatus(storeowner obj);
        //Task Delete(int customerid);
        IEnumerable<SelectListItem> GetAllStore();
        IEnumerable<storedetails> GetAll();
    }
}
