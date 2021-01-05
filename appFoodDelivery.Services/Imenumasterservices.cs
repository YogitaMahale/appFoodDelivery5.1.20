using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using appFoodDelivery.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace appFoodDelivery.Services
{
   public  interface Imenumasterservices
    {
        Task CreateAsync(menumaster obj);

        menumaster GetById(int id);
        Task UpdateAsync(menumaster obj);
        void Updatestatus(menumaster obj);
        Task Delete(int id);

        IEnumerable<menumaster> GetAll();
        IEnumerable<SelectListItem> GetAllMenuList(int cusineid);
    }
}
