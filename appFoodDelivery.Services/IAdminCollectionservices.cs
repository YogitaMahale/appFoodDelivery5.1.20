using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
 public    interface IAdminCollectionservices
    {
        Task CreateAsync(AdminCollection obj);
        AdminCollection GetById(int id);
        Task UpdateAsync(AdminCollection obj);
        Task Delete(int id);
     
        IEnumerable<AdminCollection> GetAll();
    }
}
