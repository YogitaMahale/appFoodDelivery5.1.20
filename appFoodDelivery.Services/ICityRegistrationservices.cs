using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Services
{
 public    interface ICityRegistrationservices
    {
        Task CreateAsync(CityRegistration  obj);
        CityRegistration GetById(int affilateid);
        Task UpdateAsync(CityRegistration obj);
        Task Delete(int countryid);
        IEnumerable<SelectListItem> GetAllCity(int stateid);
        IEnumerable<CityRegistration> GetAll();
    }
}
