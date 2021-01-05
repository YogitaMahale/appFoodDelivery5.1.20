using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
 public    interface IAssignDeliveryboyToManagerServices
    {
        Task CreateAsync(AssignDeliveryboyToManager obj);
        AssignDeliveryboyToManager GetById(int id);
        Task UpdateAsync(AssignDeliveryboyToManager obj);
        Task Delete(int id);
        //IEnumerable<SelectListItem> GetAllCity(int stateid);
        IEnumerable<AssignDeliveryboyToManager> GetAll();
    }
}
