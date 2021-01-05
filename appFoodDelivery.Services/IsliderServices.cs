using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
  public  interface IsliderServices
    {
        Task CreateAsync(slider  obj);
        slider GetById(int id);
        Task UpdateAsync(slider obj);
        Task Delete(int id);
         
        IEnumerable<slider> GetAll();
    }
}
