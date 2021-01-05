using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
   public interface IdistanceServices
    {
        //Task CreateAsync(CityRegistration obj);
        distance GetById(int id);
        Task UpdateAsync(distance obj);
        //Task Delete(int countryid);
        //IEnumerable<SelectListItem> GetAllCity(int stateid);
        //IEnumerable<CityRegistration> GetAll();
    }
}
